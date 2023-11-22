<template>
  <div>
    <main id="main">
      <div id="left">
        <h1>Lucas Eduardo Sasse</h1>
        <h2>Estagiário em Desenvolvimento de Softwares</h2>
        <h2>Desenvolvedor em produção...</h2>
        <!--<img src="../assets/images/img_lucas_camisa_lyncas_azul.jpg" alt="Imagem do Lucas">-->
      </div>
      <div id="right">
        <h1>About Lucas:</h1>
        <!--
        <p>
          Anteriormente, atuei por dois anos como Advogado, possuindo conhecimento com resolução de conflitos e experiência na área jurídica, principalmente nos campos bancário, societário e contratual.
        </p>
        <p>
          Após a decisão de mudança de carreira por n motivos, já atuei por 6 meses auxiliando no desenvolvimento de um Sistema integrado para gestão da saúde pública (SUS),
          utilizando principalmente Javascript, ASP Classic, XML e PostgreSQL.
        </p>
        <p>
          Hoje me desenvolvo como estagiário, estudando principalmente Vue.js 3, C# e SQL.
        </p>
        -->
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