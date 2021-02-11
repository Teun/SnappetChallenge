import Vue from 'vue'
import Vuex from 'vuex'
import axios from '../plugins/axios'
Vue.use(Vuex)

const state = {
  dailyProgress: [],
  dailyDifficulty: [],
  students: [],
  classSubmissions: [],
  studentSubmissions: []
}

export default new Vuex.Store({
  state: state,
  getters: {
    dailyProgress(state) {
      return state.dailyProgress;
    },
    dailyDifficulty(state) {
      return state.dailyDifficulty;
    },
    today() {
      return new Date('2015-03-24T11:30:00Z');
    },
    students(state) {
      return state.students;
    },
    classSubmissions(state) {
      return state.classSubmissions;
    },
    studentSubmissions(state) {
      return state.studentSubmissions;
    }
  },
  mutations: {
    setTodayProcessReport(state, payload) {
      state.dailyProgress = payload;
    },
    setTodayDifficultyReport(state, payload) {
      state.dailyDifficulty = payload;
    },
    setStudents(state, payload) {
      state.students = payload;
    },
    setClassSubmissions(state, payload) {
      state.classSubmissions = payload;
    },
    setStudentSubmissions(state, payload) {
      state.studentSubmissions = payload;
    }
  },
  actions: {
    async getProcessReport({ getters, commit }) {
      let now = getters.today;
      let todayMidnight = new Date(now);
      todayMidnight.setHours(0, 0, 0, 0);

      let response = await axios.get(`/api/v1/progress?fromDate=${now.toISOString()}&endDate=${todayMidnight.toISOString()}`)
      commit('setTodayProcessReport', response.data);
    },
    async getDifficultyReport({ getters, commit }) {
      let now = getters.today;
      let todayMidnight = new Date(now);
      todayMidnight.setHours(0, 0, 0, 0);

      let response = await axios.get(`/api/v1/difficulty?fromDate=${now.toISOString()}&endDate=${todayMidnight.toISOString()}`)
      commit('setTodayDifficultyReport', response.data);
    },
    async getStudents({ commit }) {
      let response = await axios.get(`/api/v1/users`)
      commit('setStudents', response.data);
    },
    async getStudentSubmissions({ getters, commit }, userId) {
      let now = getters.today;
      let todayMidnight = new Date(now);
      todayMidnight.setHours(0, 0, 0, 0);

      let response = await axios.get(`/api/v1/users/${userId}/submissions?fromDate=${now.toISOString()}&endDate=${todayMidnight.toISOString()}`)
      commit('setStudentSubmissions', response.data);
    },
    async getClassSubmissions({ getters, commit }) {
      let now = getters.today;
      let todayMidnight = new Date(now);
      todayMidnight.setHours(0, 0, 0, 0);

      let response = await axios.get(`/api/v1/submissions?fromDate=${now.toISOString()}&endDate=${todayMidnight.toISOString()}`)
      commit('setClassSubmissions', response.data);
    }
  },
  modules: {
  }
})
