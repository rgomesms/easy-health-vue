<template v-slot:activator="{ on, attrs }">
    <v-text-field
        v-model="date"
        label="Picker without buttons"
        append-icon="mdi-calendar"
        readonly
    ></v-text-field>
    <!-- <v-text-field
        v-model="date"
        label="Picker without buttons"
        prepend-icon="mdi-calendar"
        readonly
        v-bind="attrs"
        v-on="on"
    ></v-text-field> -->
</template>

<script>
export default {
    name: "DatePickerComponent",
    data: () => ({
        date: new Date().toISOString().substr(0, 10),
        menu: false,
        modal: false,
        menu2: false,
    }),
};
</script>
