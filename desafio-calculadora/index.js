const panel = document.querySelector('#panel')

function updateValueOnScreen(value){
    if(value == "+" || value == "-" || value == "x" || value == "/"){
        if(panel.value != ""){
            verifyPoint()
            verifyDoubleOperator()
            changeXtoX(value)
        }
    }else if(value == "."){
        panel.value += value
        verifyDoublePoint()
    }else if(value == "0"){
        panel.value += value
        verifyDoubleZero()
    }else{
        panel.value += value
    }
}

function verifyPoint(){
    if(panel.value[panel.value.length - 1] == "."){
        panel.value = panel.value.slice(0, -1)
    } 
}

function verifyDoublePoint(){
    panel.value = panel.value.replace("..", ".")
}

function verifyDoubleOperator(){
    let char = panel.value[panel.value.length - 1]
    if(char == "+" || char == "-" || char == "x" || char == "/"){
        panel.value = panel.value.slice(0, -1)
    }
}

function changeXtoX(value){
    if(value == "x"){
        panel.value += "*"
    }else{
        panel.value += value
    }
}

function verifyDoubleZero(){

    //Resolver 00.7 + n || n + 00.7 --- eval() não entende vários 0 antes do . --- Deve remover os 0 excedentes antes do ., deixando apenas um 0
    //Se tiver um "0.", verificar se há outro número antes de algum operador. Se houver, remover os 0 excedentes
}

function equal(){
    verifyString()
    let result = eval(panel.value)
    if(verifyResult(result)){
        panel.value = result
    }else{
        alert(panel.value + " é uma operação matemática inválida!")
        clearArea()
    }
}

function verifyString(){
    const char = panel.value[panel.value.length - 1]
    if(char == "+" || char == "-" || char == "x" || char == "/" || char == "."){
        panel.value = panel.value.slice(0,-1)
    }
}

function verifyResult(result){
    if(isNaN(result)){
        return false
    }else if(result == Infinity){
        return false
    }else{
        return true
    }
}

function clearArea(){
    panel.value = ''
}

function del(){
    panel.value = panel.value.slice(0,-1)
}