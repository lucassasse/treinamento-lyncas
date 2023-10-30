const panel = document.querySelector('#panel')
let pointPostOperator = false

function updateValueOnScreen(value){
    if(verifyIsOperator(value)){
        modifyPointPostOperator("operator")
        verifyPoint()
        verifyDoubleOperator()
        changeXtoX(value)
    }else if(value == "."){
        if(!pointPostOperator){
            panel.value += value
        }
        modifyPointPostOperator("point")
        verifyDoublePoint()
    }else if(value == "0"){
        panel.value += value
        verifyDoubleZero()
    }else{
        panel.value += value
    }
}

function modifyPointPostOperator(value){
    if(value == "operator"){
        pointPostOperator = false
    }else{
        pointPostOperator = true
    }
}

function verifyPoint(){
    if(panel.value[panel.value.length - 1] == "."){
        slice()
    } 
}

function verifyDoublePoint(){
    panel.value = panel.value.replace("..", ".")
}

function verifyDoubleOperator(){
    let char = panel.value[panel.value.length - 1]
    if(verifyIsOperator(char)){
        slice()
    }
}

function changeXtoX(value){
    if(value == "x"){
        panel.value += "*"
    }else{
        panel.value += value
    }
}

//se o valor antes do 0 for 0 e 2 antes do 0 for operador, slice()
function verifyDoubleZero(){
    let char1 = panel.value[panel.value.length - 2]
    let char2 = panel.value[panel.value.length - 3]
    if(char1 == "0" && verifyIsOperator(char2)){ 
        slice()
    }
    if(char1 == "0" && char2 == undefined){
        slice()
    }
}

//Evitar utilizar eval() em códigos futuros - possui problemas de segurança
function equal(){
    verifyString()
    let result = eval(panel.value)
    if(verifyResult(result)){
        panel.value = result
        verifyPointOnScreenAfterResult(panel.value)
    }else{
        alert(panel.value + " é uma operação matemática inválida!")
        clearPanel()
    }
}

function verifyString(){
    const char = panel.value[panel.value.length - 1]
    if(verifyIsOperator(char) || char == "."){
        slice()
    }
}

function verifyResult(result){
    if(isNaN(result)){
        return false
    }else if(result == Infinity || result == -Infinity){
        return false
    }else{
        return true
    }
}

function verifyPointOnScreenAfterResult(result){
    if(!result.includes('.')){
        pointPostOperator = false
    } else{
        pointPostOperator = true
    }
}

function verifyIsOperator(value){
    if(value == "+" || value == "-" || value == "x" || value == "/" || value == "*"){
        return true
    } else{
        return false
    }
}

function clearPanel(){
    pointPostOperator = false
    panel.value = ''
}

function del(){
    if(panel.value[panel.value.length - 1] == '.'){
        slice()
        pointPostOperator = false
    } else if (verifyIsOperator(panel.value[panel.value.length - 1])) {
        slice();
        let operator = /[+\-*/]/;
        let operatorIndex = -1;

        // Encontrar o índice do último operador na string
        for (let i = panel.value.length - 1; i >= 0; i--) {
            if (operator.test(panel.value[i])) {
                operatorIndex = i;
                break;
            }
        }

        //Verificar se tem ponto neste trecho de string
        if (operatorIndex !== -1) {
            let stringValue = panel.value.substring(operatorIndex + 1);
            verifyPointOnScreenAfterResult(stringValue);
        } else{
            verifyPointOnScreenAfterResult(panel.value)
        }
    } else{
        slice()
    }
}

function slice(){
    panel.value = panel.value.slice(0, -1)
}