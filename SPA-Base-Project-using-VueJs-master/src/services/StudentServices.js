
class StudentsService {
  axios;
  baseUrl;
  constructor(axios, apiurl) {
    this.axios = axios;
    this.baseUrl = `${apiurl}student`;
  }
  get(id) {

    return this.axios.get(`${this.baseUrl}/${id}`);
  }

  getAll() {

    return this.axios.get(`${this.baseUrl}`);
  }

  add(model) {

    return this.axios.post(`${this.baseUrl}`, model);
  }

  update(model) {

    return this.axios.put(`${this.baseUrl}/${model.studentId}`, model);
  }

  remove(id) {
  console.log(id, "hola");
    return this.axios.delete(`${this.baseUrl}/${id}`);
  }
}

export default StudentsService