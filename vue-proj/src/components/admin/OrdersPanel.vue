<template>
  <div>
    <h1>Orders</h1>
  </div>
  <div class="tableView table-responsive">
    <table class="table table-striped table-bordered">
      <thead>
        <tr>
          <th>Order ID</th>
          <th>Order Name</th>
          <th>Email</th>
          <th>Address</th>
          <th>Cart</th>
          <th>Total Amount</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(o, i) in orders" :key="i">
          <td>{{ o.orderId }}</td>
          <td>{{ o.orderName }}</td>
          <td>{{ o.email }}</td>
          <td>{{ o.address }}</td>
          <td>
            <ul class="list-group">
              <li class="list-group-item" v-for="(item, index) in JSON.parse(o.cart)" :key="index">
                <div > {{ item.product.productName }} </div>
                <div> &#8377;{{ item.product.price }}</div>
                <div> {{ item.quantity }} </div>
              </li>
            </ul>
          </td>
          <td>{{ o.totalAmount }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import { mapActions, mapState } from "vuex";

export default {
  computed: {
    ...mapState("order", ["orders"]),
  },
  methods: {
    ...mapActions("order", ["setOrdersAction"]),
  },
  created() {
    this.setOrdersAction();
  },
};
</script>

<style scoped>
h1 {
  margin: 1.5rem;
  text-align: center;
  color: #434445;
}
</style>
