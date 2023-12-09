import { createStore } from "vuex";
import Axios from "axios";
import cartModule from "./Cart";
import orderModule from "./Order";
import axios from "axios";
import AuthModule from "./Auth";

const baseUrl = "https://localhost:44314/api";
const pagesUrl = `${baseUrl}/Pages`;
const categoriesUrl = `${baseUrl}/Category`;
const productsUrl = `${baseUrl}/Product`;
const productImagesUrl = `https://localhost:44314/images`;

export default createStore({
  strict: true,
  modules: { cart: cartModule, order: orderModule, auth: AuthModule },
  state: {
    products: [],
    pages: [],
    categories: [],
    productImages: productImagesUrl,
  },  
  mutations: {
    setPages(state, pages) {
      state.pages = pages;
    },
    setCategories(state, categories) {
      state.categories = categories;
    },
    setProducts(state, products) {
      state.products = products;
    },
  },
  getters: {
    productById: (state) => (id) =>
      state.products.find((p) => p.productId == id),
    pageById: (state) => (id) => state.pages.find((p) => p.pageId == id),
  },
  actions: {
    async setPagesAction(context) {
      const response = await Axios.get(pagesUrl);
      context.commit("setPages", response.data);
      
    },
    async setCategoriesAction(context) {
      const response = await Axios.get(categoriesUrl);
      context.commit("setCategories", response.data);
    },
    async setProductsByCategoryAction(context, category) {
      let url;
      if (category != "All") {
        url = `${productsUrl}/categories/${category}`;
      } else {
        url = `${productsUrl}`;
      }
      const response = await Axios.get(url);
      context.commit("setProducts", response.data);
    },
    async addOrEditProduct(context, product) {
      await axios.post(productsUrl, product);
    },
    async deleteProduct(context, product) {
      console.log(product);
      await axios.delete(`${productsUrl}/${product.productId}`);
      window.location.reload();
    },
    async addOrEditPage(context, page) {
      await axios.post(pagesUrl, page);
    },
    async deletePage(context, page) {
      console.log(page);
      await axios.delete(`${pagesUrl}/${page.pageId}`);
      window.location.reload();
    }
  },
});