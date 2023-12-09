<template>
  <div>
    <h1>{{ editMode ? "Edit Page" : "Add Page" }}</h1>
  </div>
  <div class="form-group col-8">
    <label for="">Page Name:</label>
    <input type="text" class="form-control" v-model="page.pageName" />
  </div>
  <br />
  <div class="form-group col-8">
    <label for="">Slug:</label>
    <textarea class="form-control" v-model="page.slug"></textarea>
  </div>
  <br />
  <div class="form-group col-8">
    <label for="">Description:</label>
    <vue-editor  v-model="page.content"></vue-editor>
  </div>
  <br />   
  <div class="text-left">
    <router-link to="/admin/pages" class="btn btn-warning mb-3"
      >Cancel</router-link
    >
    <button class="btn btn-primary mb-3" @click="handlePage">
      {{ editMode ? "Update" : "Add" }}
    </button>
  </div>
</template>

<script>
import { mapActions, mapState,mapGetters } from "vuex";
export default {
  data() {
    return {
      page: {
        pageName: "",
        content: "",
        slug: ""
      },
    };
  },
  computed: {
    ...mapState(["pages"]),
    ...mapGetters(["pageById"]),
    editMode() {
      return this.$route.params["op"] == "edit";
    },
  },
  methods: {
    ...mapActions(["addOrEditPage"]),
    async handlePage() {
      console.log("Page Object:", this.page);
      const pageData = new FormData();     
      pageData.append("PageName", this.page.pageName);
      pageData.append("Content", this.page.content);
      pageData.append("Slug", this.page.slug);
      if(this.editMode){
        pageData.append("PageId", this.page.pageId);
      }
      console.log(pageData);
      await this.addOrEditPage(pageData);
      this.$router.push(`/admin/pages`);
    },
  },
  created() {
    if (this.editMode) {
      Object.assign(
        this.page,
        this.$store.getters.pageById(this.$route.params.id)
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
