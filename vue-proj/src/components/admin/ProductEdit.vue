<template>
  <div>
    <h1>{{ editMode ? "Edit Product" : "Add Product" }}</h1>
  </div>
  <div class="form-group col-8">
    <label for="">Product Name:</label>
    <input type="text" class="form-control" v-model="product.productName" />
  </div>
  <br />
  <div class="form-group col-8">
    <label for="">Product Description:</label>
    <textarea class="form-control" v-model="product.description"></textarea>
  </div>
  <br />
  <div class="form-group col-8">
    <label for="">Product Price: (&#8377;)</label>
    <input type="text" class="form-control" v-model="product.price" />
  </div>
  <br />
  <div class="form-group col-8">
    <label for="">Product Image:</label>
    <p v-if="editMode">
      <img
        style="width: 60px; height: 60px"
        :src="getImageUrl(product.image)"
        class="img-fluid"
      />
    </p>
    <input
      type="file"
      class="form-control"
      name="ImageFile"
      @change="onFileSelected"
    />
  </div>
  <br />
  <div class="form-group col-8">
    <label for="">Product Category:</label>
    <select class="form-control" @change="onChange">
      <option :value="null">--Select Category--</option>
      <option
        v-for="(c, i) in categories"
        :key="i"
        :value="c.categoryId"
        :selected="c.categoryId == product.categoryId"
      >
        {{ c.categoryName }}
      </option>
    </select>
  </div>
  <div class="text-left">
    <router-link to="/admin/products" class="btn btn-warning mb-3"
      >Cancel</router-link
    >
    <button class="btn btn-primary mb-3" @click="handleProduct">
      {{ editMode ? "Update" : "Add" }}
    </button>
  </div>
</template>

<script>
import { mapState, mapGetters, mapActions, mapMutations } from "vuex";
export default {
  data() {
    return {
      product: {
        productName: "",
        description: "",
        price: "",
        imageFile: "",
        category: null,
        categoryId: null,
      },
    };
  },
  computed: {
    ...mapState(["products", "categories"]),
    productImagesUrl() {
      return this.$store.state.productImages;
    },
    ...mapGetters(["productById"]),
    editMode() {
      return this.$route.params["op"] == "edit";
    },
  },
  methods: {
    ...mapActions(["addOrEditProduct"]),
    ...mapMutations(["setProduct"]),
    onFileSelected(e) {
      if (e.target.files.length > 0) {
    this.product.imageFile = e.target.files[0];
    console.log(this.product.imageFile);
    this.selectedImageName = e.target.files[0].name;
  } else {
    this.product.imageFile = ""; // Set imageFile to an empty string when no file is selected
    this.selectedImageName = ""; // Reset the selected image name
  }
    },
    onChange(e) {
      this.product.categoryId = e.target.value; // Update assignment to categoryId
    },
    getImageUrl(imageName) {
      return `${this.$store.state.productImages}/${imageName}`;
    },
    async handleProduct() {
      console.log("Product Object:", this.product);
      const productData = new FormData();     
      productData.append("ProductName", this.product.productName);
      productData.append("Description", this.product.description);
      productData.append("Price", this.product.price);
      if(this.editMode){
      productData.append("ProductId", this.product.productId);
      productData.append("ImageFile", this.product.imageFile);
      productData.append("Image", this.product.image);
      }else{
      productData.append("Image", this.product.imageFile.name);
      productData.append("ImageFile", this.product.imageFile);
      }      
      productData.append("CategoryId", this.product.categoryId);
      console.log(productData);
      await this.addOrEditProduct(productData);
      this.$router.push(`/admin/products`);
    },
  },
  created() {
    if (this.editMode){
      Object.assign(
        this.product,       
        this.$store.getters.productById(this.$route.params.id)
      );
    }
  },
};
</script>
<style scoped>
h1 {
  margin: 1.5rem;
  text-align: left;
  color: #434445;
}
.btn,
div {
  margin: 0.5rem;
}
</style>
