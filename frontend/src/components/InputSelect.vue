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
        <option class="options" value="1">Ciente Um</option>
        <option class="options" value="2">Ciente Dois</option>
        <option class="options" value="3">Ciente Três</option>
    </select>
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