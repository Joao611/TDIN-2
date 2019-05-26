import Vue from 'vue';
import 'bootstrap';
import 'bootswatch/dist/united/bootstrap.css';
import App from './App.vue';

Vue.config.productionTip = true;

new Vue({
    render: h => h(App)
}).$mount('#app');
