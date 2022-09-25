import { createRouter, createWebHistory } from "vue-router";
// import HomeView from "../views/HomeView.vue";
import LoginView from "../views/LoginView.vue";
import HomeView from "../views/HomeView.vue";
import ProfileView from "../views/ProfileView.vue";
import PendingTransactionsViewVue from "@/views/PendingTransactionsView.vue";
import RequestDataViewVue from "@/views/RequestDataView.vue";
import TransactionViewVue from "@/views/TransactionView.vue";
import PastTransactionsVue from "@/views/PastTransactions.vue";
import AvatarViewVue from "@/views/AvatarView.vue";


import { PassageUser } from "@passageidentity/passage-elements/passage-user";

const routes = [
  { path: "/", component: LoginView },
  { path: "/home", component: HomeView },
  { path: "/profile", component: ProfileView },
  { path: "/pending", component: PendingTransactionsViewVue },
  { path: "/request", component: RequestDataViewVue },
  {
    path: "/transaction",
    component: TransactionViewVue,
    props: (route: { query: { c: unknown } }) => ({ index: route.query.c }),
  },
  {
    path: "/past",
    component: PastTransactionsVue,
  },
 { 
  path: "/avatar", 
 component: AvatarViewVue
},

];
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});

router.beforeEach((to) => {
  if (to.path !== "/" && to.path !== "/avatar") {
    if (!new PassageUser().authGuard()) {
      return "/";
    }
  }
});

export default router;
