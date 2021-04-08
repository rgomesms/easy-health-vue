<template>
    <div>
        <v-data-table
            :headers="headers"
            :items="data"
            item-key="name"
            class="elevation-1"
            :loading="loading"
        >
            <template v-slot:top>
                <v-text-field label="Buscar" class="mx-4"></v-text-field>
            </template>
        </v-data-table>
    </div>
</template>

<script>
export default {
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
