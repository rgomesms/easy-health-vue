<template>
    <v-form ref="form" v-model="valid" lazy-validation>
        <v-row>
            <template v-for="field of fields">
                <v-col
                    :cols="field.size || 12"
                    class="pa-2 pb-0 pt-0 mb-0 mr-0"
                    :key="field.label"
                >
                    <component
                        :is="field.is"
                        v-bind="field"
                        :key="field.label"
                        :rules="rules(field.required)"
                        v-on="field.on"
                        v-model="field.value"
                        @change="validate"
                        :required="field.required"
                        dense
                        shaped
                        outlined
                    />
                </v-col>
            </template>
        </v-row>

        <template v-for="button of buttons">
            <component
                :is="button.is"
                v-bind="button"
                :key="button.label"
                v-on:click="submit"
                :disabled="!valid"
                elevation="4"
                rounded
                large
                class="mr-4 mt-3 mb-10 mx-auto"
            >
                {{ button.label }}
            </component>
        </template>
    </v-form>
</template>

<style lang="scss">
.address {
    text-align: center;
}
</style>

<script>
import { VTextField, VSelect, VCheckbox, VBtn, VCol } from "vuetify/lib";
import DatePickerComponent from "./DatePickerComponent";

export default {
    name: "Address",
    props: {
        fields: {
            type: Object,
        },
        buttons: {
            type: Object,
        },
    },
    data: () => ({
        valid: false,
        genericRules: [(v) => !!v || "Campo obrigatório"],
    }),
    methods: {
        validate() {
            // console.log("Entrei na validação", e);
            return this.$refs.form.validate();
        },
        submit() {
            console.log("Submit aqui na quebrada", this.$refs.form.validate());
            if (this.$refs.form.validate()) {
                this.buttons.submit.on.click();
                this.$refs.form.reset();
            }
        },
    },

    components: {
        VTextField,
        VSelect,
        VCheckbox,
        VBtn,
        DatePickerComponent: DatePickerComponent,
        VCol,
    },
    computed: {
        rules: function() {
            return function(required) {
                return required ? [(v) => !!v || "Campo obrigatório"] : [];
            };
        },
    },
};
</script>
