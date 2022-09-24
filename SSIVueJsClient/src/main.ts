/* eslint-disable vue/multi-word-component-names */
import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'
import router from './router'
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import 'perfect-scrollbar/css/perfect-scrollbar.css'
import './styles/reset.css'
import './styles/global.scss'
import ActionBar from './components/ActionBar.vue'
import Configurator from './components/Configurator.vue'
import Container from './components/Container.vue'
import Footer from './components/Footer.vue'
import Header from './components/Header.vue'
import PerfectScrollbar from './components/PerfectScrollbar.vue'
import SectionWrapper from './components/SectionWrapper.vue'
import Sider from './components/Sider.vue'
import store, { storeKey } from '@/stores'

const app = createApp(App)
app.component('ActionBar', ActionBar)
app.component('Configurator', Configurator)
app.component('Container', Container)
app.component('FooterVue', Footer)
app.component('HeaderVue', Header)
app.component('PerfectScrollbar', PerfectScrollbar)
app.component('SectionWrapper', SectionWrapper)
app.component('Sider', Sider)

app.use(ElementPlus)
//* These errors will show however they aren't actual errors
app.use(createPinia())
app.use(router)
app.use(store, storeKey)

app.mount('#app')
