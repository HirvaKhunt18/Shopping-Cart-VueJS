<template>
  <div class="row mt-3">
    <div class="col">
      <AppCategory />
    </div>
    <div class="col-9">
      <h2 class="display-4">Your Cart</h2>
      <table class="table table-border">
        <thead>
          <tr>
            <th>Product</th>
            <th>Quantity</th>
            <th>Actions</th>
            <th>Price per Unit</th>
            <th>Sub Total</th>
          </tr>
        </thead>
        <tbody>
          <tr v-if="itemCount == 0">
            <td colspan="5" class="text-center">Your cart is empty</td>
          </tr>
          <tr v-else v-for="(item, index) in cart" :key="index">
            <td>{{ item.product.productName }}</td>
            <td>{{ item.quantity }}</td>
            <td>
              <button
                class="btn small btn-secondary mx-1"
                @click="handleAddProduct(item.product)"
              >
                +
              </button>
              <button
                class="btn small btn-secondary mx-1"
                @click="handleSubtractProduct(item.product.productId)"
              >
                -
              </button>
              <button
                class="btn small btn-danger mx-1"
                @click="handleRemoveProduct(item.product.productId)"
              >
                Remove
              </button>
            </td>
            <td>&#8377;{{ item.product.price }}</td>
            <td>&#8377;{{ item.product.price * item.quantity }}</td>
          </tr>
        </tbody>
        <tfoot v-if="itemCount > 0">
          <tr>
            <td colspan="5" style="text-align: right;">
              <h4>Total: &#8377;{{ totalPrice }}</h4>
            </td>
          </tr>
          <tr colspan="5">
            <button class="btn btn-danger" @click="handleClearCart()">Clear Cart</button
            >&nbsp;&nbsp;&nbsp;
            <router-link to="/checkout"  class="btn btn-primary align-right">
              Checkout
            </router-link>
          </tr>
        </tfoot>
      </table>
    </div>
  </div>
</template>
  
  <script>
import { mapState, mapGetters,mapActions } from "vuex";
import AppCategory from './AppCategory'

export default {
  components: {
    AppCategory
  },
  computed: {
    ...mapState("cart", ["cart"]),
    ...mapGetters({
      itemCount: "cart/itemCount",
      totalPrice: "cart/totalPrice",
    }) 
  },
  
  methods: {
    ...mapActions({clearCart: "cart/clearCart"}),
    handleAddProduct(product) {
      this.$store.commit("cart/addProduct", product);
    },
    handleSubtractProduct(productId) {
      this.$store.commit("cart/subtractProduct", productId);
    },
    handleRemoveProduct(productId) {
      this.$store.commit("cart/removeProduct", productId);
    },
    handleClearCart(){
        this.clearCart();
    }

  },
 
};
</script>
<style scoped>
 </style>