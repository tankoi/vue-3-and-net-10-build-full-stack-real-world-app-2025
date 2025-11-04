<template>
  <button @click="increment">Increment</button>
  <button @click="decrement">Decrement</button>
  <p>{{ count }}</p>

  <br /><br />
  <ButtonCounter />
</template>

<script setup>
import { useCounter } from "./composables/useCounter";
import ButtonCounter from "./components/ButtonCounter.vue";

const { count, increment, decrement } = useCounter(100, 10);
</script>
