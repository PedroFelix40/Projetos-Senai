const { defineConfig } = require("cypress");

module.exports = defineConfig({
  e2e: {
    baseUrl : "http://localhost:8081",

    // Definir o tamanho da tela
    viewportWidth : 414,
    viewportHeight : 896,

    testIsolation : false,
    reactNativeHotReload : true
  },
});
