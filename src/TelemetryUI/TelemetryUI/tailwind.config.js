/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./**/*.{razor,html,cshtml}','../TelemetryUI.Client/**/*.{razor,html,cshtml}'],
  theme: {
    extend: {},
  },
  plugins: [
    require('daisyui'),
  ],daisyui: {
    themes: [
      {
        mytheme: {
          
          "primary": "#ff00ff",
                    
          "secondary": "#ff00ff",
                    
          "accent": "#00ffff",
                    
          "neutral": "#ff00ff",
                    
          "base-100": "#fdfd99",
                    
          "info": "#0000ff",
                    
          "success": "#00ff00",
                    
          "warning": "#00ff00",
                    
          "error": "#ff0000",
                    },
      },
      "light",
      "dark",
      "cupcake",
      "bumblebee",
      "emerald",
      "corporate",
      "synthwave",
      "retro",
      "cyberpunk",
      "valentine",
      "halloween",
      "garden",
      "forest",
      "aqua",
      "lofi",
      "pastel",
      "fantasy",
      "wireframe",
      "black",
      "luxury",
      "dracula",
      "cmyk",
      "autumn",
      "business",
      "acid",
      "lemonade",
      "night",
      "coffee",
      "winter",
      "dim",
      "nord",
      "sunset",
    ],
  },
}

