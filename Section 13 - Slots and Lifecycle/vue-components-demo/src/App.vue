<template>
  <LuckyNumberParentComponent>
    <p class="pt-2">We have two version for picking lucky numbers</p>
    <p>Click the buttons above to switch between versions.</p>
    <button @click="showMessage">What will we learn?</button>
    <h4 class="text-success">{{ message }}</h4>
    <hr>
  </LuckyNumberParentComponent>
</template>

<script setup>
import LuckyNumberParentComponent from './components/LuckyNumberParentComponent.vue';
import { ref } from 'vue';

const message = ref('');

function showMessage() {
  message.value = 'We will learn how to use slots';
}
</script>