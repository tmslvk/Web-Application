<template>
  <form>
    <div
      class="block"
      @submit.prevent="onSubmit"
    >
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
                    v-bind:value="user.username"
                    @input="user.username = $event.target.value"
                    class="input"
                    type="text"
                    placeholder="e.g. Kiberslonyara"
                  />
                  <span class="icon is-small is-left">
                    <i class="fa-solid fa-user"></i>
                  </span>
                </p>
              </div>
            </div>
            <div class="field">
              <label class="label">Firstname</label>
              <div class="control">
                <p class="control has-icons-left has-icons-right">
                  <input
                    v-bind:value="user.firstname"
                    @input="user.firstname = $event.target.value"
                    class="input"
                    type="text"
                    placeholder="e.g. Alex"
                  />
                  <span class="icon is-small is-left">
                    <i class="fa-solid fa-f"></i>
                  </span>
                </p>
              </div>
            </div>
            <div class="field">
              <label class="label">Lastname</label>
              <div class="control">
                <p class="control has-icons-left has-icons-right">
                  <input
                    v-bind:value="user.lastname"
                    @input="user.lastname = $event.target.value"
                    class="input"
                    type="text"
                    placeholder="e.g. Romanov"
                  />
                  <span class="icon is-small is-left">
                    <i class="fa-solid fa-l"></i>
                  </span>
                </p>
              </div>
            </div>
            <div class="field">
              <label class="label">Email</label>
              <div class="control">
                <p></p>
                <p class="control has-icons-left has-icons-right">
                  <input
                    v-bind:value="user.email"
                    @input="user.email = $event.target.value"
                    class="input"
                    type="email"
                    placeholder="e.g. romanovalex@gmail.com"
                  />

                  <span class="icon is-small is-left">
                    <i class="fas fa-envelope"></i>
                  </span>
                </p>
              </div>
            </div>
            <div class="field">
              <label class="label">Password</label>
              <div class="control">
                <p class="control has-icons-left has-icons-right">
                  <input
                    v-bind:value="user.password"
                    @input="user.password = $event.target.value"
                    class="input"
                    type="password"
                    placeholder="e.g. Jebrajmykh"
                  />
                  <span class="icon is-small is-left">
                    <i class="fa-solid fa-lock"></i>
                  </span>
                </p>
              </div>
            </div>
            <div class="field">
              <label class="label">Date of birth</label>
              <div class="control">
                <p class="control has-icons-left has-icons-right">
                  <input
                    v-bind:value="user.dateOfBirth"
                    @input="user.dateOfBirth = $event.target.value"
                    class="input"
                    type="date"
                  />
                  <span class="icon is-small is-left">
                    <i class="fa-regular fa-calendar"></i>
                  </span>
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
  </form>
</template>

<script>
import axios from "axios";
import { computed } from "vue";
import { required, email, minLength } from "@vuelidate/validators";
import useVuelidate from "@vuelidate/core";
export function validName(name) {
  let validNamePattern = new RegExp("^[a-zA-Z]+(?:[-'\\s][a-zA-Z]+)*$");
  if (validNamePattern.test(name)) {
    return true;
  }
  return false;
}

export function validEmail(email) {
  let validEmailPattern = new RegExp("/^w+([.-]?w+)*@w+([.-]?w+)*(.w{2,3})+$/");
  if (validEmailPattern.test(email)) {
    return true;
  }
  return false;
}

export function validPassword(password) {
  let validEmailPattern = new RegExp(
    "/^(?=.*d)(?=.*[a-z])(?=.*[A-Z]).{8,20}$/"
  );
  if (validEmailPattern.test(password)) {
    return true;
  }
  return false;
}

export default {
  setup() {
    return { v$: useVuelidate() };
  },

  validations() {
    return {
      form: {
        firstName: {
          required,
          name_validation: {
            $validator: validName,
            $message:
              "Invalid Name. Valid name only contain letters, dashes (-) and spaces",
          },
        },
        lastName: {
          required,
          name_validation: {
            $validator: validName,
            $message:
              "Invalid Name. Valid name only contain letters, dashes (-) and spaces",
          },
        },
        email: {
          required,
          email_validation: {
            $validator: validEmail,
          },
          email,
          $message: "Invalid email. Must contains '@' and '.' symbols",
        },
        password: {
          required,
          password_validation: {
            $validator: validPassword,
            $message:
              "Password must contain at least 1 digit and 1 special symbol",
          },
        },

        username: {
          required,
          $message: "Invalid username.",
        },
      },
    };
  },

  data() {
    return {
      user: {
        username: "",
        firstname: "",
        lastname: "",
        email: "",
        password: "",
        dateOfBirth: "",
      },
    };
  },

  methods: {
    async fetchUsers() {
      try {
        console.log(this.user);
        const data = this.user;
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
        this.$router.push("/Login");
      } catch (e) {
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
</style>
