import Axios from 'axios'
import exampleService from '../services/ExampleService'
import studentService from "../services/StudentServices";

let apiurl = "https://localhost:44333/";
// Axios Configuration
Axios.defaults.headers.common.Accept = 'application/json'

export default {
  exampleService: new exampleService(Axios),
  studentService: new studentService(Axios, apiurl)
};