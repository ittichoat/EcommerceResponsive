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
  </div>
</template>
<script>
import CategoryBox from "../components/CategoryBox.vue";
export default {
  name: "Category",
  components: { CategoryBox },
  data() {
    return {
      sSearch: "",
      baseURL: "https://localhost:7174",
      categories: [],
    };
  },
  methods: {
    async getCategories() {
      const data = { sSearch: this.sSearch };
      const headers = { 
        "Content-Type": "application/json",
        "Allow-Control-Allow-Origin": "*"
      };
      await this.$axios.$post(`${this.baseURL}/api/Category/CategoryList/`, JSON.stringify(data), {headers})
        .then((res) => {
          //console.log("data", res.data);
          this.categories = res.data
        })
        .catch((err) => console.log(err));
    },
    // async getCategories() {
    //   const data = { sSearch: this.sSearch };
    //   const requestOptions = {
    //     method: "POST",
    //     headers: { "Content-Type": "application/json" },
    //     body: JSON.stringify(data)
    //   };
    //   const response = await fetch(`${this.baseURL}/api/Category/CategoryList/`, requestOptions);
    //   this.categories  = await response.json().data;
    // },
  },
  mounted() {
    this.getCategories();
  },
};
</script>
<style scoped>
</style>
