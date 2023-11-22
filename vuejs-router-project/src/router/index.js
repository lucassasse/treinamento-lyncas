import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import About from '../views/AboutView.vue'
import Contact from '../views/ContactView.vue'
import Projects from '../views/projects/ProjectView.vue'
import ProjectDetails from '../views/projects/ProjectDetails.vue'
import NotFound from '../views/NotFound.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/about',
    name: 'about',
    component: About
  },
  {
    path: '/contact',
    name: 'contact',
    component: Contact
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
  // redirect
  {
    path: '/all-projects',
    redirect: '/projects'
  },
  // catchall 404
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
