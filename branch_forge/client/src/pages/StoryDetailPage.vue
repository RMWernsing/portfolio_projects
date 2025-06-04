<script setup>
import { AppState } from '@/AppState.js';
import EditStoryForm from '@/components/EditStoryForm.vue';
import { storiesService } from '@/services/StoriesService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const route = useRoute()
const router = useRouter()
const story = computed(() => AppState.activeStory)
const account = computed(() => AppState.account)

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

async function deleteStory() {
  try {
    const confirm = await Pop.confirm('Are you sure you want to delete this story?', 'If you do, it will be gone forever')
    if (!confirm) {
      return
    }
    await storiesService.deleteStory(route.params.storyId)
    router.push({ name: 'Home' })
    Pop.success(`Successfully deleted ${story.value.title}`)
  }
  catch (error) {
    Pop.error(error, 'Could not delete story')
    logger.error("COULD NOT DELETE STORY", error)
  }
}

</script>

<template>
  <section v-if="story" class="container mt-3">
    <div class="row justify-content-center">
      <div class="col-9">
        <div v-if="account?.id == story?.authorId" class="row justify-content-between align-items-center">
          <div class="col-4">
            <button @click="deleteStory()" class="btn btn-danger">Delete Story</button>
          </div>
          <div class="col-4">
            <div class="d-flex justify-content-end">
              <button class="btn btn-indigo" data-bs-toggle="modal" data-bs-target="#editStoryModal">Edit Story</button>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-9">
        <div class="mt-3">
          <img class="rounded-4" :src="story.coverImg" :alt="`cover image for ${story.title}`">
        </div>
        <div>
          <div class="d-flex justify-content-center my-3">
            <button class="btn btn-success">Play Story</button>
          </div>
        </div>
        <div>
          <h1 class="text-center mt-2">{{ story.title }}</h1>
          <p>{{ story.description }}</p>
        </div>
      </div>
    </div>
  </section>
  <EditStoryForm />
</template>

<style lang="scss" scoped>
img {
  width: 100%;
  max-height: 60dvh;
  object-fit: cover;
  object-position: center;
}
</style>