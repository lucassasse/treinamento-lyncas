import { routeLocationKey } from 'vue-router';
<template>
    <h1>Project Details - NAME - Page</h1>
    <p>The project id is {{ id }}</p>
</template>

<script>
export default {
    props: {
    id: { type: String }
  },
}
</script>