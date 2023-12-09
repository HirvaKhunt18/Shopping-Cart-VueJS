<template>
  <div>
    <h1>Products</h1>
    <router-link to="/admin/products/add" class="btn btn-primary mb-3"
      >Add Product</router-link>
  </div>
  <div class="tableView table-responsive">
    <table class="table table-striped table-bordered">
      <thead>
        <tr>
          <th>Product Name</th>
          <th>Image</th>
          <th>Price</th>
          <th>Category</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(p, i) in products" :key="i">
          <td>{{ p.productName }}</td>
          <td>
            <img
              style="width: 100px; height: 100px"
              :src="getImageUrl(p.image)"
              class="img-fluid"
            />
          </td>
          <td>&#8377;{{ p.price }}</td>
          <td>{{ p.categoryName }}</td>
          <td>
            <span style="display: flex; align-items: center"
              ><a @click="handleEdit(p)"
                ><i class="fa fa-edit btn btn-success"></i
              ></a>
              &nbsp; &nbsp;<a @click="deleteProduct(p)"
                ><i class="fa fa-trash btn btn-danger"></i
              ></a>
            </span>
          </td>
        </tr>
      </tbody>
    </table>

  </div>
</template>
    
    <script>
import { mapActions, mapState } from "vuex";

export default {
  components: {},
  computed: {
    ...mapState(["products"]),
    productImagesUrl() {
      return this.$store.state.productImages;
    },
  },
  methods: {
    ...mapActions(["setProductsByCategoryAction", "deleteProduct"]),
    handleEdit(product) {     
      this.$router.push(`/admin/products/edit/${product.productId}`);      
    },
    getImageUrl(imageName) {
      return `${this.productImagesUrl}/${imageName}`;
    },
  },
  created() {
    this.setProductsByCategoryAction("All");
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
    