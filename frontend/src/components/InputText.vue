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
    :autocomplete="autocomplete"
    >
    <div class="errorText" v-if="!isValid">{{ textError }}</div>
</template>

<script>
import helpers from '@/common/helpers'
export default {
    props: {
        labelFor: String,
        id: String,
        textLabel: {type: String, default: ''},
        textPlaceholder: String,
        modelValue: String,
        type: {type: String, default: "text"},
        required: {type: Boolean, default: false},
        autocomplete: {type: Boolean, default: true}
    },
    data() {
        return {
            isValid: true,
            textError: ''
        }
    },
    computed:{
        verifyError(){
            return this.isValid ? "": "errorInput"
        }
    },
    methods:{
        sendInputValue(event){
            this.isValid = true
            this.$emit('update:modelValue', (event.target.value))
        },
        valid() {
            return this.requiredValid() && this.emailValid() ? this.isValid = true : this.isValid = false
        },
        requiredValid() {
            if(this.required && this.modelValue){
                return this.isValid = true
            } else {
                this.textError = `Preencha o campo ${this.textLabel}`
                return this.isValid = false
            }
        },
        emailValid() {
            if(this.type == "email"){
                if(helpers.validEmail(this.modelValue)){
                    return true
                } else{
                    this.textError = 'E-mail inválido'
                    return false
                }
            }
            return true
        },
    },
}
</script>