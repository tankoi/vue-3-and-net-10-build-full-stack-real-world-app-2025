<template>
    <div class="bg-info rounded p-2 m-2">
        <h1>Contact Us</h1>
        <p>Please send an email to {{ email }}</p>
    </div>
</template>

<script setup>
import { ref } from 'vue';
// Composition API code can go here
const email = ref("hello@dotnetmastery.com");

</script>