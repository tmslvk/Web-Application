<template>
  <div class="block">
    <div class="columns is-mobile is-centered">
      <div class="column is-half">
        <form>
          <div class="title">
            <h1>Sign up</h1>
          </div>
          <div class="field">
            <label class="label">Username</label>
            <div class="control">
              <p class="control has-icons-left has-icons-right">
                <input
                  v-bind:value="setupState.user.username"
                  @input="setupState.user.username = $event.target.value"
                  class="input"
                  type="text"
                  placeholder="e.g. Kiberslonyara"
                />
                <span class="icon is-small is-left">
                  <i class="fa-solid fa-user"></i>
                </span>
              </p>
              <p
                class="help is-danger"
                v-if="v$.user.username.$error"
              >
                {{v$.user.username.$errors[0].$message}}
              </p>
            </div>
          </div>
          <div class="field">
            <label class="label">Firstname</label>
            <div class="control">
              <p class="control has-icons-left has-icons-right">
                <input
                  v-bind:value="setupState.user.firstname"
                  @input="setupState.user.firstname = $event.target.value"
                  class="input"
                  type="text"
                  placeholder="e.g. Alex"
                />
                <span class="icon is-small is-left">
                  <i class="fa-solid fa-f"></i>
                </span>
              </p>
              <p
                class="help is-danger"
                v-if="v$.user.firstname.$error"
              >
                {{v$.user.firstname.$errors[0].$message}}
              </p>
            </div>
          </div>
          <div class="field">
            <label class="label">Lastname</label>
            <div class="control">
              <p class="control has-icons-left has-icons-right">
                <input
                  v-bind:value="setupState.user.lastname"
                  @input="setupState.user.lastname = $event.target.value"
                  class="input"
                  type="text"
                  placeholder="e.g. Romanov"
                />
                <span class="icon is-small is-left">
                  <i class="fa-solid fa-l"></i>
                </span>
              </p>
              <p
                class="help is-danger"
                v-if="v$.user.lastname.$error"
              >
                {{v$.user.lastname.$errors[0].$message}}
              </p>
            </div>
          </div>
          <div class="field">
            <label class="label">Email</label>
            <div class="control">
              <p class="control has-icons-left has-icons-right">
                <input
                  v-bind:value="setupState.user.email"
                  @input="setupState.user.email = $event.target.value"
                  class="input"
                  type="email"
                  placeholder="e.g. romanovalex@gmail.com"
                />
                <span class="icon is-small is-left">
                  <i class="fas fa-envelope"></i>
                </span>
              </p>
              <p
                class="help is-danger"
                v-if="v$.user.email.$error"
              >
                {{v$.user.email.$errors[0].$message}}
              </p>
            </div>
          </div>
          <div class="field">
            <label class="label">Password</label>
            <div class="control">
              <p class="control has-icons-left has-icons-right">
                <input
                  v-bind:value="setupState.user.password"
                  @input="setupState.user.password = $event.target.value"
                  class="input"
                  type="password"
                  placeholder="e.g. Jebrajmykh"
                />
                <span class="icon is-small is-left">
                  <i class="fa-solid fa-lock"></i>
                </span>
              </p>
              <p
                class="help is-danger"
                v-if="v$.user.password.$error"
              >
                {{v$.user.password.$errors[0].$message}}
              </p>
            </div>
          </div>
          <div class="field">
            <label class="label">Date of birth</label>
            <div class="control">
              <p class="control has-icons-left has-icons-right">
                <input
                  v-bind:value="setupState.user.dateOfBirth"
                  @input="setupState.user.dateOfBirth = $event.target.value"
                  class="input"
                  type="date"
                />
                <span class="icon is-small is-left">
                  <i class="fa-regular fa-calendar"></i>
                </span>
              </p>
              <p
                class="help is-danger"
                v-if="v$.user.dateOfBirth.$error"
              >
                {{v$.user.dateOfBirth.$errors[0].$message}}
              </p>
            </div>
          </div>
        </form>
        <div class="field is-grouped is-grouped-right">
          <button
            class="button is-link is-right"
            @click="fetchUsers"
          >Sign up</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import { computed, reactive } from "vue";
import useVuelidate from "@vuelidate/core";
import { required, minLength, email } from "@vuelidate/validators";

export default {
  setup() {
    const setupState = reactive({
      user: {
        username: "",
        firstname: "",
        lastname: "",
        email: "",
        password: "",
        dateOfBirth: "",
      },
    });

    const rules = computed(() => {
      return {
        user: {
          username: { required, minLength: minLength(5) },
          firstname: { required },
          lastname: { required },
          email: { required, email },
          password: { required, minLength: minLength(8) },
          dateOfBirth: { required },
        },
      };
    });

    const v$ = useVuelidate(rules, setupState);

    return {
      setupState,
      v$,
    };
  },

  methods: {
    async fetchUsers() {
      try {
        setTimeout(() => this.v$.$validate(), 1000);
        console.log(this.setupState.user);
        const data = { ...this.setupState.user };
        data.dateOfBirth = new Date(data.dateOfBirth).toISOString();
        const response = await axios
          .post("https://localhost:7234/api/Auth/Registration", data, {
            headers: {
              "Content-Type": "application/json",
              accept: "text/plain",
            },
          })
          .catch((e) => console.log(e));
        console.log(response);
        localStorage.setItem("token", response.data);

        this.$store.dispatch("setUser");

        this.$router.push("/MainPage");
      } catch (e) {
        console.log(e);
        alert("Error");
      }
    },
  },
};
</script>

<style scoped>
.button {
  margin-top: 1rem;
}

.valid {
  color: lightgreen;
}

.inValid {
  color: lightcoral;
}
</style>
