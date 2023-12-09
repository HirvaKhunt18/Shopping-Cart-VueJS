<template>
    <div class="col-3">
      <h3>Categories</h3>
      <ul class="flex-column mt-3">
        <li class="nav-item">
            <router-link class="nav-link" to="/categories/All">
                All
            </router-link>
            <hr class="hr"/>
        </li>
        <li class="nav-item" v-for="(category, i ) in categories" :key="i">
            <router-link class="nav-link" :to="'/categories/' + category.categoryName">
                {{ category.categoryName }}
            </router-link>
            <hr class="hr"/>
        </li>
      </ul>
    </div>
  </template>
  
  <script>
  import { mapState } from 'vuex';
  
  export default {
    components: {},
    computed: {
      ...mapState(["categories"]),
    }
  };
  </script>
  <style scoped>
  li{
    list-style-type:none;
    font-size: 1.5rem;
  }
  h3{
    font-size: 2rem;
    padding-left: 2rem;
  }
  .hr{
    width: 10rem;
  }
  a.router-link-active{
  width: 100%;
  background: black;
  color: white;
  }
</style>
  
   
  