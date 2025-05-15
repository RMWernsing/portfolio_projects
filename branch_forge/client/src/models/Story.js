import { Profile } from "./Account.js"

export class Story {
  constructor(data) {
    this.id = data.id
    this.createdAt = new Date(data.createdAt)
    this.updatedAt = new Date(data.updatedAt)
    this.title = data.title
    this.description = data.description
    this.coverImg = data.coverImg
    this.authorId = data.authorId
    this.likeCount = data.likeCount
    this.creator = new Profile(data.creator)
  }
}