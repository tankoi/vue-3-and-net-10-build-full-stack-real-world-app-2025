<template>
    <div class="container">
        <div>{{ message }}</div>
        <contact name="Tankoi" :phone="123123123" :ownerName="contactsOwner"></contact>
    </div>
</template>

<script setup>
import Contact from './components/Contact.vue';

const message = "Hello from Composition API!";
const contactsOwner = "DotNetMastery";
</script>

<style></style>