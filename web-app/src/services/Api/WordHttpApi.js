import { Http } from "../Http";

export const WordHttpApi = {
  next: () => {
    return Http.get("/words")
  },

  unknown: (data) => {
    return Http.post("/words/unknown", data)
  },

  complete: (data) => {
    return Http.post("/words/completed", data)
  }
}