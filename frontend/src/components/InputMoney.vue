<template>
    <label id="label-form" :for="labelFor">{{ textLabel }}</label>
    <input
        class="input-form"
        :type="type"
        :class="verifyError"
        :id="id"
        :placeholder="textPlaceholder"
        :disabled="disabled"
        :value="modelValue"
        @input="sendInputValue"
        autocomplete="off"
        :required="required"
        v-money3="config"
    >
    <div class="errorText" v-if="!isValid">{{ textError }}</div>
</template>

<script>
import { Money3Directive, unformat } from 'v-money3'

export default {
    props: {
        id: String,
        type: {type: String, default: "text"},
        labelFor: String,
        textLabel: String,
        textPlaceholder: String,
        disabled: String,
        modelValue: String,
        required: {type: Boolean, default: false},
    },
    computed:{
        verifyError(){
            return this.isValid ? "" : "errorInput"
        }
    },
    data(){
        return{
            config: {
            masked: false,
            prefix: 'R$ ',
            suffix: '',
            thousands: '.',
            decimal: ',',
            precision: 2,
            disableNegative: true,
            disabled: false,
            min: null,
            max: null,
            allowBlank: false,
            minimumNumberOfCharacters: 0,
            shouldRound: true,
            focusOnRight: false,
            },
            isValid: true,
            textError: ''
        }
    },
    directives: { 
        money3: Money3Directive
    },
    methods:{
        sendInputValue(event){
            this.isValid = true
            this.$emit('update:modelValue', unformat(event.target.value))
        },
        valid() {
            return this.requiredValid() && this.moneyValid() ? this.isValid = true : this.isValid = false
        },
        requiredValid() {
            if(this.required && this.modelValue){
                return true
            } else {
                this.textError = `Preencha o campo ${this.textLabel}`
                return false
            }
        },
        moneyValid(){
            if(this.id == "unityValue"){
                if(this.modelValue != "0.00"){
                    return true
                }else{
                    this.textError = `Preencha o campo ${this.textLabel}`
                    return false
                }
            }
            return true
        },
    }
}
</script>