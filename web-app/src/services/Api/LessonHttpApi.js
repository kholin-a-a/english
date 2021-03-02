import { Http } from "../Http";

export const LessonHttpApi = {
  start: () => {
    return Http.post("/lessons")
  }
}
