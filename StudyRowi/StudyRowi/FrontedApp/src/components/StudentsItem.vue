<script>
import { HTTP } from "../api/http-common";

export default {
  data() {
    return {
      id: 0,
      firstName: "",
      lastName: "",
      patronymic: "",
      DateReceipt: 0,
      formStudy: "",
      groupeId: 0,
      groupe: "",
      studyJournal: "",
    };
  },
  props: ["data", "popup", "groupes"],
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
          groupeId: this.groupeId,
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
          groupeId: this.groupeId,
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
    console.log(this.data);
    this.popupCreateItem = this.popup ?? 0;
    this.isSingleItem = this.$route.params.id ?? false;
    this.id = this.data.id ?? 0;
    this.firstName = this.data.firstName ?? "";
    this.lastName = this.data.lastName ?? "";
    this.patronymic = this.data.patronymic ?? "";
    this.dateReceipt = this.data.dateReceipt ?? 0;
    this.formStudy = this.data.formStudy ?? "";
    this.groupeId = this.data.groupeId ?? 0;
  },
  setup() {},
};
</script>

<template>
  <div>
    <div>
      <div>
        <form method="POST" v-if="this.isSingleItem || this.popup">
          <div class="px-4 py-3 bg-gray-50 text-center sm:px-6">
            <h2>Карточка студета</h2>
            <br />
            <input
              type="text"
              firstName="firstName"
              id="firstName"
              class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-7 pr-12 sm:text-sm border-gray-300 rounded-md"
              placeholder="Фамилия"
              v-model="this.firstName"
            />
            <br />
            <input
              type="text"
              lastName="lastName"
              id="lastName"
              class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-7 pr-12 sm:text-sm border-gray-300 rounded-md"
              placeholder="Имя"
              v-model="this.lastName"
            />
            <br />
            <input
              type="text"
              patronymic="patronymic"
              id="patronymic"
              class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-7 pr-12 sm:text-sm border-gray-300 rounded-md"
              placeholder="Отчество"
              v-model="this.patronymic"
            />
            <br />
            <input
              type="text"
              dateReceipt="dateReceipt"
              id="dateReceipt"
              class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-7 pr-12 sm:text-sm border-gray-300 rounded-md"
              placeholder="Дата поступления"
              v-model="this.dateReceipt"
            />
            <br />
            <select
              type="text"
              formStudy="formStudy"
              id="formStudy"
              class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-7 pr-12 sm:text-sm border-gray-300 rounded-md"
              placeholder="Форма обучения"
              v-model="this.formStudy"
            >
             <option>Очная</option>
             <option>Заочная</option>
            </select>
            <br />
            <select 
            id="groupeId" 
            name="groupeId" 
            v-model="this.groupeId"
            class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-7 pr-12 sm:text-sm border-gray-300 rounded-md"
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
            <br />
            <input
              type="text"
              groupe="studyJournal"
              id="studyJournal"
              class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-7 pr-12 sm:text-sm border-gray-300 rounded-md"
              placeholder="Название журнала"
              v-model="this.studyJournal"
            />
            <br />
            <button
              type="submit"
              v-on:click.prevent="save"
              class="inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
            >
              Save
            </button>
          </div>
        </form>
        <div
          v-else
          class="details flex justify-center width-50 text-left rounded-lg p-6 bg-white ring-1 ring-slate-700/5 shadow-lg space-y-3 hover:bg-sky-50 hover:ring-sky-50"
        >
          <table  class="w-full">
              <tr class="odd:bg-white even:bg-slate-100">
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900 w-1/6"
                >
                  {{ firstName }}
                </td>
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900 w-1/6"
                >
                  {{ lastName }}
                </td>
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900  w-1/6"
                >
                  {{ patronymic }}
                </td>
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900  w-1/6"
                >
                 <select id="formStudy" name="formStudy"  class="pointer-events-none outline-none select-none" v-model="this.formStudy">
                   <option>Очная</option>
                   <option>Заочная</option>
                  </select>
                </td>
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900 w-1/6"
                >
                 <select id="groupeId" name="groupeId"  class="pointer-events-none outline-none select-none" v-model="this.groupeId">
                   <option
                      v-for="groupe of this.groupes"
                      :key="groupe.id"
                      :value="groupe.id"
                      :selected="groupe.id == this.groupe"
                    >
                      {{ groupe.name }}
                   </option>
                  </select>
                </td>
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900 w-1/6"
                >
                  {{ dateReceipt }}
                </td>
                <td
                  class="px-6 py-3  text-sm font-medium text-slate-900 w-1/6"
                >
                  {{ studyJournal }}
                </td>
                <td>
                  <a
                    :href="`/students/${this.id}`"
                    class="text-blue-400 hover:text-blue-800"
                  >
                    Профиль</a
                  >
                </td>
              </tr>
          </table>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
