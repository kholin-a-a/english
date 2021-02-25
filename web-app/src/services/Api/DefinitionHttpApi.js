import { Http } from "../Http/Http";

export const DefinitionHttpApi = {
  get: (wordId) => {
    return Http.get(`/words/${wordId}/definitions`)
  }
}
