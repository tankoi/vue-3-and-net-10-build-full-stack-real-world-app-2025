<template>
    <div class="bg-info rounded p-4 m-2">
        <h3>Name: {{ name }}</h3>
        <p>Email: {{ email }}</p>
        <p>Phone: {{ phone }}</p>
        <p class="float-end small" v-if="ownerName != ''">
            *this contact information belongs to {{ ownerName }}
        </p>
    </div>
</template>

<script setup>
import { ref, defineProps } from 'vue';
// Composition API code can go here
const email = ref("hello@dotnetmastery.com");
const props = defineProps({
    name: {
        type: String
    },
    phone: {
        type: Number
    },
    ownerName: {
        type: String
    }
});

</script>