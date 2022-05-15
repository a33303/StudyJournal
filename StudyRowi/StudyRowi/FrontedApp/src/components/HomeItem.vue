<template>
  <div class="item">
    <div class="details flex justify-center">
      <i class="">
        <slot name="icon"></slot>
      </i>
      <h3 class="">
        <slot name="heading"></slot>
      </h3>
      <slot></slot>
    </div>
  </div>
</template>

<style scoped></style>
