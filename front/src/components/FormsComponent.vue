<template>
    <v-form ref="form" lazy-validation>
        <template v-for="field of fields">
            <component
                :is="field.is"
                v-bind="field"
                :key="field.label"
                v-on="field.on"
                required
            />
        </template>

        <template v-for="button of buttons">
            <component
                :is="button.is"
                v-bind="button"
                :key="button.label"
                v-on="button.on"
                required
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

export default {
    name: "Address",
    props: {
        fields: {
            type: Object,
        },
        buttons: {
            type: Array,
        },
    },
    methods: {
        validate() {
            console.log(JSON.stringify(this.fields));
        },
        test(t) {
            console.log("entrei no test");
            alert(t);
            // this.$emit("update_cep");
        },
    },

    components: { VTextField, VSelect, VCheckbox, VBtn },
    computed: {
        currentTabComponent: function() {
            return "v-text-field";
        },
    },
};
</script>
