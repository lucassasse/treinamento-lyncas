<template>
    <nav>
        <div id="div-img-logo">
            <img src="@/assets/images/img_logo_lyncas.png" alt="logo lyncas" id="img-logo">
        </div>

        <div id="div-links">
            <router-link to="/dashboard">
                <font-awesome-icon class="icon" icon="fa-regular fa-square"/>
                Dashboard
            </router-link>
            <router-link to="/customers" :class="activeCustomersFormClass">
                <font-awesome-icon class="icon" icon="fa-solid fa-person"/>
                Clientes 
            </router-link>
            <router-link to="/sales" :class="activeSalesFormClass">
                <font-awesome-icon class="icon" icon="fa-solid fa-cart-shopping"/>
                Vendas
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
    position: fixed;
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    align-items: center;
    align-content: center;

    background-color: #1C3B85;
    width: 250px;
    height: 100vh;
}

#div-img-logo{
    box-sizing: border-box;
    width: 100%;
    padding: 90px 50px 50px;
}

#img-logo{
    max-width: 100%;
}

.icon{
    margin: 5px 15px;
    color: white;
}

#div-links{
    display: flex;
    flex-direction: column;
    align-items: center;
    position: absolute;
    width: 100%;
    top: 50%;
    margin-top: -112px;
}

nav a {
    display: flex;
    align-items: center;
    width: 150px;
    height: 40px;
    margin: 15px;
    font-size: large;
    color: white;
    text-decoration: none;
    border: 1px solid #142957;
    border-radius: 5px;
}
  
nav a:hover{
    background-color: #183474; 
}
  
nav a.router-link-exact-active,
.active-route {
    background-color: #142957;
}

@media only screen and (max-width: 550px) {
    nav{
        
    }
}
</style>