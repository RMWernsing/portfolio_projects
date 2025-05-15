<script setup>
import { Story } from '@/models/Story.js';


defineProps({
  story: { type: Story, required: true }
})

</script>


<template>
  <div>
    {{ story.title }}
  </div>
</template>


<style lang="scss" scoped></style>