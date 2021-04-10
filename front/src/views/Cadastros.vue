<template>
    <v-content style="padding-top:30px;" class="address">
        <v-container fluid>
            <v-row class="dd">
                <v-col sm="2">
                    <v-card
                        rounded="lg"
                        elevation="1"
                        style="min-height:40vh"
                        class="pa-3"
                    >
                        <v-list dense>
                            <v-subheader
                                >Selecione o tipo de cadastro:</v-subheader
                            >
                            <v-list-item-group
                                v-model="selectedItem"
                                color="primary"
                            >
                                <v-list-item
                                    v-for="(item, i) in items"
                                    :key="i"
                                >
                                    <v-list-item-icon>
                                        <v-icon v-text="item.icon"></v-icon>
                                    </v-list-item-icon>
                                    <v-list-item-content>
                                        <v-list-item-title
                                            v-text="item.text"
                                        ></v-list-item-title>
                                    </v-list-item-content>
                                </v-list-item>
                            </v-list-item-group>
                        </v-list>
                    </v-card>
                </v-col>
                <v-col sm="8">
                    <v-card
                        rounded="lg"
                        elevation="1"
                        style="min-height:70vh"
                        class="pa-12"
                    >
                        <FormsComponent
                            :fields="
                                Object.values(this.items)[selectedItem].fields
                            "
                            :buttons="
                                Object.values(this.items)[selectedItem].buttons
                            "
                            @update_cep="handleCepUpdate"
                        />
                        <!-- <FormsComponent
                            :fields="items.endereco.fields"
                            :buttons="items.endereco.buttons"
                            @update_cep="handleCepUpdate"
                        /> -->
                        <v-btn @click="testar">Testar</v-btn>
                    </v-card>
                </v-col>
                <v-col sm="2">
                    <v-card rounded="lg" elevation="1" style="min-height:40vh">
                        <h3>This is the address page</h3>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
    </v-content>
</template>

<style lang="scss">
.address {
    text-align: center;
}
</style>

<script>
import FormsComponent from "../components/FormsComponent";
import axios from "axios";

export default {
    name: "Address",
    components: { FormsComponent },
    data: (t) => {
        return {
            items: {
                paciente: {
                    text: "Paciente",
                    icon: "mdi-account",
                    fields: {
                        tipoSanguineo: {
                            label: "Tipo Sanguineo",
                            is: "v-text-field",
                            required: true,
                        },
                        peso: {
                            label: "Peso",
                            is: "v-text-field",
                            required: true,
                        },
                        altura: {
                            label: "Altura",
                            is: "v-text-field",
                            required: true,
                        },
                    },
                },
                funcionario: {
                    text: "Funcionário",
                    icon: "mdi-clipboard-account",
                    fields: {
                        dataContrato: {
                            label: "Data de Contrato",
                            is: "v-text-field",
                            required: true,
                        },
                        salario: {
                            label: "Salario",
                            is: "v-text-field",
                            required: true,
                        },
                        senha: {
                            label: "Senha (Provisorio)",
                            is: "v-text-field",
                            required: true,
                        },
                    },
                },
                endereco: {
                    text: "Endereço",
                    icon: "mdi-home",
                    fields: {
                        cep: {
                            label: "CEP",
                            is: "v-text-field",
                            required: true,
                            counter: 8,
                            // rules: [
                            //     (v) => {
                            //         if (v.length == 8) {
                            //             return true;
                            //         } else return "CEP Invalido";
                            //     },
                            // ],
                            on: {
                                change: function(cep) {
                                    t.handleCepUpdate(cep);
                                }.bind(t),
                            },
                        },
                        logradouro: {
                            label: "Logradouro",
                            is: "v-text-field",
                            required: true,
                        },
                        bairro: {
                            label: "Bairro",
                            is: "v-text-field",
                            required: true,
                        },
                        cidade: {
                            label: "Cidade",
                            is: "v-text-field",
                            required: true,
                        },
                        estado: {
                            label: "Estado",
                            is: "v-text-field",
                            required: true,
                        },
                    },
                    buttons: [
                        {
                            label: "Submeter",
                            color: "success",
                            class: "mr-4",
                            is: "v-btn",
                        },
                    ],
                },
                consulta: {
                    text: "Consulta",
                    icon: "mdi-calendar-plus",
                    fields: {
                        especialidade: {
                            label: "Especialidade Medica",
                            is: "v-select",
                            required: true,
                            items: [],
                            on: {
                                change: function(especialidade) {
                                    t.setMedicos(especialidade);
                                }.bind(t),
                            },
                        },
                        medico: {
                            label: "Medico",
                            is: "v-select",
                            required: true,
                            items: [],
                        },
                    },
                },
            },
            selectedItem: 3,
        };
    },
    created() {
        this.setEspecialidades();
    },
    methods: {
        async handleCepUpdate(cep) {
            let data = await fetchCEP(cep);

            if (data) {
                let endereco = this.items["endereco"].fields;
                endereco.cep.value = data.cep;
                endereco.logradouro.value = data.logradouro;
                endereco.bairro.value = data.bairro;
                endereco.cidade.value = data.cidade;
                endereco.estado.value = data.estado;

                this.items["endereco"].fields = endereco;
            }

            async function fetchCEP(cep) {
                if (cep.length === 8) {
                    console.log("FetchCEP - cep", cep);
                    let data;
                    try {
                        const response = await axios.get(
                            `https://localhost:44320/endereco/get?cep=${cep}`
                        );
                        data = response.data[0];
                        return data;
                    } catch (e) {
                        console.log(
                            `Erro ao realizar a request no endpoint https://localhost:44320/endereco/get?cep=${cep}`,
                            JSON.stringify(e)
                        );
                    }
                }
            }
        },
        testar() {
            let itemsArray = Object.values(this.items);
            console.log(itemsArray);
        },
        setEspecialidades() {
            fetchEspecialidades().then((result) => {
                this.items.consulta.fields.especialidade.items = result.data;
            });
            function fetchEspecialidades() {
                try {
                    return axios.get(
                        `https://localhost:44320/medico/get/especialidades`
                    );
                } catch (e) {
                    console.log(
                        "Erro ao realizar a request no endpoint https://localhost:44320/medico/get/especialidades",
                        JSON.stringify(e)
                    );
                }
            }
        },
        setMedicos(especialidade) {
            fetchMedicos().then((result) => {
                this.items.consulta.fields.medico.items = result.data;
            });
            function fetchMedicos() {
                try {
                    return axios.get(
                        `https://localhost:44320/medico/get/especialidades?especialidade=${especialidade}`
                    );
                } catch (e) {
                    console.log(
                        `Erro ao realizar a request no endpoint https://localhost:44320/medico/get/especialidades?especialidade=${especialidade}`,
                        JSON.stringify(e)
                    );
                }
            }
        },
    },
};
</script>
