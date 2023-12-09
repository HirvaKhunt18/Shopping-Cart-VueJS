import axios from "axios";

const authUrl = "https://localhost:44314/api/Login";

export default {
  namespaced: true,
  state: {
    authenticated : false
  },
  mutations: {
    setAuthenticated(state) {
        state.authenticated = true;
        console.log(state.authenticated);
    },
  },
  actions: {
    async authenticate(context, credentials) {
      let response = await axios.post(authUrl, credentials);
      console.log(response);
      if(response.data.success == true){
        context.commit("setAuthenticated");
      }
    }
  },
};
