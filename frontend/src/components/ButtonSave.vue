<template>
    <button id="btn-save">
        Salvar
    </button>
</template>

<script>
export default {
    props: {
        text: { type: String },
    },
    data(){
        return{
            btnText: this.text
        }
    }
}
</script>

<style scoped>
    #btn-save{
        background-color: #03C874;
        color: white;
        padding: 8px 25px;
        border: none;
        border-radius: 5px;
        font-size: large;
        font-weight: 600;
    }

    #btn-save:hover{
        cursor: pointer;
        background-color: #049b5a;
    }
</style>