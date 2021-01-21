import Vue from 'vue';
import Vuex from 'vuex';

import { empresa } from './empresa.module';

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    empresa
  }
});