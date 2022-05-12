<script>
import { ref } from "vue";
import { HTTP } from "../api/http-common";
import StudentsItem from "../components/StudentsItem.vue";

export default {
  components: { StudentsItem },
  data() {
    return {
      date: "",
      groupes: [],
      students: [],
      errors: [],
      newGroupe: 0,
      dataRange: ref(),
      sortedGropues: [],
      searchByDisease: "",
      searchByDiseaseCount: 0,
      isSorting: 0,
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
      this.getStudyJournals();
      this.getDoctors();
    },
    dateChanged() {
      return this.date;
    },
    getStudyJournals() {
      HTTP.get(`/api/groupes`)
        .then((response) => {
          this.patients = response.data;
          return this.patients;
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },
    getStudents() {
      HTTP.get(`/api/studyJournals`)
        .then((response) => {
          this.medicines = response.data;
          return this.medicines;
        })
        .catch((e) => {
          this.errors.push(e);
        });
    },
    getGroupes() {
      HTTP.get(`/api/students`)
        .then((response) => {
          this.visits = response.data;
          console.log(this.visits.filter(this.$route.params.id));
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
    async save() {
      let response = await HTTP.post(`/api/students`, {
        groupeDate: this.groupeDate,
        groupePlace: this.groupePlace,
        student: this.student,
        doctor: this.doctor,
        studyJournal: this.studyJournal,
        diagnosis: this.diagnosis,
        recommendation: this.recommendation,
      });
      if (response.data) {
        this.$toast.success(`Created.`);
        setTimeout(this.$toast.clear, 500);
      }
    },
    getStudentsCountByDisease() {
      if (!this.searchByDisease) {
        this.$toast.error(`Input Disease name!.`);
        return;
      } 
      this.searchByDiseaseCount = this.visits.filter(
        (goupe) => groupe.diagnosis == this.searchByDisease
      ).length;
      this.searchByDiseaseCount > 0
        ? this.$toast.success(`Updated.`)
        : this.$toast.info(`No Results :(`);
    },
    getGroupesByDate() {
      if (!this.dataRange) {
        this.$toast.error(`Select search date Range.`);
      } else {
        this.isSorting = 1;
        this.sortedGroupes = this.groupes.filter(
          (visit) =>
            (new Date(groupe.groupeDate).getTime() >=
              new Date(this.dataRange[0]).getTime()) &
            (new Date(groupe.groupeDate).getTime() <=
              new Date(this.dataRange[1]).getTime())
        );
        if (this.sortedGroupes.length) {
          this.$toast.success(`Filtered.`);
        } else {
          this.$toast.error(`Nothing to show.`);
        }
      }
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
      <a href="#" class="group block max-w-xs mx-auto rounded-lg p-6 bg-white ring-1 ring-slate-900/5 shadow-lg space-y-3 hover:bg-sky-500 hover:ring-sky-500" @click="this.newStudent = 1">
      <div class="flex items-center space-x-3">
        <img src="https://img.icons8.com/nolan/64/add-to-favorites.png"/>
        <h3 class="text-slate-900 group-hover:text-white text-sm font-semibold">New Group</h3>
      </div>
      <p class="text-slate-500 group-hover:text-white text-sm">Create a new student from a Hogwards.</p>
      </a>  
    </div>
    <br>  
    <div class="py-4 flex justify-between w-4/5 m-auto">
      <span class="w-3/10">Search groupe by DateRange</span>
      <Datepicker
        class="w-2/5"
        v-model="this.dataRange"
        @cleared="this.isSorting = 0"
        range
      />
      <button
        class="w-1/5 bg-green-400 rounded-md text-white hover:bg-green-700"
        @click="getGroupesByDate"
      >
        Search
      </button>
    </div>
    <div class="py-4 flex justify-between w-4/5 m-auto">
      <span class="w-3/10">Get Patient count by disease(diagnosis)</span>
      <input
        type="text"
        v-model="this.searchByDisease"
        name="searchByDisease"
        id="searchByDisease"
        placeholder="Disease name..."
        class="w-2/5 py-2 px-4 mt-1 focus:ring-indigo-500 focus:border-indigo-500 block shadow-sm sm:text-sm border-gray-300 rounded-md"
      />
      <button
        class="w-1/5 bg-green-400 rounded-md text-white hover:bg-green-700"
        @click="getPatientsCountByDisease"
      >
        Get
      </button>
      <span class="px-4 py-5 text-center" v-if="this.searchByDiseaseCount">{{
        this.searchByDiseaseCount
      }}</span>
    </div>
    <div class="flex flex-col" v-if="!this.$route.params.id">
      <div v-if="this.sortedVisits && this.isSorting">
        <span v-for="visit in this.sortedVisits" :key="visit.id" class="w-full">
          <GroupesItem
            :data="groupe"
            :students="this.students"
          />
        </span>
      </div>
      <GroupesItem
        v-else
        v-for="groupe of this.groupes"
        :key="groupe.id"
        :data="groupe"
        :students="this.students"
      />
    </div>
    <div class="flex flex-col" v-else>
      <div>
        <span v-for="groupe in this.groupes" :key="groupe.id" class="w-full">
          <GroupesItem
            :data="groupe"
            :students="this.students"
            v-if="groupe.id == this.$route.params.id"
          />
        </span>
      </div>
    </div>

    <div
      v-if="this.newGroupe"
      class="invisible0 fixed z-10 inset-0 overflow-y-auto"
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
          <div class="mt-10 sm:mt-0">
            <div class="px-12 py-6">
              <GroupesItem
                :data="{}"
                :popup="1"
                :students="this.studens"
                @modalClose="this.modalClose()"
                @groupesRefresh="this.getGropues()"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
