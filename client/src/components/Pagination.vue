<template>
  <div class="pagination">
    <span @click="prevPage">&lt;</span>
    <span v-for="page in totalPages" :key="page" @click="gotoPage(page)" :class="{ active: currentPage === page }">{{ page }}</span>
    <span @click="nextPage">&gt;</span>
  </div>
</template>

<script>
export default {
  props: {
    totalPages: Number,
    currentPage: Number,
    prevPage: Function,
    nextPage: Function,
    gotoPage: Function,
  },
};
</script>

  
<style scoped>
  .pagination {
    display: flex;
    justify-content: center;
    align-items: center;
    margin: 15px 0 25px 0;
  }

  .pagination span {
    cursor: pointer;
    padding: 5px 10px;
    margin: 0 5px;
    border: 1px solid #ccc;
    border-radius: 5px;
  }

  .pagination span:hover {
    color: #fff;
    background-color: #1C3B85;
  }

  .pagination span.active {
    background-color: #1C3B85;
    color: #fff;
  }
</style>
  