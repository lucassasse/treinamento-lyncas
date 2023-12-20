<template>
    <Header id="header-top">
        <template #btnAdd>
            <router-link to="/customers-form" tag="button" class="btn-add btn-add-web">Adicionar</router-link>
            <router-link to="/customers-form" tag="button" class="btn-add btn-add-mobile">+</router-link>
        </template>
    </Header>

    <div id="main">
        <div id="header">
            <h1>Lista de clientes</h1>
            <InputSearch/>
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
                <tbody v-if="mokCustomers.length">
                    <tr v-for="(customer, index) in mokCustomers" :key="index" class="list-table">
                        <td class="tg-0lax column-list-table first-td">{{ customer.name }}</td>
                        <td class="tg-0lax column-list-table">{{ customer.email }}</td>
                        <td class="tg-0lax column-list-table">{{ customer.tel }}</td>
                        <td class="tg-0lax column-list-table">{{ customer.cpf }}</td>
                        <td class="tg-0lax column-list-table last-td">
                            <ButtonTable classBtn="delete" textButton="Deletar" @click="togglePopUp()"/>
                            <ButtonTable classBtn="edit" textButton="Editar"/>
                        </td>
                    </tr>
                </tbody>
    
                <tbody v-if="!mokCustomers.length">
                    <tr class="list-table">
                        <td colspan="5" class="tg-0lax column-list-table first-td last-td nullAlert">Nenhum cliente foi cadastrado!</td>
                    </tr>
                </tbody>
            </table>
        </div>
        <PopUpDelete v-if="showPopUpDelete" @close="togglePopUp()" @deleteItem="deleteConfirm()"/>
    </div>
</template>

<script>
import InputSearch from '@/components/InputSearch.vue'
import ButtonTable from '@/components/ButtonTable.vue'
import Header from '@/layouts/Header.vue'
import PopUpDelete from '@/components/PopUpDelete.vue'
    export default{
        props: {
            text: String
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
                mokCustomers:[{
                    name: 'Genara Souza',
                    email: 'genara7souza@gmail.com',
                    tel: '(91) 99844-3343',
                    cpf: '000.000.000-00'
                },{
                    name: 'Genara Souza',
                    email: 'genara7souza@gmail.com',
                    tel: '(91) 99844-3343',
                    cpf: '000.000.000-00'
                },{
                    name: 'Genara Souza',
                    email: 'genara7souza@gmail.com',
                    tel: '(91) 99844-3343',
                    cpf: '000.000.000-00'
                }]
            }
        },
        methods:{
            deleteConfirm(){
                console.log("Item excluído com sucesso!")
                this.togglePopUp()
            },
            togglePopUp(){
                this.showPopUpDelete = !this.showPopUpDelete
            }
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