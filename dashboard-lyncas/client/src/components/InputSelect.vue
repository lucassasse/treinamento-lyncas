<template>
    <label id="label-form" :for="labelFor">{{ textLabel }}</label>

    <select
        :id="id" 
        class="input-form" 
        :class="verifyError"
        :value="modelValue" 
        @change="sendInputValue" 
        @input-change="handleInputChange" 
        :disabled="isDisabled" 
        :required="required"
    >
        <option class="options" value="0" selected disabled></option>

        <option v-for="customer in customers" :value="customer.id" :key="customer.id">{{ customer.fullName }}</option>
    </select>

    <div class="errorText" v-if="!isValid">{{ textError }}</div>
</template>

<script>
export default {
    props: {
        id: String,
        labelFor: String,
        textLabel: String,
        modelValue: [String, Number],
        isDisabled: {type: Boolean, default: false},
        required: {type: Boolean, default: false},
        customers: {type: Array, default: []}
    },

    emits: ['update:modelValue', 'input-change'],

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
            this.$emit('update:modelValue', (event.target.value));
            this.$emit('input-change');
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