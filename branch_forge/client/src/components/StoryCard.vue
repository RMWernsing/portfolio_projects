<script setup>
import { Story } from '@/models/Story.js';


defineProps({
  story: { type: Story, required: true }
})

</script>


<template>
  <RouterLink :to="{ name: 'StoryDetail', params: { storyId: story.id } }">
    <div class="rounded-4 shadow-lg" :title="`Navigate to ${story.title} detail page`">
      <img class="cover-img rounded-4 p-2" width="100%" :src="story.coverImg" :alt="`cover image for ${story.title}`">
      <div class="px-3 pb-3 pt-1 d-flex justify-content-between">
        <span class="text-dark d-flex align-items-center">{{ story.title }}</span>
        <img :src="story.creator.picture" :alt="`Profile picture for ${story.creator.name}`" class="profile-img"
          :title="story.creator.name">
      </div>
    </div>
  </RouterLink>
</template>


<style lang="scss" scoped>
.cover-img {
  height: 30dvh;
  object-fit: cover;
  object-position: center;
}

a {
  text-decoration: none;
}

.profile-img {
  height: 50px;
  border-radius: 50%;
  aspect-ratio: 1/1;
  object-fit: cover;
  object-position: center;
}
</style>