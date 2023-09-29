<template>
  <div class="creatingMusician">
    <div class="card">
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
        type="text"
        placeholder="City"
      />
      <button
        class="button is-success is-outlined"
        @click="createMusician"
      >Create musician</button>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import { mapState } from "vuex";
export default {
  computed: { ...mapState(["musician"]) },
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