import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import 'vuetify/dist/vuetify.min.css'
import CompositionApi from '@vue/composition-api'
import 'core-js/stable'
import 'regenerator-runtime/runtime'

Vue.config.productionTip = false
Vue.use(CompositionApi)

new Vue({
  router,
  store,
  vuetify,
  render: (h) => h(App),
}).$mount('#app')
