<template>
    <v-form ref="form" lazy-validation>
        <!-- <component v-bind:is="fields[0].is" v-bind="fields[0]" /> -->
        <!-- <component v-bind:is="fields[0].is" v-bind="fields[0]" /> -->

        <template v-for="field of fields">
            <component
                :is="field.is"
                v-bind="field"
                :key="field.label"
                required
            />
        </template>

        <v-select
            v-model="select"
            :items="items"
            :rules="[(v) => !!v || 'Item is required']"
            label="Item"
            required
        ></v-select>

        <v-checkbox
            v-model="checkbox"
            :rules="[(v) => !!v || 'You must agree to continue!']"
            label="Do you agree?"
            required
        ></v-checkbox>

        <v-btn
            :disabled="!valid"
            color="success"
            class="mr-4"
            @click="validate"
        >
            Validate
        </v-btn>

        <!-- <v-btn color="error" class="mr-4" @click="reset">
            Reset Form
        </v-btn>

        <v-btn color="warning" @click="resetValidation">
            Reset Validation
        </v-btn> -->
    </v-form>
</template>

<style lang="scss">
.address {
    text-align: center;
}
</style>

<script>
// [{ name, type }] um array contendo o nome e o tipo de cada input
// [ {name, type, function } ] um array contendo os botoes no final do formulario
import { VTextField, VSelect, VCheckbox } from "vuetify/lib";
// @ is an alias to /src
export default {
    name: "Address",
    props: {
        fields: {
            type: Array,
        },
    },

    components: { VTextField, VSelect, VCheckbox },
    computed: {
        currentTabComponent: function() {
            return "v-text-field";
        },
    },
};
</script>
