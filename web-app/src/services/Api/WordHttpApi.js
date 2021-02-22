import { Http } from "../Http";

export const WordHttpApi = {
  next: () => {
    return Http.get("/words")
  },

  unknown: (id) => {
    return Http.post("/words/unknown", id)
  },

  complete: (data) => {
    return Http.post("/words/completed", data)
  }
}