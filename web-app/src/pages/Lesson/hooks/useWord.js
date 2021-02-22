import { useState } from "react";
import { WordHttpApi } from "services/Api";

export function useWord() {
  const [id, setId] = useState()
  const [text, setText] = useState()
  const [fetching, setFetching] = useState()

  const next = () => {
    setFetching(true)

    return WordHttpApi
      .next()
      .then(word => {
        setId(word.id)
        setText(word.text)
      })
      .then(() => setFetching(false))
  }

  const unknown = () => {
    setFetching(true)

    return WordHttpApi
      .unknown(id)
      .then(() => setFetching(false))
  }

  const complete = (lessonId, text) => {
    setFetching(true)

    const model = {
      id: id,
      lessonId,
      text
    }

    return WordHttpApi
      .complete(model)
      .then(() => setFetching(false))
  }

  return {
    id,
    text,
    fetching,

    next,
    unknown,
    complete
  }
}
