<template>
    <div>{{ message }}</div>
    <contact-us></contact-us>
    <button-counter></button-counter>
</template>

<script>

export default {
    setup() {
        // Composition API code can go here
        const message = "Hello from Composition API!";

        return {
            message
        }
    }
}

</script>

<style>



</style>