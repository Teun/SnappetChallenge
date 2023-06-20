<script>
import { GraphQLClient } from 'graphql-request';
import {onMount} from 'svelte';
import { DateInput } from 'date-picker-svelte';
import Table from "./components/table.svelte"
import Chart from "./components/chart.svelte"
let selectedDate = new Date("2015-03-25T07:35:38.740")
let users = null;
const client = new GraphQLClient('/graphql'); // Replace with your GraphQL endpoint URL
const query = `
    query WorkOfTheDay($submitDateTime: String!) {
    workOfTheDay(SubmitDateTime: $submitDateTime) {
        SubmittedAnswers {
        SubmitDateTime
        Subject
        Progress
        Correct
        Domain
        LearningObjective
        }
        UserId
        UserName
    }
    }
`;

const fetchWorkOfTheDay = async (date) => {
    users = null
    console.log("fetching", date)
    try {
    const variables = { "submitDateTime": date }
    let data = await client.request(query, variables);
    users = data.workOfTheDay;
    } catch (error) {
    console.error(error); // Handle any errors
    }
};

$: fetchWorkOfTheDay(selectedDate);
    
</script>
<DateInput bind:value={selectedDate} closeOnSelection={true} />

{#if users == null}
    <p> loading...</p>

{:else if users.length == 0}
    <p>Sorry, geen data voor vandaag beschikbaar.</p>

{:else}
    <div class="leerlingen">
        {#each users as user}
            <div class="leerlingBlok">
                <img src="https://robohash.org/{user.UserId}?set=set3">
                <h1>{user.UserName}</h1>
                <h3> leerling #{user.UserId}</h3>
                <p>Laatst gewerkte domein: {user.SubmittedAnswers[user.SubmittedAnswers.length-1].Domain}</p>
                <p>totaal gemaakte opdrachten: {user.SubmittedAnswers.length-1} </p>
                <button on:click={() => {user.toggle = true}}>Bekijk gemaakte opdrachten</button>
                {#if user.toggle}
                    <dialog open>
                        <a on:click={() => {user.toggle = false}}>X</a>
                        <!-- <Chart data={user.SubmittedAnswers}></Chart> -->
                        <Table SubmittedAnswers={user.SubmittedAnswers}></Table>
                    </dialog>
                {/if}
            </div>
        {/each}
    </div>
{/if}

<style>
.leerlingen {
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    justify-content: center;
}

.leerlingBlok {
    width: 20%;
    min-width: 250px;
    margin: 10px;
    background-color: #d6ecf7;
    border-radius: 16px;
    padding: 10px;
}

.leerlingBlok img {
    width: 50%;
    margin: 0 auto;
    display: block;
}

dialog {
    border-radius: 5px;
    border-width: 1px;
    transition: all 2s;
    top: 0;
    margin: 10px auto;
}

dialog::backdrop {
    background: linear-gradient(rgba(0,0,0,0.4), rgba(0,0,0,0.7));
    animation: fade-in 1s;
}

@keyframes fade-in {
    from {
        opacity: 0;
    }
    to {
        opacity: 1;
    }
}

a {
    cursor: pointer;
}

button {
    display: block;
    padding: 5px 10px;
    border-radius: 10px;
    background-color: #34a3d7;
    border: 0;
    color: white;
    cursor: pointer;
    width: 100%;
}
</style>
    