import { createRouter, createWebHistory } from "vue-router";
import pages from "../components/AppPages";
import AppProduct from "../components/AppProduct";
import ShoppingCart from "../components/ShoppingCart";
import CheckoutForm from "../components/CheckoutForm";
import ThanksPage from "../components/ThanksPage";
import AdminPanel from "../components/admin/AdminPanel";
import ProductsPanel from "../components/admin/ProductsPanel";
import ProductEdit from "../components/admin/ProductEdit";
import PagesPanel from "../components/admin/PagesPanel";
import PageEdit from "../components/admin/PageEdit";
import OrdersPanel from "../components/admin/OrdersPanel";
import LoginAuth from "../components/admin/LoginAuth";
import dataStore from "../store/Auth";

const routes = [
  { path: "/categories/:category", component: AppProduct },
  { path: "/:slug?", component: pages },
  { path: "/:pathMatch(.*)*", redirect: "/" },
  { path: "/cart", component: ShoppingCart },
  { path: "/checkout", component: CheckoutForm },
  { path: "/thanks", component: ThanksPage },
  { path: "/login", component: LoginAuth },
  {
    path: "/admin",
    component: AdminPanel,
    beforeEnter(to,from, next){
      if(dataStore.state.authenticated){
        next();
      }else{
        next("/login");
      }
    },
    children: [
      { path: "/admin/products", component: ProductsPanel },
      {
        path: "/admin/products/:op(add|edit)/:id(\\d+)?",
        component: ProductEdit,
      },
      { path: "/admin/pages", component: PagesPanel },
      {
        path: "/admin/pages/:op(add|edit)/:id(\\d+)?",
        component: PageEdit,
      },
      { path: "/admin/orders", component: OrdersPanel },
      { path: "*", redirect: "/admin/products" },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
