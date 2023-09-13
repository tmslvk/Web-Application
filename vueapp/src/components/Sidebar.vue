<template>
  <aside :class="`${isExpanded ? 'isExpanded' : ''}`">
    <div class="logo">
      <img
        src="../assets/logo.svg"
        alt="Vue"
      />
    </div>

    <div class="menu-toggle-wrap">
      <button
        class="menu-toggle"
        @click="ToggleMenu"
      >
        <span class="material-icons">keyboard_double_arrow_right</span>
      </button>
    </div>

    <h3>Menu</h3>
    <div class="menu">
      <router-link
        class="button"
        to="/MainPage"
      >
        <span class="material-icons">home</span>
        <span class="text">Home</span>
      </router-link>
      <router-link
        class="button"
        to="/Bands"
      >
        <span class="material-icons">groups</span>
        <span class="text">Bands</span>
      </router-link>
      <router-link
        class="button"
        to="/Profile"
      >
        <span class="material-icons">person</span>
        <span class="text">Profile</span>
      </router-link>
    </div>

    <div class="flex"></div>

    <div class="menu">
      <router-link
        class="button"
        to="/Settings"
      >
        <span class="material-icons">settings</span>
        <span class="text">Settings</span>
      </router-link>
    </div>
  </aside>
</template>

<script setup>
import { ref } from "vue";
const isExpanded = ref(localStorage.getItem("isExpanded") === "true");
const ToggleMenu = () => {
  isExpanded.value = !isExpanded.value;

  localStorage.setItem("isExpanded", isExpanded.value);
};
</script>

<style lang="scss" scoped>
aside {
  display: flex;
  flex-direction: column;
  width: calc(2rem + 2rem);
  min-height: 100vh;
  overflow: hidden;
  padding: 1rem;

  background-color: var(--dark);
  color: var(--light);

  transition: 0.4s;

  .flex {
    flex: 1 1 0;
  }

  .logo {
    margin-bottom: 1rem;

    img {
      width: 2rem;
    }
  }

  .menu-toggle-wrap {
    display: flex;
    justify-content: flex-end;
    margin-bottom: 1rem;

    position: relative;
    top: 0;
    transition: 0.2s ease-out;

    .menu-toggle {
      transition: 0.2s ease-out;

      .material-icons {
        font-size: 2rem;
        color: var(--light);
      }

      &:hover {
        .material-icons {
          color: var(--primary);
          transform: translateX(0.5rem);
        }
      }
    }
  }
  h3,
  .button .text {
    opacity: 0;
    transition: 0.3s ease-out;
  }

  h3 {
    color: var(--grey);
    font-size: 0.875rem;
    margin-bottom: 0.5rem;
    text-transform: uppercase;
  }

  .menu {
    margin: 0 -1rem;

    .button {
      display: flex;
      align-items: center;
      text-decoration: none;

      padding: 0.5rem 1rem;
      transition: 0.2s ease-out;

      .material-icons {
        font-size: 2rem;
        color: var(--light);
        transition: 0.2s ease-out;
      }

      .text {
        color: var(--light);
        transition: 0.2s ease-out;
      }

      &:hover,
      &.router-link-exact-active {
        background-color: var(--dark-alt);

        .material-icons,
        .text {
          color: var(--primary);
        }
      }

      &.router-link-exact-active {
        border-right: 5px solid var(--primary);
      }
    }
  }

  &.isExpanded {
    width: var(--sidebar-width);

    .menu-toggle-wrap {
      top: -3rem;
      .menu-toggle {
        transform: rotate(-180deg);
      }
    }

    h3,
    .button .text {
      opacity: 1;

      .button {
        .material-icons {
          margin-right: 1rem;
        }
      }
    }
  }

  @media (max-width: 768px) {
    position: fixed;
    z-index: 99;
  }
}
</style>