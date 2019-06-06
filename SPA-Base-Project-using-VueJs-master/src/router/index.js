import Vue from 'vue'
import Router from 'vue-router'

import Default from '@/components/Default'
import ExampleIndex from '@/components/example/Index'
import ExampleView from '@/components/example/View'
import Students from "@/components/students/Index";
import StudentsCreateOrUpdate from "../components/students/CreateOUpdate.vue";

Vue.use(Router)

const routes = [
  { path: "/", name: "Default", component: Default },
  { path: "/example", name: "ExampleIndex", component: ExampleIndex },
  { path: "/example/:id", name: "ExampleView", component: ExampleView },
  { path: "/students", name: "Students", component: Students },
  {
    path: "/students/add",
    name: "StudenteCreate",
    component: StudentsCreateOrUpdate
  },
  {
    path: "/students/:id/edit",
    name: "StudenteEdit",
    component: StudentsCreateOrUpdate
  }
];

export default new Router({
  routes
})
