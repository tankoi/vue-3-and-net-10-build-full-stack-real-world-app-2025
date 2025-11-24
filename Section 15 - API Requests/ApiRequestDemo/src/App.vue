<template>
	<div v-if="destinationObj.isLoading" class="d-flex justify-content-center p-4">
		<Loader />
	</div>
	<div v-else class="container p-4 bg-white">
		<div>
			<h1 class="success text-center">TravelOPedia</h1>
			<hr>
			<table class="table table-striped table-light">
				<thead>
					<tr>
						<th>Name</th>
						<th>Days</th>
						<th>Price</th>
					</tr>
				</thead>
				<tbody>
					<tr class="table-light" v-for="destination in destinationObj.destinationList" :key="destination.id">
						<td>{{ destination.name }}</td>
						<td>{{ destination.days }}</td>
						<td>{{ destination.price }}</td>
					</tr>
				</tbody>
			</table>
		</div>
	</div>
</template>

<script setup>
import axios from 'axios';
import { reactive, onMounted } from 'vue';

const destinationObj = reactive({
	destinationList: [],
	isLoading: false
});


onMounted(() => {
	loadDestination();
})

function loadDestination() {
	destinationObj.isLoading = true;
	axios.get('http://localhost:3000/destination')
		.then(response => {
			new Promise((resolve) => {
				setTimeout(
					resolve
					, 2000);
			}).then(() => {
				console.log(response.data);
				destinationObj.destinationList = response.data;
				destinationObj.isLoading = false;
			});
		})
}


</script>
