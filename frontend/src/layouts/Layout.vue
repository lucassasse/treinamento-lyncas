<template>
    <div id="template">
        <NavBar/>
        <div id="right">
            <router-view/>
        </div>
    </div>
</template>

<script>
import NavBar from '@/layouts/NavBar.vue'
export default{
    components:{
        NavBar
    }
}
</script>

<style scoped>
#template{
    display: flex;
}

#right{
    width: 100%;
    padding-right: 25px;
    margin-left: 275px;
    display: flex;
    flex-direction: column;
}

@media only screen and (max-width: 900px) {
    
}
</style>