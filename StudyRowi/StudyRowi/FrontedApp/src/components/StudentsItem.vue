<script>
import { HTTP } from "../api/http-common";
import { createToaster } from "@meforma/vue-toaster";
import { ref } from "vue";

export default {
  data() {
    return {
      id: 0,
      firstName: "",
      lastName: "",
      patronymic: "",
      DateReceipt: 0,
      formStudy: "",
    };
  },
  props: ["data", "popup"],
  emits: ["modalClose", "studentsRefresh"],
  methods: {
    async save() {
      if (!this.id) {
        let response = await HTTP.post(`/api/students`, {
          firstName: this.firstName,
          lastName: this.lastName,
          patronymic: this.patronymic,
          dateReceipt: this.dateReceipt,
          formStudy: this.formStudy,
        //  groupe: this.groupe,
          groupId: this.groupId,
         // groupList: this.groupList
        });

        if (response.data) {
          this.$toast.success(`Created.`);
          this.popupCreateItem = 0;
        }
      } else {
        let response = await HTTP.put(`/api/students/${this.id}`, {
          Id: this.id,
          firstName: this.firstName,
          lastName: this.lastName,
          patronymic: this.patronymic,
          dateReceipt: this.dateReceipt,
          formStudy: this.formStudy,
        //  groupe: this.groupe,
          groupId: this.groupId,
         // groupList: this.groupList
        });

        this.$toast.success(`Updated.`);
      }
      this.refreshClose();
    },
    refreshClose() {
      this.$emit("studentsRefresh");
      this.$emit("modalClose");
    },
  },
  mounted() {
  //  console.log(this.popup);
    this.popupCreateItem = this.popup ?? 0;
    this.isSingleItem = this.$route.params.id ?? false;
    this.id = this.data.id ?? 0;
    this.firstName = this.data.firstName ?? "";
    this.lastName = this.data.lastName ?? "";
    this.patronymic = this.data.patronymic ?? "";
    this.dateReceipt = this.data.dateReceipt ?? 0;
    this.formStudy = this.data.formStudy ?? "";
   // this.groupe = this.data.groupe ?? "";
    this.groupId = this.data.groupId ?? 0;
   // this.groupList = [];
  },
  setup() {},
};
</script>

<template>
<div>
  <div>
    <div>
       <form method="POST"  v-if="this.isSingleItem || this.popup">
        <div class="px-4 py-3 bg-gray-50 text-center sm:px-6">
          <h2>Создание студета</h2>
          <br>
          <input 
          type="text" 
          firstName="firstName" 
          id="firstName" 
          class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-7 pr-12 sm:text-sm border-gray-300 rounded-md" 
          placeholder="Фамилия"
          v-model="this.firstName"
          >
          <br>
          <input
          type="text"
          lastName="lastName"
          id="lastName"
          class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-7 pr-12 sm:text-sm border-gray-300 rounded-md" 
          placeholder="Имя"
          v-model="this.lastName"
          />
          <br>
          <input
          type="text"
          patronymic="patronymic"
          id="patronymic"
          class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-7 pr-12 sm:text-sm border-gray-300 rounded-md" 
          placeholder="Отчество"
          v-model="this.patronymic"
          />
          <br>
          <input
          type="text"
          dateReceipt="dateReceipt"
          id="dateReceipt"
          class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-7 pr-12 sm:text-sm border-gray-300 rounded-md" 
          placeholder="Дата поступления"
          v-model="this.dateReceipt"
          />
          <br>
          <input
          type="text"
          formStudy="formStudy"
          id="formStudy"
          class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-7 pr-12 sm:text-sm border-gray-300 rounded-md" 
          placeholder="Форма обучения"
          v-model="this.formStudy"
          />
          <br>
          <input
          type="text"
          groupe="groupeId"
          id="groupeId"
          class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-7 pr-12 sm:text-sm border-gray-300 rounded-md" 
          placeholder="ID группы"
          v-model="this.groupeId"
          />
          <br>
          <button
          type="submit"
          v-on:click.prevent="save"
          class="inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
          >
            Save
          </button>
        </div>
      </form>
         <div v-else class="details flex justify-center width-50 text-left rounded-lg p-6 bg-white ring-1 ring-slate-700/5 shadow-lg space-y-3 hover:bg-sky-50 hover:ring-sky-50">
            <table class="min-w-full" >
              <tbody>
                <tr class="odd:bg-white even:bg-slate-100">
                  <td class="px-6 py-3 text-center text-sm font-medium text-slate-900">
                    {{ firstName }}
                  </td>
                  <td class="px-6 py-3 text-center text-sm font-medium text-slate-900">
                    {{ lastName }}
                  </td>
                  <td class="px-6 py-3 text-center text-sm font-medium text-slate-900">
                    {{ patronymic }}
                  </td>
                  <td class="px-6 py-3 text-center text-sm font-medium text-slate-900">
                    {{ formStudy }}
                  </td>
                   <td class="px-6 py-3 text-center text-sm font-medium text-slate-900">
                    {{ groupe }}
                  </td>
                   <td class="px-6 py-3 text-center text-sm font-medium text-slate-900">
                    {{ dateReceipt }}
                  </td>
                  <td class="px-6 py-3 text-center text-sm font-medium text-slate-900">
                    <a
                      :href="`/students/${this.id}`"
                      class="text-blue-500 hover:text-blue-900"
                      > Edit Information</a
                    >
                  </td>
                </tr>
              </tbody>
            </table>
          </div> 
     
    </div>
  </div>
</div>
 </template>

<style scoped></style>
