<template>
  <div class="bg-black text pt-3" :style="{ height: '100vh' }">
    <h1 class="text-center text-success">ContactOpedia</h1>
    <div class="container">
      <LuckyNumber></LuckyNumber>
      <br>
      <LuckyNumberV2></LuckyNumberV2>
    </div>
  </div>
</template>

<script setup>
import LuckyNumber from './components/LuckyNumber.vue';
import LuckyNumberV2 from './components/LuckyNumberV2.vue';
</script>

<style></style>
