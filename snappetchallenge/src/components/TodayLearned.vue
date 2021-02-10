<template>
  <div class="">
    <h4>Waar heeft mijn klas vandaag aan gewerkt?</h4>
    <ul class="list-group">
      <div v-for="(objectives, subject) in learnedToday" v-bind:key="subject" >
        <li class="list-group-item d-flex justify-content-between align-items-center" >
          {{ subject }}
          <span class="badge badge-primary badge-pill">{{ objectives.length }}</span>
        </li>
        <ul class="list-group">
          <li class="list-group-item d-flex justify-content-between align-items-center" v-for="value in objectives" v-bind:key="value"> - {{value}} </li>
        </ul>
      </div>

    </ul>
  </div>
</template>

<script>

export default {
  name: 'TodayLearned',
  props: {
    work: Object
  },
  setup (props) {
    // check if 2 dates are on the same day
    const datesAreOnSameDay = (firstDate, secondDate) =>
        firstDate.getFullYear() === secondDate.getFullYear() &&
        firstDate.getMonth() === secondDate.getMonth() &&
        firstDate.getDate() === secondDate.getDate();

    const dateToday = new Date("2015-03-24 11:30:00"); // hardcoded from the assignment
    const workToday = props.work.filter(e => datesAreOnSameDay( new Date(e.SubmitDateTime), dateToday) );

    // loop through the objects and add the subjects and learning objectives to the obj
    let learnedToday = {};
    workToday.forEach(work => {
      // check if the subject is already in the object
      if (work.Subject in learnedToday) {
        // only add learning objective if it's unique in the array
        if (!learnedToday[work.Subject].includes(work.LearningObjective)) {
          learnedToday[work.Subject].push(work.LearningObjective);
        }
      } else {
        // add new subject and objective to the obj
        learnedToday[work.Subject] = [work.LearningObjective]
      }
    });

    return {
      learnedToday
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
