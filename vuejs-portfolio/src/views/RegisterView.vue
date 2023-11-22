<template>
<div id="divMain">
    <h1>Criar uma conta</h1>
    <form ref="form" @submit.prevent="sendEmail" class="row g-3">
        <label for="inputName" class="form-label">Nome Completo</label>
        <input v-model="fullName" type="text" class="form-control" id="inputName" required/>
        
        <label for="inputEmail" class="form-label">E-mail</label>
        <input v-model="email" type="email" class="form-control" id="inputEmail" required/>
    
        <label for="inputPassword" class="form-label">Senha</label>
        <input v-model="password" type="password" class="form-control" id="inputPassword" minlength="8" required/>

        <button @click="register()" id="buttonRegister" class="btn btn-primary">Registrar</button>
    </form>
</div>
</template>

<script>
import axios from 'axios'
export default {
    data(){
        return{
            baseUrl: 'http://localhost:3000',
            fullName: '',
            email: '',
            password: '',
        }
    },
    methods:{
        register(){
            if (this.fullName == ''  || this.email == '' || this.password.length < 8){
                return
            } else{
                axios.post(`${this.baseUrl}/users`, {
                    fullName: this.fullName,
                    email: this.email,
                    password: this.password
                })
                .then(() => {
                    this.$router.replace({path: '/login'})
                    alert("Cadastro efetuado com sucesso!")
                    this.clearData()
                })
                .catch(() => {
                    alert("Ops, algo de errado aconteceu ao tentar criar sua conta!")
                });
            }
        },
        clearData(){
            this.fullName = '',
            this.email = '',
            this.password = ''
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

    #buttonRegister{
        margin-top: 50px;
    }
</style>