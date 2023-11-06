<script>
export default {
  data() {
    return {
      header: "ToDo List",
      newItem: "",
      checked: false,
      important: false,
      editing: false,
      edit: "",
      hideCheckedItems: false,
      items:[
        {id: 1, important: true, label: "item teste", checked:true},
        {id: 2, important: false, label: "outro teste", checked:false},
      ]
    }
  },
  computed:{
    filteredCheckedItems(){
      return this.hideCheckedItems
      ? this.items.filter((i) => !i.checked)
      : this.items
    }
  },
  methods:{
    insertItemOnList(){
      if(!this.newItem){
        return false
      } else {
        this.items.push({
          id:this.items.length + 1, 
          important:this.important,
          checked: false,
          editing: false,
          label: this.newItem
        })
        this.newItem = ""
        this.important = false
      }
    },
    toggleEditItem(item){
      item.editing = !item.editing
    },
    saveChanges(item){
      if(!this.edit){
        return false
      }else{
        item.label = this.edit
        this.edit = ""
        this.toggleEditItem(item)
      }
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

<template>
<div id="main">
  <h1>{{ header || "Welcome" }}</h1>
  <div>
    <input v-model="newItem" @keypress.enter="insertItemOnList" placeholder="Item...">
    <input type="checkbox" v-model="important">Important
  </div> <br>
  <button @click="insertItemOnList">Save</button> <br>
  
  <div id="importants">
    <h3>Importants:</h3>
    <ul v-if="filteredCheckedItems.length > 0" >
      <template v-for="item in filteredCheckedItems">
        <li v-if="item.important" :key="item.id">
          <input type="checkbox" v-model="item.checked">
          <span :class="{ checked: item.checked }">
            {{item.label}}
          </span>
          <button @click="toggleEditItem(item)">{{!item.editing ? "Edit" : "Cancel"}}</button>
          <button @click="removeItem(item)">X</button>
          <div v-if="item.editing">
            <input v-model="edit" :placeholder="item.label" @keypress.enter="saveChanges(item)">
            <button @click="saveChanges(item)">Save changes</button>
          </div>
        </li>
      </template>
    </ul>
    <p v-else>No items on the list!</p>
  </div>

  <div id="notImportants">
    <h3>Not Importants:</h3>
     <ul v-if="filteredCheckedItems.length > 0" >
      <template v-for="item in filteredCheckedItems">
        <li v-if="!item.important" :key="item.id">
          <input type="checkbox" v-model="item.checked">
          <span :class="{ checked: item.checked }">
            {{item.label}}
          </span>
          <button @click="toggleEditItem(item)">{{!item.editing ? "Edit" : "Cancel"}}</button>
          <button @click="removeItem(item)">X</button>
          <div v-if="item.editing">
            <input v-model="edit" :placeholder="item.label" @keypress.enter="saveChanges(item)">
            <button @click="saveChanges(item)">Save changes</button>
          </div>
        </li>
      </template>
    </ul>
    <p v-else>No items on the list!</p>
  </div>
  <hr>

  <button @click="removeAllItem">Remove all items</button> <br>
  <button @click="hideCheckedItems = !hideCheckedItems">
    {{ hideCheckedItems ? "Show all items" : "Hide checked items"}}
  </button>
</div>
</template>

<style scoped>
#main{
  margin-top: 50px;
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

.checked{
  text-decoration: line-through;
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