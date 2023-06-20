<script>
    import SvelteTable from "svelte-table";
    export let SubmittedAnswers;

    console.log(SubmittedAnswers)
    
    const columns = [
        {
            key: "Domein",
            title: "Domain",
            value: v => v.Domain,
            sortable: true,
        },
        {
            key: "Leer doel",
            title: "LearningObjective",
            value: v => v.LearningObjective,
            sortable: true,
        },
        {
            key: "Voortgang",
            title: "Voortgang",
            value: v => v.Progress,
            sortable: true,
        },
        {
            key: "Correct",
            title: "Correct",
            value: v => v.Correct,
            sortable: true,
        },
        {
            key: "Tijd",
            title: "Tijd",
            value: v => v.SubmitDateTime,
            sortable: true,
        },
    ];
  </script>
  
  <SvelteTable columns="{columns}" bind:rows="{SubmittedAnswers}"></SvelteTable>