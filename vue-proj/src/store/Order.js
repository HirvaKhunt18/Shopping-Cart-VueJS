import axios from "axios";

const orderUrl = "https://localhost:44314/api/Order";

export default {
  namespaced: true,
  state: {
    orders: [],
  },
  mutations: {
    setOrders(state, orders) {
      state.orders = orders;
      console.log(orders);
    },
  },
  actions: {
    async storeOrder(context, order) {
      const response = await axios.post(orderUrl, order);
      return response.data.id;
    },
    async setOrdersAction(context) {
      const response = await axios.get(orderUrl);
      context.commit("setOrders", response.data);
    },
  },
};
