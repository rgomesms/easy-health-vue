<template>
    <v-row
        class="pa-10"
        :style="{
            background: `transparent url(${require('../../assets/fundo_claro.jpg')}) repeat center top`,
        }"
    >
        <v-col v-for="n in 8" :key="n" class="d-flex child-flex " cols="4">
            <v-img
                :src="`${require(`../../assets/gallery/img${n}.jpg`)}`"
                aspect-ratio="1"
            >
                <template v-slot:placeholder>
                    <v-row
                        class="fill-height ma-0"
                        align="center"
                        justify="center"
                    >
                        <v-progress-circular
                            indeterminate
                            color="grey lighten-5"
                        ></v-progress-circular>
                    </v-row>
                </template>
            </v-img>
        </v-col>
    </v-row>
</template>

<script>
export default {
    // data:()=>{
    //   photos:[],
    // }
};
</script>
