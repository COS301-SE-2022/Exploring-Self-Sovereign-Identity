import { createApp } from "vue";
import { createPinia } from "pinia";
import App from "./App.vue";
import router from "./router";
// import "./assets/base.scss";
import ElementPlus from "element-plus";
import "element-plus/dist/index.css";
import 'perfect-scrollbar/css/perfect-scrollbar.css';
import './styles/reset.css';
import './styles/global.scss';
//import store, { storeKey } from '@/stores'



const app = createApp(App);
app.use(ElementPlus);
//* These errors will show however they aren't actual errors
app.use(createPinia());
app.use(router);
//app.use(store, storeKey);

app.mount("#app");
