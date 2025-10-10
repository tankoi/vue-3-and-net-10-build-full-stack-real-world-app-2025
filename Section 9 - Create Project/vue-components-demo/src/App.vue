<template>
    <div>{{ message }}</div>
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