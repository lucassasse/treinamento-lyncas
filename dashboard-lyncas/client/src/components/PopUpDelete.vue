<template>
    <div class="pop-up">
        <div class="pop-up-inner" :class="popUpInnerClass">
            <h2>Deseja mesmo excluir?</h2>
            <div id="buttons-confirm">
                <button class="btn" :class="btnClass" @click="deleteItem()">Excluir</button>
                <button class="btn" :class="btnClass" @click="close()">Cancelar</button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props:{
        message: {type: String, default: ""},
        popUpClass: {type: String, default: 'error'}
    },
    computed: {
        btnClass() {
            return `btn-${this.popUpClass}`;
        },
        popUpInnerClass(){
            return `pop-up-inner-${this.popUpClass}`;
        }
    },
    methods:{
        close(){
            this.$emit('close')            
        },
        deleteItem(){
            this.$emit('deleteItem')
        }
    }
}
</script>

<style scoped>
    h2{
        margin-top: 0;
    }

    .pop-up{
        position: fixed;
        top: 0;
        left: 0;
        z-index: 10;
        padding: 32px 16px 120px;
        height: 100vh;
        width: 100%;
        background-color: rgba(116, 116, 116, 0.5);
        display: grid;
        place-items: center;
    }

    .pop-up-inner{
        background-color: rgb(245, 47, 47);
        color: white;
        position: relative;
        width: 380px;
        padding: 30px;
        border-radius: 5px;
        box-shadow: 0 5px 5px rgba(0, 0, 0, 0.2);
        display: flex;
        flex-direction: column;
        align-items: center
    }

    #buttons-confirm{
        width: 85%;
        display: flex;
        justify-content: space-around;
    }

    .btn{
        background-color: white;
        color: rgb(245, 47, 47);
        padding: 8px 25px;
        border: none;
        border-radius: 5px;
        font-size: large;
        font-weight: 600;
    }
    
    .btn:hover{
        cursor: pointer;
    }

    @media only screen and (max-width: 900px) {
        .pop-up{
            position: fixed;
            top: 0;
            left: 0;
            z-index: 10;
            padding: 32px 16px;
            height: 100vh;
            width: 100%;
            background-color: rgba(116, 116, 116, 0.5);
            display: grid;
            place-items: center;
        }
    
        .pop-up-inner{
            width: 90%;
            padding: 20px;

        }
    
        #buttons-confirm{
            display: flex;
            flex-direction: column;
            align-items: center;
        }
    
        .btn{
            width: 100%;
            margin: 10px;
        }
    }
</style>