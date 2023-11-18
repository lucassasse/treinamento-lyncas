<template>
  <div>
    <main id="main">
      <div id="left">
        <h1>Lucas Eduardo Sasse</h1>
        <h2>Desenvolvedor em produção...</h2>
        <img src="../assets/images/img_lucas_camisa_lyncas_azul.jpg" alt="Imagem do Lucas">
      </div>
      <div id="right">
        <h1>About Lucas:</h1>
        <h3 id="line01">Estagiário em Desenvolvimento de Softwares</h3>
        <h3 id="line02">Advogado</h3>
        <h3 id="line03">Técnico em Mecânica</h3>
        <h3 id="line04">Solucionador de problemas</h3>
        <h3></h3>
      </div>
    </main>
  </div>
</template>

<script>
export default {
  
}
</script>

<style scoped>
  #main{
    display: flex;
    max-width: 98vw;
    max-height: 100vh;
  }

  #left, #right{
    width: 50%;
  }

  img{
    border-radius: 100%;
  }
</style>