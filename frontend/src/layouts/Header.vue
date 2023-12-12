<template>
    <header>
        <div id="data_user">
            <div>
                <img src="@/assets/images/img_user.png" alt="foto do usuário">
            </div>
            <div id="div-user">
                <p id="txt-name-user" class="text-user">Olá Usuário</p>
                <router-link to="/login" class="text-user link-logout">Sair</router-link>
            </div>
        </div>

        <div id="button">
            <slot name="btnAdd"></slot>
        </div>
    </header>
</template>

<script>
export default {
    name: 'btnAdd'
}
</script>

<style scoped>
header{
    display: flex;
    justify-content: space-between;
    align-items: center;
    
    padding: 20px 0;
    margin-top: 50px;
    border-bottom: 2px solid #E5EBF1;
}

img{
    margin-right: 20px;
}

#data_user{
    display: flex;
    align-items: center;
}

#div-user{
    display: flex;
    flex-direction: column;
}


#txt-name-user{
    color: #26324B;
    font-weight: 700;
}

.text-user{
    margin: 0;
}

.link-logout{
    max-width: 30px;
    color: #767a7e;
    font-weight: 500;
    text-decoration: none;
}

.link-logout:hover{
    border-bottom: 1px solid #767a7e;
}
</style>