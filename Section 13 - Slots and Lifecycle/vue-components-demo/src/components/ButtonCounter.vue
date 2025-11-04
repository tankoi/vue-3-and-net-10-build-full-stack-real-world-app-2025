<template>
  <button @click="increment">++</button>
  <span>{{ count }}</span>
  <button @click="decrement">--</button>
</template>

<script setup>
import { useCounter } from "../composables/useCounter";

const { count, increment, decrement } = useCounter();
</script>
