check DB preferences [Hogwards]

backend - /
    npm i && dotnet build && dotnet run
frontend - /frontend-rowi-hw
    npm i && npm run dev
api url - /frontend-rowi-hw/api


DB
    student - [id, firstName, lastName, patronymic, dateReceipt, formStudy, groupeId]
    groupe - [id, name]
    studyJournal - [id, name, grade, studentId, studyPlanId]
    studyPlan - [id, name, speciality, discipline, semestr, studyTime, formExam]
------------------------------------
dotnet ef migrations add Initial
dotnet ef database update

