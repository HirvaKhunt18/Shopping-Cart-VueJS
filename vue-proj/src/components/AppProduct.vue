<template>
  <div class="row mt-3">
    <div class="col col-md-3">
      <AppCategory />
    </div>
    <div class="col">
      <div class="row">
        <div
          class="col-lg-4 col-md-6 col-sm-10 mt-3"
          v-for="(p, i) in products"
          :key="i"
        >
          <div class="product-box">
            <div class="image-section">
              <p>
                <img :src="getImageUrl(p.image)" class="img-fluid" />
              </p>
            </div>
            <div class="details-section">
              <h3>{{ p.productName }}</h3>
              <p>{{ p.description }}</p>
              <p>&#8377;{{ p.price }}</p>
              <hr />
              <button class="btn btn-primary" @click="handleAddProduct(p)">Add to cart</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
  
  <script>
import { mapActions, mapState, mapMutations} from "vuex";
import AppCategory from "./AppCategory";

export default {
  components: {
    AppCategory,
  },
  computed: {
    ...mapState(["products"]),
    productImagesUrl() {
      return this.$store.state.productImages;
    },
  },
  methods: {
    ...mapActions(["setProductsByCategoryAction"]),
    ...mapMutations({addProduct: "cart/addProduct"}),
    handleAddProduct(product){
      this.addProduct(product);
    },
    getImageUrl(imageName) {
      return `${this.productImagesUrl}/${imageName}`;
    },
  },
  created() {
    let category = this.$route.params.category;
    this.setProductsByCategoryAction(category);
  },
  beforeRouteUpdate(to, from, next) {
    this.setProductsByCategoryAction(to.params.category);
    next();
  },  
};
</script>
  <style scoped>
.row {
  margin-left: 1rem;
  margin-right: 1rem;
}
.product-box {
  width: 100%;
  height: 100%;
  padding: 1rem;
  border: 0.2rem solid #ccc;
  margin-bottom: 1rem;
  position: relative;
}
.image-section {
  box-sizing: border-box;
}
.image-section img {
  width: 34rem;
  height: 13rem;
}
.btn {
  position: absolute;
  bottom: 0.5rem;
  left: 0.5rem;
  margin-top: 1rem;
}
.details-section hr {
  width: 100%;
  position: relative;
  margin-bottom: 2rem;
}
.details-section {
  height: 40%;
  box-sizing: border-box;
}
</style>
  