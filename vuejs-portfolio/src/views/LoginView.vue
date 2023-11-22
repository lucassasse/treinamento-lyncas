<template>
  <div id="divMain">
    <h1>Login</h1>
    <form ref="form" @submit.prevent="sendEmail" class="row g-3">
      
      <label for="inputEmail" class="form-label">E-mail</label>
      <input v-model="email" name="user_email" type="email" class="form-control" id="inputEmail" required/>
    
      <label for="inputPassword" class="form-label">Senha</label>
      <input v-model="password" name="InputPassword" type="password" class="form-control" id="inputPassword" autocomplete="on" required/>

      <button @click="login()" value="login" id="buttonLogin" class="btn btn-primary">Entrar</button>
      
      <label id="labelRegister">Não é cadastrado?</label>
      <router-link to="/register">
        <button id="buttonRegister" class="btn btn-primary">Criar Conta</button>
      </router-link>
    </form>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  data(){
    return{
      baseUrl: 'http://localhost:3000',
      email: '',
      password: ''
    }
  },
  methods:{
    async login(){
      if(this.email == '' || this.password == ''){
        return
      } else{
        await axios.get(`${this.baseUrl}/users?email=${this.email}`)
          .then(response => {            
            this.verifyLogin(response.data) ? alert("Login efetuado com sucesso!") : alert("E-mail ou senha incorretos!")
          })
          .catch(error => {
            console.error('Error fetching data:', error);
            alert("Algo de errado aconteceu ao buscar pelos dados.")
          });
      }
    },
    verifyLogin(data){
      let verifyEmail = data.length > 0 ? true : false
      if(verifyEmail){
        return this.password == data[0].password ? true : false
      }
    }
  } 
}
</script>
  
<style scoped>
#divMain{
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

h1{
  margin-bottom: 50px;
}

form{
  width: 30vw;
}

#buttonLogin{
  margin-top: 25px;
}

#labelRegister{
  margin-top: 75px;
}
</style>