<template>
    <div class="text-center">
        <p>Let's play a game</p>
        <h2 class="text-primary pb-3">Current Score: {{ gameStore.score }}</h2>
        <span class="text-primary pb-3">Max Score: {{ gameStore.maxHealth }}</span>
        <br>
        <div class="row">
            <div class="col-5 offset-1">
                <button class="btn btn-success form-control p-4" @click="increase">Increase</button>
            </div>
            <div class="col-5">
                <button class="btn btn-danger form-control p-4" @click="decrease">Decrease</button>
            </div>
            <div class="col-6 offset-3 pt-2">
                <button class="btn btn-warning form-control p-4" @click="random">Random</button>
            </div>
        </div>
    </div>
</template>

<script setup>
import { useGameStore } from "@/store/gameStore";

const gameStore = useGameStore();

function increase() {
    gameStore.score += Math.floor(Math.random() * 30) + 1;
}
function decrease() {
    gameStore.score -= Math.floor(Math.random() * 10) + 1;
}

function random() {
    Math.random() < 0.5 ? increase() : decrease();
}

</script>