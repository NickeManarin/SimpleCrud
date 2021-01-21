import Vue from 'vue'
import App from './App.vue'
import router from "./router";
import store from './store';
import Buefy from "buefy";
import VueScrollTo from 'vue-scrollto';
import VueCurrencyInput from 'vue-currency-input';
import i18n from "./locales";

Vue.config.productionTip = false

Vue.use(Buefy, {
  defaultIconPack: "unicons",
});
Vue.use(VueScrollTo);
Vue.use(VueCurrencyInput, {
  globalOptions: { currency: 'BRL' }
})

new Vue({
  router,
  store,
  i18n,
  render: h => h(App),

  created() {
    if (sessionStorage.redirect) {
        const redirect = sessionStorage.redirect;
        const hash = sessionStorage.hash;
        delete sessionStorage.redirect;
        delete sessionStorage.hash;

        this.$router.push(redirect + hash);
    }
}
}).$mount('#app')
