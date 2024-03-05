<template>
    <Header>
        <template #btnAdd>
            <router-link to="/customers" tag="button" class="btn-back">{{ txtButtonAdd }}</router-link>
        </template>
    </Header>

    <div id="div-form">
        <div>
            <h1 id="title">{{CreateOrEdit}}</h1>
        </div>

        <form action="send" id="customers-form">
            <div id="div-top">
                <div id="div-left">
                    <InputText type="text" textLabel="Nome" id="fullName" labelFor="fullName" v-model="customer.fullName" ref="customerFullName" autocomplete required/> 
                    <InputMask type="tel" textLabel="Telefone" id="telephone" labelFor="telephone" v-model="customer.telephone" ref="customerTelephone" mask="['(##)####-####', '(##)#####-####']" required/>
                </div>

                <div id="div-right">
                    <InputText type="email" textLabel="E-mail" id="email" labelFor="email" v-model="customer.email" ref="customerEmail" required/>
                    <InputMask type="text" textLabel="CPF" id="cpf" labelFor="cpf" v-model="customer.cpf" ref="customerCpf" mask="###.###.###-##" required/>
                </div>
            </div>

            <div id="div-bottom">
                <div id="div-btn">
                    <ButtonSave @click.prevent="sendForm()"/>
                </div>
            </div>
        </form>

        <Transition>
            <pop-up v-if="popUp" @close="togglePopUp()" :message="messagePopUp" popUpClass="sucess"/>
        </Transition>
    </div>
</template>

<script>
import InputMask from '@/components/InputMask.vue'
import InputText from '@/components/InputText.vue'
import ButtonSave from '@/components/ButtonSave.vue'
import Header from '@/layouts/Header.vue'
import PopUp from '@/components/PopUp.vue'
import ApiService from "@/common/apiService"
import CustomerService from "@/common/service/customer.service"
import { Customer } from '@/models/Customer'

    export default{
        components:{
            InputMask,
            InputText,
            ButtonSave,
            Header,
            PopUp
        },

        data(){
            return{
                customer: new Customer({}),
                popUp: false,
                messagePopUp: '',
                popUpRedirect: false,
                isEdit: false
            }
        },

        computed:{
            txtButtonAdd(){ return window.innerWidth < 500 ? '<<' : 'Voltar' },
            
            CreateOrEdit(){ return !this.isEdit ? 'Adicionar cliente' : 'Editar cliente' }
        },

        methods:{
            verifyCreateOrEditCustomer() {
                const currentId = this.$route.params.id

                if (currentId) {
                    this.isEdit = true
                    this.fetchCustomer(currentId)
                }
            },

            async fetchCustomer(id){
                await CustomerService.searchById(id)
                .then(response => {
                    this.customer = response
                }).catch((error) => {
                    console.error(error)
                })
            },

            sendForm(){
                this.validate()
                if(this.$refs.customerFullName.valid() && this.$refs.customerEmail.valid() && this.$refs.customerTelephone.valid() && this.$refs.customerCpf.valid()){
                    this.isEdit ? this.updateCustomer() : this.createCustomer()
                } else{
                    return alert("Ops, algo errado aconteceu.")
                }
            },

            async createCustomer(){
                try {
                    await ApiService.post('customer', this.customer)
                    this.togglePopUp("Cliente adicionado com sucesso!")
                    this.popUpRedirect = true
                } catch (error) {
                    console.error('Error adding customer:', error.message)
                }
            },

            async updateCustomer(){
                try {
                    await ApiService.put(`customer/${this.customer.id}`, this.customer)
                    this.togglePopUp("Cliente atualizado com sucesso!")
                    this.popUpRedirect = true
                } catch (error) {
                    console.error('Error editting customer:', error.message)
                }
            },

            validate() {
                this.$refs.customerFullName.valid()
                this.$refs.customerEmail.valid()
                this.$refs.customerTelephone.valid()
                this.$refs.customerCpf.valid()
            },

            togglePopUp(message) {
                if(this.popUpRedirect) this.$router.push('/customers')
                this.messagePopUp = message
                this.popUp = !this.popUp
            },
            
        },
        
        mounted() {
            this.verifyCreateOrEditCustomer()
        },
}
</script>

<style scoped>
    #div-form{
        display: flex;
        flex-direction: column;
        margin-top: 50px;
        background-color: white;
        border: 1px solid #E5EBF1;
        border-radius: 5px;
        padding: 10px 35px 35px;
    }

    #title{
    font-weight: 600;
    }

    #customers-form{
        display: flex;
        flex-direction: column;
    }

    #div-top{
        display: flex;
        justify-content: space-between;
    }

    #div-left,
    #div-right{
        width: 49%;
    }

    #div-btn{
        display: flex;
        flex-direction: row-reverse
    }

    @media only screen and (max-width: 900px) {
        #div-form{
            margin-top: 25px;
            padding: 0 20px 10px;
        }

        #div-top{
            flex-direction: column;
        }

        #div-left,
        #div-right{
            width: 100%;
        }
    }
</style>