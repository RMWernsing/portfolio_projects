import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class StoryNodesService {
  async getFirstStoryNode(storyId) {
    const response = await api.get(`api/storyNodes/${storyId}/first`)
    logger.log('Here is your story node!', response.data)
  }

}

export const storyNodesService = new StoryNodesService()