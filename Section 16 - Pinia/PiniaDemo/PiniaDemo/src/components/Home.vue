<template>
    <div class="text-center">
        <p>Let's play a game</p>
        <h2 class="text-primary pb-3">Current Score: {{ gameStore.getScore }}</h2>
        <span class="text-primary pb-3">Max Score: {{ gameStore.maxHealth }}</span>
        <br>
        <span class="text-success pb-3 h3" v-if="gameStore.getScore >= 100">
            You Won!
        </span>
        <span class="text-danger pb-3 h3" v-if="gameStore.getScore <= 0">
            You Lost!
        </span>
        <div class="row" v-if="gameStore.getScore < 100 && gameStore.getScore > 0">
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
        <div v-else>
            <button class="form-control btn btn-primary p-4" @click="gameStore.resetScore()">
                Reset Game
            </button>
        </div>
    </div>
</template>

<script setup>
import { useGameStore } from "@/store/gameStore";

const gameStore = useGameStore();

function increase() {
    gameStore.setNextAttack();
}
function decrease() {
    gameStore.setNextDefense();
}

function random() {
    Math.random() < 0.5 ? increase() : decrease();
}

</script>