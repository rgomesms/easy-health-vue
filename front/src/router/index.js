import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import NewAddress from '../views/NewAddress.vue'
import NewAppointment from '../views/NewAppointment.vue'
import Consultas from '../views/Consultas.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/photos',
    name: 'Photos',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/Photos.vue')
  },
  {
    path: '/newaddress',
    name: 'NewAddress',
    component: NewAddress
  },
  {
    path: '/newappointment',
    name: 'NewAppointment',
    component: NewAppointment
  },
  {
    path: '/consultas',
    name: 'Consultas',
    component: Consultas
  },
]

const router = new VueRouter({
  routes
})

export default router
