<template>
    <nav>
        <div id="nav-left">
            <img src="@/assets/images/icon.png" alt="Logo">
            <div id="status-bar">
                <p>Life: </p>
                <p>Money: </p>
                <p>Power: </p>
            </div>
        </div>

        <div id="link-list">
            <router-link to="/city">
                City
            </router-link>
            <router-link to="/store" :class="activeCustomersFormClass">
                Store
            </router-link>
            <router-link to="/tabern" :class="activeSalesFormClass">
                Tabern
            </router-link>
            <router-link to="/church" :class="activeSalesFormClass">
                Church
            </router-link>
        </div>
    </nav>
</template>

<script>
export default{
    data(){
        return{
            activeCustomersForm: false,
            activeSalesForm: false
        }
    },
    computed: {
        activeCustomersFormClass() {
            return this.activeCustomersForm ? 'active-route' : ''
        },
        activeSalesFormClass() {
            return this.activeSalesForm ? 'active-route' : ''
        },
        currentRoute() {
            return this.$route.name
        }
    },
    methods:{
        verifyCurrentRoute() {
            if(this.currentRoute == 'customers-form'){
                this.activeCustomersForm = true
                this.activeSalesForm = false
            } else if(this.currentRoute == 'sales-form'){
                this.activeCustomersForm = false
                this.activeSalesForm = true
            } else{
                this.activeCustomersForm = false
                this.activeSalesForm = false
            }
        }
    },
    watch: {
        currentRoute() {
            this.verifyCurrentRoute()
        }
    },
    mounted(){
        this.verifyCurrentRoute()
    }
}
</script>

<style scoped>
nav{
    height: 15vh;
    background-color: rgb(63, 62, 62);
    display: flex;
    align-items: center;
    justify-content: space-between;
}

#nav-left{
    display: flex;
    align-items: center;
}

img{
    height: 10vh;
    margin: 2.5vh;
    border-radius: 50%;
}

#link-list{
    height: 15vh;
    display: flex;
    align-items: center;
}

#status-bar{
    color: white;
    margin-left: 50px;
    display: flex;
}

#status-bar p{
    margin-right: 100px;
}

nav a{
    color: white;
    text-decoration: none;
    padding: 10px 20px;
    border: 1px solid white;
    border-radius: 25px;
    margin: 15px;
}

nav a:hover{
    background-color: black;
    color: white;
}
  
nav a.router-link-exact-active,
.active-route {
    background-color: black;
}

@media only screen and (max-width: 900px) {
    nav a{
        padding: 5px 10px;
        border-radius: 10px;
        margin: 5px;
    }
}

@media only screen and (max-width: 350px) {
    nav {
        flex-direction: column;
        height: 125px;
        justify-content: center;
        margin: 0;
    }
}
</style>