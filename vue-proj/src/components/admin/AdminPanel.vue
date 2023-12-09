<template>
  <div class="row ">
    <div class="col-lg-2 col-md-3  card ">
      <router-link to="/admin/products" class="btn btn-block btn-secondary"
        >Products</router-link
      ><br>
      <router-link to="/admin/pages" class="btn btn-block btn-secondary"
        >Pages</router-link
      ><br>
      <router-link to="/admin/orders" class="btn btn-block btn-secondary"
        >Orders</router-link
      ><br>
    </div>
    <div class="col">
      <router-view></router-view>
    </div>
  </div>
</template>
<style scoped>
.btn{
  margin: 0.6rem 0.6rem 0.6rem 0.6rem ;
}
.card{
  border-radius: 0;
  background-color:#ededed;
}

</style>