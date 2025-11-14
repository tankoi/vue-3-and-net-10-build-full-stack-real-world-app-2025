<template>
	<div>RequestOPedia</div>
	<hr>
	<div v-for="user in userObj.users" :key="user.id">
		<p>{{ user.name }}</p>
		<p>{{ user.email }}</p>
		<hr>
	</div>
</template>

<script setup>
import axios from 'axios';
import { reactive, onMounted } from 'vue';

const userObj = reactive({
	users: []
});


onMounted(() => {
	axios.get('https://jsonplaceholder.typicode.com/users')
		.then(response => {
			console.log(response.data);
			userObj.users = response.data;
		})
		.catch(error => {
			console.error('There was an error!', error);
		});
})

</script>