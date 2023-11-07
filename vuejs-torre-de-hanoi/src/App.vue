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
    <div class="tower">
      <div v-for="piece in tower1" :key="piece">
        <p @click="movePiece(piece)" class="piece">{{piece}}</p>
      </div>
    </div>
    
    <div class="tower">
      <div v-for="piece in tower2" :key="piece">
        <p @click="movePiece(piece)" class="piece">{{piece}}</p>
      </div>
    </div>

    <div class="tower">
      <div v-for="piece in tower3" :key="piece">
        <p @click="movePiece(piece)" class="piece">{{piece}}</p>
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
  computed:{

  },
  methods:{
    movePiece(piece){
      this.loosePiece = piece
      console.log("Preciso saber de qual torre vem a peça")
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

.piece:hover{
  cursor: pointer;
}
</style>
