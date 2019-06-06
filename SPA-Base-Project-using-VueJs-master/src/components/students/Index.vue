<template>
    <div>
        <h2>Estudiantes</h2>
        <el-table  v-loading="loading" :data="data" style="width: 100%" >
            <el-table-column prop="name" label="Nombre" width="180" sortable> 
                <template slot-scope="scope">
                    {{scope.row.lastName }}, {{scope.row.name }}
                </template>
            </el-table-column>
            <el-table-column prop="bio" label="Biografia" width="180" sortable> </el-table-column>
            <el-table-column prop="name" label="Nombre" width="180" sortable> 
                <template slot-scope="scope">
                    <el-button type="danger" @click="remove(scope.row.studentId)">Eliminar</el-button>
                    <el-button @click="$router.push(`/students/${scope.row.studentId}/edit`)">Editar</el-button>
                </template>
            </el-table-column>
        </el-table>
    </div>
</template>

<script>
export default {
  name: "StudentIndex",
  data(){
      return{
          data : [],
          loading : false
      }
  },
  created(){
      this.getAll()
     
  },
  methods:{

      getAll(){
            this.loading = true
          this.$store.state.services.studentService
          .getAll()
          .then((r) =>{
              this.data = r.data
              this.loading = false
          })
          .catch((error) => {
              this.$message({
                  message : "Ocurrio un error inesperado",
                  type : "error"
              })
          })
      },

      remove(id) {

      this
        .$confirm("Esta seguro de realizar esta acción?", "Confirmación", {
          confirmButtonText: "Si",
          cancelButtonText: "Cancelar",
          type: "warning"
        })
        .then(() => {
          _remove();
        })
        .catch(() => {});
        let self = this
      function _remove() {
        self.$store.state.services.studentService
          .remove(id)
          .then(r => {
            self.loading = false;
            self.getAll();
          })
          .catch(r => {
            self.$message({
              message: "Ocurrió un error inesperado",
              type: "error"
            });
          });
      }
    }
  }
 
};
</script>