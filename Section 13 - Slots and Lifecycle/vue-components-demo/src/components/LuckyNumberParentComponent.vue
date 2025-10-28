<template>
	<div class="bg-black text pt-3" :style="{ height: '100vh' }">
		<h1 class="text-center text-success">ContactOpedia</h1>
		<div class="container">
			<button class="btn btn-primary text-black m-2" @click="newVersion = !newVersion">Toggle Component</button>
			<button class="btn btn-primary text-black m-2" @click="newVersion = false">Lucky Number V1</button>
			<button class="btn btn-primary text-black m-2" @click="newVersion = true">Lucky Number V2</button>
			<br>
			<br>
			<!-- component will not be remounted, so it preserves its state -->
			<keep-alive :include="['LuckyNumber', 'LuckyNumberV2']">
				<component :is="currentComponent" />
			</keep-alive>
		</div>
	</div>
</template>

<script setup>
import { ref, computed } from 'vue';
import LuckyNumber from './LuckyNumber.vue';
import LuckyNumberV2 from './LuckyNumberV2.vue';

const newVersion = ref(false);

const currentComponent = computed(() => {
	return newVersion.value ? LuckyNumberV2 : LuckyNumber;
});

</script>

<style></style>
