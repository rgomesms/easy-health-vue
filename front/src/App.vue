<template>
    <v-app>
        <v-app-bar app :style="barStyle"  height="80">
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

                <v-tab to=/photos>
                    Fotos
                </v-tab>

                <v-tab :to="cadastros">
                    Cadastros
                </v-tab>

                <v-tab :to="consultas" v-if="this.tipoUsuario" >
                    Consultas
                </v-tab>
            </v-tabs>

            <v-spacer></v-spacer>

            <ModalLogin v-if="!this.tipoUsuario"
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
        codigoUsuario:null,
        tipoUsuario:"",
        test:null,
      };
    },
    computed:{
        barStyle(){
            if(this.tipoUsuario)
            return "background-color: rgba(13, 140, 152, .7);"
            else return "background-color: rgba(55, 181, 187,.7)"
        },
        consultas(){
            if(this.codigoUsuario&&
            this.tipoUsuario)
                return{
                name:"Consultas",
                params:{tipoUsuario:this.tipoUsuario,
                    codigoUsuario:this.codigoUsuario}
            }
            else
                return "/consultas"
        },
        cadastros(){
            if(this.codigoUsuario&&
            this.tipoUsuario)
                return{
                name:"Cadastros",
                params:{tipoUsuario:this.tipoUsuario,
                    codigoUsuario:this.codigoUsuario}
            }
            else
                return "/cadastros"
        },
        
    },

    methods: {

        logout(){
            console.log(this.$appName);
                this.$router.push("/");

            this.tipoUsuario=""
        },
        loginSucedido(data){
            this.codigoUsuario=data.codigoUsuario
            this.tipoUsuario=data.tipoUsuario;
            console.log("cc",this.codigoUsuario);
            this.test={
                name:"Consultas",
                params:{codigoUsuario:this.codigoUsuario}
            }
            console.log(this.tipoUsuario);
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
