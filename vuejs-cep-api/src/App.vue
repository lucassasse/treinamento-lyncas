<template>
  <div id="main">
    <div id="top">
      <h1>
        CEP API
      </h1>
      <p>Informe o CEP</p>
      <input maxlength="9" placeholder="12345-678" v-model="cep"/>
    </div>

    <div v-if="loading">
      <h1>LOADING...</h1>
    </div> 

    <div v-else>
      <div id="bottom" v-if="response !== null">
        <p>Estado</p>
        <input disabled :value="estado"/>
        <p>Cidade</p>
        <input disabled :value="cidade"/>
        <p>Bairro</p>
        <input disabled :value="bairro"/>
        <p>Rua</p>
        <input disabled :value="logradouro"/>
        <p>Número</p>
        <input/>
        <p>Complemento</p>
        <input/> <br>
        <button>Enviar</button>
      </div>
    </div>       
  </div>
</template>

<script>
import axios from 'axios';

  export default{
    data(){
      return{
        cep: '',
        baseUrl: 'https://viacep.com.br/ws/',
        response: null,
        loading: false,
        estado: '',
        cidade: '',
        bairro: '',
        logradouro: ''
      }
    },
    methods:{
       async getCep(){
        this.loading = true
          const url = `${this.baseUrl}${this.cep}/json/`
          await axios.get(url)
          .then(resp => {
            this.inputValues(resp.data)
          })
          .catch((error) => {
            console.log("[ERROR] = " + error)
            alert("Ops, algo de errado aconteceu.\n\nCEP inválido!")
          })
          .finally(() => {this.loading = false})
      },
      inputValues(data){
        if(!data.erro){
          this.response = data
          this.estado = data.uf
          this.cidade = data.localidade
          this.bairro = data.bairro
          this.logradouro = data.logradouro
        } else{
          alert("CEP não encontrado!")
        }
      }
    },
      watch: {
        cep: function(newCep) {
          this.cep = newCep.replace(/\D/g,'')
          this.cep = newCep.replace(/(\d{5})(\d)/,'$1-$2')

          if (newCep.length === 9) this.getCep()
          else this.response = null
        }
      }
  }
</script>

<style>
#main {
  font-family: Arial, Helvetica, sans-serif;
  display: flex;
  flex-direction: column; 
  align-items: center;
  justify-content: center;
}

#top{
  margin: 25px 0;
  padding: 15px;
  border: 1px solid gray;
  border-radius: 5px;
}

#bottom{
  padding: 15px;
  border: 1px solid gray;
  border-radius: 5px;
}

h1{
  margin-top: 0;
}

p{
  margin-bottom: 0px;
}

input{
  display: block;
  height: 22px;
  border: 1px solid #ccc;
  border-radius: 4px;
  padding: 4px 10px;
}
</style>
