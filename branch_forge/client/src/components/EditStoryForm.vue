<script setup>
import { AppState } from '@/AppState.js';
import { storiesService } from '@/services/StoriesService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed, ref, watch } from 'vue';
import { useRoute } from 'vue-router';

const story = computed(() => AppState.activeStory)

watch(story, (newStory) => {
  editableStoryData.value = {
    title: story.value?.title,
    description: story.value?.description,
    coverImg: story.value?.coverImg
  }
})

const editableStoryData = ref({
  title: story.value?.title,
  description: story.value?.description,
  coverImg: story.value?.coverImg
})

async function editStory() {
  try {
    await storiesService.editStory(editableStoryData.value, story.value.id)
  }
  catch (error) {
    Pop.error(error, 'Could not edit story')
    logger.log('COULD NOT EDIT STORY', error)
  }
}

</script>


<template>
  <!-- Button trigger modal -->
  <!-- <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#createStoryModal">
    Launch demo modal
  </button> -->

  <!-- Modal -->
  <div class="modal fade" id="editStoryModal" tabindex="-1" aria-labelledby="editStoryLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="editStoryLabel">Edit this Story</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="editStory()">
            <div class="mb-3">
              <label for="title" class="form-label">Title</label>
              <input v-model="editableStoryData.title" type="text" class="form-control" id="title" required
                minlength="5" maxlength="50">
            </div>
            <div class="mb-3">
              <label for="description" class="form-label">Description</label>
              <textarea v-model="editableStoryData.description" type="text" class="form-control" id="description"
                required minlength="10" maxlength="1000"></textarea>
            </div>
            <div class="mb-3">
              <label for="coverImg" class="form-label">Cover Image</label>
              <input v-model="editableStoryData.coverImg" type="url" class="form-control" id="coverImg" required
                maxlength="5000">
            </div>
            <div>
              <img v-if="editableStoryData.coverImg" class="w-100" :src="editableStoryData.coverImg"
                :alt="`cover image for ${editableStoryData.title}`">
            </div>
            <div class="modal-footer">
              <button data-bs-dismiss="modal" type="submit" class="btn btn-primary">Create</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped></style>