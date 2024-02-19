<template>
    <Header>
        <template #btnAdd>
            <router-link to="/sales-form" tag="button" class="btn-add btn-add-web">Adicionar</router-link>
            <router-link to="/sales-form" tag="button" class="btn-add btn-add-mobile">+</router-link>
        </template>
    </Header>

    <div id="main">
        <div id="header">
            <h1>Lista de vendas</h1>
            <InputSearch/>
        </div>
        
        <div id="table-div">
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
                <tbody v-if="sales.length">
                    <tr v-for="(sale) in sales" :key="sale.id"  class="list-table">
                        <td class="tg-0lax column-list-table first-td">{{ sale.name }}</td>
                        <td class="tg-0lax column-list-table">{{ sale.quantity }}</td>
                        <td class="tg-0lax column-list-table">{{ sale.saleDate }}</td>
                        <td class="tg-0lax column-list-table">{{ sale.billingDate }}</td>
                        <td class="tg-0lax column-list-table">{{ sale.totalValueItem }}</td>
                        <td class="tg-0lax column-list-table last-td">
                            <ButtonTable classBtn="delete" textButton="Deletar" @click="togglePopUp()"/>
                            <ButtonTable classBtn="edit" textButton="Editar" @click="redirectToUpdate(sale.id)"/>
                        </td>
                    </tr>
                </tbody>
                <tbody v-if="!sales.length">
                    <tr class="list-table">
                        <td colspan="6" class="tg-0lax column-list-table first-td last-td nullAlert">Nenhuma venda foi cadastrada!</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <Transition>
            <PopUpDelete v-if="showPopUpDelete" @close="togglePopUp()" @deleteItem="deleteConfirm()"/>
        </Transition>
    </div>
</template>

<script>
import InputSearch from '@/components/InputSearch.vue'
import ButtonTable from '@/components/ButtonTable.vue'
import Header from '@/layouts/Header.vue'
import PopUpDelete from '@/components/PopUpDelete.vue'
    export default{
        props: {
            text: String,
        },
        components:{
            InputSearch,
            ButtonTable,
            Header,
            PopUpDelete
        },
        data(){
            return{
                showPopUpDelete: false,
                sales:[]
            }
        },
        methods:{
            deleteConfirm(){
                console.log("Item excluído com sucesso!")
                this.togglePopUp()
            },
            togglePopUp(){
                this.showPopUpDelete = !this.showPopUpDelete
            },
            getSales(){
                this.sales =[{
                    id: 9,
                    name: 'Genara Souza',
                    quantity: '5',
                    saleDate: '18/09/2023',
                    billingDate: '19/09/2023',
                    totalValueItem: 'R$ 450,00'
                },{
                    id: 19,
                    name: 'Pedro Pedrinho',
                    quantity: '7',
                    saleDate: '27/10/2023',
                    billingDate: '28/10/2023',
                    totalValueItem: 'R$ 39,50'
                }]
            },
            redirectToUpdate(SaleId){
                this.$router.push({path: '/sales-form', query: {key: SaleId}})
            }
        },
        created(){
            this.getSales()
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
    width: 100%;
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

.nullAlert{
    color: red;
    text-align: center;
}

@media only screen and (max-width: 900px) {
    #main{
        margin: 0;
    }

    #header{
        margin-top: 15px;
        flex-direction: column-reverse;
    }
    
    #table-div{
        overflow: auto;
        margin: 0 15px;
    }

    table{
        margin-top: 0;
    }

    .column-list-table{
        min-width: 150px;
    }

    .last-td{
        max-width: 250px;
    }
}
</style>