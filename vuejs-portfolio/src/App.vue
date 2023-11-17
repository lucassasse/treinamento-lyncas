<template>
  <template id="body">
    <nav id="nav">
      <div>
        <img src="@/assets/images/img_bucket.png" alt="">
      </div>
      <div>
        <router-link to="/">Home</router-link>
        <router-link to="/projects">Projects</router-link>
        <router-link to="/about">About</router-link>
        <router-link to="/contact">Contact</router-link>
        <router-link to="/login">Login</router-link>
      </div>
    </nav>
    <router-view/>
    
    <div>
      <p>Lorem ipsum dolor, sit amet consectetur adipisicing elit. Itaque ullam quibusdam ab eum quae accusamus eaque saepe consectetur temporibus. Debitis, ullam! Itaque deleniti porro expedita reprehenderit optio voluptatem repellendus asperiores?</p>
    </div>
  </template>
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  background-color: #DEDEDE;
  color: #183E6F;
}

#body{
  height: 100vh;
}

#nav{
  display: flex;
  justify-content: space-between;
  align-items: center;
}

img{
  width: 100px;
  margin-left: 25px;
}

nav a {
  font-weight: bold;
  background-color: #183E6F;
  color: #DEDEDE;
  padding: 10px 20px;
  margin: 0 5px;
  border-radius: 5px;
  text-decoration: none;
}

nav a.router-link-exact-active {
  background-color: #2F6A99;
}
</style>
