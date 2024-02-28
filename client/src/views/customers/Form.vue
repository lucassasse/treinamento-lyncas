<template>
    <Header>
        <template #btnAdd>
            <router-link to="/customers" tag="button" class="btn-back btn-return-web">Voltar</router-link>
            <router-link to="/customers" tag="button" class="btn-back btn-return-mobile">&lsaquo;</router-link>
        </template>
    </Header>

    <div id="div-form">
        <div>
            <h1 id="title">Adicionar cliente</h1>
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
import ApiService from "@/common/apiService";
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
                popUpRedirect: false
            }
        },

        methods:{
            sendForm(){
                this.validate()
                if(this.$refs.customerFullName.valid() && this.$refs.customerEmail.valid() && this.$refs.customerTelephone.valid() && this.$refs.customerCpf.valid()){
                    this.createCustomer()
                } else{
                    return alert("Ops, algo errado aconteceu.")
                }
            },
            async createCustomer(){
                try {
                    await ApiService.post('customer', this.customer);
                    this.togglePopUp("Cliente adicionado com sucesso!")
                    this.popUpRedirect = true
                    this.clearInputs()
                } catch (error) {
                    console.error('Error adding customer:', error.message);
                }
            },
            clearInputs(){
                this.customer = new Customer({})
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
            async getCustomers() {
                console.log('customerId:', this.$route.query.key)

                if (!this.$route.query.key) {
                    console.log('Key not found in the query parameter');
                    return;
                }

                await ApiService.query('customer')
                .then(response => {
                    this.customers = response.data.map(customerData => new Customer({
                        id: customerData.id, 
                        fullName: customerData.fullName, 
                        email: customerData.email, 
                        telephone: customerData.telephone, 
                        cpf: customerData.cpf}));
                })
            },
        
        mounted(){
            this.getCustomers()
        }
    }
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