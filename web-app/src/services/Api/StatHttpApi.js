import { Http } from "../Http";

export const StatHttpApi = {
  get: () => {
    return Http.get("/stats")
  }
}
