import DealershipWorkflow from '@/router/dealership-self-service'
import store from '@/store'
import { UserSessionGetters } from '@/store/modules/user-session/getters'
import Gateway from '@/views/Gateway.vue'
import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '',
      redirect: '/Gateway',
    },
    {
      path: '/Gateway',
      name: 'Gateway',
      component: Gateway,
    },
    DealershipWorkflow
  ],
  scrollBehavior() {
    // eslint-disable-next-line no-unused-expressions
    document.getElementById('app')?.scrollIntoView()
  },
})

router.beforeEach((to, _from, next) => {
  const dealerId = store.getters[UserSessionGetters.DealerId]
  if (dealerId || to.path === '/Gateway') next()
  else next({ name: 'Gateway' })
})

export default router
