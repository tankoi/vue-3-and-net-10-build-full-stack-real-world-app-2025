<script setup></script>

<template>
  <header>
    <div class="text-ceter pt-3 text-success h3">CountOPedia</div>
    <hr>
    <div class="row">
      <div class="col-4 offset-1">
        <RouterLink class="form-control badge rounded-pill text-bg-warning p-4" to="/">Home</RouterLink>
      </div>
      <div class="col-4 offset-1">
        <RouterLink class="form-control badge rounded-pill text-bg-warning p-4" to="/info">Info</RouterLink>
      </div>
    </div>
  </header>
  <RouterView />
</template>

<style scoped></style>
