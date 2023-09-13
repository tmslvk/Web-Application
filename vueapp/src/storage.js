import {createStore} from "vuex";
import axios from "axios";
import router from "./router";
export const store = createStore({
    state: {
      user: null,
    },
    mutations: {
      setUser(state, user) {
        state.user = user;
      },
      setMusician(state, musician){
        if(state.user != null){
          state.user.musician = musician;
          state.user.musicianId = musician.musicianId;
        }
      }
    },
    actions: {
      async setUser({ commit }) {
        try {
          const token = localStorage.getItem("token");
          if (token == null) {
            console.log(null);
            commit("setUser", null);
            return;
          }
          const { data: user } = await axios.get(
            "https://localhost:7234/api/Auth/Me",
            {
              headers: {
                Authorization: `Bearer ${localStorage.getItem("token")}`,
              },
            }
          );
          console.log(user);
          commit("setUser", user);
        } catch (e) {
          console.log(e);
        }
      },
      async logout({commit}){
        commit("setUser", null);
      },
      async setMusician({commit}, musician){
        commit("setMusician", musician)
      }
    },
  });