import { createApp } from 'vue'
import App from './App.vue'
// Import Bootstrap CSS and JS
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap/dist/js/bootstrap.bundle.min.js'

import Loader from './Components/Loader.vue'

const app = createApp(App);
app.component('Loader', Loader);
app.mount('#app');
