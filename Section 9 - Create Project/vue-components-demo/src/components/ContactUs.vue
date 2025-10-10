<template>
    <div class="">
        <h1>Contact Us</h1>
        <p>Please send an email to {{ email }}</p>
    </div>
</template>

<script>
import { ref } from 'vue';

export default {
    

    setup() {
        // Composition API code can go here
        const email = ref("hello@dotnetmastery.com");
        return {
            email
        }
    }
}

</script>