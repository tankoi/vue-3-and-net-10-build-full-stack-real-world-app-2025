<template>
    <div class="bg-info rounded p-1 m-1">
        <div class="row">
            <div class="col-12">
                <h3>Name: {{ name }}</h3>
                <p>Email: {{ email }}</p>
                <p>Phone: {{ phone }}</p>
                <p class="float-end small" v-if="ownerName != ''">
                    *this contact information belongs to {{ ownerName }}
                </p>
            </div>
        </div>
    </div>
</template>

<script setup>
const props = defineProps({
    name: {
        type: String,
        required: true,
    },
    phone: {
        type: Number
    },
    ownerName: {
        type: String
    },
    email: {
        type: String,
        required: false,
        default: "-n/a-"
    },
    isFavorite: {
        type: Boolean
    }
});

</script>