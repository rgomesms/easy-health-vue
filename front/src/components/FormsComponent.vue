<template>
    <v-form ref="form" v-model="valid" lazy-validation>
        <template v-for="field of fields">
            <component
                :is="field.is"
                v-bind="field"
                :key="field.label"
                :rules="rules(field.required)"
                v-on="field.on"
                v-model="field.value"
                @change="validate"
                :required="field.required"
            />
        </template>

        <template v-for="button of buttons">
            <component
                :is="button.is"
                v-bind="button"
                :key="button.label"
                v-on:click="submit"
                :disabled="!valid"
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
import { VTextField, VSelect, VCheckbox, VBtn } from "vuetify/lib";
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
