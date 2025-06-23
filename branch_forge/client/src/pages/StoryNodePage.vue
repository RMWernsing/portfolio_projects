<script setup>
import { storyNodesService } from '@/services/StoryNodesService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()
onMounted(() => {
  getFirstStoryNode()
})

async function getFirstStoryNode() {
  try {
    await storyNodesService.getFirstStoryNode(route.params.storyId)
  }
  catch (error) {
    Pop.error(error, "Could Not Get First Story Node")
    logger.error("COULD NOT GET FIRST STORY NODE", error)
  }
}
</script>


<template>
  <section class="container">
    <div class="row">
      <div class="col-md-4">

      </div>
    </div>
  </section>
</template>


<style lang="scss" scoped></style>