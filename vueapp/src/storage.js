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
      },
      setBand(state, band){
        if(state.user.musician != null){
          state.user.musician.band = band;
          state.user.musician.bandId = band.bandId
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
            "https://localhost:7234/api/auth/me",
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
      },
      async setBand({commit}, band){
        commit("setBand", band)
      }
    },
  });