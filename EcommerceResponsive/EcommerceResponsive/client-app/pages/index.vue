<template>
  <div class="container">
    <div class="row">
      <div class="col-12 text-center">
        <h3 class="pt-3">Product</h3>
      </div>
    </div>
    <div class="row">
      <div
        v-for="category of categories"
        :key="category.nID"
        class="col-xl-4 col-md-6 col-12 pt-3 d-flex"
      >
        <CategoryBox :category="category"> </CategoryBox>
      </div>
    </div>
  </div>
</template>
<script>
const axios = require("axios");
import CategoryBox from "../components/CategoryBox.vue";
export default {
  name: "Category",
  components: { CategoryBox },
  data() {
    return {
      baseURL: "https://localhost:44359",
      categories: [],
    };
  },
  methods: {
    async getCategories() {
      const data = { sSearch: "" };
      await axios
        .post(`${this.baseURL}/api/Category/CategoryList/`, data)
        .then((res) => {
          console.log("data", res.data);
          this.categories = res.data.data
        })
        .catch((err) => console.log(err));
    },
  },
  mounted() {
    this.getCategories();
  },
};
</script>
<style scoped></style>