import { Http } from "../Http/Http";

export const ExplanationHttpApi = {
  get: (wordId) => {
    return Http.get(`/words/${wordId}/explanation`)
  }
}
