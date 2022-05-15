import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import Toaster from "@meforma/vue-toaster";
import Datepicker from "@vuepic/vue-datepicker";
import StudentsItem from "./components/StudentsItem.vue";
import HomeItem from "./components/HomeItem.vue";
import HomePage from "./components/HomePage.vue";
import Home from "./views/HomeView.vue";
import "@vuepic/vue-datepicker/dist/main.css";
import DocumentationIcon from "./components/icons/IconDocumentation.vue";
import ToolingIcon from "./components/icons/IconTooling.vue";
import EcosystemIcon from "./components/icons/IconEcosystem.vue";
import CommunityIcon from "./components/icons/IconCommunity.vue";
import SupportIcon from "./components/icons/IconSupport.vue";

const app = createApp(App);
//var cors = require('cors')
app.use(router);
app.use(Toaster, {
  // One of the options
  position: "top",
  duration: 500,
});
app.component("Datepicker", Datepicker);
app.component("HomeView", Home);
app.component("HomeItem", HomeItem);
app.component("StudentsItem", StudentsItem);
app.component("HomePage", HomePage);
app.component("DocumentationIcon", DocumentationIcon);
app.component("ToolingIcon", ToolingIcon);
app.component("EcosystemIcon", EcosystemIcon);
app.component("CommunityIcon", CommunityIcon);
app.component("SupportIcon", SupportIcon);
//app.use(cors()) // Use this after the variable declaration
app.mount("#app");
