<template>
    <v-app>
        <v-app-bar app style="background-color: rgb(55, 181, 187,.7)"  height="80">
            <div class="d-flex align-center">
                <v-img
                    alt="Vuetify Logo"
                    class="shrink mr-2"
                    contain
                    src="./assets/easyhealth.png"
                    transition="scale-transition"
                    width="130"
                />
            </div>

            <v-tabs centered dark icons-and->
                <v-tabs-slider></v-tabs-slider>

                <v-tab to="/">
                    Home
                </v-tab>

                <v-tab :tipoUsuario=this.$tipoUsuario to=/photos>
                    Fotos
                </v-tab>

                <v-tab to="/cadastros">
                    Cadastros
                </v-tab>

                <v-tab to="/consultas" v-if="this.$tipoUsuario">
                    Consultas
                </v-tab>
            </v-tabs>

            <v-spacer></v-spacer>

            <ModalLogin v-if="!this.$tipoUsuario"
                @close="closeModal"
                @login="loginSucedido"
            />
            <v-btn 
                v-else
                color="#37B5BB"
                dark
                @click="logout"
                    > 
                    Logout
                </v-btn>

        </v-app-bar>

        <v-main :style="{ background: `transparent url(${require('./assets/fundo_claro.jpg')}) repeat center top` }"> <router-view></router-view> </v-main>
    </v-app>
</template>

<script>
import ModalLogin from './components/ModalLogin.vue';
// import Vue from "vue"

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
        logout(){
            console.log(this.$appName);

            this.$tipoUsuario=""
        },
        loginSucedido(tipo){
            this.$tipoUsuario=tipo;
            console.log(this.$tipoUsuario);
        },
      showModal() {
        this.isModalVisible = true;
      },
      closeModal() {
        this.isModalVisible = false;
      }
    }
};
</script>
