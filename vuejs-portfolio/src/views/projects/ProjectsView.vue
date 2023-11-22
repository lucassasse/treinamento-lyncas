<template>
  <div id="projects">
    <h2 id="title">Selecione o Projeto para saber mais sobre...</h2>

    <div id="divCarousel">
      <Carousel :itemsToShow="3.95" :wrapAround="true" :transition="500">
        <Slide v-for="project in projects" :key="project.id">
          <div class="carousel__item">
            <router-link :to="{ name: 'ProjectDetails', params: { id: project.id } }">
              <img :src="getImgUrl(project.linkImg)" :alt="project.name">
            </router-link>
          </div>
        </Slide>

        <template #addons>
          <Pagination />
          <Navigation />
        </template>
      </Carousel>
    </div>
  </div>
</template>


<script>
import { defineComponent } from 'vue'
import { Carousel, Pagination, Slide, Navigation } from 'vue3-carousel'
import axios from 'axios'
import 'vue3-carousel/dist/carousel.css'

export default defineComponent({
  name: 'Autoplay',
  data() {
    return {
      baseUrl: 'http://localhost:3000',
      projects: []
    }
  },
  components: {
    Carousel,
    Slide,
    Navigation,
    Pagination,
  },
  methods: {
    async fetchData() {
      await axios.get(`${this.baseUrl}/projects`)
        .then(response => {
          this.projects = response.data
        })
        .catch(error => {
          console.error('Error fetching data:', error);
          alert("Algo de errado aconteceu ao buscar pelos dados.")
        });
    },
    getImgUrl(linkImg) {
      try {
        let img = require('@/assets/images/projects/' + linkImg);
        return img;
      } catch (error) {
        console.clear()
        return false;
      }
    }
  },
  created(){
    this.fetchData();
  }
})
</script>


<style scoped>
  #projects{
    display: flex;
    flex-direction: column;
    align-items: center;
  }

  #title{
    margin: 25px auto 100px auto;
  }

  img{
    width: 300px;
    height: 300px;
    padding: 10px;
    margin: 25px;
    object-fit: cover;
    border: 1px solid rgb(102, 101, 101);
    border-radius: 2px;
  }

  #divCarousel{
    margin: auto;
    width: 70vw;
  }

  .carousel__slide {
    padding: 5px;
  }
  
  .carousel__viewport {
    perspective: 2000px;
  }
  
  .carousel__track {
    transform-style: preserve-3d;
  }
  
  .carousel__slide--sliding {
    transition: 0.5s;
  }
  
  .carousel__slide {
    opacity: 0.9;
    transform: rotateY(-20deg) scale(0.9);
  }
  
  .carousel__slide--active ~ .carousel__slide {
    transform: rotateY(20deg) scale(0.9);
  }
  
  .carousel__slide--prev {
    opacity: 1;
    transform: rotateY(-10deg) scale(0.95);
  }
  
  .carousel__slide--next {
    opacity: 1;
    transform: rotateY(10deg) scale(0.95);
  }
  
  .carousel__slide--active {
    opacity: 1;
    transform: rotateY(0) scale(1.1);
  }

</style>