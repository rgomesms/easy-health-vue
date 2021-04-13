<template>
  <v-footer
    dark
    padless
  >
    <v-card
      class="flex"
      flat
      tile
      :style="{ background: `transparent url(${require('../../assets/fundo_barra_top_2.jpg')}) repeat center top` }"
    >
      <v-card-title>
        <strong class="subheading">Acesse Easy Health nas redes sociais!</strong>

        <v-spacer></v-spacer>

        <v-btn
          v-for="icon in icons"
          :key="icon"
          class="mx-4"
          dark
          icon
        >
          <v-icon size="24px">
            {{ icon }}
          </v-icon>
        </v-btn>
      </v-card-title>

      <v-card-text class="py-2 white--text text-center black" >
        {{ new Date().getFullYear() }} — <strong>Easy Health by Davi Emediato, Gabriel Ribeiro, Rafael Silvério e Rodrigo Gomes</strong>
      </v-card-text>
    </v-card>
  </v-footer>
</template>
<script>
  export default {
    data: () => ({
      icons: [
        'mdi-facebook',
        'mdi-twitter',
        'mdi-linkedin',
        'mdi-instagram',
      ],
    }),
  }
</script>