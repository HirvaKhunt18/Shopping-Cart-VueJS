<template>
  <div class="row">
    <div class="col-12">
      <div class="m-2">
        <div class="form-group m-2">
          <label for="">Name:</label>
          <input
            type="text"
            class="form-control"
            v-model="order.name"
          />
          <validation-error :validation="validation.order.name" />
        </div>
      </div>
      <div class="m-2">
        <div class="form-group m-2">
          <label for="">E-mail:</label>
          <input
            type="text"
            class="form-control"
            v-model="order.email"
          />
          <validation-error :validation="validation.order.email" />
        </div>
      </div>
      <div class="m-2">
        <div class="form-group m-2">
          <label for="">Address:</label>
          <input
            type="address"
            class="form-control"
            v-model="order.address"
          />
          <validation-error :validation="validation.order.address" />
        </div>
      </div>
    </div>
    <div class="col-12 text-center">
      <router-link to="/cart" class="btn btn-secondary m-1">Back</router-link>
      <button class="btn btn-primary m-1" @click="submitOrder">Place Order</button>
    </div>
  </div>
</template>

<script>
import ValidationError from "./ValidationError";
import { required, email } from "vuelidate/lib/validators";
import { reactive, computed, ref } from "vue";
import { useStore } from 'vuex';
import { useRouter } from 'vue-router'; 

export default {
  components: {
    ValidationError,
  },
  setup() {
    const store = useStore();
    const router = useRouter(); 
    const order = reactive({
      name: "Hirva",
      email: "hirva@gmail.com",
      address: "Ahmedabad, Gujarat",
    });

    const touched = ref({
      name: false,
      email: false,
      address: false,
    });

    const validation = computed(() => ({
      order: {
        name: { required },
        email: { required, email },
        address: { required },
      },
    }));

    const submitOrder = async () => {
      Object.keys(touched.value).forEach((key) => {
        touched.value[key] = true;
      });

      if (!validation.value.$invalid) {
        const orderData = new FormData();
        orderData.append("OrderName", order.name);
        orderData.append("Email", order.email);
        orderData.append("Address", order.address);
        orderData.append("Cart", JSON.stringify(store.state.cart.cart));
        orderData.append("TotalAmount", store.getters["cart/totalPrice"]);
        console.log(orderData);
        await store.dispatch("order/storeOrder", orderData);
        store.dispatch("cart/clearCart");
        router.push(`/thanks`); 
      }
    };

    return {
      order,
      touched,
      validation,
      submitOrder,
    };
  },
};
</script>


<style scoped>
</style>
