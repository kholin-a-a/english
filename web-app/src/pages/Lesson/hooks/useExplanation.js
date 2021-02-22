import { useState } from "react";
import { ExplanationHttpApi } from "services/Api";

export function useExplanation() {
  const [meanings, setMeanings] = useState([])
  const [fetching, setFetching] = useState(false)
  const [visible, setVisible] = useState(false)

  const fetch = (wordId) => {
    setFetching(true)

    return ExplanationHttpApi
      .get(wordId)
      .then(meanings => setMeanings(meanings))
      .then(() => setFetching(false))
  }

  const show = () => {
    setVisible(true)
  }

  const hide = () => {
    setVisible(false)
  }

  return {
    meanings,
    fetching,
    visible,

    show,
    hide,
    fetch
  }
}