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
    name: "Cadastros",
    components: { FormsComponent },
    data: (t) => {
        return {
            items: {
                paciente: {
                    text: "Paciente",
                    icon: "mdi-account",
                    fields: {
                        nome: {
                            label: "Nome",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        email: {
                            label: "Email",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        telefone: {
                            label: "Telefone",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        cep: {
                            label: "CEP",
                            is: "v-text-field",
                            value: "",
                            required: true,
                            counter: 8,
                            on: {
                                change: function(cep) {
                                    t.handleCepUpdate(cep, "paciente");
                                }.bind(t),
                            },
                        },
                        logradouro: {
                            label: "Logradouro",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        bairro: {
                            label: "Bairro",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        cidade: {
                            label: "Cidade",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        estado: {
                            label: "Estado",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        tipoSanguineo: {
                            label: "Tipo Sanguineo",
                            is: "v-select",
                            value: "",
                            chips: true,
                            items: [
                                "A+",
                                "A-",
                                "B+",
                                "B-",
                                "AB+",
                                "AB-",
                                "O+",
                                "O-",
                            ],
                            required: true,
                        },
                        peso: {
                            label: "Peso",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        altura: {
                            label: "Altura",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                    },
                    buttons: [
                        {
                            label: "Submeter",
                            color: "success",
                            class: "mr-4",
                            is: "v-btn",
                            on: {
                                click: function() {
                                    t.handleSubmitPaciente("paciente");
                                }.bind(t),
                            },
                        },
                    ],
                },
                funcionario: {
                    text: "Funcionário",
                    icon: "mdi-clipboard-account",
                    fields: {
                        tipo: {
                            label: "Tipo",
                            is: "v-select",
                            value: "",
                            items: ["Funcionario", "Médico"],
                            required: true,
                            on: {
                                change: function(especialidade) {
                                    if (especialidade !== "Médico") {
                                        t.items.funcionario.fields.especialidade.class =
                                            "d-none";
                                        t.items.funcionario.fields.crm.class =
                                            "d-none";
                                    } else {
                                        t.items.funcionario.fields.especialidade.class =
                                            "";
                                        t.items.funcionario.fields.crm.class =
                                            "";
                                    }
                                    console.log(
                                        "Mudou tipo",
                                        especialidade,
                                        t.items.funcionario.fields.especialidade
                                    );
                                }.bind(t),
                            },
                        },
                        especialidade: {
                            label: "Especialidade",
                            is: "v-text-field",
                            value: "",
                            class: "",
                            required: true,
                        },
                        crm: {
                            label: "CRM",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },

                        nome: {
                            label: "Nome",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        email: {
                            label: "Email",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        telefone: {
                            label: "Telefone",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        cep: {
                            label: "CEP",
                            is: "v-text-field",
                            value: "",
                            required: true,
                            counter: 8,
                            on: {
                                change: function(cep) {
                                    t.handleCepUpdate(cep, "paciente");
                                }.bind(t),
                            },
                        },
                        logradouro: {
                            label: "Logradouro",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        bairro: {
                            label: "Bairro",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        cidade: {
                            label: "Cidade",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        estado: {
                            label: "Estado",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        dataContrato: {
                            label: "Data de Contrato",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        salario: {
                            label: "Salario",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        senha: {
                            label: "Senha (Provisorio)",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                    },
                    buttons: [
                        {
                            label: "Submeter",
                            color: "success",
                            class: "mr-4",
                            is: "v-btn",
                            on: {
                                click: function() {
                                    t.handleSubmitFuncionario("funcionario");
                                }.bind(t),
                            },
                        },
                    ],
                },
                endereco: {
                    text: "Endereço",
                    icon: "mdi-home",
                    fields: {
                        cep: {
                            label: "CEP",
                            is: "v-text-field",
                            value: "",
                            required: true,
                            counter: 8,
                        },
                        logradouro: {
                            label: "Logradouro",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        bairro: {
                            label: "Bairro",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        cidade: {
                            label: "Cidade",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        estado: {
                            label: "Estado",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                    },
                    buttons: [
                        {
                            label: "Submeter",
                            color: "success",
                            class: "mr-4",
                            is: "v-btn",
                            on: {
                                click: function() {
                                    t.handleSubmitAddress("endereco");
                                }.bind(t),
                            },
                        },
                    ],
                },
                //Exemplo de teste, para o testar a mudança de cep alterar campos, para o cadastro de funcionario
                enderecoTeste: {
                    text: "AutoCompletaCepAPI",
                    icon: "mdi-comment-alert",
                    fields: {
                        cep: {
                            label: "CEP",
                            is: "v-text-field",
                            value: "",
                            required: true,
                            counter: 8,
                            on: {
                                change: function(cep) {
                                    t.handleCepUpdate(cep, "enderecoTeste");
                                }.bind(t),
                            },
                        },
                        logradouro: {
                            label: "Logradouro",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        bairro: {
                            label: "Bairro",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        cidade: {
                            label: "Cidade",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                        estado: {
                            label: "Estado",
                            is: "v-text-field",
                            value: "",
                            required: true,
                        },
                    },
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
                            itemsCodigos: [],
                            on: {
                                change: function() {
                                    //Caso medico tenha valor, exibe os campos data e horario, senao nem exibe.
                                    if (t.items.consulta.fields.medico.value) {
                                        t.items.consulta.fields.data.classType =
                                            "";
                                        t.items.consulta.fields.horario.class =
                                            "";
                                    } else {
                                        t.items.consulta.fields.data.classType =
                                            "d-none";
                                        t.items.consulta.fields.horario.class =
                                            "d-none";
                                    }
                                }.bind(t),
                            },
                        },
                        data: {
                            label: "Data",
                            is: "DatePickerComponent",
                            required: true,
                            value: new Date().toISOString().substr(0, 10),
                            on: {
                                changedDate: function(date) {
                                    //Atualiza o valor do componente filho para aqui.
                                    t.items.consulta.fields.data.value = date;
                                    t.setHorarios(date);
                                }.bind(t),
                            },
                            classType: "d-none",
                        },
                        horario: {
                            label: "Horario",
                            is: "v-select",
                            required: true,
                            // value:
                            //     "TEMPORARIO - ADICIONAR COMPONENTE PARA HORARIO",
                            items: [],
                            class: "d-none",
                        },
                    },
                },
                teste: {
                    text: "Teste",
                    icon: "mdi-home",
                    fields: {
                        test: {
                            label: "Davi muito safado",
                            is: "v-text-field",
                            value: "",
                        },
                    },
                },
            },
            selectedItem: 4,
            funcionarioTipo: "",
        };
    },
    created() {
        this.setEspecialidades();
    },
    methods: {
        handleSubmitAddress() {
            let requestBody = {
                cep: this.items.endereco.fields.cep.value,
                logradouro: this.items.endereco.fields.logradouro.value,
                bairro: this.items.endereco.fields.bairro.value,
                cidade: this.items.endereco.fields.cidade.value,
                estado: this.items.endereco.fields.estado.value,
            };
            //Checa se tem algum elemento nao preenchido
            const isEmpty = !Object.values(requestBody).some(
                (x) => x !== null && x !== ""
            );
            if (!isEmpty) sendNewAddress(requestBody);
            else alert("Preencha todos os campos!");

            async function sendNewAddress(requestBody) {
                const url = `https://localhost:44320/endereco/post`;
                try {
                    const response = await axios.post(url, requestBody);
                    return response;
                } catch (e) {
                    console.log(
                        `Erro ao realizar a request no endpoint ${url}`,
                        JSON.stringify(e)
                    );
                }
            }
        },

        handleSubmitPaciente(path) {
            let requestBody = {
                nome: this.items[path].fields.nome.value,
                email: this.items[path].fields.email.value,
                telefone: this.items[path].fields.telefone.value,
                cep: this.items[path].fields.cep.value,
                logradouro: this.items[path].fields.logradouro.value,
                bairro: this.items[path].fields.bairro.value,
                cidade: this.items[path].fields.cidade.value,
                estado: this.items[path].fields.estado.value,
                tipoSanguineo: this.items[path].fields.tipoSanguineo.value,
                peso: this.items[path].fields.peso.value,
                altura: this.items[path].fields.altura.value,
            };
            console.log(requestBody);
            //Checa se tem algum elemento nao preenchido
            // const isEmpty = !Object.values(requestBody).some(
            //     (x) => x !== null && x !== ""
            // );

            // if (!isEmpty) sendNewAddress(requestBody);
            // else console.log("Preencha todos os campos!");

            // async function sendNewAddress(requestBody) {
            //     const url = `https://localhost:44320/endereco/post`;
            //     try {
            //         const response = await axios.post(url, requestBody);
            //         return response;
            //     } catch (e) {
            //         console.log(
            //             `Erro ao realizar a request no endpoint ${url}`,
            //             JSON.stringify(e)
            //         );
            //     }
            // }
            // },
        },

        handleSubmitFuncionario(path) {
            let requestBody = {
                tipo: this.items[path].fields.tipo.value,
                nome: this.items[path].fields.nome.value,
                email: this.items[path].fields.email.value,
                telefone: this.items[path].fields.telefone.value,
                cep: this.items[path].fields.cep.value,
                logradouro: this.items[path].fields.logradouro.value,
                bairro: this.items[path].fields.bairro.value,
                cidade: this.items[path].fields.cidade.value,
                estado: this.items[path].fields.estado.value,
                dataContrato: this.items[path].fields.dataContrato.value,
                salario: this.items[path].fields.salario.value,
                senha: this.items[path].fields.senha.value,
            };
            console.log(requestBody);
        },

        async handleCepUpdate(cep, path) {
            let data = await fetchCEP(cep);

            if (data) {
                this.items[path].fields.cep.value = data.cep;
                this.items[path].fields.logradouro.value = data.logradouro;
                this.items[path].fields.bairro.value = data.bairro;
                this.items[path].fields.cidade.value = data.cidade;
                this.items[path].fields.estado.value = data.estado;
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
            console.log(itemsArray[this.selectedItem]);
        },
        setHorarios() {
            // alert(this.items.consulta.fields.medico.value, date);
            // fetchHorarios().then((response) => {
            //     this.items.consulta.fields.especialidade.items = response.data;
            // });
            // function fetchHorarios() {
            //     try {
            //         return axios.get(
            //             `https://localhost:44320/agenda/get/horarios?`
            //         );
            //     } catch (e) {
            //         console.log(
            //             "Erro ao realizar a request no endpoint https://localhost:44320/agenda/get/horarios?",
            //             JSON.stringify(e)
            //         );
            //     }
            // }
        },
        setEspecialidades() {
            fetchEspecialidades().then((response) => {
                this.items.consulta.fields.especialidade.items = response.data;
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
            fetchMedicos().then((response) => {
                //A partir do json no formato {nome, codigo, ..., ...}
                //Vou pegar o campo nome e colocar no items(para exibicao)
                //E salvo o codigo no campo itemsCodigos. Identifico os dois pelo index em comum
                const { data } = response;
                let nomes = [];
                let codigos = [];
                data.forEach(function(medico) {
                    nomes.push(medico.nome);
                    codigos.push(medico.codigo);
                });
                this.items.consulta.fields.medico.items = nomes;
                this.items.consulta.fields.medico.itemsCodigos = codigos;
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
