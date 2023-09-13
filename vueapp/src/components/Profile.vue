<template>
  <div class="block">
    <div class="block">
      <div class="box">
        <div class="profile">
          <h1 class="title"><strong>{{this.$store.state.user.username}}</strong></h1>
          <h2>Description:</h2>
          <h2>Name: <strong>{{this.$store.state.user.lastname}}</strong> <strong>{{this.$store.state.user.firstname}}</strong></h2>
          <h2>Date Of birth: <strong>{{(new Date(this.$store.state.user.dateOfBirth)).toLocaleDateString('en-GB')}}</strong></h2>
          <div class="column is-1 is-offset-5">
            <button
              class="button is-info is-outlined"
              @click="showUp"
            >Become a musician</button>
          </div>
        </div>
      </div>
      <div class="creatingMusician">
        <div
          class="card"
          v-if="componentShown == true"
        >
          <input
            v-bind:value="musician.profileInstruments"
            @input="musician.profileInstruments = $event.target.value"
            class="input"
            type="text"
            placeholder="Profile instruments"
          />
          <input
            v-bind:value="musician.yearsOfExperience"
            @input="musician.yearsOfExperience = $event.target.value"
            class="input"
            type="int"
            placeholder="Years of experience"
          />
          <input
            v-bind:value="musician.statusOfActivity"
            @input="musician.statusOfActivity = $event.target.value"
            class="input"
            type="text"
            placeholder="Status of Activity"
          />
          <input
            v-bind:value="musician.country"
            @input="musician.country = $event.target.value"
            class="input"
            type="text"
            placeholder="Country"
          />
          <input
            v-bind:value="musician.city"
            @input="musician.city = $event.target.value"
            class="input"
            type="password"
            placeholder="City"
          />
          <button
            class="button is-success is-outlined"
            @click="createMusician"
          >Create musician</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState } from "vuex";
import axios from "axios";

export default {
  computed: { ...mapState(["user"]) },
  data() {
    return {
      componentShown: false,
      musician: {
        profileInstruments: "",
        yearsOfExperience: 0,
        county: "",
        city: "",
        statusOfActivity: "",
      },
    };
  },
  methods: {
    showUp() {
      this.componentShown = !this.componentShown;
    },
    async createMusician() {
      const data = this.musician;
      const response = await axios
        .post("https://localhost:7234/api/Musician/AddMusician", data, {
          headers: {
            "Content-Type": "application/json",
            accept: "text/plain",
            Authorization: `Bearer ${localStorage.getItem("token")}`,
          },
        })
        .catch((e) => console.log(e));

      this.$store.dispatch("setMusician", response.data);

      this.$router.push("/Profile");
    },
  },
};
</script>

<style lang="scss" scoped>
.input {
  margin-top: 0.75rem;
  margin-bottom: 0.75rem;
}
</style>