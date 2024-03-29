<template>
    <Header>
        <template #btnAdd>
            <router-link to="/sales-form" tag="button" class="btn-add">{{ txtButtonAdd }}</router-link>
        </template>
    </Header>

    <div id="main">
        <div id="header">
            <h1>Lista de vendas</h1>
            <InputSearch v-model="searchTerm" @search-clicked="fetchSales"/>
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
                
                <tbody v-if="displayedSales.length">
                    <tr v-for="sale in displayedSales" :key="sale.id"  class="list-table">
                        <td class="tg-0lax column-list-table first-td">{{ sale.fullName }}</td>
                        <td class="tg-0lax column-list-table">{{ sale.saleTotalItems }}</td>
                        <td class="tg-0lax column-list-table">{{ sale.saleDate }}</td>
                        <td class="tg-0lax column-list-table">{{ sale.billingDate }}</td>
                        <td class="tg-0lax column-list-table">{{ mountMoneyMask(sale.saleTotalValue) }}</td>
                        <td class="tg-0lax column-list-table last-td">
                            <ButtonTable classBtn="delete" textButton="Deletar" @click="togglePopUpDelete(sale.id)"/>
                            <ButtonTable classBtn="edit" textButton="Editar" @click="redirectToUpdate(sale.id)"/>
                        </td>
                    </tr>
                </tbody>
                <tbody v-if="!displayedSales.length">
                    <tr class="list-table">
                        <td colspan="6" class="tg-0lax column-list-table first-td last-td nullAlert">Nenhuma venda foi encontrada!</td>
                    </tr>
                </tbody>
            </table>
        </div>

        <Pagination :totalPages="totalPages" :currentPage="currentPage" :prevPage="prevPage" :nextPage="nextPage" :gotoPage="gotoPage" />

        <Transition>
            <PopUpDelete v-if="showPopUpDelete" @close="togglePopUpDelete()" @deleteItem="deleteConfirm()" :itemId="saleToDeleteId"/>
        </Transition>
    </div>
</template>

<script>
import InputSearch from '@/components/InputSearch.vue'
import ButtonTable from '@/components/ButtonTable.vue'
import Header from '@/layouts/Header.vue'
import PopUpDelete from '@/components/PopUpDelete.vue'
import SaleService from "@/common/service/sale.service"
import Pagination from '@/components/Pagination.vue'

    export default{
        components:{
            InputSearch,
            ButtonTable,
            Header,
            PopUpDelete,
            Pagination
        },
        
        data(){
            return{
                showPopUpDelete: false,
                sales: [],
                saleToDeleteId: null,
                itemsPerPage: 5,
                currentPage: 1,
                totalPages: null,
                searchTerm: '',
            }
        },

        computed:{
            txtButtonAdd(){ return window.innerWidth < 500 ? '+' : 'Adicionar'; },

            displayedSales() {
                const start = (this.currentPage - 1) * this.itemsPerPage;
                const end = start + this.itemsPerPage;
                return this.sales.slice(start, end);
            }
        },

        methods:{

            mountMoneyMask(saleTotalValue){
                return saleTotalValue.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' })
            },

            togglePopUpDelete(saleId){
                this.saleToDeleteId = saleId
                this.showPopUpDelete = !this.showPopUpDelete
            },

            async fetchSales() {
                await SaleService.search()
                    .then(response => {
                        this.sales = response.filter(sale => {
                            const fieldsToSearch = ['fullName', 'saleTotalItems', 'saleDate', 'billingDate', 'saleTotalValue']

                            return fieldsToSearch.some(field => {
                                const value = String(sale[field]).toLowerCase()
                                return value.includes(this.searchTerm.toLowerCase())
                            })
                        })
                        this.totalPages = Math.ceil(this.sales.length / this.itemsPerPage)
                    })

                    .catch(e => {
                        console.error(`Erro ao buscar vendas: ${e.message}`)
                    });
            },

            async deleteConfirm(){
                await SaleService.delete(this.saleToDeleteId)
                .then(() => {
                    this.saleToDeleteId = null
                    this.togglePopUpDelete()
                    this.fetchSales()
                }).catch((error) => {
                    console.error(`Erro ao deletar venda: ${error.message}`)
                })
            },

            redirectToUpdate(SaleId){
                this.$router.push({name: 'sales-form', params: {id: SaleId}})
            },
            
            prevPage() {
                if (this.currentPage > 1) {
                    this.currentPage--;
                }
            },

            nextPage() {
                if (this.currentPage < this.totalPages) {
                    this.currentPage++;
                }
            },

            gotoPage(page) {
                if (page >= 1 && page <= this.totalPages) {
                    this.currentPage = page;
                }
            }
        },

        mounted(){
            this.fetchSales()
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