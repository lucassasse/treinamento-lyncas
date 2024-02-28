<template>
    <label id="label-form" :for="labelFor">{{ textLabel }}</label>
    <input
        class="input-form"
        :class="verifyError"
        :id="id"
        :type="type"
        :placeholder="textPlaceholder"
        :value="modelValue"
        @input="sendInputValue"
        :required="required"
        v-maska
        :data-maska="mask"
    >
    <div class="errorText" v-if="!isValid">{{ textError }}</div>
</template>

<script>
import { vMaska } from "maska"
import helpers from '@/common/helpers'
export default {
    props: {
        labelFor: String,
        id: String,
        textLabel: String,
        textPlaceholder: String,
        modelValue: String,
        mask: String,
        type: {type: String, default: "text"},
        required: {type: Boolean, default: false},
    },
    data() {
        return {
            isValid: true,
            textError: ''
        }
    },
    computed:{
        verifyError(){
            return this.isValid ? "" : "errorInput"
        }
    },
    methods:{
        sendInputValue(event){
            this.isValid = true
            this.$emit('update:modelValue', (event.target.value))
        },
        valid() {
            return this.requiredValid() && this.telephoneValid() && this.cpfValid() ? this.isValid = true : this.isValid = false
        },
        requiredValid() {
            if(this.required && this.modelValue){
                return true
            } else {
                this.textError = `Preencha o campo ${this.textLabel}`
                return false
            }
        },
        telephoneValid(){
            if(this.type == "tel"){
                if(helpers.validTelephone(this.modelValue)){
                    return true
                }else{
                    this.textError = 'Telefone inválido'
                    return false
                }
            }
            return true
        },
        cpfValid(){
            if(this.id == "cpf"){
                if(helpers.validCpf(this.modelValue)){
                    return true
                }else{
                    this.textError = 'CPF inválido'
                    return false
                }
            }
            return true
        }
    },
    directives: {
        maska: vMaska
    }
}
</script>