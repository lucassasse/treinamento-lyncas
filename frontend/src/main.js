import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import './assets/css/style.css'

import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

import { faCartShopping, faPerson, faMagnifyingGlass } from '@fortawesome/free-solid-svg-icons'
import { faSquare } from '@fortawesome/free-regular-svg-icons'
library.add(faCartShopping, faSquare, faPerson, faMagnifyingGlass)

createApp(App).component('font-awesome-icon', FontAwesomeIcon).use(router).mount('#app')
