<template>
    <div class="bg-info rounded p-1 pb-4 m-1">
        <div class="row">
            <div class="col-6">
                <h3>Name: {{ name }}</h3>
                <p>Email: {{ email }}</p>
                <p>Phone: {{ phone }}</p>
            </div>
            <div class="col-3">
                <button @click="toggleFavorite" :class="[isFavorite ? 'btn btn-warning' : 'btn btn-success']">
                    {{ isFavorite ? 'Remove from Favorites' : 'Add to Favorites' }}
                </button>
            </div>
        </div>
        <span class="float-end small" v-if="ownerName != ''">
            *this contact information belongs to {{ ownerName }}
        </span>
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

const emit = defineEmits(['update-favorite']);

function toggleFavorite() {
    emit('update-favorite');
}

</script>