import { delay } from "../../utils/delay";

export const WordHttpApi = {
  next: () => {
    return delay(500)
      .then(() => ({
        id: 123,
        text: "example"
      }))
  },

  unknown: () => {
    return delay(500)
  },

  commit: (data) => {
    const {
      wordId,
      lessonId,
      text
    } = data

    return delay(500)
  }
}