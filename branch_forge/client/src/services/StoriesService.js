import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Story } from "@/models/Story.js"

class StoriesService {
  async editStory(storyData, id) {
    const response = await api.put(`api/stories/${id}`, storyData)
    // logger.log('your story was edited successfully', response.data)
    const story = new Story(response.data)
    AppState.activeStory = story
  }
  async createStory(storyData) {
    const response = await api.post('api/stories', storyData)
    // logger.log('here is your new story!', response.data)
    const story = new Story(response.data)
    AppState.stories.push(story)
  }
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