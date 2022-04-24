import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'home',
    component: () => import('../views/HomeView.vue')
  },
  {
    path: '/about',
    name: 'about',
    component: () => import('../views/AboutView.vue')
  },
  {
    path: '/plan',
    name: 'studyPlan',
    component: () => import('../views/StudyPlanView.vue')
  },
  {
    path: '/journal',
    name: 'studyJournal',
    component: () => import('../views/StudyJournalView.vue')
  },
  {
    path: '/student',
    name: 'student',
    component: () => import('../views/StudentView.vue')
  },
  {
    path: '/group',
    name: 'group',
    component: () => import('../views/GroupView.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
