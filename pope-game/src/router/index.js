import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    redirect: '/city',
    name: 'city',
    component: () => import("@/layouts/Layout.vue"),
    children:[
      {
        path: '/city',
        name: 'city',
        component: () => import("@/views/city/Index.vue"),
      },{
        path: '/store',
        name: 'store',
        component: () => import("@/views/store/Index.vue"),
      },{
        path: '/tabern',
        name: 'tabern',
        component: () => import("@/views/tabern/Index.vue"),
      },{
        path: '/church',
        name: 'church',
        component: () => import("@/views/church/Index.vue"),
      }
    ]
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
