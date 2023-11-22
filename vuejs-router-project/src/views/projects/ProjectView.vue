<template>
  <div class="home">
    <h1>Project page</h1>
  </div>
  <div v-for="project in projects" :key="project.id" class="project">
    <router-link :to="{ name: 'ProjectDetails', params: { id: project.id } }">
      <h2>{{project.title}}</h2>
    </router-link>
  </div>
</template>
  
<script>
export default{
  data(){
    return{
      projects:[
        { id: 1, title: "Projeto um", details: 'lorem'},
        { id: 2, title: "Projeto dois", details: 'lorem'},
        { id: 3, title: "Projeto três", details: 'lorem'},
      ]
    }
  }
}
</script>
  
<style>
.project h2{
  background: #f4f4f4;
  padding: 20px;
  border-radius: 10px;
  margin: 10px auto;
  max-width: 600px;
  cursor: pointer;
  color: #444;
}

.project h2:hover{
  background-color: #ddd;
}

.project a{
  text-decoration: none;
}
</style>