<template>
    <div>
        <input type="text" v-model="user.name">
        <h1></h1>
    </div>
</template>

<script>

export default{
  props: {
    user:{ type: Object}
  }
}
</script>