<template>
    <div class="row mt-3">
      <div class="col">
       <AppCategory/>
      </div>
      <div class="col-9">
       <div v-html="pageContent"></div>
      </div>
    </div>
  </template>
  
  <script>
  import { mapState } from 'vuex';
  import AppCategory from './AppCategory';
  
  export default {
    components: {
      AppCategory
    },
    computed: {
      ...mapState(["pages"]),
      pageContent() {
        const slug = this.$route.params.slug || "home";
        const page = this.pages.find((page) => page.slug === slug);
        if (page) {
          return page.content;
        } else {
          return "";
        }
      }
    }
  };
  </script>
  
   
  