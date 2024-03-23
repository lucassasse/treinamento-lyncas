<template>
    <Header id="header-top">
        <template #btnAdd>
            <router-link to="/customers-form" tag="button" class="btn-add">{{ txtButtonAdd }}</router-link>
        </template>
    </Header>

    <div id="main">
        <div id="header">
            <h1>Lista de clientes</h1>
            <InputSearch v-model="searchTerm" @search-clicked="searchCustomers"/>
        </div>

        <div id="table-div">
            <table class="tg">
                <thead>
                    <tr>
                        <th class="tg-0lax column-header-table">Nome</th>
                        <th class="tg-0lax column-header-table">E-mail</th>
                        <th class="tg-0lax column-header-table">Telefone</th>
                        <th class="tg-0lax column-header-table">CPF</th>
                        <th class="tg-0lax column-header-table">Ações</th>
                    </tr>
                </thead>

                <tbody v-if="customers.length">
                    <tr v-for="customer in customers" :key="customer.id" class="list-table">
                        <td class="tg-0lax column-list-table first-td">{{ customer.fullName }}</td>
                        <td class="tg-0lax column-list-table">{{ customer.email }}</td>
                        <td class="tg-0lax column-list-table">{{ customer.telephone }}</td>
                        <td class="tg-0lax column-list-table">{{ customer.cpf }}</td>
                        <td class="tg-0lax column-list-table last-td">
                            <ButtonTable classBtn="delete" textButton="Deletar" @click="togglePopUpDelete(customer.id)"/>
                            <ButtonTable classBtn="edit" textButton="Editar" @click="redirectToUpdate(customer.id)"/>
                        </td>
                    </tr>
                </tbody>
    
                <tbody v-if="!customers.length">
                    <tr class="list-table">
                        <td colspan="5" class="tg-0lax column-list-table first-td last-td nullAlert">Nenhum cliente foi encontrado!</td>
                    </tr>
                </tbody>
            </table>
        </div>

        <Pagination :totalPages="totalPages" :currentPage="currentPage" :prevPage="prevPage" :nextPage="nextPage" :gotoPage="gotoPage" />

        <Transition>
            <PopUpDelete v-if="showPopUpDelete" @close="togglePopUpDelete()" @deleteItem="deleteCustomer()" :itemId="customerToDeleteId"/>
        </Transition>
    </div>
</template>

<script>
import InputSearch from '@/components/InputSearch.vue'
import ButtonTable from '@/components/ButtonTable.vue'
import Header from '@/layouts/Header.vue'
import PopUpDelete from '@/components/PopUpDelete.vue'
import Pagination from '@/components/Pagination.vue'
import CustomerService from "@/common/service/customer.service"

    export default{
        props: {
            text: String
        },

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
                customers: [],
                customerToDeleteId: null,
                itemsPerPage: 5,
                currentPage: 1,
                totalPages: null,
                searchTerm: ''
            }
        },

        computed:{
            txtButtonAdd(){ return window.innerWidth < 500 ? '+' : 'Adicionar' }
        },

        methods:{
            togglePopUpDelete(customerId){
                this.customerToDeleteId = customerId
                this.showPopUpDelete = !this.showPopUpDelete
            },

            calcTotalPages(){
                let result = Math.ceil(this.totalItensInList / this.itemsPerPage)
                this.totalPages = result
            },

            gotoPage(page) {
                this.currentPage = page
                this.fetchCustomers()
            },

            prevPage() {
                if (this.currentPage > 1) {
                    this.currentPage--
                    this.fetchCustomers()
                }
            },

            nextPage() {
                if (this.currentPage < this.totalPages) {
                    this.currentPage++
                    this.fetchCustomers()
                }
            },

            mountObj(){
                return {
                    page: this.currentPage,
                    numberPerPage: this.itemsPerPage,
                    filter: this.searchTerm
                }
            },

            searchCustomers(){
                this.currentPage = 1
                this.fetchCustomers()
            },

            async fetchCustomers() {
                let obj = this.mountObj()
                await CustomerService.searchFiltred('pagination', obj)
                .then(response => {
                    this.totalItensInList = response.totalCount
                    this.calcTotalPages()
                    this.customers = response.data;
                }).catch((error) => {
                    console.error("Error when searching for customers: ", error)
                })
            },

            async deleteCustomer(){
                await CustomerService.delete(this.customerToDeleteId)
                .then(() => {
                    this.customerToDeleteId = null
                    this.togglePopUpDelete()
                    this.fetchCustomers()
                }).catch((error) => {
                    console.error("Error when deleting customer: ", error)
                })
            },
            
            redirectToUpdate(customerId){
                this.$router.push({name: 'customers-form', params: { id: customerId }})
            }
        },

        mounted(){
            this.fetchCustomers()
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