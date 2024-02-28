<template>
    <div id="div_input">
        <input type="text" id="input_search" placeholder="Buscar cliente...">
        <button id="btn_search">
            <font-awesome-icon class="icon" icon="fa-magnifying-glass" />
        </button>
    </div>
</template>

<style scoped>
#div_input{
    background-color: white;
    border: 1px solid #E5EBF1;
    border-radius: 5px;
    position: relative;
}

#div_input:focus-within{
    border: 1px solid black;
}

#input_search{
    padding: 10px 15px;
    width: 400px;
    border: none;
    font-size: medium;
    border-radius: 5px;
    font-family: 'Jost', sans-serif;
}

#input_search::placeholder{
    color: #abaeb1;
}

#btn_search{
    background: none;
    padding: 10px;
    border: none;
    position: absolute;
    right: 5px;
    top: 2px;
}
.icon{
    color: #abaeb1;
}

.icon:hover{
    cursor: pointer;
}

@media only screen and (max-width: 900px) {
    #input_search{
        width: 225px;
    }
}
</style>