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
      groupes: [],
      filterGroupes: 0,
      sortedGroupes: [],
      errors: [],
      newStudent: 0,
    };
  },
  props: ["id"],

  created() {
    this.init();
  },
  methods: {
    init() {
      this.getStudents();
      this.getGroupes();
    },
    dateChanged() {
      return this.date;
    },
    modalClose() {
      this.newStudent = 0;
    },
    filterStudentsByGroupe() {
     let sortedGroupes = this.students.filter(
          (student) =>
            (student.groupeId == this.filterGroupes )  );
            this.sortedGroupes = sortedGroupes;
    console.log(sortedGroupes);
    },

    ClearfilterStudentsByGroupe() {
       let sortedGroupes = this.students.remove(
         this.students = response.data
       );
       this.sortedGroupes = sortedGroupes;
    },
    getStudents() {
      console.log("reftrests");
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
    getGroupes() {
      HTTP.get(`/api/groupes`)
        .then((response) => {
          this.groupes = response.data;
          return this.groupes;
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
    <div class="details flex justify-center">
      <a
        href="#"
        class="group block max-w-xs mx-auto rounded-lg p-6 bg-white ring-1 ring-slate-900/5 shadow-lg space-y-3 hover:bg-sky-500 hover:ring-sky-500"
        @click="this.newStudent = 1"
      >
        <div class="flex items-center space-x-3">
          <img src="https://img.icons8.com/nolan/64/add-to-favorites.png" />
          <h3
            class="text-slate-900 group-hover:text-white text-sm font-semibold"
          >
            Новый Студент
          </h3>
        </div>
        <p class="text-slate-500 group-hover:text-white text-sm">
          Создайте нового студента в Хогвардс.
        </p>
      </a>
    </div>
    <br>
    <div name="filter" class="col-span-6 sm:col-span-3">
      <label for="country" class="block text-sm font-medium text-gray-700">Выберите группу для фильтрации</label>
      <select 
      id="groupeFilter" 
      name="groupeFilter" 
      v-model="this.filterGroupes"
      class="mt-1 block w-full py-2 px-3 border border-gray-300 bg-white rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
      >
        <option
          v-for="groupe of this.groupes"
          :key="groupe.id"
          :value="groupe.id"
          :selected="groupe.id == this.groupe"
        >
          {{ groupe.name }}
        </option>
      </select>
    </div>
    <br>
    <div>
       <button 
       class="inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
      @click.prevent="this.filterStudentsByGroupe()"
      >Поиск 
      </button>
      <button 
       class="inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-yellow-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
      @click.prevent="this.ClearfilterStudentsByGroupe()"
      > Очистить 
      </button>
    </div>
    <br />
    <table class="w-full">
        <tr class="odd:bg-white even:bg-slate-100">
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900  w-1/6"
                >
                  Фамилия
                </td>
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900  w-1/6"
                >
                  Имя
                </td>
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900  w-1/6"
                >
                  Отчество
                </td>
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900  w-1/6"
                >
                  Форма обучения
                </td>
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900  w-1/6"
                >
                  Группа
                </td>
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900  w-1/6"
                >
                  Дата поступления
                </td>
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900  w-1/6"
                >
                  Учебный журнал
                </td>
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900  w-1/6"
                >
                  Карточка студента
                </td>
              </tr>
    </table>
    
    <div class="flex flex-col" v-if="!this.$route.params.id">
      <StudentsItem
        v-for="student of this.students"
        :key="student.id"
        :data="student"
        :groupes="this.groupes"
        :formStudy="this.formStudy"
        @modalClose="this.modalClose()"
        @studentsRefresh="this.getStudents()"
      />
    </div>
    <div class="flex flex-col" v-else-if="this.sortedGroupes">
      <StudentsItem
        v-for="student of this.sortedGroupes"
        :key="student.id"
        :data="student"
        :groupes="this.groupes"
        :formStudy="this.formStudy"
        @modalClose="this.modalClose()"
        @studentsRefresh="this.getStudents()"
      />
    </div>
    <div class="flex flex-col" v-else>
      <span v-for="student in this.students" :key="student.id" class="w-full">
        <StudentsItem
          :data="student"
          :groupes="this.groupes"
          :formStudy="this.formStudy"
          v-if="student.id == this.$route.params.id"
        />
      </span>
      <a href="`/students/${this.id}`">{{ this.id }}</a>
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
                :groupes="this.groupes"
                :formStudy="this.formStudy"
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
