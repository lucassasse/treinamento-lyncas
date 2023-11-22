<template>
  <div id="divMain">
    <div id="divLeft">
      <h1>Contate-nos</h1>

      <form ref="form" @submit.prevent="sendEmail" class="row g-3">
        <input type="hidden" name="contact_number">
        
          <label for="inputName" class="form-label">Nome Completo</label>
          <input v-model="name" name="user_name" type="text" class="form-control" id="inputName" required/>
        
          <label for="inputEmail" class="form-label">E-mail</label>
          <input v-model="email" name="user_email" type="email" class="form-control" id="inputEmail" required/>
        
          <label for="inputMessage" class="form-label">Mensagem</label>
          <input v-model="message" name="message" type="text" class="form-control" id="inputMessage" required/>
  
        <div class="col-12">
          <button type="submit" value="Send" id="buttonSend" class="btn btn-primary">Enviar</button>
        </div>
      </form>
    </div>

    <div id="divRight">
      <div class="card">
        <div class="card-body">
          <h5 class="card-title">Lyncas - Onde nos encontrar</h5>
          <p>Rua Coronel Procópio Gomes de Oliveira, nº 474</p>
          <p>Salas 5,6,7,8 - Bairro: Centro</p>
          <p id="lastP">Jaraguá do Sul/SC CEP: 89251-200</p>
          <a id="buttonLink" href="https://lyncas.net/" target="_blank">Ir para o site</a>
        </div>
        <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d14284.439936370825!2d-49.0792521!3d-26.4844034!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94de9553f1dbe555%3A0x5b551366a15b7790!2sLyncas!5e0!3m2!1spt-BR!2sbr!4v1700483913138!5m2!1spt-BR!2sbr" height="337" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
      </div>
    </div>
  </div>
</template>
  
<script>
import emailjs from '@emailjs/browser';

export default {
  data(){
    return{
      name: '',
      email: '',
      message: '',
    }
  },

  methods: {
    sendEmail() {
      emailjs.sendForm('service_xdvw1gr', 'template_p07nb5m', this.$refs.form, 'vizNovrWMg1j1gnUD')
          .then(function() {
              alert("Mensagem enviada com sucesso!")
          }, function(error) {
              alert("Ops, algo de estranho aconteceu.")
          })
      this.name = ''
      this.email = ''
      this.message = ''
      this.contact_number = null
    },
  },

  mounted(){
    emailjs.init('vizNovrWMg1j1gnUD');
  }
}
</script>
  
<style scoped>
#divMain{
  color: rgb(50, 50, 50);
  display: flex;
  align-items: center;
  justify-content: center
}

#divLeft{
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  margin: 50px;
  padding: 50px;
  border: 1px solid rgba(168, 167, 167, 0.719);
  border-radius: 5px;
}

#divLeft h1{
  margin-bottom: 40px;
}

#divRight{
  margin: 50px 100px;
}

form{
  display: flex;
  flex-direction: column;
}

#inputName,
#inputEmail,
#inputMessage{
  width: 20vw;
}

.card{
  height: 557px;
  width: 450px;
  margin: 0 100px;
}

.card-title{
  font-weight: bold;
}

p{
  margin-bottom: 0px;
}
#lastP{
  margin-bottom: 15px;
}

#buttonSend{
  margin-top: 25px;
}

#buttonLink{
  color: black;
  border: 1px solid rgb(88, 88, 88);
  border-radius: 3px;
  padding: 10px;
  text-decoration: none;
}

#buttonLink:hover{
  background-color: rgba(224, 220, 220, 0.795);
  border: 1px solid black;
}

@media only screen and (max-width: 950px) {
  #body {
    height: 100%;
    width: 100vw;
  }

  #divMain{
    color: rgb(50, 50, 50);
    display: flex;
    flex-direction: column-reverse;
    align-items: center
  }

  #inputName,
  #inputEmail,
  #inputMessage{
    width: 65vw;
  }
}

@media only screen and (max-width: 500px) {
#divRight{
  width: 80vw;
}
}
</style>