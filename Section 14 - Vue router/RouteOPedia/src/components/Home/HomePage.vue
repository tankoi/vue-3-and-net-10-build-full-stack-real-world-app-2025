<template>
  <div>Home page</div>
  <button @click="goToContact">Go to Contact Page</button>
</template>

<script setup>
import { useRouter } from 'vue-router';

const router = useRouter();

function goToContact() {
  //router.push({ name: 'contact' });
  router.push('/contact');
}

</script>