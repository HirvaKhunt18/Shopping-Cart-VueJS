export default {
  namespaced: true,
  state: {
    cart: [],
  },
  getters: {
    itemCount: (state) =>
      state.cart.reduce((total, cartItem) => total + cartItem.quantity, 0),
    totalPrice: (state) =>
      state.cart.reduce((total, cartItem) => total + cartItem.price, 0),
  },
  mutations: {
    addProduct(state, product) {
      let cartItem = state.cart.find(
        (cartItem) => cartItem.product.productId == product.productId
      );
      if (cartItem != null) {
        cartItem.quantity++;
        cartItem.price = cartItem.product.price * cartItem.quantity;
      } else {
        state.cart.push({
          product: product,
          quantity: 1,
          price: product.price,
        });
      }
      console.log(product);
      console.log(state.cart);
    },
    subtractProduct(state, productId) {
      let cartItem = state.cart.find(
        (cartItem) => cartItem.product.productId == productId
      );
      if (cartItem.quantity > 1) {
        cartItem.quantity--;
        cartItem.price = cartItem.product.price * cartItem.quantity;
      }
    },
    removeProduct(state, productId) {
      let index = state.cart.findIndex(
        (item) => item.product.productId == productId
      );
      if (index !== -1) {
        state.cart.splice(index, 1);
      }
    },
    setCartData(state, data) {
      state.cart = data;
    },
  },
  actions: {
    loadCartData(context) {
      let data = localStorage.getItem("cart");
      if (data != null) {
        context.commit("setCartData", JSON.parse(data));
      }
    },
    storeCartData(context) {
      localStorage.setItem("cart", JSON.stringify(context.state.cart));
    },
    initializeCart(context, store) {
      context.dispatch("loadCartData");
      store.watch(
        (state) => state.cart.cart,
        () => context.dispatch("storeCartData"),
        { deep: true }
      );
    },
    clearCart(context) {
      context.commit("setCartData", []);
    },
  },
};
