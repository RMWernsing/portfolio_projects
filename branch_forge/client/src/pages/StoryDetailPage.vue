<script setup>
import { AppState } from '@/AppState.js';
import { storiesService } from '@/services/StoriesService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()
const story = computed(() => AppState.activeStory)

onMounted(() => {
  getStoryById()
})

async function getStoryById() {
  try {
    await storiesService.getStoryById(route.params.storyId)
  }
  catch (error) {
    Pop.error(error, 'Could not get story')
    logger.error('COULD NOT GET STORY', error)
  }
}
</script>

<template>
  <section v-if="story" class="container mt-3">
    <div class="row justify-content-center">
      <div class="col-9">
        <div class="row justify-content-between align-items-center">
          <div class="col-4">
            <button class="btn btn-danger">Delete Story</button>
          </div>
          <div class="col-4">
            <div class="d-flex justify-content-end">
              <button class="btn btn-indigo">Edit Story</button>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-9">
        <div class="mt-3">
          <img class="rounded-4" :src="story.coverImg" :alt="`cover image for ${story.title}`">
        </div>
        <div>
          <h1 class="text-center mt-2">{{ story.title }}</h1>
          <p>{{ story.description }}</p>
        </div>
      </div>
    </div>
  </section>
</template>

<style lang="scss" scoped>
img {
  width: 100%;
  max-height: 60dvh;
  object-fit: cover;
  object-position: center;
}
</style>