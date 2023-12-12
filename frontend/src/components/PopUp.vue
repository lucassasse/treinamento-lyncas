<template>
    <div class="pop-up">
        <div class="pop-up-inner" :class="popUpInnerClass">
            <h2>{{message}}</h2>
            <button class="btn" :class="btnClass" @click="close()">Ok</button>
        </div>
    </div>
</template>

<script>
export default {
    props:{
        message: {type: String, default: ""},
        popUpClass: {type: String, default: 'error'},
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
        color: white;
        position: relative;
        width: 25%;
        padding: 30px;
        border-radius: 5px;
        box-shadow: 0 5px 5px rgba(0, 0, 0, 0.2);
    }

    .pop-up-inner-sucess{
        background-color: #03C874;
    }

    .pop-up-inner-error{
        background-color: rgb(245, 47, 47);
    }

    .btn{
        background-color: white;
        padding: 8px 25px;
        border: none;
        border-radius: 5px;
        font-size: large;
        font-weight: 600;
    }
    
    .btn-sucess{
        color: #03C874;
    }

    .btn-error{
        color: rgb(245, 47, 47);
    }

    .btn:hover{
        cursor: pointer;
    }
</style>