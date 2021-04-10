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
                                >Selecione a Tabela de Consulta</v-subheader
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
                        <DataTableComponent
                            :data="data"
                            :headers="headers"
                            :loading="loading"
                        />
                        <v-btn @click="getData">Recarregar</v-btn>
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
// @ is an alias to /src
import DataTableComponent from "../components/DataTableComponent";
import axios from "axios";

export default {
    name: "Consultas",
    components: { DataTableComponent },
    data() {
        return {
            items: [
                {
                    text: "Pessoa",
                    icon: "mdi-account-multiple-outline",
                    urlSufix: "pessoa/get",
                    headers: [
                        {
                            text: "Codigo",
                            value: "codigo",
                        },
                        {
                            text: "Nome",
                            value: "nome",
                        },
                        {
                            text: "Email",
                            value: "email",
                        },
                        {
                            text: "Telefone",
                            value: "telefone",
                        },
                        {
                            text: "CEP",
                            value: "cep",
                        },
                        {
                            text: "Bairro",
                            value: "bairro",
                        },
                        {
                            text: "Cidade",
                            value: "cidade",
                        },
                        {
                            text: "Estado",
                            value: "estado",
                        },
                    ],
                },
                {
                    text: "Paciente",
                    icon: "mdi-account",
                    urlSufix: "paciente/get",
                    headers: [
                        {
                            text: "Codigo",
                            value: "codigo",
                        },
                        {
                            text: "Nome",
                            value: "nome",
                        },
                        {
                            text: "Tipo Sanguineo",
                            value: "tipoSanguineo",
                        },
                        {
                            text: "Peso",
                            value: "peso",
                        },
                        {
                            text: "Altura",
                            value: "altura",
                        },
                    ],
                },
                {
                    text: "Funcionario",
                    icon: "mdi-clipboard-account",
                    urlSufix: "funcionario/get",
                    headers: [
                        {
                            text: "Codigo",
                            align: "start",
                            value: "codigo",
                        },
                        {
                            text: "Nome",
                            value: "nome",
                        },
                        {
                            text: "Data de Contrato",
                            value: "dataContrato",
                        },
                        {
                            text: "Salario",
                            value: "salario",
                        },
                    ],
                },
                {
                    text: "Medico",
                    icon: "mdi-medical-bag",
                    urlSufix: "medico/get",
                    headers: [
                        {
                            text: "Codigo",
                            align: "start",
                            value: "codigo",
                        },
                        {
                            text: "Nome",
                            value: "nome",
                        },
                        {
                            text: "Especialidade",
                            value: "especialidade",
                        },
                        {
                            text: "CRM",
                            value: "crm",
                        },
                    ],
                },
                {
                    text: "Todos Agendamentos",
                    icon: "mdi-calendar",
                    urlSufix: "agenda/get",
                    headers: [
                        {
                            text: "Codigo",
                            align: "start",
                            value: "codigo",
                        },
                        {
                            text: "Nome",
                            value: "nome",
                        },
                        {
                            text: "Email",
                            value: "email",
                        },
                        {
                            text: "Telefone",
                            value: "telefone",
                        },
                        {
                            text: "Codigo do Medico",
                            align: "start",
                            value: "codigoMedico",
                        },
                        {
                            text: "Nome do Medico",
                            align: "start",
                            value: "nomeMedico",
                        },
                    ],
                },
                {
                    text: "Enderecos",
                    icon: "mdi-home",
                    urlSufix: "endereco/get",
                    headers: [
                        {
                            text: "CEP",
                            value: "cep",
                        },
                        {
                            text: "Logradouro",
                            value: "logradouro",
                        },
                        {
                            text: "Bairro",
                            value: "bairro",
                        },
                        {
                            text: "Cidade",
                            value: "cidade",
                        },
                        {
                            text: "Estado",
                            value: "estado",
                        },
                    ],
                },
            ],
            selectedItem: 0,
            data: [],
            errors: [],
            loading: false,
        };
    },

    watch: {
        selectedItem: function() {
            this.getData();
        },
    },

    methods: {
        async getData() {
            this.data = []; //Emptying the array to test reload
            this.headers = [];
            let urlSufix = this.items[this.selectedItem].urlSufix;
            try {
                this.loading = true;
                const response = await axios.get(
                    `https://localhost:44320/${urlSufix}`
                );
                this.data = response.data;
                this.headers = this.items[this.selectedItem].headers;
            } catch (e) {
                alert("Houve erro" + `https://localhost:44320/${urlSufix}`);
                this.errors.push(e);
            }
            this.loading = false;
        },
    },
    async created() {
        this.getData();
    },
};
</script>
