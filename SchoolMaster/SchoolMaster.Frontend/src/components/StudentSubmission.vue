<template>
  <div>
    <div class="row">
      <div class="col-md-6">
        <label for="range-1">Student</label>
        <b-form-select
          v-model="selected"
          text-field="fullName"
          value-field="userId"
          :options="students"
          @change="changeStudent"
        ></b-form-select>
      </div>
    </div>
    <div class="row mt-5">
      <div class="col-md-6">
        <h5>{{ $t("Class") }}</h5>
        <submission-grid :items="classSubmissions"></submission-grid>
      </div>
      <b-spinner label="Loading ..." v-if="loading"></b-spinner>
      <div class="col-md-6" v-if="selected != null">
        <h5>{{ $t("Student") }}</h5>
        <submission-grid :items="studentSubmissions"></submission-grid>
      </div>
    </div>
  </div>
</template>

<script>
import SubmissionGrid from "../components/SubmissionGrid.vue";
import { mapActions, mapGetters } from "vuex";

export default {
  props: {
    students: {
      type: Array,
      default: function () {
        return [];
      },
    },
    classSubmissions: {
      type: Array,
      default: function () {
        return [];
      },
    },
  },
  data() {
    return {
      selected: null,
      loading: false,
    };
  },
  computed: {
    ...mapGetters(["studentSubmissions"]),
  },
  methods: {
    ...mapActions(["getStudentSubmissions"]),
    async changeStudent() {
      this.loading = true;
      await this.getStudentSubmissions(this.selected);
      this.loading = false;
    },
  },
  components: {
    SubmissionGrid,
  },
};
</script>