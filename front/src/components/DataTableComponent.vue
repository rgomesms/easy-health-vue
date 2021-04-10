<template>
    <div>
        <v-data-table
            :headers="headers"
            :items="data"
            item-key="name"
            class="elevation-1"
            :loading="loading"
            :search="search"
        >
            <template v-slot:top>
                <v-text-field
                    v-model="search"
                    label="Buscar"
                    class="mx-4"
                    append-icon="mdi-magnify"
                ></v-text-field>
            </template>
        </v-data-table>
    </div>
</template>

<script>
export default {
    data() {
        return {
            search: "",
        };
    },
    props: {
        data: {
            type: Array,
        },
        headers: {
            type: Array,
        },
        loading: {
            type: Boolean,
        },
    },
};
</script>
