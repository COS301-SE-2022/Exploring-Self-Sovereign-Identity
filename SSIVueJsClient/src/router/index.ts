import { createRouter, createWebHistory } from "vue-router";
// import HomeView from "../views/HomeView.vue";
import LoginView from "../views/LoginView.vue";
import HomeView from "../views/HomeView.vue";
import ProfileView from "../views/ProfileView.vue";
import PendingTransactionsViewVue from "@/views/PendingTransactionsView.vue";
import RequestDataViewVue from "@/views/RequestDataView.vue";
import TransactionViewVue from "@/views/TransactionView.vue";
import PastTransactionsVue from "@/views/PastTransactions.vue";
const routes = [
  { path: "/", component: LoginView },
  { path: "/home", component: HomeView },
  { path: "/profile", component: ProfileView },
  { path: "/pending", component: PendingTransactionsViewVue },
  { path: "/request", component: RequestDataViewVue },
  {
    path: "/transaction",
    component: TransactionViewVue,
    props: (route) => ({ index: route.query.c }),
  },
  {
    path: "/past",
    component: PastTransactionsVue,
  },
];
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

export default router;
