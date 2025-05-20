<script setup>
import { AppState } from '@/AppState.js';
import Example from '@/components/Example.vue';
import StoryCard from '@/components/StoryCard.vue';
import { storiesService } from '@/services/StoriesService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const stories = computed(() => AppState.stories)

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
  <section class="container-fluid mt-3">
    <div class="row">
      <div v-for="story in stories" :key="story.id" class="col-md-4">
        <StoryCard :story="story" />
      </div>
    </div>
  </section>
  <button class="btn btn-indigo">Create Story</button>
</template>

<style scoped lang="scss">
button {
  position: fixed;
  bottom: 10px;
  right: 10px;
  ;
}
</style>
