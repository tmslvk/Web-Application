<template>
  <div>
    Page to become a musician
    <form>
      <h4>Registration of musician</h4>
      <input
        v-bind:value="musician.lastname"
        @input="musician.lastname = $event.target.value"
        class="input"
        type="text"
        placeholder="text"
      />
      <input
        v-bind:value="musician.firstname"
        @input="musician.firstname = $event.target.value"
        class="input"
        type="text"
        placeholder="text"
      />
      <input
        v-bind:value="musician.profileInstruments"
        @input="musician.profileInstruments = $event.target.value"
        class="input"
        type="text"
        placeholder="text"
      />
      <input
        v-bind:value="musician.yearsOfExperience"
        @input="musician.yearsOfExperience = $event.target.value"
        class="input"
        type="int"
        placeholder="int"
      />
      <input
        v-bind:value="musician.statusOfActivity"
        @input="musician.statusOfActivity = $event.target.value"
        class="input"
        type="text"
        placeholder="text"
      />
      <input
        v-bind:value="musician.country"
        @input="musician.country = $event.target.value"
        class="input"
        type="text"
        placeholder="text"
      />
      <input
        v-bind:value="musician.city"
        @input="musician.city = $event.target.value"
        class="input"
        type="text"
        placeholder="text"
      />
    </form>
    <button class="confirmButton">Become a musician</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      dialogVisible: false,
      musician: {
        lastname: "",
        firstname: "",
        profileInstruments: "",
        statusOfActivity: "",
        yearsOfExperience: "",
        country: "",
        city: "",
      },
    };
  },

  methods: {
    async getInfoFromProfile() {
      profileLastname = await axios.get(
        "https://localhost:7234/api/Auth/Authorize",
        data.lastname
      );
      profileFirstname = await axios.get(
        "https://localhost:7234/api/Auth/Authorize",
        data.firstname
      );
    },
  },
};
</script>

<style>
</style>