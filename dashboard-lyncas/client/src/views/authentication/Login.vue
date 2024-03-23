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
import { User } from '@/models/User'

    export default{
        components:{
            InputText,
        },

        data(){
            return{
                user: new User({})
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
    width: 100%;
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
    align-items: center;
    width: 30%;
    height: 100%;
    margin: 25px auto;
}

form{
    min-width: 100%;
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

@media only screen and (max-width: 900px) {
    #main{
        flex-direction: column;
    }

    #div-left{
        width: 100%;
        height: 100%;
    }

    img{
        width: 50%;
        margin: 10px 0px;
    }

    #div-right{
        width: 85%;
    }

    #btn-login{
        width: 100%;
    }

    p{
        width: 80%;
    }
}
</style>