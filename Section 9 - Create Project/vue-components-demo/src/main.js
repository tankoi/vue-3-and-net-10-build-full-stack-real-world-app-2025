import { createApp } from 'vue'
import App from './App.vue'
import ContactUs from './components/ContactUs.vue'
import ButtonCounter from './components/ButtonCounter.vue'

const app = createApp(App);

app.component('contact-us', ContactUs);
app.component('button-counter', ButtonCounter);

app.mount('#app');
