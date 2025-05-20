<script setup>
import { storiesService } from '@/services/StoriesService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { ref } from 'vue';


const editableStoryData = ref({
  title: '',
  description: '',
  coverImg: ''
})

async function createStory() {
  try {
    await storiesService.createStory(editableStoryData.value)
    editableStoryData.value = {
      title: '',
      description: '',
      coverImg: ''
    }
  }
  catch (error) {
    Pop.error(error, 'could not create story')
    logger.error('COULD NOT CREATE STORY', error)
  }
}
function resetForm() {
  editableStoryData.value = {
    title: '',
    description: '',
    coverImg: ''
  }
}

</script>


<template>
  <!-- Button trigger modal -->
  <!-- <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#createStoryModal">
    Launch demo modal
  </button> -->

  <!-- Modal -->
  <div class="modal fade" id="createStoryModal" tabindex="-1" aria-labelledby="createStoryModalLabel"
    aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="createStoryModalLabel">Create a Story</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createStory()">
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
              <button @click="resetForm()" type="button" class="btn btn-secondary">Clear</button>
              <button data-bs-dismiss="modal" type="submit" class="btn btn-primary">Create</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped></style>