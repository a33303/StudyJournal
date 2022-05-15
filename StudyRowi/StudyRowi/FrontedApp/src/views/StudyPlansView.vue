<script>
import { ref } from "vue";
import { HTTP } from "../api/http-common";
import MedicinesItem from "../components/StudyPlansItem.vue.vue";

export default {
  components: { MedicinesItem },
  data() {
    return {
      medicines: "",
      name: "",
      useMethod: "",
      effects: "",
      sideEffects: "",
      errors: [],
      newMedicine: 0,
      searcSideEffecthMedicineId: 0,
    };
  },
  props: ["id"],

  created() {
    this.init();
  },
  methods: {
    init() {
      this.getMedicines();
    },
    dateChanged() {
      return this.date;
    },
    modalClose() {
      this.newMedicine = 0;
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
    getSideEffectById() {
      this.sideEffectGet = this.medicines.filter(
        (medicine) => medicine.id == this.searcSideEffecthMedicineId
      )[0].sideEffects;
    },
  },
};
</script>

<template>
  <div>
    <div class="details flex justify-center">
      <button
        class="bg-green-500 hover:bg-green-900 px-2 py-2 rounded-md flex text-white"
        @click="this.newMedicine = 1"
      >
        <i class="px-1 self-center"><DocumentationIcon /></i>
        New Medicine
      </button>
    </div>
    <div class="details flex justify-around" v-if="!this.$route.params.id">
      <span class="m-auto px-4"
        >To get medicine side effects, you need to...</span
      >
      <select
        class="w-1/5 h-12 m-auto bg-white px-4 py-4 m-auto hover:bg-green-300 rounded-md"
        @change="getSideEffectById"
        name="sideEffectByMedicine"
        id="sideEffectByMedicine"
        v-model="this.searcSideEffecthMedicineId"
      >
        <option value="0" class="" selected>... Select Medicine ...</option>
        <option
          v-for="medicine in this.medicines"
          :key="medicine.id"
          :value="medicine.id"
        >
          {{ medicine.name }}
        </option>
      </select>
      <div class="w-1/2 py-4 px-4 border-indigo-500 rounded-md">
        <label
          for="sideEffects"
          class="block text-sm font-medium text-gray-700"
        >
          Side Effects
        </label>

        <textarea
          v-model="this.sideEffectGet"
          id="sideEffects"
          name="sideEffects"
          rows="3"
          class="w-full pointer-events-none outline-none shadow-sm focus:ring-indigo-500 focus:border-indigo-500 mt-1 py-1 px-1 block sm:text-sm border border-gray-300 rounded-md"
        ></textarea>
      </div>
    </div>
    <div class="flex flex-col" v-if="!this.$route.params.id">
      <MedicinesItem
        v-for="medicine of this.medicines"
        :key="medicine.id"
        :data="medicine"
      />
    </div>
    <div class="flex flex-col 1" v-else>
      <span
        v-for="medicine in this.medicines"
        :key="medicine.id"
        class="w-full"
      >
        <MedicinesItem
          :data="medicine"
          v-if="medicine.id == this.$route.params.id"
        />
      </span>
    </div>
    <div
      v-if="this.newMedicine"
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
              <MedicinesItem
                :data="{}"
                :popup="1"
                @modalClose="this.modalClose()"
                @medicinesRefresh="this.getMedicines()"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
