<template>
    <v-app>
        <v-app-bar app color="primary" dark>
            <div class="d-flex align-center">
                <v-img
                    alt="Vuetify Logo"
                    class="shrink mr-2"
                    contain
                    src="https://cdn.vuetifyjs.com/images/logos/vuetify-logo-dark.png"
                    transition="scale-transition"
                    width="40"
                />
            </div>

            <v-tabs centered dark icons-and-text>
                <v-tabs-slider></v-tabs-slider>

                <v-tab to="/">
                    Home
                </v-tab>

                <v-tab to=/photos>
                    Photos
                </v-tab>

                <v-tab to="/cadastros">
                    Cadastros
                </v-tab>

                <v-tab to="/newappointment">
                    Testes
                </v-tab>

                <v-tab to="/consultas">
                    Consultas
                </v-tab>

            </v-tabs>

            <v-spacer></v-spacer>
            
            <ModalLogin
                @close="closeModal"
            />
        </v-app-bar>

        <v-main style="background-color:#eeeeee"> <router-view></router-view> </v-main>
    </v-app>
</template>

<script>
import ModalLogin from './components/ModalLogin.vue';

export default {
    name: "App",
    components: {
      ModalLogin,
    },
    data() {
      return {
        isModalVisible: false,
      };
    },
    methods: {
      showModal() {
        this.isModalVisible = true;
      },
      closeModal() {
        this.isModalVisible = false;
      }
    }
};
</script>
