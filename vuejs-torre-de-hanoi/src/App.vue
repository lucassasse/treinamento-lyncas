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
  
    <p id="pieces">Peça em mãos: {{ loosePiece ? loosePiece : "Nenhuma" }}</p>
  
    <h3 id="txtTowers">Torres:</h3>
  
    <div id="towers">
      <Tower :quantityPiecesInTower="quantityPiecesInTower" @move-piece="movePiece(0)"/> 
      <Tower :quantityPiecesInTower="towers[1]" @move-piece="movePiece(1)"/> 
      <Tower :quantityPiecesInTower="towers[2]" @move-piece="movePiece(2)"/>
    </div>
    
    <p id="clicks">Jogadas totais: {{clicks}}</p>
  </div>
</template>
  
  
<script>
  import Tower from './components/Tower'
  
  export default {
    components:{
      Tower
    },
    data(){
      return{
        quantityPieces: 0,
        loosePiece: '',
        towers: [[],[],[]],
        clicks: 0
      }
    },
    computed:{
      quantityPiecesInTower(){
        if(this.quantityPieces == 0) return this.towers[0];
        this.clearGame()
        for(var i=0; i < this.quantityPieces; i++){
          this.towers[0].unshift((i+1).toString())
        }
        return this.towers[0]
      }
    },
    methods:{
      movePiece(tower){
        if(this.loosePiece != ''){
          this.putPiece(tower)
        } else{
          this.pickPiece(tower)
        }
      },
      pickPiece(tower){
        for(let i = 0; i < 3; i++){
          if(tower == i && this.towers[i]){
            this.loosePiece = this.towers[i][this.towers[i].length - 1]
            this.towers[i].pop()
          }
        }
      },
      putPiece(tower){
        for(let i = 0; i < 3; i++){
          if(tower == i && this.loosePiece != ''){
            if(this.loosePiece < this.towers[i][this.towers[i].length - 1] || this.towers[i].length == 0){
              this.towers[i].push(this.loosePiece)
              this.loosePiece == undefined ? false : this.clicks++
              this.loosePiece = ''
            }
          }
        }
      },
      clearGame(){
        this.loosePiece = ''
        this.towers = [[],[],[]]
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
</style>
  