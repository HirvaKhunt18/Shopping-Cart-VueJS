<template>
  <div>
    <h1>Pages</h1>
    <router-link to="/admin/pages/add" class="btn btn-primary mb-3"
      >Add Pages</router-link>
  </div>
  <div class="tableView table-responsive">
    <table class="table table-striped table-bordered">
      <thead>
        <tr>
          <th>Page Name</th>
          <th>Page Description</th>
          <th>Slug</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(p, i) in pages" :key="i">
          <td>{{ p.pageName }}</td>
          <td>{{ p.content }}</td>
          <td>{{ p.slug }}</td>
          <td>
            <span style="display: flex; align-items: center"
              ><a @click="handleEdit(p)"
                ><i class="fa fa-edit btn btn-success"></i
              ></a>
              &nbsp; &nbsp;<a @click="deletePage(p)"
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
    ...mapState(["pages"])
  },
  methods: {
    ...mapActions(["deletePage","setPagesAction"]),
    handleEdit(page) {     
      this.$router.push(`/admin/pages/edit/${page.pageId}`);      
    }
  },
  created() {
    this.setPagesAction();
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
    