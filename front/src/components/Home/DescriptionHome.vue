<template>
    <v-container
        fluid
        :style="{
            background: `transparent url(${require('../../assets/fundo_claro.jpg')}) repeat center top`,
        }"
    >
        <v-row>
            <v-card
                class="mx-auto my-12 px-4"
                max-width="500"
                color="transparent"
                elevation="0"
            >
                <div class="d-flex flex-no-wrap justify-space-around">
                    <v-img
                        height="150px"
                        width="150px"
                        src="../../assets/easyhealth.png"
                        contain
                    ></v-img>
                    <v-card-title style="color: #0D8C98; font-size: 2.2em"
                        >Sobre Nós</v-card-title
                    >
                </div>
                <v-card-text
                    style="color: #0D8C98; font-size: 1em; text-align: justify"
                >
                    <p>
                        A EasyHealth é a maior rede de clínicas populares do
                        Brasil. A proposta é levar um atendimento médico de
                        qualidade, humanizado e sem burocracia à população
                        brasileira.
                    </p>
                    <p>
                        Tudo isso com condições especiais para quem não pode
                        pagar um convênio médico ou esperar um longo período por
                        um atendimento no SUS.
                    </p>
                </v-card-text>
            </v-card>
            <v-card
                class="mx-auto my-12 px-4"
                max-width="500"
                color="transparent"
                elevation="0"
            >
                <div class="d-flex flex-no-wrap justify-space-around">
                    <v-img
                        height="150px"
                        width="150px"
                        src="../../assets/easyhealth.png"
                        contain
                    ></v-img>
                    <v-card-title style="color: #0D8C98; font-size: 2.2em"
                        >Nossa Missão</v-card-title
                    >
                </div>
                <v-card-text
                    style="color: #0D8C98; font-size: 1em; text-align: justify"
                >
                    <p>
                        Proporcionar cuidado humanizado e de excelência em
                        saúde, com foco na vida e no acolhimento com qualidade,
                        na construção de conhecimento e na sustentabilidade.
                    </p>
                </v-card-text>
            </v-card>
            <v-card
                class="mx-auto my-12 px-4"
                max-width="500"
                color="transparent"
                elevation="0"
            >
                <div class="d-flex flex-no-wrap justify-space-around">
                    <v-img
                        height="150px"
                        width="150px"
                        src="../../assets/easyhealth.png"
                        contain
                    ></v-img>
                    <v-card-title style="color: #0D8C98; font-size: 2.2em"
                        >Nossos Valores</v-card-title
                    >
                </div>
                <v-card-text
                    style="color: #0D8C98; font-size: 1em; text-align: justify"
                >
                    <p>
                        Humanização, Ética, Sustentabilidade, Excelência,
                        Respeito.
                    </p>
                </v-card-text>
            </v-card>
        </v-row>
    </v-container>
</template>
<script>
export default {
    components: {},
    data() {
        return {};
    },
};
</script>
