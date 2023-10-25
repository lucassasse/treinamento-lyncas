<template>
  <div>
    <h1>Todo list:</h1>
    <button @click="() => (showList = !showList)">Show / Hidden</button>
    <br />
    <input type="text" v-focus/>

    <ul v-if="showList">
      <li v-for="(task, index) in tasks" :key="`${task}-${index}`">
        {{ task.name }}
      </li>
    </ul>

    <p v-else>Lista oculta!</p>
  </div>
</template>

<script>
const focus = {
  inserted: (el) => {
    el.focus()
  }
}

export default {
  directives: {
    focus
  },
  data: () => ({
    showList: false,
    tasks: [
      {name: 'Assistir aulas', isDone: false}
    ]
  })
}
</script>
