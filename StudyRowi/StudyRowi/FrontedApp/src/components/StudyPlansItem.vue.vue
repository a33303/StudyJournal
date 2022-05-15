<script>
import { HTTP } from "../api/http-common";
import { createToaster } from "@meforma/vue-toaster";
import { ref } from "vue";

const toaster = createToaster({
  position: "right",
});

export default {
  data() {
    return {
      id: 0,
      name: "",
      speciality: "",
      discipline: "",
      semestr: "",
      studyTime: "",
      formExam: "",
    };
  },
  props: [
    "data",
    "popup",
    "name",
    "speciality",
    "discipline",
    "semestr",
    "studyTime",
    "formExam",
  ],
  emits: ["modalClose", "studyPlansRefresh"],
  methods: {
    async save() {
      if (!this.id) {
        let response = await HTTP.post(`/api/StudyPlans`, {
          name: this.name,
          speciality: this.speciality,
          discipline: this.discipline,
          semestr: this.semestr,
          studyTime: this.studyTime,
          formExam: this.formExam,
        });

        if (response.data) {
          this.$toast.success(`Created.`);
          this.popupCreateItem = 0;
        }
      } else {
        let response = await HTTP.put(`/api/StudyPlans/${this.id}`, {
          Id: this.id,
          name: this.name,
          speciality: this.speciality,
          discipline: this.discipline,
          semestr: this.semestr,
          studyTime: this.studyTime,
          formExam: this.formExam,
        });

        //if (response.data) {
        let instance = this.$toast.success(`Updated.`);
        //setTimeout(instance.dismiss(), 100);
        //}
      }
      this.refreshClose();
    },
    refreshClose() {
      this.$emit("studyPlansRefresh");
      this.$emit("modalClose");
    },
  },
  mounted() {
    this.popupCreateItem = this.popup ?? 0;
    this.isSingleItem = this.$route.params.id ?? false;
    this.id = this.data.id ?? 0;
    this.name = this.data.name ?? "";
    this.speciality = this.data.speciality ?? "";
    this.discipline = this.data.discipline ?? "";
    this.semestr = this.data.semestr ?? "";
    this.studyTime = this.data.studyTime ?? "";
    this.formExam = this.data.formExam ?? "";
  },
  setup() {},
};
</script>

<template>
  <div>
    {{ this.StudyPlans }}
  </div>
</template>

<style scoped></style>
