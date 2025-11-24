<template>
	<div class="container p-4">
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
	destinationList: []
});


onMounted(() => {
	axios.get('http://localhost:3000/destination')
		.then(response => {
			console.log(response.data);
			destinationObj.destinationList = response.data;
		})
})

</script>