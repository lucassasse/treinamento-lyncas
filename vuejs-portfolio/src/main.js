import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

createApp(App).use(router).mount('#app')

// start client: npm run serve
// start server: npx json-server --watch .\db\db.json"