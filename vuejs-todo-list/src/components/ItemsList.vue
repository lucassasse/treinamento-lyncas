<template>
  <ul>
    <li v-for="item in filteredCheckedItems" :key="item.index" class="itemList" :class="{ important: item.important }">
      <input type="checkbox" v-model="item.checked" @click="$emit('checkItem', item)">
      <p v-if="!item.editing" :class="[item.checked ? 'checked' : '']" class="itemText">
        {{item.label}}
      </p>
      <input v-if="item.editing" v-model="item.label" @keypress.enter="saveChanges(item)" v-focus class="inputEdit">
      <button :disabled="!item.label.length" @click="$emit('toggleEditItem', item)">{{ item.editing ? "Save" : "Edit" }}</button>
      <button @click="$emit('removeItem', item)">X</button>
    </li>
  </ul>
</template>

<script>
const focus = {
  mounted: (el) => el.focus()
}
export default { 
  props: {
    filteredCheckedItems: { type: Array }
  },
  directives:{
    focus
  }
}
</script>

<style>
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