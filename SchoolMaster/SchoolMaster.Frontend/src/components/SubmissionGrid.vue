<template>
  <b-table
    class="mt-4"
    striped
    hover
    :items="items"
  ></b-table>
</template>

<script>
export default {
  props: ["items"]
};
</script>