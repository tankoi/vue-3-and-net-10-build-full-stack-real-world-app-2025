<template>
    <div class="container">
        <div>{{ message }}</div>
        <contact-us></contact-us>
    </div>
</template>

<script setup>
import ButtonCounter from './components/ButtonCounter.vue';
import ContactUs from './components/ContactUs.vue';

const message = "Hello from Composition API!";
</script>

<style></style>