<script>
    import { onMount, onDestroy } from 'svelte';
    import { Line } from 'svelte-chartjs'
    import 'chart.js/auto';
  
    let chart;
    let datasets;
    let chartdata;
    let options = {
          scales: {
            x: {
              type: 'linear',
              beginAtZero: true,
              stepSize: 1
            },
            y: {
              beginAtZero: true,
              stepSize: 1
            }
          }
        }
  
    export let data = [
      {
        SubmitDateTime: '2015-03-25T08:24:15.673',
        Subject: 'Rekenen',
        Progress: 0,
        Correct: 1,
        Domain: 'Getallen'
      },
      {
        SubmitDateTime: '2015-03-25T08:25:23.897',
        Subject: 'Rekenen',
        Progress: 0,
        Correct: 1,
        Domain: 'Getallen'
      },
      {
        SubmitDateTime: '2015-03-25T08:25:43.987',
        Subject: 'Rekenen',
        Progress: 0,
        Correct: 1,
        Domain: 'Getallen'
      },
      {
        SubmitDateTime: '2015-03-25T10:27:19.543',
        Subject: 'Spelling',
        Progress: 1,
        Correct: 1,
        Domain: 'Taalverzorging'
      },
      {
        SubmitDateTime: '2015-03-25T10:27:39.933',
        Subject: 'Spelling',
        Progress: 0,
        Correct: 1,
        Domain: 'Taalverzorging'
      },
      {
        SubmitDateTime: '2015-03-25T10:28:11.193',
        Subject: 'Spelling',
        Progress: 3,
        Correct: 1,
        Domain: 'Taalverzorging'
      },
    ];
  
    onMount(async () => {
     
      const subjects = [...new Set(data.map(item => item.Subject))]; // Get unique subjects
      console.log(subjects)
      
      datasets = await Promise.all(subjects.map(async(subject) => {
        const subjectData = data.filter(item => item.Subject === subject);
        const progress = subjectData.map(item => item.Progress);
      
        return {
          label: subject,
          data: progress,
          borderColor: getRandomColor(),
          tension: 0.1
        };
      }));
      console.log(datasets)

     chartdata = {
          labels: Array.from(Array(data.length).keys()), // Generate labels as array numbers
          datasets: datasets
        };

        console.log(chartdata)
    });
    
    function getRandomColor() {
      const letters = '0123456789ABCDEF';
      let color = '#';
      for (let i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
      }
      return color;
    }
  </script>
  
  <Line
  data={chartdata}
  width={100}
  height={50}
/>