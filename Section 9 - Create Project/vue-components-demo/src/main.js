import { createApp } from 'vue'
import App from './App.vue'
import ContactUs from './components/ContactUs.vue'

const app = createApp(App);
// global component
app.component('contact-us', ContactUs);

app.mount('#app');
