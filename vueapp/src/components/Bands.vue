<template>
  <div class="block">
    <div class="columns is-centered">
      <div class="column is-two-thirds">
        <div class="card">
          <div class="title">Band</div>
          <h1>Here you can search your favorite bands to follow.</h1>
          <h1>Here you can create your own band.</h1>
          <h1>Here you can invite other musicians to your band.</h1>
          <h1>Here you can anounce concerts</h1>
          <div class="column is-1 is-offset-5">
            <button
              class="button is-info is-outlined"
              @click="showUp"
            >Create a band</button>
          </div>
          <div class="creatingBand">
            <div
              class="block"
              v-if="componentShown == true"
            >
              <input
                v-bind:value="band.name"
                @input="band.name = $event.target.value"
                class="input"
                type="text"
                placeholder="Name of band"
              />
              <input
                v-bind:value="band.dateOfFoundation"
                @input="band.dateOfFoundation = $event.target.value"
                class="input"
                type="date"
                placeholder="Date of foundation"
              />
              <div class="field">
                <input
                  v-bind:value="band.isActive"
                  id="switchRoundedOutlinedInfo"
                  type="checkbox"
                  name="switchRoundedOutlinedInfo"
                  class="switch is-rounded is-outlined is-info"
                  checked="checked"
                  @click="checkActive"
                >
                <label for="switchRoundedOutlinedInfo">Is your band active?</label>
              </div>
              <button
                class="button is-success is-outlined"
                @click="createBand"
              >Create band</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState } from "vuex";
import axios from "axios";

export default {
  computed: { ...mapState(["band"]) },
  data() {
    return {
      componentShown: false,
      band: {
        name: "",
        isActive: true,
        dateOfFoundation: Date.now,
      },
    };
  },
  methods: {
    showUp() {
      this.componentShown = !this.componentShown;
    },
    checkActive() {
      this.band.isActive = !this.band.isActive;
    },
    async createBand() {
      const data = this.band;
      const response = await axios
        .post("https://localhost:7234/api/bands", data, {
          headers: {
            "Content-Type": "application/json",
            accept: "text/plain",
            Authorization: `Bearer ${localStorage.getItem("token")}`,
          },
        })
        .catch((e) => console.log(e));
      console.log(response);
      this.$store.dispatch("setBand", response.data);

      this.$router.push("/Profile");
    },
  },
};
</script>

<style scoped>
.card {
  padding: 1rem;
}
.input {
  margin-top: 0.25rem;
  margin-bottom: 0.25rem;
  padding: 1rem;
}
.field {
  padding-top: 1rem;
}
.button {
  padding: 1rem;
}
.switch-paddle {
  offset: 0rem;
}
</style>