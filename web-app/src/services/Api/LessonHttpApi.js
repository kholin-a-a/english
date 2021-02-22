import { Http } from "../Http";

export const LessonHttpApi = {
  start: () => {
    return Http.post("/lessons")
  },

  stop: (id) => {
    return Http.delete(`/lessons/${id}`)
  }
}
