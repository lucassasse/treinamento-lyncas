<template>
  <div id="main">
    <h1>{{ header || "Welcome" }}</h1>
    <div>
      <input v-model="newItem" @keypress.enter="insertItemOnList" placeholder="Item..." v-focus>
      <span class="characterCount" :class="[characterCount <= 100 ? '' : 'characterCountError']">{{ characterCount }}/100</span>
      <input type="checkbox" v-model="important">Important
    </div> <br>

    <button @click="insertItemOnList" :disabled="!newItem.length || newItem.length > 100">Save</button> <br>
    <h3>List:</h3>
    
    <div>
      <ItemsList vIf="showItens" :filteredCheckedItems="filteredCheckedItems" @check-item="checkItem" @toggle-edit-item="toggleEditItem" @remove-item="removeItem"></ItemsList>
    </div>
  
    <button @click="removeAllItem" :disabled="!items.length">Remove all items</button> <br>
    <button @click="checkOrDescheckAllItems" :disabled="!items.length">
      "Check/ Deschecked all items"
    </button> <br>
    <button @click="hideCheckedItems = !hideCheckedItems" :disabled="!items.length">
      {{ hideCheckedItemsBtn }}
    </button>    
  </div>
</template>


<script>
import ItemsList from './components/ItemsList.vue'

const focus = {
  mounted: (el) => el.focus()
}

export default {
  components:{
    ItemsList
  },

  data() {
    return {
      header: "ToDo List",
      newItem: "",
      important: false,
      editing: false,
      checkAllItems: false,
      hideCheckedItems: false,
      items: JSON.parse(localStorage.getItem('itemsList')) || []
    }
  },
  computed:{
    filteredCheckedItems(){
      return this.hideCheckedItems ? this.items.filter((i) => !i.checked) : this.items
    },
    characterCount(){
      return this.newItem.length
    },
    showItens () {
      return filteredCheckedItems.length > 0
    },
    hideCheckedItemsBtn(){
      return this.hideCheckedItems ? "Show all items" : "Hide checked items"
    }
  },
  methods:{
    insertItemOnList(){
      if(!this.newItem){
        return false
      }
      
      const newItemObject = {
        id: this.items.length + 1 || 1,
        important: this.important,
        checked: false,
        editing: false,
        label: this.newItem,
      }
      
      if(this.important){
        this.items.splice(this.findIndexLastImportant() + 1, 0, newItemObject)
      } else{
        this.items.push(newItemObject)
      }

      this.newItem = ""
      this.important = false
      localStorage.setItem('itemsList', JSON.stringify(this.items));
    },
    findIndexLastImportant(){
      const index = this.items.findLastIndex(item => item.important);
      return index
    },
    toggleEditItem(item){
      item.editing = !item.editing
    },
    saveChanges(item){
      this.toggleEditItem(item)
      localStorage.setItem('itemsList', JSON.stringify(this.items));
    },
    checkItem(item){
      item.checked = !item.checked
      localStorage.setItem('itemsList', JSON.stringify(this.items));
    },
    checkOrDescheckAllItems(){
      let verifyCheck = false
      this.items.forEach(e => {
        if(!e.checked){
          verifyCheck = true
        }
      });

      verifyCheck ? this.items.map((i) => i.checked = true) : this.items.map((i) => i.checked = false)
      localStorage.setItem('itemsList', JSON.stringify(this.items));
    },
    removeItem(item){
      this.items = this.items.filter((i) => i !== item)
      localStorage.setItem('itemsList', JSON.stringify(this.items));
    },
    removeAllItem(){
      this.items = []
      localStorage.removeItem('itemsList');
    }
  },
  directives:{
    focus
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

.characterCount{
  margin: 0 5px;
}

.characterCountError{
  color: red;
}

h1{
  margin-top: 0;
}

h3{
  margin: 20px 0 0 0;
}





.itemList{
  margin-bottom: 10px;
  display: flex;
  flex-direction: row nowrap;
  align-items: center;
}

.itemText{
  display: inline-block;
  max-width: 250px;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  margin: 0 10px;
}

.inputEdit{
  margin: 0 5px 0;
  border: none;
  border-bottom: 1px solid black;
}

.inputEdit:focus{
  margin: 0 5px 0;
  border: none;
  outline: none;
  border-bottom: 1px solid black;
}

.important{
  color: red;
}

.checked{
  text-decoration: line-through;
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