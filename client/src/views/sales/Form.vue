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
                            v-model="sale.fullName" ref="saleCustomer" :customers="customers" required />
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
                            <input id="totalValue" type="text" class="input-form" :value="item.totalValueItem" disabled>
                        </div>

                    </div>

                    <div id="div-btn">
                        <button id="btn-add-item" @click.prevent="addItem()">Adicionar Itens</button>
                    </div>

                </div>

            </form>

            <div id="div-table-items" v-if="sale.item.length > 0">
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
                        <tr v-for="(item, index) in sale.item" :key="index" class="list-table">
                            <td class="tg-0lax column-list-table first-td">{{ item.description }}</td>
                            <td class="tg-0lax column-list-table">{{ item.unityValue }}</td>
                            <td class="tg-0lax column-list-table">{{ item.quantity }}</td>
                            <td class="tg-0lax column-list-table last-td">{{ item.totalValueItem }}</td>
                            <td class="tg-0lax column-list-form last-td">
                                <ButtonTable classBtn="delete" textButton="Deletar" @click="togglePopUpDelete(index)" />
                                <ButtonTable classBtn="edit" textButton="Editar" @click="toEditItem(index, item)"/>
                            </td>
                        </tr>
                    </tbody>

                </table>
            </div>

            <div id="total-and-save">
                <p id="total-value">Total: {{ finalValue || "R$ 0,00" }}</p>
                <ButtonSave @click.prevent="sendForm()" />
            </div>

            <Transition>
                <pop-up v-if="popUp" @close="togglePopUpSucess()" :message="messagePopUp"
                    :popUpClass="popUpSucessOrError" />
            </Transition>

            <Transition>
                <PopUpDelete v-if="showPopUpDelete" @close="togglePopUpDelete()" @deleteItem="deleteConfirm()"
                    :itemId="index" />
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
import ApiService from '@/common/apiService'
import SaleService from '@/common/service/sale.service'
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
            sale: new Sale({ customerName: null, item: [] }),
            item: new Item({}),
            index: '',
            popUp: false,
            popUpSucessOrError: 'sucess',
            messagePopUp: '',
            popUpRedirect: false,
            showPopUpDelete: false,
            itemInEddit: false,
            isEdit: false,
            currentId: null
        }
    },

    computed: {
        txtButtonAdd(){ return window.innerWidth < 500 ? '<<' : 'Voltar' },

        CreateOrEdit() { return !this.isEdit ? 'Adicionar venda' : 'Editar venda' },

        finalValue() {
            const sum = this.sale.item.reduce((sum, item) => {
                return sum + Number(item.totalValueItem.replace(/[\"R$"\","\"."]/g, ''))
            }, 0)

            this.sale.saleTotalValue = (sum / 100).toLocaleString('pt-br', { style: 'currency', currency: 'BRL' })
            return this.sale.saleTotalValue
        },
    },

    methods: {

        async fetchCustomers() {
            await ApiService.query('customer')
                .then(response => {
                    this.customers = response.data.map(customerData => ({ ...customerData }));
                })
                //console.log(this.customers)
        },

        addItem() {
            this.validateItems()
            if (this.$refs.itemDescription.valid() && this.$refs.itemQuantity.valid() && this.$refs.itemUnityValue.valid()) {

                this.item = new Item({
                    description: this.item.description,
                    quantity: this.item.quantity,
                    unityValue: this.item.unityValue,
                    totalValueItem: this.item.totalValueItem
                })
                
                this.item.unityValue = Number(this.item.unityValue).toLocaleString('pt-br', { style: 'currency', currency: 'BRL' })
                
                this.sale.item.push(this.item)
                this.sale.saleTotalItems = this.sale.item.length
                
                this.popUpSucessOrError = 'sucess'
                this.togglePopUpSucess("Item adicionado com sucesso!")
                this.clearInputs()
                this.itemInEddit = false
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
            this.convertValueTypes()
            console.log(this.sale)
            try {
                await SaleService.create(this.sale)
                this.popUpSucessOrError = 'sucess'
                this.togglePopUpSucess("Formulário enviado com sucesso!")
                this.popUpRedirect = false
                this.clearAll()
            } catch (error) {
                console.error('Error adding sale:', error.message)
            }
        },

        async updateSale() {
            this.convertValueTypes()
            console.log(this.sale)
            try {
                await SaleService.create('sale', this.currentId, this.sale)
                this.popUpSucessOrError = 'sucess'
                this.togglePopUpSucess("Formulário atualizado com sucesso!")
                this.popUpRedirect = false
                this.clearAll()
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

        convertValueTypes(){

            //console.log(this.sale);

            this.sale.saleTotalItems = parseInt(this.sale.saleTotalItems)
            this.sale.saleTotalValue = this.sale.saleTotalValue.replace(/[\"R$"\" "]/g, '').replace(',', '.')
            this.sale.saleDate = new Date().toISOString()

            for (let i = 0; i < this.sale.item.length; i++) {
                const currentItem = this.sale.item[i]

                currentItem.quantity = parseInt(currentItem.quantity)
                currentItem.unityValue = currentItem.unityValue.replace(/[\"R$"\" "]/g, '').replace(',', '.')

                currentItem.totalValueItem = currentItem.totalValueItem.replace(/[\"R$"\" "]/g, '').replace(',', '.')
            }

            console.log(this.sale);
        },

        sendForm() {
            if (!this.sale.item.length) {
                this.popUpSucessOrError = 'error'
                this.togglePopUpSucess("Adicione pelo menos um item...")
                return
            }

            this.validadeSale()
            if (this.$refs.saleCustomer.valid() && this.$refs.saleBillingDate.valid()) {
                this.isEdit ? this.updateSale() : this.createSale()
            } else {
                return
            }
        },

        clearInputs() {
            this.item = new Item({})
        },

        clearAll() {
            this.clearInputs()
            this.finalValue = ''
            this.sale = new Sale({})
        },

        togglePopUpSucess(messagePopUp) {
            if (this.popUpRedirect) this.$router.push('/sales')
            this.messagePopUp = messagePopUp
            this.popUp = !this.popUp
        },

        deleteConfirm() {
            this.sale.item.splice(this.id, 1)
            this.togglePopUpDelete()
        },

        togglePopUpDelete(item) {
            if (item)
                this.id = this.sale.item.indexOf(item)
            this.showPopUpDelete = !this.showPopUpDelete
        },

        calcTotalValueItems(){
            if (this.item.quantity && this.item.unityValue) {
                this.item.totalValueItem = (this.item.quantity * this.item.unityValue.replace(/[\"R$"\","\"."]/g, '') / 100)
                    .toLocaleString('pt-br', { style: 'currency', currency: 'BRL' })
                return this.item.totalValueItem
            } else {
                return ''
            }
        },

        toEditItem(index, item){
            if(!this.itemInEddit){
                this.itemInEddit = true
                this.item.description = item.description
                this.item.quantity = item.quantity
                this.item.unityValue = item.unityValue
                this.item.totalValue = item.totalValue
                this.sale.item.splice(index, 1)
            }
            else{
                alert("Já há um item em edição")
            }
        },

        verifyCreateOrEditSale() {
            const currentId = this.$route.params.id

            if (currentId){
                this.isEdit = true
                this.currentId = currentId
                this.fetchSale(currentId)
            }

        },

        async fetchSale(id) {
            await SaleService.searchById(id)
            .then(response => {
                this.sale = response
            }).catch((error) => {
                console.error(error)
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