<script>
import { HTTP } from "../api/http-common";
import { ref } from "vue";

export default {
  data() {
    return {
      id: 0,
      name: "",
      grade: "",
      studentId: "",
      groupe: "",
      studyPlansId: "",
    };
  },
  props: ["data", "popup", "student", "groupe", "studyPlans"],
  emits: ["modalClose", "StudyJournalRefresh"],
  methods: {
    async save() {
      if (!this.id) {
        let response = await HTTP.post(`/api/studyJournals`, {
          name: this.name,
          grade: this.grade,
          studentId: this.studentId,
          studyPlanId: this.studyPlanId,
        });

        if (response.data) {
          this.$toast.success(`Created.`);
          this.popupCreateItem = 0;
        }
      } else {
        let response = await HTTP.put(`/api/studyJournals/${this.id}`, {
          Id: this.id,
          studyPlanId: this.studyPlan,
          studentId: this.studentId,
          groupe: this.groupe,
          name: this.name,
          grade: this.grade,
        });
        //if (response.data) {
        this.$toast.success(`Updated.`);
        //}
      }
      this.refreshClose();
    },
    refreshClose() {
      this.$emit("StudyJournalRefresh");
      this.$emit("modalClose");
    },
  },
  mounted() {
    this.popupCreateItem = this.popup ?? 0;
    this.isSingleItem = this.$route.params.id ?? false;
    this.id = this.data.id ?? 0;;
    this.studyPlan = this.data.studyPlan ?? 0;
    this.studentId = this.data.studentId ?? 0;
    this.groupe = this.data.groupe ?? 0;
    this.name = this.data.name ?? "";
    this.grade = this.data.grade ?? "";
  },
  setup() {},
};
</script>

<template>
 <div>
   {{ this.StudyJournals.Name }}
 </div>
</template>

<style scoped></style>
