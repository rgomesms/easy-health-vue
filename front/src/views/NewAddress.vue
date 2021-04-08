<template>
    <v-content style="padding-top:30px;" class="address">
        <v-container fluid>
            <v-row class="dd">
                <v-col sm="2">
                    <v-card rounded="lg" elevation="1" style="min-height:40vh">
                        <h3>This is the address page</h3>
                    </v-card>
                </v-col>
                <v-col sm="8">
                    <v-card rounded="lg" elevation="1" style="min-height:70vh">
                        <!-- <h3>This is the address page</h3> -->
                        <v-col sm="8">
                            <FormsComponent :fields="fields" />
                        </v-col>
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
import FormsComponent from "../components/FormsComponent";

export default {
    name: "Address",
    components: { FormsComponent },
    data: () => {
        return {
            fields: [
                {
                    label: "CEP",
                    is: "v-text-field",
                    required: true,
                    counter: 8,
                },
                {
                    label: "Logradouro",
                    is: "v-text-field",
                    required: true,
                },
                {
                    label: "Bairro",
                    is: "v-text-field",
                    required: true,
                },
                {
                    label: "Cidade",
                    is: "v-text-field",
                    required: true,
                },
                {
                    label: "Estado",
                    is: "v-text-field",
                    required: true,
                },
            ],
        };
    },
};
</script>
