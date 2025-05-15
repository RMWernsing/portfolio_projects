<script setup>
import Example from '@/components/Example.vue';
import { storiesService } from '@/services/StoriesService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { onMounted } from 'vue';

onMounted(() => {
  getStories()
}
)

async function getStories() {
  try {
    await storiesService.getStories()
  }
  catch (error) {
    Pop.error(error, "Could not get stories");
    logger.error('COULD NOT GET STORIES', error)
  }
}

</script>

<template>
  <Example />
</template>

<style scoped lang="scss"></style>
