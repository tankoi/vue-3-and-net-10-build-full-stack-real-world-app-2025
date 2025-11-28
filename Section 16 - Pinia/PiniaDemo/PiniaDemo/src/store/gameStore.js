import { defineStore } from "pinia";
import { ref, computed } from "vue";

export const useGameStore = defineStore("gameStore", () => {
  const score = ref(50);
  const maxHealth = ref(100);
  const maxAttack = ref(30);
  const maxDefense = ref(10);

  const getScore = computed(() => score.value);
  const getWinningScore = computed(() => maxHealth.value);

  const setNextAttack = () => {
    let attack = Math.floor(Math.random() * maxAttack.value) + 1;
    console.log("attack", attack);
    score.value += attack;
  };
  const setNextDefense = () => {
    let defense = Math.floor(Math.random() * maxDefense.value) + 1;
    console.log("defense", defense);
    score.value -= defense;
  };
  const resetScore = () => {
    score.value = 50;
  };

  return {
    // state
    score,
    maxHealth,
    maxAttack,
    maxDefense,
    // getters
    getScore,
    getWinningScore,
    // actions
    setNextAttack,
    setNextDefense,
    resetScore,
  };
});
