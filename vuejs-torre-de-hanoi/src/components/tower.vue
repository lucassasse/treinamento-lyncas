<template>
    <div class="tower" @click="$emit('movePiece')">
        <div v-for="piece in quantityPiecesInTower" :key="piece">
            <p class="piece">{{piece}}</p>
        </div>
    </div>
</template>


<script>
export default {
    props: {
        quantityPiecesInTower: { type: Array },
    }
}
</script>


<style>
.tower{
    display: flex;
    flex-direction: column-reverse;
    min-height: 202px;
    width: 35px;
    padding: 5px;
    margin: 10px;
    border: 1px solid gray;
    border-radius: 2px;
}

.piece{
    margin: 10px;
}

.tower:hover{
    cursor: pointer;
}
</style>