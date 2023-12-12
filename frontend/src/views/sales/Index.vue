<template>
    <Header>
        <template #btnAdd>
            <router-link to="/sales-form" tag="button" class="btn-add">Adicionar</router-link>
        </template>
    </Header>

    <div id="main">
        <div id="header">
            <h1>Lista de vendas</h1>
            <InputSearch/>
        </div>
        
        <table>
            <thead>
                <tr>
                    <th class="tg-0lax column-header-table">Cliente</th>
                    <th class="tg-0lax column-header-table">Qtd. itens</th>
                    <th class="tg-0lax column-header-table">Data da venda</th>
                    <th class="tg-0lax column-header-table">Data faturamento</th>
                    <th class="tg-0lax column-header-table">Valor total</th>
                    <th class="tg-0lax column-header-table">Ações</th>
                </tr>
            </thead>
            <tbody>
                <tr class="list-table">
                    <td class="tg-0lax column-list-table first-td">Genara Souza</td>
                    <td class="tg-0lax column-list-table">1</td>
                    <td class="tg-0lax column-list-table">14/05/2022</td>
                    <td class="tg-0lax column-list-table">14/05/2022</td>
                    <td class="tg-0lax column-list-table">R$ 90,00</td>
                    <td class="tg-0lax column-list-table last-td">
                        <ButtonTable classBtn="delete" textButton="Deletar"/>
                        <ButtonTable classBtn="edit" textButton="Editar"/>
                    </td>
                </tr>
                <tr class="list-table">
                    <td class="tg-0lax column-list-table first-td">Genara Souza</td>
                    <td class="tg-0lax column-list-table">5</td>
                    <td class="tg-0lax column-list-table">14/05/2022</td>
                    <td class="tg-0lax column-list-table">14/05/2022</td>
                    <td class="tg-0lax column-list-table">R$ 450,00</td>
                    <td class="tg-0lax column-list-table last-td">
                        <ButtonTable classBtn="delete" textButton="Deletar"/>
                        <ButtonTable classBtn="edit" textButton="Editar"/>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import InputSearch from '@/components/InputSearch.vue'
import ButtonTable from '@/components/ButtonTable.vue'
import Header from '@/layouts/Header.vue'
    export default{
        props: {
            text: String
        },
        components:{
            InputSearch,
            ButtonTable,
            Header
        }
    }
</script>

<style scoped>
#main{
    margin-top: 50px;
    display: flex;
    flex-direction: column;
}

#header{
    display: flex;
    justify-content: space-between;
    align-items: center;
}

h1{
    color: #26324B;
    font-weight: 500;
    margin-bottom: 0;
}

table{
    margin-top: 30px;
    border-spacing: 0 15px;
}

.column-header-table{
    text-align: left;
    font-weight: 400;
    font-size: large;
    color: #767a7e;
}

.list-table{
    background-color: white;
}

.column-list-table{
    font-weight: 500;
    color: #26324B;
    padding: 10px;
    text-align: left;
}

.first-td{
    border-top-left-radius: 5px;
    border-bottom-left-radius: 5px;
}

.last-td{
    border-top-right-radius: 5px;
    border-bottom-right-radius: 5px;
    width: 250px;
}
</style>