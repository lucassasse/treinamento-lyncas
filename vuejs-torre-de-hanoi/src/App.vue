<template>
<div id="main">
  <div>
    <h1>Torre de Hanoi</h1>
    <p>Peça menor sempre deve estar acima de uma maior</p>
  </div>

  <div>
    <p>Peça em mãos: {{loosePiece}}</p>
    <h3>Torres:</h3>
  </div>

  <div id="towers">
    <div class="tower" @click="movePiece('tower1')">
      <div v-for="piece in tower1" :key="piece">
        <p class="piece">{{piece}}</p>
      </div>
    </div>
    
    <div class="tower" @click="movePiece('tower2')">
      <div v-for="piece in tower2" :key="piece">
        <p class="piece">{{piece}}</p>
      </div>
    </div>

    <div class="tower" @click="movePiece('tower3')">
      <div v-for="piece in tower3" :key="piece">
        <p class="piece">{{piece}}</p>
      </div>
    </div>
  </div>
</div>
</template>


<script>
export default {
  data(){
    return{
      loosePiece: '',
      tower1: [ '3', '2'],
      tower2: ['1'],
      tower3: [],
    }
  },
  methods:{
    movePiece(tower){
      if(tower == 'tower1'){
        this.loosePiece = this.tower1[this.tower1.length - 1]
        this.tower1.pop()
      }
      if(tower == 'tower2'){
        this.loosePiece = this.tower2[this.tower2.length - 1]
        this.tower2.pop()
      }
      if(tower == 'tower3'){
        this.loosePiece = this.tower3[this.tower3.length - 1]
        this.tower3.pop()
      }
    }
  }
}
</script>


<style>
#main{
  margin-top: 25px;
	font-family: Arial, Helvetica, sans-serif;
	width: 350px;
	margin-left: auto;
  margin-right: auto;
	padding: 25px;
	border: 1px solid #ccc;
	border-radius: 2px;

  display: flex;
  flex-direction: column;
}

h1{
  margin-top: 0;
}

#towers{
  display: flex;
	margin-left: auto;
  margin-right: auto;
}

.tower{
  display: flex;
  flex-direction: column-reverse;
  width: 35px;
  height: 114px;
  padding: 5px;
  margin: 10px;
  border: 1px solid gray;
  border-radius: 2px;
}

.piece{
  margin: 10px;
}

.tower:hover{
  cursor: pointer;
}
</style>
