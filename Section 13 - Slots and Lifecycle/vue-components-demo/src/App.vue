<template>
  <h1>{{ message }}</h1>
  <button @click="showMessage">Show Message</button>
  <br />
  <h1>{{ count }}</h1>
  <button @click="count++">Clicked {{ count }} times</button>
  <ButtonCounter v-if="count == 1" />
</template>

<script setup>
import ButtonCounter from "./components/ButtonCounter.vue";
import {
  ref,
  onBeforeMount,
  onMounted,
  onBeforeUpdate,
  onUpdated,
  onBeforeUnmount,
  onUnmounted,
} from "vue";

const message = ref("Hello Vue");
const showMessage = () => {
  message.value = "Hello Vue from function";
};
const count = ref(0);

onBeforeMount(() => {
  console.log("onBeforeMount - App.vue");
});
onMounted(() => {
  console.log("onMounted - App.vue");
});
onBeforeUpdate(() => {
  console.log("onBeforeUpdate - App.vue");
});
onUpdated(() => {
  console.log("onUpdated - App.vue");
});
onBeforeUnmount(() => {
  console.log("onBeforeUnmount - App.vue");
});
onUnmounted(() => {
  console.log("onUnmounted - App.vue");
});
</script>
