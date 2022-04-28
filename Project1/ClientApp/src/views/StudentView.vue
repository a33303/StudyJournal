<template>
    <h1>{{message}}</h1>
    <p>Фамилия</p>
    <input type="text">
    <p>Имя</p>
    <input type="text">
    <p>Отчество</p>
    <input type="text">
    <p>Группа</p>
    <input type="text">
    <p>Дата поступления</p>
    <input type="text"><br>
    <button>Создать</button>
    <button>Очистить</button>
   <p>{{students[0]}}</p>
</template>

<script>
import axios from "axios"
export default {
    data(){
        return {
            message: "Student!",
            students: []
        }
    },

    mounted() {
        axios
            .get("/api/Students")
            .then(response => (this.students = response.data))       
    }
}
</script>
