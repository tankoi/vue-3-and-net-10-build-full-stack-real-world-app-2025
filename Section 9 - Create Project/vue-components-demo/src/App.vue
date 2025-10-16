<template>
    <div class="container">
        <div>{{ message }}</div>
        <div class="row">
            <div class="col-12" v-for="contact in contacts" :key="contact.name">
                <contact :name="contact.name" :phone="contact.phone" :email="contact.email"
                    :ownerName="contact.ownerName" :isFavorite="contact.isFavorite"></contact>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref, reactive } from 'vue';
import Contact from './components/Contact.vue';

const message = "Hello from Composition API!";
const ownerName = ref("DotNetMastery");
const contacts = reactive([{
    name: "Bhrugen",
    phone: 123123123,
    ownerName: ownerName.value,
    isFavorite: false,
},
{
    name: "Bella",
    phone: 434343434343,
    ownerName: ownerName.value,
    isFavorite: true,
},
{
    name: "Charlie",
    phone: 777777777,
    ownerName: ownerName.value,
    email: "ben@dotnetmastery.com",
    isFavorite: false,
}]);
</script>

<style></style>