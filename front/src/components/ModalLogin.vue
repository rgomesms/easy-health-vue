<template>
  <v-row justify="center">
    <v-dialog
      v-model="dialog"
      max-width="600px"
      transition="dialog-top-transition"
    >
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          color="primary"
          dark
          v-bind="attrs"
          v-on="on"
        >
          <span class="mr-2">Login</span>
          <v-icon>mdi-open-in-new</v-icon>
        </v-btn>
      </template>
      <v-card>
        <v-card-title>
          <span class="headline">Login</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-form
              ref="form"
              v-model="valid"
              lazy-validation
            >
              <v-row>
                <v-col cols="12">
                  <v-text-field
                    v-model="email"
                    :rules="emailRules"
                    label="Email"
                    required
                    outlined
                  ></v-text-field>
                </v-col>
                <v-col cols="12">
                  <v-text-field
                    v-model="senha"
                    :rules="senhaRules"
                    label="Senha"
                    type="password"
                    required
                    outlined
                  ></v-text-field>
                </v-col>
              </v-row>
            </v-form>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="blue darken-1"
            text
            @click="reset"
          >
            Fechar
          </v-btn>
          <v-btn
            color="blue darken-1"
            text
            @click="validate"
          >
            Entrar
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script>
  export default {
    name: 'ModalLogin',
    data: () => ({
      dialog: false,
      valid: true,
      senha: '',
      senhaRules: [],
      email: '',
      emailRules: [],
    }),
    methods: {
      validate () {
        this.emailRules = [
          v => !!v || 'E-mail é necessário',
          v => /.+@.+\..+/.test(v) || 'E-mail deve estar no formato correto',
        ],
        this.senhaRules = [
          v => !!v || 'Senha é necessária',
        ],
        this.$refs.form.validate()
      },
      reset () {
        this.senhaRules = [],
        this.emailRules = [],
        this.dialog = false;
        this.$refs.form.reset()
      },
      resetValidation () {
        this.$refs.form.resetValidation()
      },
    },
  };
</script>