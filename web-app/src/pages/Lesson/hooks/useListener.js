import { useState } from "react";
import { SpeechRecognition } from "services/SpeechRecognition";

export function useListener() {
  const [ recognition, setRecognition ] = useState(new SpeechRecognition())
  const [ pending, setPending ] = useState(false)

  const start = () => {
    return new Promise(res => {
      recognition.start()
      res()
    })
  }

  const stop = () => {
    setPending(true)

    return recognition
      .stop()
      .then(() => setPending(false))
  }

  const spoken = () => {
    return new Promise(res => {
      res(recognition.text())
    })
  }

  return {
    pending,

    start,
    stop,
    spoken
  }
}