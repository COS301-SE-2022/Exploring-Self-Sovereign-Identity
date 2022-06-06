import { createApp } from "vue";
import ElementPlus from "element-plus";
import "element-plus/dist/index.css";
import { createPinia } from "pinia";
import App from "./App.vue";
import router from "./router";

const app = createApp(App);

app.use(ElementPlus);
//* These errors will show however they aren't actual errors
app.use(createPinia());
app.use(router);

app.mount("#app");
