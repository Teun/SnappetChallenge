<template>
  <div class="container-fluid">
    <h1>Snappet</h1>

    <div class="row mt-4">
      <TodayLearned v-bind:work="work" class="col-md-5"/>
      <WorkOverview v-bind:work="work" class="col-md-7"/>
    </div>
  </div>
</template>

<script>
import WorkJSON from '../../Data/work.json'
import WorkOverview from './components/WorkOverview.vue'
import TodayLearned from "@/components/TodayLearned";

export default {
  name: 'App',
  components: {
    TodayLearned,
    WorkOverview
  },
  setup() {
    const dateToday = new Date("2015-03-24 11:30:00");
    const work = WorkJSON.filter(e => new Date(e.SubmitDateTime) <= dateToday);

    return {
      work
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin: 30px 0px;

}
</style>
<style src="@/assets/css/bootstrap.min.css"></style>
