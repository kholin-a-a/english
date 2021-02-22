import { useEffect, useState } from "react"
import { StatHttpApi } from "services/Api";

export function useStats() {
  const [ totalLessons, setTotalLessons ] = useState(0);
  const [ fetching, setFetching ] = useState(true);

  const fetch = () => {
    setFetching(true)

    return StatHttpApi
      .get()
      .then(stats => {
        setTotalLessons(stats.totalLessons)
        setFetching(false)
      })
  }

  useEffect(() => {
    fetch()
  }, [])

  return {
    totalLessons,
    fetching,
    fetch
  }
}