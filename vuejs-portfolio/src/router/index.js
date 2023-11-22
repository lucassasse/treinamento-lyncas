import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Projects from '../views/projects/ProjectsView.vue'
import ProjectDetails from '../views/projects/ProjectDetails.vue'
import Contact from '../views/ContactView.vue'
import Login from '../views/LoginView.vue'
import RegisterView from '../views/RegisterView'
import NotFound from '../views/NotFound.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/projects',
    name: 'projects',
    component: Projects
  },
  {
    path: '/projects/:id',
    name: 'ProjectDetails',
    component: ProjectDetails,
    props: true
  },
  {
    path: '/contact',
    name: 'contact',
    component: Contact
  },
  {
    path: '/login',
    name: 'login',
    component: Login
  },
  {
    path: '/register',
    name: 'register',
    component: RegisterView
  },
  {
    path: '/:catchAll(.*)',
    name: 'NotFound',
    component: NotFound
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
