<template>
  <div id="main">
    <h1>{{ header || "Welcome" }}</h1>
    <div>
      <input v-model="newItem" @keypress.enter="insertItemOnList" placeholder="Item...">
      <span class="characterCount" :class="[characterCount <= 100 ? '' : 'characterCountError']">{{ characterCount }}/100</span>
      <input type="checkbox" v-model="important">Important
    </div> <br>
    <button @click="insertItemOnList" :disabled="!newItem.length || newItem.length > 100">Save</button> <br>
    
    <div id="importants">
      <h3>List:</h3>
      <ul v-if="filteredCheckedItems.length > 0" >
        <template v-for="item in filteredCheckedItems" :key="item.id">
          <li class="itemList" :class="{ important: item.important }">
            <input type="checkbox" v-model="item.checked">
            <span :class="[item.checked ? 'checked' : '']">
              {{item.label}}
            </span>
            <button @click="toggleEditItem(item)" :disabled="!item.label.length">{{!item.editing ? "Edit" : "Cancel"}}</button>
            <button @click="removeItem(item)">X</button>
            <div v-if="item.editing" id="btnEdit">
              <input class="inputEdit" v-model="item.label" @keypress.enter="saveChanges(item)">
              <button @click="saveChanges(item)" :disabled="!item.label.length">Save changes</button>
            </div>
          </li>
        </template>
      </ul>
    </div>
  
    <button @click="removeAllItem">Remove all items</button> <br>
    <button @click="hideCheckedItems = !hideCheckedItems">
      {{ hideCheckedItems ? "Show all items" : "Hide checked items"}}
    </button>
  </div>
</template>


<script>
export default {
  data() {
    return {
      header: "ToDo List",
      newItem: "",
      checked: false,
      important: false,
      editing: false,
      hideCheckedItems: false,
      items:[
        {id: 1, important: true, label: "Item teste - checked + important", checked:true},
        {id: 2, important: false, label: "Teste 01", checked:false},
        {id: 3, important: false, label: "Texto 02 - checked", checked:true},
        {id: 4, important: false, label: "Valor 03", checked:false},
      ]
    }
  },
  computed:{
    filteredCheckedItems(){
      return this.hideCheckedItems
      ? this.items.filter((i) => !i.checked)
      : this.items
    },
    characterCount(){
      return this.newItem.length
    }
  },
  methods:{
    insertItemOnList(){
      if(!this.newItem){
        return false
      } else {
        if(this.important){
          this.items.splice(0,0, {
            id:this.items.length + 1, 
            important:this.important,
            checked: false,
            editing: false,
            label: this.newItem
          })
        }else{
          this.items.push({
            id:this.items.length + 1, 
            important:this.important,
            checked: false,
            editing: false,
            label: this.newItem
          })
        }
        this.newItem = ""
        this.important = false
      }
    },
    toggleEditItem(item){
      item.editing = !item.editing
    },
    saveChanges(item){
      this.toggleEditItem(item)
    },
    checkItem(){
      this.item.checked !== "checked" 
      ? this.item.checked = "checked" 
      : this.item.checked = ""
    },
    checkAllItem(){
      this.items.map((i) => i.checked = true)
    },
    removeItem(item){
      this.items = this.items.filter((i) => i !== item)
    },
    removeAllItem(){
      this.items = []
    }
  }
}
</script>


<style scoped>
#main{
  margin-top: 25px;
	font-family: Arial, Helvetica, sans-serif;
	width: 350px;
	margin-left: auto;
  margin-right: auto;
	padding: 25px;
	border: 1px solid #ccc;
	border-radius: 5px;

  display: flex;
  flex-direction: column;
}

#btnEdit{
  margin: 5px 0 10px 0;
}

.checked{
  text-decoration: line-through;
}

.important{
  background-color: yellow;
}

.itemList{
  margin-bottom: 10px;
}

.inputEdit{
  margin: 0 5px 3px 3px;
}

.characterCount{
  margin: 0 5px;
}

.characterCountError{
  color: red;
}

h1{
  margin-top: 0;
}

ul{
  padding: 0;
}

li{
	list-style: none;
}

li span{
  margin-right: 10px;
}

li button{
  margin-right: 5px;
}
</style>