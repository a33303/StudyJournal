import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";
import GroupesView from "../views/GroupesView.vue";
import StudyPlansView from "../views/StudyPlansView.vue";
import StudentsView from "../views/StudentsView.vue";
import StudyJournalsView from "../views/StudyJournalsView.vue";

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      name: "home",
      component: HomeView,
    },
    {
      path: "/groupes",
      name: "groupes",
      component: GroupesView,
    },
    {
      path: "/groupes/:id",
      name: "single-groupe",
      component: GroupesView,
    },
    {
      path: "/studyPlans",
      name: "studyPlans",
      component: StudyPlansView,
    },
    {
      path: "/studyPlans/:id",
      name: "single-studyPlan",
      component: StudyPlansView,
    },
    {
      path: "/studyJournals",
      name: "studyJournals",
      component: StudyJournalsView,
    },
    {
      path: "/studyJournals/:id",
      name: "single-studyJournal",
      component: StudyJournalsView,
    },
    {
      path: "/students",
      name: "students",
      component: StudentsView,
    },
    {
      path: "/students/:id",
      name: "single-student",
      component: StudentsView,
    },
  ],
});

export default router;
