const validEmail = (value) => {
    const regex = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    return regex.test(value)
}

const validTelephone = (value) => {
    const regex = /^\([1-9]{2}\)(?:[2-8]|9[0-9])[0-9]{3}\-[0-9]{4}$/
    return regex.test(value)
}

const validCpf = (value) => {
    let cpf = value
    cpf = cpf.replace(/[^\d]+/g,'');	
    if(cpf == '') return false;	
    if (cpf.length != 11 || 
        cpf == "00000000000" || 
        cpf == "11111111111" || 
        cpf == "22222222222" || 
        cpf == "33333333333" || 
        cpf == "44444444444" || 
        cpf == "55555555555" || 
        cpf == "66666666666" || 
        cpf == "77777777777" || 
        cpf == "88888888888" || 
        cpf == "99999999999")
            return false;	
    let add = 0;	
    for (let i=0; i < 9; i ++)		
        add += parseInt(cpf.charAt(i)) * (10 - i);	
        let rev = 11 - (add % 11);	
        if (rev == 10 || rev == 11)		
            rev = 0;	
        if (rev != parseInt(cpf.charAt(9)))		
            return false;		
    add = 0;	
    for (let i = 0; i < 10; i ++)		
        add += parseInt(cpf.charAt(i)) * (11 - i);	
    rev = 11 - (add % 11);	
    if (rev == 10 || rev == 11)	
        rev = 0;	
    if (rev != parseInt(cpf.charAt(10)))
        return false;		
    return true;
}

const formatDate = (isoDate) => {
    const date = new Date(isoDate);
    const day = String(date.getDate()).padStart(2, '0');
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const year = date.getFullYear();

    return `${day}-${month}-${year}`;
}

const revertDate = (isoDate) => {
    var day  = isoDate.split("-")[0];
    var month  = isoDate.split("-")[1];
    var year  = isoDate.split("-")[2];

    return year + '-' + ("0" + month).slice(-2) + '-' + ("0" + day).slice(-2);
}

export default{
    validEmail,
    validTelephone,
    validCpf,
    formatDate,
    revertDate
}