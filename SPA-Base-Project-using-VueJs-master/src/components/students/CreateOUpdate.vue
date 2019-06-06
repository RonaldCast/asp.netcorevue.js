<template>
    <div>
        <h2>{{pageTitle}}</h2>
       <el-form v-loading="loading" :model="form" :rules="rules" ref="ruleForm">
      <el-form-item label="Nombre" prop="name">
        <el-input v-model="form.name"></el-input>
      </el-form-item>
      <el-form-item label="Apellido" prop="lastName">
        <el-input v-model="form.lastName"></el-input>
      </el-form-item>
      <el-form-item label="Acerca de mí" prop="bio">
        <el-input type="textarea" v-model="form.bio"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button @click="save" type="primary">Guardar</el-button>
      </el-form-item>
    </el-form>
    </div>
</template>

<script>
export default {
  name: "StudentCrreateOrUpdate",
 data(){
     return{
        loading: false,
        form: {
            studentId: 0,
            name: null,
            lastName: null,
            bio: null
        },
        rules: {
        name: [
          { required: true, message: "Debe ingresar un nombre" },
          { min: 3, message: "Debe contener como mínimo 3 caracteres" }
        ],
        lastName: [{ required: true, message: "El apellido es requerido" }],
        bio: [{ required: true, message: "Este campo es requerido" }]
      }
     }
 },
 created(){
     if(this.$route.params.id !== undefined){
          this.get(this.$route.params.id)
     }
    

 },
 computed: {
     pageTitle(){
         return this.form.studentId === 0 ? "Nuevo estudiante" : `${this.form.lastName}, ${this.form.name}`
     }
 },
 methods:{
         get(id) {
            this.loading = true;
            this.$store.state.services.studentService
                .get(id)
                .then(r => {
                this.loading = false;
                this.form.studentId = r.data.studentId;
                this.form.name = r.data.name;
                this.form.lastName = r.data.lastName;
                this.form.bio = r.data.bio;
                })
                .catch(r => {
                this.$message({
                    message: "Ocurrió un error inesperado",
                    type: "error"
                });
        });
    },

        save() {

            this.$refs["ruleForm"].validate(valid => {
                if (valid) {
                this.loading = true;
                if(this.form.studentId > 0) {
                    this.$store.state.services.studentService
                    .update(this.form)
                    .then(r => {
                    this.loading = false;
                    this.$router.push('/students');
                    })
                    .catch(r => {
                    this.$message({
                        message: "Ocurrió un error inesperado",
                        type: "error"
                    });
                    });
                } else {
                    this.$store.state.services.studentService
                    .add(this.form)
                    .then(r => {
                        this.loading = false;
                        this.$router.push('/students');
                    })
                    .catch(r => {
                        this.$message({
                        message: "Ocurrió un error inesperado",
                        type: "error"
                        });
                    });
                }
                }
            });
            }
 }
 
};
</script>