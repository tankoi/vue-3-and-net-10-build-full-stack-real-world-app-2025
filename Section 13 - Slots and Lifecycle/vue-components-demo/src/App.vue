<template>
  <button @click="increment">Increment</button>
  <button @click="decrement">Decrement</button>
  <p>{{ count }}</p>
</template>

<script setup>
import { useCounter } from "./composibles/useCounter";

const { count, increment, decrement } = useCounter();
</script>
