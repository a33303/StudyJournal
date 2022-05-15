<script>
import { ref } from "vue";
import { HTTP } from "../api/http-common";
import StudentsItem from "../components/GroupesItem.vue";

export default {
  components: { StudentsItem },
  data() {
    return {
      date: "",
      visits: [],
      doctors: [],
      medicines: [],
      patients: [],
      errors: [],
      newPatient: 0,
    };
  },
  props: ["id"],

  created() {
    this.init();
  },
  methods: {
    init() {
      this.getPatients();
    },
    dateChanged() {
      return this.date;
    },
    modalClose() {
      this.newPatient = 0;
    },
    getPatients() {
      HTTP.get(`/api/patients`)
        .then((response) => {
          this.patients = response.data;
          return this.patients;
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },

    getGroupeById() {},
  },
};
</script>

<template>
  <div></div>
</template>
