import { createApp } from 'vue';
import App from './App.vue';
import store from './store/Index';
import router from './router/Index';
import vuelidate from 'vuelidate';
import vue3Editor from 'vue3-editor';

import "bootstrap/dist/css/bootstrap.min.css";
import "font-awesome/css/font-awesome.min.css";

createApp(App).use(router).use(store).use(vue3Editor).use(vuelidate).mount('#app');
