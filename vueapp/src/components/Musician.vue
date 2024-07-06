<template>
  <div class="columns is-mobile is-centered">
    <div class="column is-three-fifths">
      <div class="creatingMusician">
        <div class="card">
          <div class="title">Become a musician</div>

          <div class="field">
            <label class="label">Profile instruments</label>
            <input
              v-bind:value="musician.profileInstruments"
              @input="musician.profileInstruments = $event.target.value"
              class="input"
              type="text"
              placeholder="e.g. Drums"
            />
          </div>
          <div class="field">
            <label class="label">Years of experience</label>
            <input
              v-bind:value="musician.yearsOfExperience"
              @input="musician.yearsOfExperience = $event.target.value"
              class="input"
              type="int"
              placeholder="e.g. 4"
            />
          </div>
          <div class="field">
            <label class="label">Status of activity</label>
            <input
              v-bind:value="musician.statusOfActivity"
              @input="musician.statusOfActivity = $event.target.value"
              class="input"
              type="text"
              placeholder="e.g. Active"
            />
          </div>
          <div class="field">
            <label class="label">Country</label>
            <input
              v-bind:value="musician.country"
              @input="musician.country = $event.target.value"
              class="input"
              type="text"
              placeholder="e.g. Belarus"
            />
          </div>
          <div class="field">
            <label class="label">City</label>
            <input
              v-bind:value="musician.city"
              @input="musician.city = $event.target.value"
              class="input"
              type="text"
              placeholder="e.g. Minsk"
            />
          </div>
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
import axios from "axios";
import { mapState } from "vuex";
export default {
  computed: { ...mapState(["musician"]) },
  data() {
    return {
      componentShown: false,
      musician: {
        profileInstruments: "",
        yearsOfExperience: null,
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
        .post("https://localhost:7234/api/musicians", data, {
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
  padding: 0.5rem;
}
.card {
  padding: 1rem;
}
</style>