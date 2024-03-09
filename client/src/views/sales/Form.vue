<template>
    <div>
        <Header>
            <template #btnAdd>
                <router-link to="/sales" tag="button" class="btn-back">{{ txtButtonAdd }}</router-link>
            </template>
        </Header>

        <div id="div-main">
            <form>

                <h1>{{ CreateOrEdit }}</h1>

                <div class="form" id="form-top">

                    <div class="div-left">
                        <InputSelect id="selectCustomer" label-for="selectCustomer" text-label="Cliente"
                            v-model="sale.customerId" ref="saleCustomer" :customers="customers" required />
                    </div>

                    <div class="div-right">
                        <InputDate id="date" label-for="date" text-label="Data de faturamento" v-model="sale.billingDate"
                            ref="saleBillingDate" required />
                    </div>

                </div>

                <h2 id="title">Itens do pedido</h2>

                <div id="form-bottom">
                    <div action="send" class="form">
                        <div class="div-left">

                            <InputText id="description" label-for="description" text-label="Descrição do item"
                                v-model="item.description" ref="itemDescription" required />

                            <InputMask id="quantity" label-for="quantity" text-label="Quantidade"
                                v-model="item.quantity" ref="itemQuantity" mask="#############" required />
                        </div>

                        <div class="div-right">
                            <InputMoney id="unityValue" label-for="unityValue" text-label="Valor unitário"
                                v-model="item.unityValue" ref="itemUnityValue" required />

                            <label id="label-form" for="totalValue">Valor total</label>
                            <input id="totalValue" type="text" class="input-form" :value="item.totalValue" disabled>
                        </div>

                    </div>

                    <div id="div-btn">
                        <button id="btn-add-item" @click.prevent="addItem()">Adicionar Itens</button>
                    </div>

                </div>

            </form>

            <div id="div-table-items" v-if="sale.saleItems.length && showItens">
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
                        <tr v-for="(item, index) in sale.saleItems" :key="index" class="list-table">
                            <td class="tg-0lax column-list-table first-td">{{ item.description }}</td>
                            <td class="tg-0lax column-list-table">{{ item.unityValue }}</td>
                            <td class="tg-0lax column-list-table">{{ item.quantity }}</td>
                            <td class="tg-0lax column-list-table last-td">{{ item.totalValue }}</td>
                            <td class="tg-0lax column-list-form last-td">
                                <ButtonTable classBtn="delete" textButton="Deletar" @click="togglePopUpDelete(index)" />
                                <ButtonTable classBtn="edit" textButton="Editar" @click="toEditItem(index)"/>
                            </td>
                        </tr>
                    </tbody>

                </table>
            </div>

            <div id="total-and-save">
                <p id="total-value">Total: {{ sale.saleTotalValue || "R$ 0,00" }}</p>
                <ButtonSave @click.prevent="sendForm()" />
            </div>

            <Transition>
                <pop-up v-if="popUp" @close="togglePopUpSucess()" :message="messagePopUp" :popUpClass="popUpSucessOrError" />
            </Transition>

            <Transition>
                <PopUpDelete v-if="showPopUpDelete" @close="togglePopUpDelete()" @deleteItem="deleteConfirm()"/>
            </Transition>

        </div>
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
import helpers from '@/common/helpers'
import SaleService from '@/common/service/sale.service'
import CustomerService from '@/common/service/customer.service'
import { Sale } from '@/models/Sale'
import { Item } from '@/models/Item'

export default {
    emits: ['input-change'],

    components: {
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

    data() {
        return {
            customers: [],
            sale: new Sale({ customerName: null, saleItems: [] }),
            item: new Item({}),
            popUp: false,
            popUpSucessOrError: 'sucess',
            messagePopUp: '',
            popUpRedirect: false,
            showPopUpDelete: false,
            itemInEddit: false,
            isEdit: false,
            currentId: null,
            indexToDelete: null,
            showItens: true
        }
    },

    computed: {
        txtButtonAdd(){ return window.innerWidth < 500 ? '<<' : 'Voltar' },

        CreateOrEdit() { return !this.isEdit ? 'Adicionar venda' : 'Editar venda' },
    },

    methods: {

        addItem() {
            this.validateItems()
            if (this.$refs.itemDescription.valid() && this.$refs.itemQuantity.valid() && this.$refs.itemUnityValue.valid()) {

                this.item = new Item({
                    description: this.item.description,
                    quantity: this.item.quantity,
                    unityValue: this.item.unityValue,
                    totalValue: this.item.totalValue
                })
                
                this.sale.saleItems.push(this.item)
                this.sale.saleTotalItems = this.sale.saleItems.length
                
                this.popUpSucessOrError = 'sucess'
                this.togglePopUpSucess("Item adicionado com sucesso!")
                this.clearInputs()
                this.itemInEddit = false

                this.finalValue()
            } else {
                return
            }
        },

        validateItems() {
            this.$refs.itemDescription.valid()
            this.$refs.itemQuantity.valid()
            this.$refs.itemUnityValue.valid()
        },

        async createSale() {
            await this.convertSendTypeValues()
            try {
                await SaleService.create(this.sale)
                this.popUpSucessOrError = 'sucess'
                this.togglePopUpSucess("Formulário enviado com sucesso!")
                this.popUpRedirect = true
            } catch (error) {
                console.error('Error adding sale:', error.message)
            }
        },

        async updateSale() {
            this.convertSendTypeValues()
            try {
                await SaleService.edit(this.currentId, this.sale)
                this.popUpSucessOrError = 'sucess'
                this.togglePopUpSucess("Formulário atualizado com sucesso!")
                this.popUpRedirect = true
            } catch (error) {
                console.error('Error updating sale:', error.message)
            }
        },

        validateItems() {
            this.$refs.itemDescription.valid()
            this.$refs.itemQuantity.valid()
            this.$refs.itemUnityValue.valid()
        },

        validadeSale() {
            this.$refs.saleCustomer.valid()
            this.$refs.saleBillingDate.valid()
        },

        async convertSendTypeValues(){
            this.sale.saleTotalItems = Number(this.sale.saleTotalItems)
            this.sale.customerId = parseInt(this.sale.customerId)
            this.sale.saleDate = new Date().toISOString()
            this.sale.saleTotalValue = Number(this.sale.saleTotalValue.replace(/[\"R$"\"."]/g, '').replace(/[\"R$"\","]/g, '.'))

            for (let i = 0; i < this.sale.saleItems.length; i++) {
                const currentItem = this.sale.saleItems[i]
                currentItem.quantity = parseInt(currentItem.quantity)
                currentItem.unityValue = Number(currentItem.unityValue.replace(/[\"R$"\"."]/g, '').replace(/[\"R$"\","]/g, '.'))
                currentItem.totalValue = Number(currentItem.totalValue.replace(/[\"R$"\"."]/g, '').replace(/[\"R$"\","]/g, '.'))
            }
        },

        convertReceivedTypeValues(){
            this.sale.saleTotalValue = this.sale.saleTotalValue.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' })
            this.sale.billingDate = helpers.revertDate(this.sale.billingDate)

            for (let i = 0; i < this.sale.saleItems.length; i++) {
                const currentItem = this.sale.saleItems[i]
                currentItem.unityValue = currentItem.unityValue.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' })
                currentItem.totalValue = currentItem.totalValue.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' })
            }
        },

        sendForm() {
            if (!this.sale.saleItems.length) {
                this.popUpSucessOrError = 'error'
                this.togglePopUpSucess("Adicione pelo menos um item...")
                return
            }

            if(this.itemInEddit){
                this.popUpSucessOrError = 'error'
                this.togglePopUpSucess("Há um item em edição...")
                return
            }

            this.validadeSale()
            if (this.$refs.saleCustomer.valid() && this.$refs.saleBillingDate.valid()) {
                this.showItens = false
                this.isEdit ? this.updateSale() : this.createSale()
            } else {
                return
            }
        },

        finalValue() {
            let sum = 0

            for (let i = 0; i < this.sale.saleItems.length; i++) {
                const currentItem = this.sale.saleItems[i]
                sum += Number(currentItem.totalValue.replace(/[\"R$"\"."]/g, '').replace(/[\"R$"\","]/g, '.'))
            }

            this.sale.saleTotalValue = sum.toLocaleString('pt-br', { style: 'currency', currency: 'BRL' })
        },

        clearInputs() {
            this.item = new Item({})
        },

        togglePopUpSucess(messagePopUp) {
            if (this.popUpRedirect) this.$router.push('/sales')
            this.messagePopUp = messagePopUp
            this.popUp = !this.popUp
        },

        deleteConfirm() {
            this.sale.saleItems.splice(this.indexToDelete, 1)
            this.togglePopUpDelete()
            this.finalValue()
        },

        togglePopUpDelete(index) {
            if (index >= 0)
                this.indexToDelete = index
            this.showPopUpDelete = !this.showPopUpDelete
        },

        calcTotalValueItems(){
            if (this.item.quantity && this.item.unityValue) {
                this.item.totalValue = (this.item.quantity * this.item.unityValue.replace(/[\"R$"\","\"."]/g, '') / 100)
                    .toLocaleString('pt-br', { style: 'currency', currency: 'BRL' })
                return this.item.totalValue
            } else {
                return ''
            }
        },

        toEditItem(index){
            if(!this.itemInEddit){
                this.itemInEddit = true

                this.item.description = this.sale.saleItems[index].description,
                this.item.quantity = this.sale.saleItems[index].quantity,
                this.item.unityValue = this.sale.saleItems[index].unityValue,
                this.item.totalValue = this.sale.saleItems[index].totalValue

                this.sale.saleItems.splice(index, 1)
            }
            else{
                alert("Já há um item em edição")
            }
        },

        async fetchSale(id) {
            await SaleService.searchById(id)
            .then(response => {
                this.sale = response
                this.convertReceivedTypeValues()
            }).catch((error) => {
                console.error(error)
            })
        },

        verifyCreateOrEditSale() {
            const currentId = this.$route.params.id

            if (currentId){
                this.isEdit = true
                this.currentId = currentId
                this.fetchSale(currentId)
            }
        },

        async fetchCustomers() {
            await CustomerService.search()
                .then(response => {
                    this.customers = response.map(customerData => ({ ...customerData }))
                })
        },
    },

    mounted() {
        this.fetchCustomers()
        this.verifyCreateOrEditSale()
    },

    watch: {
        "item.quantity"(){
            this.calcTotalValueItems()
        },
        "item.unityValue"(){
            this.calcTotalValueItems()
        }
    },
}
</script>


<style scoped>
#div-main {
    background-color: white;
    margin-top: 50px;
    border: 1px solid #E5EBF1;
    border-radius: 5px;
    padding: 10px 35px;
}

#title {
    font-weight: 600;
}

.form {
    display: flex;
    justify-content: space-between;
}

#form-top {
    border-bottom: 1px dashed #E5EBF1;
}

.div-left,
.div-right {
    width: 49%;
}

#form-bottom {
    display: flex;
    flex-direction: column;
    border-bottom: 1px dashed #E5EBF1;
}

#div-btn {
    padding-bottom: 15px;
    display: flex;
    flex-direction: row-reverse
}

#btn-add-item {
    font-weight: 700;
    font-size: large;
    background-color: white;
    color: #274A9D;
    border: 1px solid #274A9D;
    border-radius: 5px;
    padding: 10px 30px;
}

#btn-add-item:hover {
    cursor: pointer;
    color: #203c7e;
    border: 1px solid #203c7e;
}

#total-and-save {
    margin-top: 15px;
    display: flex;
    justify-content: space-between;
    align-items: center;
}

#total-value {
    font-size: xx-large;
    font-weight: 700;
}

table {
    margin-top: 30px;
    border-spacing: 0 15px;
    width: 100%;
}

.column-header-table {
    text-align: left;
    font-weight: 400;
    font-size: large;
    color: #767a7e;
}

.list-table {
    background-color: #f8f8f8;
}

.column-list-table {
    font-weight: 500;
    color: #26324B;
    padding: 10px;
    text-align: left;
}

.first-td {
    border-top-left-radius: 5px;
    border-bottom-left-radius: 5px;
}

.last-td {
    border-top-right-radius: 5px;
    border-bottom-right-radius: 5px;
    width: 250px;
}

.input-form {
    border: 1px solid #E5EBF1;
    border-radius: 6px;
    font-size: large;
    padding: 10px 15px;
    width: 100%;
    margin-bottom: 25px;
    font-family: 'Jost', sans-serif;
}

@media only screen and (max-width: 900px) {
    #form-top {
        display: flex;
        flex-direction: column;
        width: 100%;
    }

    #div-main {
        margin-top: 25px;
        padding: 0 20px 10px;
    }

    #div-table-items {
        overflow: auto;
        margin: 0 10px;
    }

    .form {
        flex-direction: column;
    }

    table {
        margin: 0;
    }

    .div-left,
    .div-right {
        width: 100%;
    }

    .column-list-table {
        min-width: 150px;
    }

    #total-and-save {
        margin-top: 10px;
        display: flex;
        flex-direction: column;
    }

    #total-value {
        font-size: x-large;
        font-weight: 600;
    }

    #btn-add-item {
        width: 100%;
    }
}
</style>