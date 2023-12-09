<template>
      <h4 v-if="showFaliureMessage" class="bg-danger text-white text-center">
        Authentication Failed, Please Try Again!
      </h4>
      <div class="d-flex justify-content-center align-items-center mt-5">
      <div class="col-md-8 col-lg-6 col-xl-4" id="card">
        <div
          class="card"
          style="border-radius: 1rem; background-color: #d1e4ff"
        >
          <div class="card-body p-5">
              <div class="form-group">
                <label for="">User Name:</label>
                <input v-model="userName" class="form-control" />
              </div>

              <div class="form-group">
                <label for="">Password:</label>
                <input
                  v-model="password"
                  type="password"
                  class="form-control"
                />
              </div>

              <div class="text-center text-lg-start mt-4 pt-2">
                <button
                  @click="handleAuth"
                  class="btn btn-primary btn-lg"
                  style="padding-left: 2.5rem; padding-right: 2.5rem"
                >
                  Login
                </button>
              </div>
          </div>
        </div>
      </div>
    </div>
</template>
<script>
import { mapActions, mapState } from "vuex";

export default {
  data() {
    return {
      userName: "",
      password: "",
      showFaliureMessage: false,
    };
  },
  computed: {
    ...mapState({ authenticated: (state) => state.auth.authenticated }),
  },
  methods: {
    ...mapActions("auth", ["authenticate"]),
    async handleAuth() {
        await this.authenticate({
        userName: this.userName,
        password: this.password,
      });
      if (this.authenticated) {
        this.$router.push("/admin");
        console.log("yes");
      } else {
        this.showFaliureMessage = true;
      }
    },
  },
};
</script>
<style scoped>
#card{
    display: flex;
  justify-content: center;
  align-items: center;
}
</style>