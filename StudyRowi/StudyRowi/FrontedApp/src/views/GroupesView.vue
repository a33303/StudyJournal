<script>
import { ref } from "vue";
import { HTTP } from "../api/http-common";
import GroupesItem from "../components/GroupesItem.vue";

export default {
  components: { GroupesItem },
  data() {
    return {
      date: "",
      groupes: [],
      students: [],
      newGroupe: 0,
    };
  },
  props: ["id"],

  created() {
    this.init();
  },
  mounted() {},
  methods: {
    init() {
      this.getGroupes();
      this.getStudents();
    },
    dateChanged() {
      return this.date;
    },
    getGroupes() {
      HTTP.get(`/api/groupes`)
        .then((response) => {
          this.groupes = response.data;
          console.log(this.groupes);
          return this.groupes;
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },
    getStudents() {
      HTTP.get(`/api/students`)
        .then((response) => {
          this.students = response.data;
          console.log(this.students);
          return this.students;
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },
    modalClose() {
      this.newGroupe = 0;
    },
  },
};
</script>

<template>
  <div>
    <div class="details flex justify-center">
      <a
        href="#"
        class="group block max-w-xs mx-auto rounded-lg p-6 bg-white ring-1 ring-slate-900/5 shadow-lg space-y-3 hover:bg-sky-500 hover:ring-sky-500"
        @click="this.newGroupe = 1"
      >
        <div class="flex items-center space-x-3">
          <img src="https://img.icons8.com/nolan/64/user-group-man-woman.png"/>
          <h3
            class="text-slate-900 group-hover:text-white text-sm font-semibold"
          >
            Новая группа
          </h3>
        </div>
        <p class="text-slate-500 group-hover:text-white text-sm">
            Создайте новую учебную группу        
        </p>
      </a>
    </div>
    <br />
    
    <div class="flex flex-col" v-if="!this.$route.params.id">
      <GroupesItem
        v-for="groupe of this.groupes"
        :key="groupe.id"
        :students="this.students"
        :data="groupe"
        @modalClose="this.modalClose()"
        @studentsRefresh="this.getGropues()"
      />
    </div>
    <div class="flex flex-col" v-else>
      <span v-for="groupe in this.groupes" :key="groupe.id" class="w-full">
        <GroupesItem
          :data="groupe"
          :students="this.students"
          v-if="groupe.id == this.$route.params.id"
        />
      </span>
      <a href="`groupes/${this.id}`">{{ this.id }}</a>
    </div>
    <div
      v-if="this.newGroupe"
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
              <GroupesItem
                :data="{}"
                :popup="1"
                :students="this.students"
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
