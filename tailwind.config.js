/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./node_modules/flowbite/**/*.js', './**/*.{razor,html,cshtml}'],
  theme: {
    extend: {},
  },
  plugins: [
    require('@tailwindcss/container-queries'),
    require('@tailwindcss/line-clamp'),
    require('@tailwindcss/aspect-ratio'),
    require('flowbite/plugin'),
  ],
}
