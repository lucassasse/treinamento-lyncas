import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    redirect: '/dashboard',
    name: 'dashboard',
    component: () => import("@/layouts/Layout.vue"),
    children:[
      {
        path: '/dashboard',
        name: 'dashboard',
        component: () => import('@/views/dashboard/Index.vue'),
      },
      {
        path: '/customers',
        name: 'customers',
        component: () => import('@/views/customers/Index.vue'),
      },
      {
        path: '/sales',
        name: 'sales',
        component: () => import('@/views/sales/Index.vue'),
      },
      {
        path: '/customers-form/:id?',
        name: 'customers-form',
        component: () => import('@/views/customers/Form.vue'),
      },
      {
        path: '/sales-form/:id?',
        name: 'sales-form',
        component: () => import('@/views/sales/Form.vue'),
      }
    ]
  },
  {
    path: '/',
    redirect: '/login',
    component: () => import('@/layouts/LayoutBlank.vue'),
    children:[
      {
        path: '/login',
        name: 'login',
        component: () => import('@/views/authentication/Login.vue'),
      }
    ]
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router

/*
import { createRouter, createWebHistory } from 'vue-router';

const routes = [
  {
    path: '/',
    redirect: '/dashboard',
    name: 'dashboard',
    component: () => import("@/layouts/Layout.vue"),
    children: [
      {
        path: 'dashboard',
        name: 'dashboard',
        component: () => import('@/views/dashboard/Index.vue'),
      },
      {
        path: 'customers',
        name: 'customers',
        component: () => import('@/views/customers/Index.vue'),
      },
      {
        path: 'sales',
        name: 'sales',
        component: () => import('@/views/sales/Index.vue'),
      },
      {
        path: 'customers-form',
        name: 'customers-form',
        component: () => import('@/views/customers/Form.vue'),
      },
      {
        path: 'sales-form',
        name: 'sales-form',
        component: () => import('@/views/sales/Form.vue'),
      },
    ]
  },
  {
    path: '/login',
    name: 'login',
    component: () => import('@/views/authentication/Login.vue'),
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
*/