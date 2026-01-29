import './style.css'
//---requerir un modulo
//import './topic/01-basic-types'
//import './topic/02-object-interface'
import './topic/03-functions'

const app = document.querySelector<HTMLDivElement>('#app')!;

app.innerHTML = `
  <h1>Hello Vite + TypeScript!</h1>
  <a href="https://vitejs.dev/guide/features.html" target="_blank">Documentation</a>
`
console.log('Hello Vite + TypeScript! AJAJA');