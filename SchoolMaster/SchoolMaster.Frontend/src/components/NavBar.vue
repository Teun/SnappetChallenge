<template>
  <b-navbar toggleable="lg" type="dark" variant="info">
    <b-navbar-brand href="#">{{ $t("Teacher Insights") }}</b-navbar-brand>
    <b-navbar-nav class="ml-auto">
      <b-nav-item-dropdown text="Lang" right>
        <b-dropdown-item href="#" @click="changeLang('en')"
          >English</b-dropdown-item
        >
        <b-dropdown-item href="#" @click="changeLang('nl')"
          >Nederlands</b-dropdown-item
        >
      </b-nav-item-dropdown>
    </b-navbar-nav>
  </b-navbar>
</template>

<script>
export default {
  methods: {
    changeLang(lang) {
      this.$i18n.locale = lang;
    },
  },
};
</script>