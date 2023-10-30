export function validadeEmptyAndLength3(value){
    if(!value){
        return '*Este campo é obrigatório!'
    }

    if(value.length < 3){
        return '*Este campo precisa de pelo menos 3 caracteres'
    }

    return true
}

export function validateEmptyAndEmail(value){
    if(!value){
        return '*Este campo é obrigatório'
    }

    const isValid = /^([\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+\.)*[\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+@((((([a-z0-9]{1}[a-z0-9\-]{0,62}[a-z0-9]{1})|[a-z])\.)+[a-z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$/i.test(value)

    if(!value){
        return '*Este campo precisa ser um email'
    }

    return true
}