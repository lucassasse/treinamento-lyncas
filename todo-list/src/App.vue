<script>
export default {
  data() {
    return {
      header: "ToDo List",
      newItem: "",
      checked: false,
      important: false,
      hideCheckedItems: false,
      items:[
        {id: 1, important: false, label: "item teste", checked:false},
        {id: 2, important: true, label: "outro item teste", checked:true},
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
      this.items.push({
        id:this.items.length + 1,
        important:this.important,
        checked: false,
        label: this.newItem
      })
      this.newItem = ""
      this.important = false
    },
    editItem(){

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
		<input v-model="newItem" @keypress.enter="insertItemOnList" placeholder="Item..."> <br>
		<input type="checkbox" v-model="important"> Important <br>
		<button @click="insertItemOnList">Save</button> <br><br><hr>

		<div id="importants">
			<h3>Importants:</h3>
			<ul v-if="filteredCheckedItems.length > 0" >
				<template v-for="item in filteredCheckedItems">
					<li v-if="item.important" :key="item.id">
						<input type="checkbox" v-model="item.checked">
						<span :class="{ checked: item.checked }">
							{{item.label}} - {{item.important}} - {{ item.checked }}
						</span>
						<button>Edit</button>
						<button @click="removeItem(item)">X</button>
					</li>
				</template>
			</ul>
			<p v-else>No items on the list!</p>
		</div>
		<hr>

		<div id="notImportants">
			<h3>Not Importants:</h3>
			<ul v-if="filteredCheckedItems.length > 0" >
				<template v-for="item in filteredCheckedItems">
					<li v-if="!item.important" :key="item.id">
						<input type="checkbox" v-model="item.checked">
						<span :class="{ checked: item.checked }">
							{{item.label}} - {{item.important}} - {{ item.checked }}
						</span>
						<button>Edit</button>
						<button @click="removeItem(item)">X</button>
					</li>
				</template>
			</ul>
			<p v-else>No items on the list!</p>
		</div>
		<hr>

		<button @click="checkAllItem">Check all items</button> <br>
		<button @click="removeAllItem">Remove all items</button> <br>
		<button @click="hideCheckedItems = !hideCheckedItems">
			{{ hideCheckedItems ? "Show all items" : "Hide checked items"}}
		</button>
	</div>
</template>

<style scoped>
.checked{
  text-decoration: line-through;
}
#main{
	font-family: Arial, Helvetica, sans-serif;
	width: 350px;
	margin-left: auto;
    margin-right: auto;
	padding: 25px;
	border: 1px solid #ccc;
	border-radius: 5px;
}
li{
	list-style: none;
}
</style>