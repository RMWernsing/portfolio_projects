<script setup>
import { AppState } from '@/AppState.js';
import CreateStoryForm from '@/components/CreateStoryForm.vue';
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
        <div class="mb-3">
          <StoryCard :story="story" />
        </div>
      </div>
    </div>
  </section>
  <button data-bs-toggle="modal" data-bs-target="#createStoryModal" class="btn btn-indigo">Create Story</button>
  <CreateStoryForm />
</template>

<style scoped lang="scss">
button {
  position: fixed;
  bottom: 10px;
  right: 10px;
  ;
}
</style>
