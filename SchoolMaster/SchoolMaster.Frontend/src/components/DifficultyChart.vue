<script>
import { Line } from "vue-chartjs";

export default {
  extends: Line,
  props: ["report"],
  computed: {
    chartData() {
      return {
        labels: this.report.map((a) => a.hour),
        datasets: [
          {
            label: "Average difficulty",
            type: "line",
            data: this.report.map((a) => a.value),
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