<script>
 import { ApolloClient, InMemoryCache, ApolloProvider, gql } from '@apollo/client';

 const client = new ApolloClient({
  uri: 'localhost:5000/graphql',
  cache: new InMemoryCache(),
});


client
  .query({
    query: gql`
            query WorkOfTheDay($submitDateTime: String!) {
                workOfTheDay(SubmitDateTime: $submitDateTime) {
                    SubmittedAnswers {
                    SubmitDateTime
                    Subject
                    Progress
                    Domain
                    LearningObjective
                    }n
                    UserId
                }
        }
    `,
  })
  .then((result) => console.log(result));


</script>

<h1>Welcome to SvelteKit</h1>
<p>Visit <a href="https://kit.svelte.dev">kit.svelte.dev</a> to read the documentation</p>
