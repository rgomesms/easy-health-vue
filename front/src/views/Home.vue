<template>
    <div class="home ">
        <carousel></carousel>
        <div>
            <div
                class="text-center"
                :style="{
                    background: `transparent url(${require('../assets/fundo_barra_top_2.jpg')}) repeat center top`,
                }"
            >
                <span style="color: white; font-size:50px; font-weight: bold;"
                    >Especialidades</span
                >
            </div>

            <cards-home></cards-home>
        </div>
        <div>
            <div
                class="text-center"
                :style="{
                    background: `transparent url(${require('../assets/fundo_barra_top_2.jpg')}) repeat center top`,
                }"
            >
                <span style="color: white; font-size:50px; font-weight: bold;"
                    >Sobre a Easy Health</span
                >
            </div>
        </div>

        <description-home></description-home>
        <footer-home></footer-home>
    </div>
</template>
<style lang="scss">
.home {
    text-align: center;
}
</style>

<script>
import Carousel from "../components/Home/CarouselHome";
import CardsHome from "../components/Home/CardsHome";
import DescriptionHome from "../components/Home/DescriptionHome";
import FooterHome from "../components/Home/FooterHome";

// import logo from '../assets/easyhealth.png';
// @ is an alias to /src
export default {
    name: "Home",
    components: {
        carousel: Carousel,
        "cards-home": CardsHome,
        "footer-home": FooterHome,
        "description-home": DescriptionHome,
    },
};
</script>
