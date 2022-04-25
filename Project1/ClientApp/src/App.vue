<template>
  <nav>
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link>
    <router-link to="/plan">StudyPlan</router-link>
    <router-link to="/journal">StudyJournal</router-link>
    <router-link to="/student">Student</router-link>
    <router-link to="/group">Group</router-link>
  </nav>
  <router-view/>
</template>

<style lang="scss">
#app {
  font-family: 'Roboto', sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;

  a {
    padding: 0 0 0 1%;
    font-weight: bold;
    color: #2c3e50;
    text-decoration: none;

    &.router-link-exact-active {
      color: #535de2;
    }
  }
}
</style>
