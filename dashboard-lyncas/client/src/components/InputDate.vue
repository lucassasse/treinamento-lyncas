<template>
    <label id="label-form" :for="labelFor">{{ textLabel }}</label>
    <input
        class="input-form"
        :class="verifyError"
        type="date"
        :id="id"
        :value="modelValue"
        @input="sendInputValue"
        autocomplete="off"
        :disabled="isDisabled"
        :required="required"
    >
    <div class="errorText" v-if="!isValid">{{ textError }}</div>
</template>

<script>
export default {
    props: {
        labelFor: String,
        id: String,
        textLabel: String,
        modelValue: String,
        isDisabled: {type: Boolean, default: false},
        required: {type: Boolean, default: false},
    },
    data(){
        return{
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
            return this.requiredValid() ? this.isValid = true : this.isValid = false
        },
        requiredValid() {
            if(this.required && this.modelValue){
                return true
            } else {
                this.textError = `Preencha o campo ${this.textLabel}`
                return false
            }
        }
    }
}
</script>