<template>
    <v-form ref="form" v-model="valid" lazy-validation>
        <template v-for="field of fields">
            <component
                :is="field.is"
                v-bind="field"
                :key="field.label"
                :rules="genericRules"
                v-on="field.on"
                v-model="field.value"
                @change="validate"
                required
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
        validate(e) {
            console.log(this.fields.cep.value, this.fields.cep);
            console.log("Entrei na validação", e);
            return this.$refs.form.validate();
        },
        submit() {
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
        currentTabComponent: function() {
            return "v-text-field";
        },
    },
};
</script>
