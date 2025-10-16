<template>
    <div class="container">
        <div>{{ message }}</div>
        <contact name="Tankoi" phone="123123123"></contact>
    </div>
</template>

<script setup>
import ButtonCounter from './components/ButtonCounter.vue';
import Contact from './components/Contact.vue';

const message = "Hello from Composition API!";
</script>

<style></style>