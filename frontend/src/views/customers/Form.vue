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
                    <InputText type="text" textLabel="Nome" id="name" labelFor="name" v-model="customers.name" ref="customerName" autocomplete required/> 
                    <InputMask type="tel" textLabel="Telefone" id="tel" labelFor="tel" v-model="customers.tel" ref="customerTelephone" mask="['(##)####-####', '(##)#####-####']" required/>
                </div>
                <div id="div-right">
                    <InputText type="email" textLabel="E-mail" id="email" labelFor="email" v-model="customers.email" ref="customerEmail" required/>
                    <InputMask type="text" textLabel="CPF" id="cpf" labelFor="cpf" v-model="customers.cpf" ref="customerCpf" mask="###.###.###-##" required/>
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
//import ApiService from "@/common/apiService";
//import { Customer } from '@/models/Customer'

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
                customers: [],
                popUp: false,
                messagePopUp: '',
                popUpRedirect: false
            }
        },
        methods:{
            sendForm(){
                this.validate()
                if(this.$refs.customerName.valid() && this.$refs.customerEmail.valid() && this.$refs.customerTelephone.valid() && this.$refs.customerCpf.valid()){
                    this.togglePopUp("Cliente adicionado com sucesso!")
                    this.popUpRedirect = true
                    this.clearInputs()
                } else{
                    return
                }
            },
            clearInputs(){
                this.customers.name = '',
                this.customers.email = '',
                this.customers.tel = '',
                this.customers.cpf = ''
            },
            validate() {
                this.$refs.customerName.valid()
                this.$refs.customerEmail.valid()
                this.$refs.customerTelephone.valid()
                this.$refs.customerCpf.valid()
            },
            togglePopUp(message) {
                if(this.popUpRedirect) this.$router.push('/customers')
                this.messagePopUp = message
                this.popUp = !this.popUp
            },
            async fetchCustomerData(){
                // if (!this.$route.query.key)
                //     return

                // await ApiService.get().then((result) =>{
                //     console.log(result)
                // })
            },
        
        created(){
            this.fetchCustomerData()
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