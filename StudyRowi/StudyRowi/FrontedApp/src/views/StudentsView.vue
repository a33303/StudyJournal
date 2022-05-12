<script>
import { ref } from "vue";
import { HTTP } from "../api/http-common";
import StudentsItem from "../components/StudentsItem.vue";

export default {
  components: { StudentsItem },
  data() {
    return {
      date: "",
      students: [],
      errors: [],
      newStudent: 0,
      // TODO groupes: []
    };
  },
  props: ["id"],

  created() {
    this.init();
  },
  methods: {
    init() {
      this.getStudents();
      // TODO this.getGroupes();
    },
    dateChanged() {
      return this.date;
    },
    modalClose() {
      this.newStudent = 0;
    },
    // TODO getGroupes() {},
    getStudents() {
      console.log("reftrests");
      HTTP.get(`/api/students`)
        .then((response) => {
          this.students = response.data;
          return this.students;
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },
    getVisitById() {},
  },
};
</script>

<template>
  <div>
    <div class="details flex justify-center">
      <a href="#" class="group block max-w-xs mx-auto rounded-lg p-6 bg-white ring-1 ring-slate-900/5 shadow-lg space-y-3 hover:bg-sky-500 hover:ring-sky-500" @click="this.newStudent = 1">
      <div class="flex items-center space-x-3">
        <img src="https://img.icons8.com/nolan/64/add-to-favorites.png"/>
        <h3 class="text-slate-900 group-hover:text-white text-sm font-semibold">New Student</h3>
      </div>
      <p class="text-slate-500 group-hover:text-white text-sm">Create a new student from a Hogwards.</p>
      </a>  
    </div>
    <br>  
    <div class="flex flex-col" v-if="!this.$route.params.id">
      <StudentsItem
        v-for="student of this.students"
        :key="student.id"
        :data="student"
      />
    </div>
    <div class="flex flex-col" v-else>
      <span v-for="student in this.students" :key="student.id" class="w-full">
        <StudentsItem :data="student" v-if="student.id == this.$route.params.id" />
      </span>
    </div>
    <div
      v-if="this.newStudent"
      class="fixed z-10 inset-0 overflow-y-auto"
      aria-labelledby="modal-title"
      role="dialog"
      aria-modal="true"
    >
      <div
        class="flex items-end justify-center min-h-screen pt-4 px-4 pb-20 text-center sm:block sm:p-0"
      >
        <div
          class="fixed inset-0 bg-gray-500 bg-opacity-75 transition-opacity"
          aria-hidden="true"
        ></div>

        <span
          class="hidden sm:inline-block sm:align-middle sm:h-screen"
          aria-hidden="true"
          >&#8203;</span
        >
        <div
          class="relative inline-block align-bottom bg-white rounded-lg text-left overflow-hidden shadow-xl transform transition-all sm:my-8 sm:align-middle sm:max-w-lg sm:w-full"
        >
          <div class="bg-white px-4 pt-5 pb-4 sm:p-6 sm:pb-4">
            <div class="sm:flex sm:items-start">
              <StudentsItem
                :data="{}"
                :popup="1"
                @modalClose="this.modalClose()"
                @studentsRefresh="this.getStudents()"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
