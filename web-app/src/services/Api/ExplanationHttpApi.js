import { delay } from "../../utils/delay";

export const ExplanationHttpApi = {
  get: (wordId) => {
    return delay(500)
      .then(() => mock)
  }
}

const mock = [
  {
    part: "Noun",
    meanings: [
      {
        meaning: "activity requiring physical effort, carried out to sustain or improve health and fitness",
        example: "exercise improves your heart and lung power",
        synonyms: [
          "activity",
          "movement",
          "exercition",
          "effort",
          "work"
        ]
      },
      {
        meaning: "a process or activity carried out for a specific purpose, especially one concerned with a specified area or skill",
        example: "an exercise in public relations",
        synonyms: []
      }
    ]
  },
  {
    part: "Verb",
    meanings: [
      {
        meaning: "use or apply (a faculty, right, or process)",
        example: "control is exercised by the Board",
        synonyms: [
          "activity",
          "movement",
          "exercition",
          "effort",
          "work"
        ]
      }
    ]
  }
]