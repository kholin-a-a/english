import { useState } from "react";
import { LessonHttpApi } from "services/Api";

export function useLesson() {
  const [id, setId] = useState()
  const [number, setNumber] = useState()
  const [fetching, setFetching] = useState();

  const start = () => {
    setFetching(true);

    return LessonHttpApi
      .start()
      .then(lesson => {
        setId(lesson.id)
        setNumber(lesson.number)
        setFetching(false)
      })
  }

  return {
    id,
    number,
    fetching,

    start
  }
}
