<script>
import { HTTP } from "../api/http-common";
import { ref } from "vue";

export default {
  data() {
    return {
      id: 0,
      name: "",
      student: "",
    };
  },
  props: ["data", "popup", "students"],
  emits: ["modalClose", "groupesRefresh"],
  methods: {
    async save() {
      if (!this.id) {
        let response = await HTTP.post(`/api/groupes`, {
          name: this.name,
        });

        if (response.data) {
          this.$toast.success(`Created.`);
          this.popupCreateItem = 0;
          setTimeout(this.$toast.clear, 100);
        }
      } else {
        let response = await HTTP.put(`/api/groupes/${this.id}`, {
          Id: this.id,
          name: this.name,
        });

        //if (response.data) {
        let instance = this.$toast.success(`Updated.`);
        //setTimeout(instance.dismiss(), 100);
        this.$toast.clear;
        //}
      }
      this.refreshClose();
    },
    refreshClose() {
      this.$emit("groupesRefresh");
      this.$emit("modalClose");
    },
  },
  mounted() {
    this.popupCreateItem = this.popup ?? 0;
    this.isSingleItem = this.$route.params.id ?? false;
    this.id = this.data.id ?? 0;
    this.name = this.data.name ?? "";
  },
  setup() {},
};
</script>

<template>
  <div class="mt-10 sm:mt-0 py-2">
    <span
      class="text-lg float-right cursor-pointer ml-5"
      v-if="this.popupCreateItem"
      @click="this.refreshClose()"
      >&times;</span
    >
    <div class="md:grid md:grid-cols-3 md:gap-6">
      <div class="md:col-span-1 m-auto">
        <div class="px-4 sm:px-0">
          <h3
            class="text-lg font-medium leading-6 text-gray-900"
            v-if="this.id"
          >
            <a
              :href="`/groupes/${this.id}`"
              class="text-blue-500 hover:text-blue-900"
              >Groupe #{{ this.id }}</a
            >
          </h3>
          <h3 class="text-lg font-medium leading-6 text-gray-900" v-else>
            <span>Create New Groupe</span>
          </h3>
          <p class="mt-1 text-sm text-gray-600">Профиль</p>
        </div>
      </div>
      <div class="mt-5 md:mt-0 md:col-span-2">
        <form method="POST" v-if="this.isSingleItem || this.popup">
          <input
            type="text"
            name="name"
            id="name"
            class="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-7 pr-12 sm:text-sm border-gray-300 rounded-md"
            placeholder="Наименование группы"
            v-model="this.name"
          />
          <br />
          <ul
            v-for="student in this.students"
            :key="student.id"
            :value="student.id"
          >
            <li>{{ this.student.id }}</li>
          </ul>
          <button
            type="submit"
            v-on:click.prevent="save"
            class="inline-flex justify-center py-2 px-4 border border-transparent shadow-sm text-sm font-medium rounded-md text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500"
          >
            Save
          </button>
        </form>
        <div
          v-else
          class="details flex justify-center width-50 text-left rounded-lg p-6 bg-white ring-1 ring-slate-700/5 shadow-lg space-y-3 hover:bg-sky-50 hover:ring-sky-50"
        >
          <table class="min-w-full">
            <tbody>
              <tr class="odd:bg-white even:bg-slate-100">
                <td
                  class="px-6 py-3 text-center text-sm font-medium text-slate-900"
                >
                  {{ name }}
                </td>
                <td
                  class="px-6 py-3 text-center text-sm font-medium text-slate-900"
                >
                  <a
                    :href="`/groupes/${this.id}`"
                    class="text-blue-500 hover:text-blue-900"
                  >
                    Edit Information</a
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
