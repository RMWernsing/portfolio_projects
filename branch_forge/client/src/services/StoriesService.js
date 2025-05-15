import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Story } from "@/models/Story.js"

class StoriesService {
  async getStories() {
    const response = await api.get('api/stories')
    // logger.log('here are your stories!', stories)
    const stories = response.data.map(pojo => new Story(pojo))
    AppState.stories = stories
  }
}

export const storiesService = new StoriesService()