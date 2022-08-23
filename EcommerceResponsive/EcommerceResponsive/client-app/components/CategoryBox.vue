<template>
    <b-card name="CategoryBox">
        <b-img class="card-img-top embed-responsive-item" style="height: 20rem;" v-bind:src="category.sImageUrl"
            rounded="top" alt="Top-rounded image" />
        <h5 class="card-title">{{ category.sName }}</h5>
        <b-card-text class="small text-muted truncate-overflow" style="height: 10rem;">
            {{ category.sDescription }}
        </b-card-text>
        <b-card-text>
            {{ "$" }}{{ category.sPrice }}
        </b-card-text>
        <b-button href="#" variant="info">Buy</b-button>
    </b-card>
</template>
<script>
import { BButton, BCardText, BImg, BCard } from 'bootstrap-vue'
export default {
    name: "CategoryBox",
    props: ["category"],
    methods: {},
    components: {
      'b-button': BButton,
      'b-card-text': BCardText,
      'b-img': BImg,
      'b-card': BCard,
    }
};
</script>

<style scoped>
.card-img-top {
    object-fit: cover;
}

.truncate-overflow {
    --max-lines: 3;
    position: relative;
    max-height: calc(var(--lh) * var(--max-lines));
    overflow: hidden;
    padding-right: 1rem;
    /* space for ellipsis */
}
</style>