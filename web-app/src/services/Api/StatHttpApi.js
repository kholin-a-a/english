import { delay } from "../../utils/delay";

export const StatHttpApi = {
  get: () => {
    return delay(500)
      .then(() => ({
        totalLessons: 32
      }))
  }
}
