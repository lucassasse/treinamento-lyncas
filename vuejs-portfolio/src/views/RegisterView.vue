<template>
<div id="divMain">
    <h1>Criar uma conta</h1>
    <form ref="form" @submit.prevent="sendEmail" class="row g-3">

        <label for="inputName" class="form-label">Nome Completo</label>
        <input v-model="name" name="user_name" type="text" class="form-control" id="inputName" required/>
        
        <label for="inputEmail" class="form-label">E-mail</label>
        <input v-model="email" name="user_email" type="email" class="form-control" id="inputEmail" required/>
    
        <label for="inputPassword" class="form-label">Senha</label>
        <input v-model="password" name="password" type="text" class="form-control" id="inputPassword" minlength="8" required/>

        <button type="submit" value="register" id="buttonRegister" class="btn btn-primary">Registrar</button>
    </form>
      
  
</div>
</template>

<script>
export default {
    data(){
        return{
            name: '',
            email: '',
            password: '',
        }
    },
    methods:{

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