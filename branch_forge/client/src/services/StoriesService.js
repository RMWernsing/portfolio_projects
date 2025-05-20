import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Story } from "@/models/Story.js"

class StoriesService {
  async deleteStory(storyId) {
    const response = await api.delete(`api/stories/${storyId}`)
    logger.log('your story has been deleted', response.data)
  }
  async getStoryById(storyId) {
    AppState.activeStory = null
    const response = await api.get(`api/stories/${storyId}`)
    // logger.log('here is your story for the story details page!', response.data)
    const story = new Story(response.data)
    AppState.activeStory = story
  }
  async getStories() {
    const response = await api.get('api/stories')
    // logger.log('here are your stories!', stories)
    const stories = response.data.map(pojo => new Story(pojo))
    AppState.stories = stories
  }
}

export const storiesService = new StoriesService()