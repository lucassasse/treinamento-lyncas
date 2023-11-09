<template>
<div id="divMain">
  <div id="header">
    <h1>Torre de Hanoi</h1>
    <p>Peça menor sempre deve estar acima de uma maior</p>
  </div>

  <div id="divQuantityPieces">
    <p>Com quantas peças você deseja jogar?</p>
    <select v-model="quantityPieces" name="quantityPieces" id="quantityPieces">
      <option disabled value="0">Quantidade de peças</option>
      <option value="3">3</option>
      <option value="4">4</option>
      <option value="5">5</option>
    </select>
  </div>

  <p id="pieces">Peça em mãos: {{loosePiece[0] ? loosePiece[0] : "Nenhuma"}}</p>
    
  <h3 id="txtTowers">Torres:</h3>

  <div id="towers">
    <div class="tower" @click="movePiece('tower1')">
      <div v-for="piece in quantityPiecesInTower" :key="piece">
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
  <p id="clicks">Jogadas totais: {{clicks}}</p>
</div>
</template>


<script>
export default {
  data(){
    return{
      quantityPieces: 0,
      loosePiece: [],
      tower1: [],
      tower2: [],
      tower3: [],
      clicks: 0
    }
  },
  computed:{
    quantityPiecesInTower(){
      if(this.quantityPieces == 0) return this.tower1;
      this.clearGame()
      for(var i=0; i < this.quantityPieces; i++){
        this.tower1.unshift((i+1).toString())
      }
      return this.tower1
    }
  },
  methods:{
    movePiece(tower){
      if(this.loosePiece.length != 0){
        this.putPiece(tower)
      } else{
        this.pickPiece(tower)
      }
    },
    pickPiece(tower){
      if(tower == 'tower1'){
        if(this.tower1.length){
          this.loosePiece = this.tower1[this.tower1.length - 1]
          this.tower1.pop()
        }
      }
      if(tower == 'tower2'){
        if(this.tower2.length){
          this.loosePiece = this.tower2[this.tower2.length - 1]
          this.tower2.pop()
        }
      }
      if(tower == 'tower3'){
        if(this.tower3.length){
          this.loosePiece = this.tower3[this.tower3.length - 1]
          this.tower3.pop()
        }
      }
    },
    putPiece(tower){
      if(tower == 'tower1'){
        if(this.loosePiece[0] < this.tower1[this.tower1.length - 1] || this.tower1.length == 0){
          this.tower1.push(this.loosePiece[0])
          this.loosePiece = []
          this.clicks++
        }
      }
      if(tower == 'tower2'){ // problema na lógica de putPiece
        if(this.loosePiece[0] < this.tower2[this.tower2.length - 1] || this.tower2.length == 0){
          this.tower2.push(this.loosePiece[0])
          this.loosePiece = []
          this.clicks++
        }
      }
      if(tower == 'tower3'){
        if(this.loosePiece[0] < this.tower3[this.tower3.length - 1] || this.tower3.length == 0){
          this.tower3.push(this.loosePiece[0])
          this.loosePiece = []
          this.clicks++
        }
      }
    },
    clearGame(){
      this.loosePiece = []
      this.tower1 = []
      this.tower2 = []
      this.tower3 = []
    }
  }
}
</script>


<style>
#divMain{
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

  text-align: center;
}

h1{
  margin-top: 0;
}

#towers{
  display: flex;
	margin-left: auto;
  margin-right: auto;

  text-align: center;
}

.tower{
  display: flex;
  flex-direction: column-reverse;
  min-height: 202px;
  width: 35px;
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
