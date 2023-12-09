<template>
  <nav class="navbar navbar-expand-md navbar-dark  bg-dark" style="padding-left: 2rem; padding-right: 2rem;">
    <RouterLink class="cart navbar-brand" :to="{ path: '/' }">Shopping Cart</RouterLink>

      <div class="collapse navbar-collapse show">
        <ul class="navbar-nav ml-auto">
          <li class="nav-item active" v-for="(p,i) in pages" :key="i">            
            <router-link v-if="p.slug !='home'" :to="'/' + p.slug" class="nav-link">{{ p.pageName }}</router-link>
          </li>
          <li class="nav-item active">            
            <router-link to="/admin" class="nav-link">Admin</router-link>
          </li>
        </ul>
      </div>
      <AppCart />
    </nav>

  </template>

<script>
import { mapState } from 'vuex';
import AppCart from './AppCart'
export default {
  components: {
    AppCart
  },
  computed:{
    ...mapState(["pages"])
  }
}
</script>
<style scoped>
.cart{
  padding-bottom: 0.7rem;
  font-size: 2rem;
}
li{

  font-size: 1.1rem;
}
</style>