<template>
  <div id="app">
    <Navbar></Navbar>
    <div class="container">
      <Dashboard></Dashboard>
    </div>
  </div>
</template>

<script>
import Dashboard from "./views/Dashboard.vue";
import Navbar from "./components/NavBar.vue";

export default {
  name: "App",
  components: {
    Dashboard,
    Navbar,
  },
};
</script>
