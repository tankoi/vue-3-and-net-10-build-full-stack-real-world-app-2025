<template>
    <div class="text-center">
        <p>Let's play a game</p>
        <h2 class="text-primary pb-3">Current Score: {{ gameStore.score }}</h2>
        <span class="text-primary pb-3">Max Score: {{ gameStore.maxHealth }}</span>
        <br>
        <div class="row">
            <div class="col-5 offset-1">
                <button class="btn btn-success form-control p-4">Increase</button>
            </div>
            <div class="col-5">
                <button class="btn btn-danger form-control p-4">Decrease</button>
            </div>
            <div class="col-6 offset-3 pt-2">
                <button class="btn btn-warning form-control p-4">Random</button>
            </div>
        </div>
    </div>
</template>

<script setup>
import { useGameStore } from "@/store/gameStore";

const gameStore = useGameStore();

</script>