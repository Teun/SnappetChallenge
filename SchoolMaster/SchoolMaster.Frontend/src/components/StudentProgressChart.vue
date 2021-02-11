<script>
import { Line } from "vue-chartjs";

export default {
  extends: Line,
  props: ["report"],
  computed: {
    chartData() {
      return {
        labels: this.report.average.map((a) => a.hour),
        datasets: [
          {
            label: "Max Progress",
            type: "line",
            data: this.report.maximum.map((a) => a.value),
            borderColor: "Green",
          },
          {
            label: "Avg Progress",
            type: "line",
            data: this.report.average.map((a) => a.value),
            borderColor: "Blue",
          },
          {
            label: "Min Progress",
            type: "line",
            data: this.report.minimum.map((a) => a.value),
            borderColor: "Red",
          },
        ],
      };
    },
  },
  data() {
    return {};
  },
  mounted() {
    this.renderChart(this.chartData, {
      maintainAspectRatio: false,
      responsive: true,
    });
  },
};
</script>