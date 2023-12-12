<template>
    <div id="main">
        <div id="div-left">
            <img src="@/assets/images/img_logo_lyncas.png" alt="Logo Lyncas">
            <p>
                Bem-vindo ao Lyncas Sales, uma aplicação simples para gerenciar vendas e clientes.
            </p>
        </div>
        
        <div id="div-right">
            <h1>Entrar</h1>
            <form action="login">
                <InputText type="email" id="email" labelFor="email" textPlaceholder="E-mail" v-model="user.email" ref="loginEmail" required/>
                <InputText type="password" id="password" textPlaceholder="Senha" v-model="user.password" ref="loginPassword" required/>
                <div class="btn-login">
                    <button id="btn-login" @click.prevent="login">Entrar</button>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
import InputText from '@/components/InputText.vue'
    export default{
        components:{
            InputText,
        },
        data(){
            return{
                user:{
                    email: '',
                    password: ''
                }
            }
        },
        methods:{
            login(){
                this.validate()
                if(this.$refs.loginEmail.valid() && this.user.password){
                    this.$router.push("/")
                }else{
                    return
                }
            },
            validate() {
                this.$refs.loginEmail.valid()
                this.$refs.loginPassword.valid()
            }
        }
    }
</script>

<style scoped>
#main{
    width: 100vw;
    height: 100vh;
    display: flex;
}

#div-left{
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    color: white;
    background-color: #274A9D;
    width: 50%;
    height: 100%;
}

img{
    width: 25%;
    margin-bottom: 50px;
}

p{
    width: 60%;
    font-weight: 400;
    font-size: x-large;
    text-align: center;
}

#div-right{
    display: flex;
    flex-direction: column;
    justify-content: center;
    width: 30%;
    height: 100%;
    margin: auto;
}

h1{
    font-weight: 600;
    text-align: center;
}

.btn-login{
    display: flex;
    flex-direction: row-reverse;
    text-decoration: none;
}

#btn-login{
    color: white;
    background-color: #03C874;
    font-weight: 600;
    font-size: large;
    border: none;
    border-radius: 5px;
    padding: 8px 30px;
}

#btn-login:hover{
    cursor: pointer;
    background-color: #049b5a;
}
</style>