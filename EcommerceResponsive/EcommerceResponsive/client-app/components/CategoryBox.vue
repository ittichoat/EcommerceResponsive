<template>
    <b-card style="max-width: 20rem; max-height: 20rem;">
        <b-img class="card-img-top embed-responsive-item" v-bind:src="category.sImageUrl" rounded="top"
            alt="Top-rounded image" />
        <h5 class="card-title">{{ category.sName }}</h5>
        <b-card-text class="small text-muted">
            {{ category.sDescription }}
        </b-card-text>
        <b-card-text>
            {{ "$" }}{{ category.sPrice }}
        </b-card-text>
        <b-button href="#" variant="info">Buy</b-button>
    </b-card>
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