<template>
    <div class="bg-info rounded p-2 m-2">
        <h3>Name: {{ name }}</h3>
        <p>Email: {{ email }}</p>
        <p>Phone: {{ phone }}</p>
    </div>
</template>

<script setup>
import { ref, defineProps } from 'vue';
// Composition API code can go here
const email = ref("hello@dotnetmastery.com");
const props = defineProps(['name', 'phone']);

</script>