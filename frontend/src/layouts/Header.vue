<template>
    <header>
        <div id="data_user">
            <img src="@/assets/images/img_user.png" alt="foto do usuário">
            <div id="div-user">
                <div id="div-wellcome">
                    <p class="text-user">Olá,</p>
                    <p class="text-user txt-name-user">{{ userName }}</p>
                </div>
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
        name: 'btnAdd',
        data(){
            return{
                userName: 'Genara Souza',
                userImage: ''
            }
        }
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

#div-wellcome{
    display: flex;
}

#div-user{
    display: flex;
    flex-direction: column;
}

.txt-name-user{
    color: #26324B;
    font-weight: 700;
}

.text-user{
    margin: 0 7px 0 0;
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

@media only screen and (max-width: 900px) {
    header{
        margin: 0 20px 0 20px;
        border-bottom: 2px solid #E5EBF1;
        display: flex;
        justify-content: space-between;
    }

    #right{
        height: 100vh;
        padding: 0;
        margin: 0;
        margin-left: 0;
        display: flex;
    }

    #div-wellcome{
        display: block;
    }

    #data_user{
        display: flex;
        align-items: center;

    }

    #div-user{
        width: 100%;
        display: flex;
        flex-direction: row;
        align-items: center;
        justify-content: space-between;
    }

    #button{
        display: flex;
        flex-direction: column;
    }
}
</style>