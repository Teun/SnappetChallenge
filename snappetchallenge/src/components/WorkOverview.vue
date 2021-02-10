<template>
  <div class="">
    <h4>Overview</h4>
    <p></p>
    <p>Bekijk de klassikale score per vak per dag. <br>
      <small><em>LETOP: -1 betekent dat er geen werk is verricht voor dat vak.</em></small></p>
    <canvas id="chart"></canvas>
  </div>
</template>

<script>
import { onMounted } from 'vue'
import Chart from 'chart.js';
import RandomColor from '../utils/RandomColor';

export default {
  name: 'WorkOverview',
  components: {},
  props: {
    work: Object
  },
  setup (props) {
    const datesGrouped = [...new Set(props.work.map(e => new Date(e.SubmitDateTime).toLocaleDateString()))];
    const subjectGrouped = [...new Set(props.work.map(e => e.Subject))];

    // create an array containing objects for the chart.js
    const datasets = subjectGrouped.map(subject => {
      let data = [];

      // we will calculate the score for each day for this subject
      datesGrouped.forEach((date) => {
        let totalScore = 0;
        let score = 0;

        props.work.forEach((e) => {
          if (e.Subject === subject && new Date(e.SubmitDateTime).toLocaleDateString() === date) {
            let parsedDiff = parseFloat(e.Difficulty);

            // there are some diffuculty set to NULL.
            if (isNaN(parsedDiff)) {
              return;
            }

            // we will add the difficulty of an answer to the total score
            totalScore += parsedDiff;

            // add or subtract diff from score based on correct or incorrect answer
            if (e.Correct > 0) {
              score += parsedDiff;
            } else {
              score -= parsedDiff;
            }
          }
        });

        // calculate score percentage by dividing the total score from the actual score (based on answers) times 100
        data.push(score !== 0 && totalScore !== 0 ? (score / totalScore * 100).toFixed(1) : -1); // we can't divide 0 with 0 (becomes NaN)
      });

      // return the dataset object for this subject
      return {
        label: subject,
        data,
        backgroundColor: RandomColor(),
        borderColor: '#000',
        borderWidth: 3
      }
    });

    onMounted(() => {
      const chartElement = document.getElementById('chart');

      // create the chart and assign it to the chartElement
      new Chart(chartElement, {
        type: 'bar',
        data: {
          labels: datesGrouped,
          datasets,
        },
        options: {
          scales: {
            yAxes: [{
              ticks: {
                beginAtZero: true,
                suggestedMax: 100,
                callback: function(value) {
                  return value+'%';
                }
              }
            }]
          },
          tooltips: {
            enabled: true,
            mode: 'single',
            callbacks: {
              label: function (tooltipItems) {
                return tooltipItems.yLabel + " %";
              }
            }
          }
        },
      });
    })

    return {}
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
