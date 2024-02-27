<template>
    <Header>
        <template #btnAdd>
            <router-link to="/sales" tag="button" class="btn-back btn-return-web">Voltar</router-link>
            <router-link to="/sales" tag="button" class="btn-back btn-return-mobile">&lsaquo;</router-link>
        </template>
    </Header>

    <div id="div-main">
        <form>
            <h1>Adicionar venda</h1>
            <div class="form" id="form-top">
                <div class="div-left">
                    <InputSelect id="selectCustomer" label-for="selectCustomer" text-label="Cliente" v-model="sale.customer" ref="saleCustomer" :customers="customers" required/>
                </div>
                <div class="div-right">
                    <InputDate id="date" label-for="date" text-label="Data de faturamento" v-model="sale.billingDate" ref="saleBillingDate" required/>
                </div>
            </div>

            <h2 id="title">Itens do pedido</h2>
            <div id="form-bottom">
                <div action="send" class="form">
                    <div class="div-left">
                        <InputText id="description" label-for="description" text-label="Descrição do item" v-model="item.description" ref="itemDescription" required/>
                        <InputMask id="quantity" label-for="quantity" text-label="Quantidade" v-model="item.quantity" ref="itemQuantity" mask="#############" required/>
                    </div>
                    <div class="div-right">
                        <InputMoney id="unityValue" label-for="unityValue" text-label="Valor unitário" v-model="item.unityValue" ref="itemUnityValue" required/>
                        <label id="label-form" for="totalValue">Valor total</label>
                        <input id="totalValue" type="text" class="input-form" :value="totalValueLocal" disabled>
                    </div>
                </div>
                <div id="div-btn">
                    <button id="btn-add-item" @click.prevent="addItem()">Adicionar Itens</button>
                </div>
            </div>
        </form>

        <div id="div-table-items" v-if="itemsList.length > 0">
            <table>
                <thead>
                    <tr>
                        <th class="tg-0lax column-header-table">Descrição</th>
                        <th class="tg-0lax column-header-table">Valor Unitário</th>
                        <th class="tg-0lax column-header-table">Quantidade</th>
                        <th class="tg-0lax column-header-table">Valor Total</th>
                        <th class="tg-0lax column-header-table">Ações</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(item) in itemsList" :key="item.id" class="list-table">
                        <td class="tg-0lax column-list-table first-td">{{item.description}}</td>
                        <td class="tg-0lax column-list-table">{{item.unityValue}}</td>
                        <td class="tg-0lax column-list-table">{{item.quantity}}</td>
                        <td class="tg-0lax column-list-table last-td">{{item.totalValueItem}}</td>
                        <td class="tg-0lax column-list-form last-td">
                            <ButtonTable classBtn="delete" textButton="Deletar" @click="togglePopUpDelete(item)"/>
                            <ButtonTable classBtn="edit" textButton="Editar" @click="toEditItem(item)"/>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        
        <div id="total-and-save">
            <p id="total-value">Total: {{ finalValue || "R$ 0,00" }}</p>
            <ButtonSave @click.prevent="sendForm()"/>
        </div>
        <Transition>
            <pop-up v-if="popUp" @close="togglePopUpSucess()" :message="messagePopUp" :popUpClass="popUpSucessOrError"/>
        </Transition>
        <Transition>
            <PopUpDelete v-if="showPopUpDelete" @close="togglePopUpDelete()" @deleteItem="deleteConfirm()"/>
        </Transition>
    </div>
</template>

<script>
import InputText from '@/components/InputText.vue'
import InputMask from '@/components/InputMask.vue'
import InputSelect from '@/components/InputSelect.vue'
import InputDate from '@/components/InputDate.vue'
import InputMoney from '@/components/InputMoney.vue'
import Header from '@/layouts/Header.vue'
import ButtonSave from '@/components/ButtonSave.vue'
import ButtonTable from '@/components/ButtonTable.vue'
import PopUp from '@/components/PopUp.vue'
import PopUpDelete from '@/components/PopUpDelete.vue'
import { Sale } from '@/models/Sale'
import { Item } from '@/models/Item'

    export default{
        emits: ['input-change'],
        components:{
            InputText,
            InputMask,
            InputSelect,
            InputDate,
            InputMoney,
            Header,
            ButtonSave,
            ButtonTable,
            PopUp,
            PopUpDelete
        },
        data(){
            return{
                customers: [],
                sale: new Sale({ item: []}),
                item: {
                    id: null,
                    description: '',
                    quantity: '',
                    unityValue: '',
                    totalValueItem: ''
                },
                finalValue: '',
                itemsList: [{
                    id: 8,
                    description: 'retfhreh rewg wergrwegewg',
                    quantity: '534,00',
                    unityValue: '534,00',
                    totalValueItem: '5435,00'
                },{
                    id: 9,
                    description: 'ewrg rwegerwg rwet',
                    quantity: '534,00',
                    unityValue: '54353,00',
                    totalValueItem: '534534,00'
                },],
                index: '',
                popUp: false,
                popUpSucessOrError: 'sucess',
                messagePopUp: '',
                popUpRedirect: false,
                showPopUpDelete: false,
                inEddit: false
            }
        },
        computed:{
            totalValueLocal: function(){
                this.item.totalValueItem = (this.item.quantity * this.item.unityValue.replace(/[\"R$"\","\"."]/g, '') / 100)
                    .toLocaleString('pt-br',{style: 'currency', currency: 'BRL'})
                return this.item.totalValueItem
            }
        },
        methods:{
            addItem(){
                this.validateItems()
                if(this.$refs.itemDescription.valid() && this.$refs.itemQuantity.valid() && this.$refs.itemUnityValue.valid()){
                    this.popUpSucessOrError = 'sucess'
                    this.togglePopUpSucess("Item adicionado com sucesso!")
                    this.item.unityValue = Number(this.item.unityValue).toLocaleString('pt-br',{style: 'currency', currency: 'BRL'})
                    let item = Object.assign({}, this.item)
                    this.itemsList.push(item)
                    this.sumListTotalValue()
                    this.clearInputs()
                    this.inEddit = false
                }else{
                    return
                }
            },
            validateItems() {
                this.$refs.itemDescription.valid()
                this.$refs.itemQuantity.valid()
                this.$refs.itemUnityValue.valid()
            },
            validadeSale(){
                this.$refs.saleCustomer.valid()
                this.$refs.saleBillingDate.valid()
            },
            sendForm(){
                if(!this.itemsList.length){
                    this.popUpSucessOrError = 'error'
                    this.togglePopUpSucess("Adicione pelo menos um item...")
                    return
                }

                this.validadeSale()
                if(this.$refs.saleCustomer.valid() && this.$refs.saleBillingDate.valid()){
                    this.popUpSucessOrError = 'sucess'
                    this.togglePopUpSucess("Formulário enviado com sucesso!")
                    this.popUpRedirect = false
                    this.clearAll()
                }else{
                    return
                }
            },
            clearInputs(){
                this.item = {
                    description: '',
                    quantity: '',
                    unityValue: '',
                    totalValueItem: '' ,
                }
            },
            clearAll(){
                this.clearInputs()
                this.itemsList = []
                this.finalValue = ''
                this.sale = {
                    customer: '',
                    billingDate: ''
                }
            },
            sumListTotalValue(){
                this.finalValue = 0
                this.itemsList.map((item) =>{
                    let itemTemp = item.totalValueItem.replace(/[\"R$"\"."]/g, '')
                    itemTemp = itemTemp.replace(/[\","]/g, '.')
                    this.finalValue += Number(itemTemp)
                })
                this.finalValue = this.finalValue.toLocaleString('pt-br',{style: 'currency', currency: 'BRL'})
            },
            togglePopUpSucess(messagePopUp) {
                if(this.popUpRedirect) this.$router.push('/sales')
                this.messagePopUp = messagePopUp
                this.popUp = !this.popUp
            },
            deleteConfirm(){
                this.itemsList.splice(this.id, 1)
                this.togglePopUpDelete()
            },
            togglePopUpDelete(item){
                if (item)
                    this.id = this.itemsList.indexOf(item)
                this.showPopUpDelete = !this.showPopUpDelete
            },
            getCustomers(){
                this.customers = [{
                    id: 1,
                    full_name: 'Cliente n. 1'
                },{
                    id: 2,
                    full_name: 'Nome do 2º Cliente'
                },{
                    id: 3,
                    full_name: 'Terceiro Cliente'
                }]
            },
            toEditItem(item){
                if(!this.inEddit){
                    this.item.description = item.description
                    this.item.quantity = item.quantity
                    this.item.unityValue = item.unityValue
                    this.item.totalValueItem = item.totalValueItem
                    this.itemsList.splice(this.id, 1)
                    this.inEddit = true
                }
                else{
                    alert("Já há um item em edição")
                }
            },
            fetchSaleData() {
                if (!this.$route.query.key){
                    return
                } else {
                    // axios.get(`url_da_api/${SaleId}`)
                    //     .then(response => {
                    //         this.sale.name = response.data.name
                    //         this.sale.email = response.data.email
                    //         this.sale.tel = response.data.tel
                    //         this.sale.cpf = response.data.cpf
                    //     })
                    //     .catch(error => {
                    //         console.error('Erro ao buscar dados da venda:', error)
                    //     })
                }
            }
        },
        created(){
            this.getCustomers()
            this.fetchSaleData()
        }
    }
</script>

<style scoped>
    #div-main{
        background-color: white;
        margin-top: 50px;
        border: 1px solid #E5EBF1;
        border-radius: 5px;
        padding: 10px 35px;
    }

    #title{
    font-weight: 600;
    }

    .form{
        display: flex;
        justify-content: space-between;
    }
    
    #form-top{
        border-bottom: 1px dashed #E5EBF1;
    }

    .div-left,
    .div-right{
        width: 49%;
    }

    #form-bottom{
        display: flex;
        flex-direction: column;
        border-bottom: 1px dashed #E5EBF1;
    }

    #div-btn{
        padding-bottom: 15px;
        display: flex;
        flex-direction: row-reverse
    }

    #btn-add-item{
        font-weight: 700;
        font-size: large;
        background-color: white;
        color: #274A9D;
        border: 1px solid #274A9D;
        border-radius: 5px;
        padding: 10px 30px;
    }

    #btn-add-item:hover{
        cursor: pointer;
        color: #203c7e;
        border: 1px solid #203c7e;
    }

    #total-and-save{
        margin-top: 15px;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    #total-value{
        font-size:xx-large;
        font-weight: 700;
    }

    table{
        margin-top: 30px;
        border-spacing: 0 15px;
        width: 100%;
    }
    
    .column-header-table{
        text-align: left;
        font-weight: 400;
        font-size: large;
        color: #767a7e;
    }
    
    .list-table{
        background-color: #f8f8f8;
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

    .input-form{
        border: 1px solid #E5EBF1;
        border-radius: 6px;
        font-size: large;
        padding: 10px 15px;
        width: 100%;
        margin-bottom: 25px;
        font-family: 'Jost', sans-serif;
    }

    @media only screen and (max-width: 900px) {
        #form-top{
            display: flex;
            flex-direction: column;
            width: 100%;
        }

        #div-main{
            margin-top: 25px;
            padding: 0 20px 10px;
        }

        #div-table-items{
            overflow: auto;
            margin: 0 10px;
        }

        .form{
            flex-direction: column;
        }

        table{
            margin: 0;
        }

        .div-left,
        .div-right{
            width: 100%;
        }
        
        .column-list-table{
            min-width: 150px;
        }

        #total-and-save{
            margin-top: 10px;
            display: flex;
            flex-direction: column;
        }

        #total-value{
            font-size: x-large;
            font-weight: 600;
        }

        #btn-add-item{
            width: 100%;
        }
    }
</style>