<template>
    <div id="nav">
        <router-link id="logo" to="/">Vue Travel App</router-link>
        <router-link 
            v-for="destination in destinations"
            :key="destination.id"
            :to="{ name: 'destination.show', params:{id: destination.id, slug: destination.slug} }"  
        >
      {{ destination.name }}
    </router-link>
    </div>
</template>

<script>
const destination = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/projects',
    name: 'projects',
    component: Projects
  },
  {
    path: '/about',
    name: 'about',
    component: About
  },
  {
    path: '/contact',
    name: 'contact',
    component: Contact
  },
  {
    path: '/login',
    name: 'login',
    component: Login
  },
  {
    path: '/:catchAll(.*)',
    name: 'NotFound',
    component: NotFound
  }
]
export default{
    data(){
        return{
            destinations: this.destinations
        }
    }
}
</script>

<style lang="css">
    
</style>