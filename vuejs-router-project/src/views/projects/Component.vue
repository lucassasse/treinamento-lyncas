<template>
    <div>
        <input type="text" v-model="user.name">
    </div>
</template>

<script>

export default{
  props: {
    user:{ type: Object}
  }
}
</script>