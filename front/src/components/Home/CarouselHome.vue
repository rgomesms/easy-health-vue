<template>
  <v-carousel
  cycle
  hide-delimiter-background
  show-arrows-on-hover
  :style="{ background: `transparent url(${require('../../assets/fundo_claro.jpg')}) repeat center top` }"
  > 
    <v-carousel-item
      v-for="(item,i) in items"
      :key="i"
      :src="item.src"
      contain
      reverse-transition="fade-transition"
      transition="fade-transition"
    ></v-carousel-item>
  </v-carousel>
</template>
<script>
  import home1 from '../../assets/home1.jpg'
  import home2 from '../../assets/home2.jpg'
  import home3 from '../../assets/home3.jpg'
  export default {
    data () {
      return {
        items: [
          {
            src: home1,
          },
          {
            src: home2,
          },
          {
            src: home3,
          },
        ],
      }
    },
  }
</script>