<template>
    <v-content style="padding-top:30px;" class="address">
        <v-container fluid>
            <v-row class="dd">
                <v-col sm="4">
                    <v-card
                        rounded="lg"
                        elevation="2"
                        style="min-height:40vh"
                        class="pa-5 pt-3 ml-5 mr-5"
                        outlined
                    >
                        <v-list dense>
                            <v-subheader
                                >Selecione a Tabela de Consulta</v-subheader
                            >
                            <v-list-item-group
                                v-model="selectedItem"
                                mandatory
                                color="primary"
                            >
                                <template v-for="(item, i) in getItems">
                                    <v-list-item
                                        :key="i"
                                        v-if="checkUser(item)"
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
                                </template>
                            </v-list-item-group>
                        </v-list>
                    </v-card>
                </v-col>
                <v-col sm="8">
                    <v-card
                        rounded="lg"
                        elevation="2"
                        style="min-height:70vh"
                        class="pa-12"
                        outlined
                    >
                        <DataTableComponent
                            :data="data"
                            :headers="headers"
                            :loading="loading"
                        />
                        <v-btn class="mt-5" @click="getData">Recarregar</v-btn>
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
                    userScope: ["funcionario"],
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
                    text: "Minha Agenda",
                    icon: "mdi-calendar-today",
                    urlSufix: `agenda/get/medico?codigoMedico=${this.codigoUsuario}`,
                    userScope: ["medico"],
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
    computed: {
        getItems() {
            let newItems = [];
            Object.values(this.items).forEach((item) => {
                if (this.checkUser(item)) newItems.push(item);
            });
            return newItems;
        },
    },

    methods: {
        async getData() {
            this.data = []; //Emptying the array to test reload
            this.headers = [];
            let urlSufix = this.getItems[this.selectedItem].urlSufix;
            try {
                this.loading = true;
                const response = await axios.get(
                    `https://localhost:44320/${urlSufix}`
                );
                this.data = response.data;
                this.headers = this.getItems[this.selectedItem].headers;
            } catch (e) {
                alert(
                    "Houve erro" +
                        `https://localhost:44320/${urlSufix} - Certifique-se que a API esta disponível nesse endereço`
                );
                this.errors.push(e);
            }
            this.loading = false;
        },
        checkUser(item) {
            if (item.userScope) {
                return item.userScope.includes(this.tipoUsuario);
            } else return true;
        },
    },

    props: {
        tipoUsuario: { type: String, default: "" },
        codigoUsuario: { type: String },
    },
    async created() {
        this.getData();
    },
};
</script>
