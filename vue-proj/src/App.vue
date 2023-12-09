<template>
  <div id="app">
    <AppHeader />
    <router-view></router-view>
  </div>
</template>

<script>
import AppHeader from './components/AppHeader';
import { mapActions } from 'vuex';
export default {
  components: {
    AppHeader
  },
  methods:{
    ...mapActions(["setPagesAction","setCategoriesAction",]),   
  },
  async created(){
    this.setPagesAction();
    this.setCategoriesAction();
  }
}
</script>

