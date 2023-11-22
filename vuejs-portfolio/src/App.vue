<template>
  <div id="body">
    <nav id="nav">
      <div>
        <router-link to="/" id="imgHome">
          <img src="@/assets/images/img_bucket.png" alt="Chapéu estilo bucket" >
        </router-link>
      </div>
      <div>
        <router-link to="/">Home</router-link>
        <router-link to="/projects">Projects</router-link>
        <router-link to="/contact">Contact</router-link>
        <router-link to="/login">Login</router-link>
      </div>
    </nav>
    <hr>
    <router-view/>
  </div>
</template>

<style scoped>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: rgb(50, 50, 50);
}

#body{
  height: 100vh;
}

#nav{
  display: flex;
  justify-content: space-between;
  align-items: center;
}

nav img{
  width: 100px;
  margin-left: 25px;
}

#imgHome{
  border: none;
}

nav img:hover{
  cursor: pointer;
}

nav a {
  font-weight: bolder;
  font-size: large;
  color: rgb(50, 50, 50);
  margin-right: 40px;
  text-decoration: none;
}

nav a:hover{
  border-bottom: 2px dashed black;
}

nav a.router-link-exact-active {
  color: black;
  border-bottom: 2px solid black;
}

@media only screen and (max-width: 950px) {
  nav a{
    margin-right: 20px;
  }
}
</style>
