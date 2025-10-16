<template>
    <div class="container">
        <div>{{ message }}</div>
        <contact name="Ben" :phone="123123123" :ownerName="contactsOwner"></contact>
        <contact name="Jessica" :phone="434343434343" :ownerName="contactsOwner" email="jessica@dotnetmastery.com">
        </contact>
    </div>
</template>

<script setup>
import Contact from './components/Contact.vue';

const message = "Hello from Composition API!";
const contactsOwner = "DotNetMastery";
</script>

<style></style>