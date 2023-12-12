<template>
    <button id="btn-component" :class="classButton">
        {{ textButton }}
    </button>
</template>

<script>
export default {
    props: {
        classBtn: { type: String, default: '' },
        textButton: { type: String, default: '' }
    },
    computed:{
        classButton(){
            return this.classBtn == 'delete' ? 'btn-component-delete' : 'btn-component-edit'
        }
    }
}
</script>

<style scoped>
    #btn-component{
        font-weight: 600;
        padding: 10px 25px;
        margin: 5px;
        border-radius: 5px;
    }
    .btn-component-delete{
        background-color: #FDF6F6;
        color: #C27476;
        border: 2px solid #F7EEEE;
    }

    .btn-component-edit {
        background-color: #F6FAFD;
        color: #5B89C7;
        border: 2px solid #F1F4F9;
    }

    #btn-component:hover{
        cursor: pointer;
    }

    .btn-component-delete:hover{
        background-color: rgb(241, 216, 216);
        color: #b66265;
        border: 2px solid #e4cdcd;
    }

    .btn-component-edit:hover{
        background-color: #dbe9f3;
        color: #4a79b6;
        border: 2px solid #d3dbe9;
    }
</style>