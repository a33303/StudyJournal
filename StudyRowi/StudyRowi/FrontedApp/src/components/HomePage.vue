<script>
import { ref } from "vue";
import { HTTP } from "../api/http-common";
import VisitsItem from "./StudyJounalsItem.vue";

export default {
  components: { VisitsItem },
  data() {
    return {
      date: "",
      visits: [],
      doctors: [],
      medicines: [],
      patients: [],
      errors: [],
    };
  },
  props: ["msg"],

  created() {
    this.init();
  },
  methods: {
    init() {
      this.getPatients();
      this.getVisits();
      this.getMedicines();
      this.getDoctors();
    },
    dateChanged() {
      return this.date;
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
    getMedicines() {
      HTTP.get(`/api/medicines`)
        .then((response) => {
          this.medicines = response.data;
          return this.medicines;
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },
    getVisits() {
      HTTP.get(`/api/visits`)
        .then((response) => {
          this.visits = response.data;
          return this.visits;
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },
    getDoctors() {
      HTTP.get(`/api/doctors`)
        .then((response) => {
          this.doctors = response.data;
          return this.doctors;
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },
  },
};
</script>

<template>
  <div>
    <h1>Hello World</h1>
  </div>
</template>
