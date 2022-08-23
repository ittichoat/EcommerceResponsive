<template>
  <div class="container">
    <div class="row">
      <div class="col-12 text-center">
        <h3 class="pt-3">Product</h3>
      </div>
    </div>
    <div class="row">
      <div class="col-3"></div>
      <div class="col-6">
        <b-input-group class="mt-3">
          <b-form-input v-model="sSearch" placeholder="Search Products"></b-form-input>
          <b-input-group-append>
            <b-button variant="primary" v-on:click="getCategories">Search</b-button>
          </b-input-group-append>
        </b-input-group>
      </div>
      <div class="col-3"></div>
    </div>
    <div class="row">
      <b-card-group deck>
        <div v-for="category of categories" :key="category.nID" class="col-xl-4 col-md-6 col-12 pt-3">
          <CategoryBox :category="category"> </CategoryBox>
        </div>
      </b-card-group>
    </div>
    <div class="loader" v-if="loading"></div>
  </div>
</template>
<script>
import CategoryBox from "../components/CategoryBox.vue";
export default {
  name: "Category",
  components: { CategoryBox },
  data() {
    return {
      loading: false,
      sSearch: "",
      baseURL: "https://localhost:7174",
      categories: [],
    };
  },
  methods: {
    async getCategories() {
      this.loading = true
      const data = { sSearch: this.sSearch }
      const headers = {
        "Content-Type": "application/json",
      };
      await this.$axios.$post(`${this.baseURL}/api/Category/CategoryList/`, JSON.stringify(data), { headers })
        .then((res) => {
          //console.log("data", res.data);
          this.categories = res.data
        })
        .catch((err) =>
          console.log(err))
        .finally(() => {
          this.loading = false
        });
    },
  },
  mounted() {
    this.getCategories();
  },
};
</script>
<style scoped>
#axiosForm {
  /* Components Root Element ID */
  position: relative;
}

.loader {
  /* Loader Div Class */
  position: absolute;
  top: 0px;
  right: 0px;
  width: 100%;
  height: 100%;
  background-color: #eceaea;
  background-image: url("~@/assets/ajax-loader.gif");
  background-size: 50px;
  background-repeat: no-repeat;
  background-position: center;
  z-index: 10000000;
  opacity: 0.4;
  filter: alpha(opacity=40);
}
</style>
