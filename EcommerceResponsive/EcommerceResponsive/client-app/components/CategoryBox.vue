<template>
<div>
  <b-card
    tag="article"
    style="max-width: 20rem; width: 20rem;"
    class="mb-2"
  >
    <b-img
        class="card-img-top embed-responsive-item"
        v-bind:src="require(`../images/${category.sImageUrl}`)"
        rounded="top"
        alt="Top-rounded image"
    />
    <h5 class="card-title">{{ category.sName }}</h5>
    <b-card-text class="small text-muted">
      {{ category.sDescription }}
    </b-card-text>
    <b-card-text>
      {{ category.sPrice }}{{".-"}}
    </b-card-text>
    <b-button href="#" variant="primary">Buy</b-button>
  </b-card>
</div>
</template>
<script>
export default {
  name: "CategoryBox",
  props: ["category"],
  methods: {},
};
</script>

<style scoped>
.card-img-top {
  object-fit: cover;
}
</style>