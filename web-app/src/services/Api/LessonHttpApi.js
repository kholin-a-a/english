import { delay } from "../../utils/delay";

export const LessonHttpApi = {
  start: () => {
    return delay(500)
      .then(() => ({
        id: 16,
        number: 456
      }))
  },

  stop: () => {
    return delay(500)
  }
}
