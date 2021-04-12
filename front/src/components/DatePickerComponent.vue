<template>
    <v-menu
        v-model="menu2"
        :close-on-content-click="false"
        :nudge-right="40"
        transition="scale-transition"
        offset-y
        min-width="auto"
    >
        <template v-slot:activator="{ on, attrs }">
            <v-text-field
                v-model="date"
                :label="label"
                append-icon="mdi-calendar"
                readonly
                v-bind="attrs"
                v-on="on"
                :class="classType"
            ></v-text-field>
        </template>
        <v-date-picker
            v-model="date"
            @input="menu2 = false"
            @change="(d) => changedDate(d)"
        ></v-date-picker>
    </v-menu>
</template>

<script>
import { VMenu } from "vuetify/lib";
export default {
    name: "DatePickerComponent",
    components: { VMenu },
    props: {
        label: {
            type: String,
        },
        required: {
            type: Boolean,
        },
        value: {
            type: String,
        },
        classType: {
            type: String,
        },
    },
    methods: {
        changedDate(d) {
            this.$emit("changedDate", d);
        },
    },
    created() {
        this.date = this.value;
    },
    data: () => ({
        date: "",
        menu: false,
        modal: false,
        menu2: false,
    }),
};
</script>
