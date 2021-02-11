<template>
  <div class="mt-5">
    <h2>🌞 {{ $t("Daily Overview") }}</h2>
    <hr />
    <b-spinner label="Loading..." v-if="loading"></b-spinner>
    <div class="row">
      <div class="col-md-6">
        <h4>{{ $t("Progress till now") }}</h4>
        <student-progress-chart
          v-if="dailyProgress.length !== 0"
          :report="dailyProgress"
          :styles="styles"
        ></student-progress-chart>
      </div>
      <div class="col-md-6">
        <h4>{{ $t("Difficulty") }}</h4>
        <difficulty-chart
          :styles="styles"
          v-if="dailyDifficulty.length !== 0"
          :report="dailyDifficulty"
        ></difficulty-chart>
      </div>
    </div>
    <div class="row mt-5">
      <div class="col-md-12">
        <h4>{{ $t("Class/Student submissions today") }}</h4>
        <student-submission
          :classSubmissions="classSubmissions"
          :students="students"
        ></student-submission>
      </div>
    </div>
  </div>
</template>

<script>
import StudentProgressChart from "../components/StudentProgressChart.vue";
import DifficultyChart from "../components/DifficultyChart.vue";
import StudentSubmission from "../components/StudentSubmission.vue";
import { mapActions, mapGetters } from "vuex";

export default {
  data() {
    return {
      styles: {
        height: "300px",
        position: "relative",
      },
      loading: true,
    };
  },
  computed: {
    ...mapGetters([
      "dailyProgress",
      "dailyDifficulty",
      "students",
      "studentSubmissions",
      "classSubmissions",
    ]),
  },
  methods: {
    ...mapActions([
      "getProcessReport",
      "getDifficultyReport",
      "getStudents",
      "getStudentSubmissions",
      "getClassSubmissions",
    ]),
  },
  components: {
    StudentProgressChart,
    DifficultyChart,
    StudentSubmission,
  },
  async mounted() {
    this.loading = true;
    await this.getProcessReport();
    await this.getDifficultyReport();
    await this.getStudents();
    await this.getClassSubmissions();
    this.loading = false;
  },
};
</script>