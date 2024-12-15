<template>
  <div id="app">
    <router-view></router-view>
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link
      href="https://fonts.googleapis.com/css2?family=Jost:ital,wght@0,100..900;1,100..900&display=swap"
      rel="stylesheet"
    />
  </div>
</template>

<script>
export default {
  name: "App",
};
</script>

<style>
:root {
  font-family: "Jost", sans-serif;
}
</style>
