import '@babel/polyfill'
import 'mutationobserver-shim'
import Vue from 'vue'
import './plugins/axios'
import './plugins/bootstrap-vue'
import App from './App.vue'
import store from './store'
import VueI18n from 'vue-i18n'
import messages from './locales/messages.js'

Vue.use(VueI18n)

const i18n = new VueI18n({
  locale: 'en',
  messages
})

Vue.config.productionTip = false

new Vue({
  store,
  i18n,
  render: h => h(App)
}).$mount('#app')
