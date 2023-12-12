<template>
    <Header>
        <template #btnAdd>
        </template>
    </Header>

    <div id="main">
        <h2>Bem-vindo</h2>
    </div>
</template>

<script>
import Header from '@/layouts/Header.vue'
export default{
        components:{
            Header
        }
    }
</script>

<style scoped>
#main{
    display: flex;
    justify-content: center;
    align-items: center;
}

h2{
    margin-top: 200px;
}
</style>