import { createRouter, createWebHistory } from 'vue-router'
import Home from '../components/Home.vue'
import Info from '../components/Info.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/info',
      name: 'Info',
      component: Info
    }
  ],
})

export default router
