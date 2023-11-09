<template>
  <div id="main">
    <h1>{{ header || "Welcome" }}</h1>
    <div>
      <input v-model="newItem" @keypress.enter="insertItemOnList" placeholder="Item...">
      <span class="characterCount" :class="[characterCount <= 100 ? '' : 'characterCountError']">{{ characterCount }}/100</span>
      <input type="checkbox" v-model="important">Important
    </div> <br>
    <button @click="insertItemOnList" :disabled="!newItem.length || newItem.length > 100">Save</button> <br>
    
    <div>
      <h3>List:</h3>
      <ul v-if="filteredCheckedItems.length > 0" >
          <div v-for="item in filteredCheckedItems" :key="item.id">
            <li class="itemList" :class="{ important: item.important }" >
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
          </div>
      </ul>
    </div>
  
    <button @click="removeAllItem" :disabled="!items.length">Remove all items</button> <br>
    <button @click="checkOrDescheckAllItems" :disabled="!items.length">Check all items
      {{ checkAllItems ? "check all items" : "Deschecked all items" }}
    </button> <br>
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
      checkAllItems: false,
      hideCheckedItems: false,
      items: JSON.parse(localStorage.getItem('itemsList')) || []
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
    },
    checkItem(){
      this.item.checked !== "checked" 
      ? this.item.checked = "checked" 
      : this.item.checked = ""
    },
    checkOrDescheckAllItems(){
      this.items.map((i) => i.checked = true)
      this.checkAllItems = true
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
  color: red;
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