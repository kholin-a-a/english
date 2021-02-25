import { useState } from "react";
import { DefinitionHttpApi } from "services/Api";

export function useWordDefinitions() {
  const [definitions, setDefinitions] = useState([])
  const [fetching, setFetching] = useState(false)
  const [visible, setVisible] = useState(false)

  const fetch = (wordId) => {
    setFetching(true)

    return DefinitionHttpApi
      .get(wordId)
      .then(definitions => setDefinitions(definitions))
      .then(() => setFetching(false))
  }

  const show = () => {
    setVisible(true)
  }

  const hide = () => {
    setVisible(false)
  }

  return {
    definitions,
    fetching,
    visible,

    show,
    hide,
    fetch
  }
}