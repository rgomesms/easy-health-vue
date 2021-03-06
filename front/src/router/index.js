import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Cadastros from '../views/Cadastros.vue'
import NewAppointment from '../views/NewAppointment.vue'
import Consultas from '../views/Consultas.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
    props: true
  },
  {
    path: '/photos',
    name: 'Photos',
    props: true,
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/Photos.vue')
  },
  {
    path: '/cadastros',
    name: 'Cadastros',
    props: true,
    component: Cadastros

  },
  {
    path: '/newappointment',
    name: 'NewAppointment',
    props: true,
    component: NewAppointment

  },
  {
    path: '/consultas',
    name: 'Consultas',
    props: true,

    component: Consultas
  },
]

const router = new VueRouter({
  routes
})

export default router
