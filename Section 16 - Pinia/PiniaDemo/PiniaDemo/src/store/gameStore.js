import { defineStore } from "pinia";

export const useGameStore = defineStore("gameStore", {
    state: () => ({
        score: 0,
        maxHealth: 100,
        maxAttack: 30,
        maxDefense: 10,
    })
});