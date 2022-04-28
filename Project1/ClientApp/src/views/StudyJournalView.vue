<template>
    <h1>{{message}}</h1>
    <p></p>
</template>

<script>
import axios from "axios"
export default {
    data(){
        return {
            message: "StudyJournal!",
            students: []
        }
    },

    mounted() {
        axios
            .get("/api/Students")
            .then(function (response) {
              this.students = response.data;
            })       
    }
}
</script>