<template>
    <div id="template">
        <NavBar/>
        <div>
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
    flex-direction: column;
}
</style>