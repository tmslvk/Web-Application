import {createRouter, createWebHistory} from 'vue-router'
import MainPage from './components/MainPage.vue'
import Bands from './components/Bands.vue'
import Profile from './components/Profile.vue'
import LoginForm from './components/LoginForm.vue'
import Musician from './components/Musician.vue'
import { store } from './storage'
import { shallowReactive } from 'vue'
import RegisterForm from './components/RegisterForm.vue'
const router = createRouter({
    linkActiveClass: 'is-active',
    history: createWebHistory(),
    routes: [
        {
            path: '/MainPage',
            name: 'MainPage',
            component: MainPage
        },
        {
            path: '/Bands',
            component: Bands
        },
        {
            path: '/Profile',
            component: Profile
        },
        {
            path: '/Login',
            name: 'Login',
            component: LoginForm,
        },
        {
            path: '/Registration',
            name: 'Registration',
            component: RegisterForm
        },
        {
            path: '/Musician',
            name: 'Musician',
            component: Musician
        }
    ]
})

router.beforeEach(async (to, from) => {
    if (
        !localStorage.getItem("token") &&
        to.name !== 'Login' && to.name !== 'Registration'
      ) {
        return { name: 'Login' }
      }
})

export default router