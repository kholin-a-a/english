import { useState } from "react";
import { SpeechRecognition } from "services/SpeechRecognition";

export function useListener() {
  const [ recognition, setRecognition ] = useState(new SpeechRecognition())

  const start = () => {
    return new Promise(res => {
      recognition.start()
      res()
    })
  }

  const stop = () => {
    return recognition.stop()
  }

  const spoken = () => {
    return new Promise(res => {
      res(recognition.text())
    })
  }

  return {
    start,
    stop,
    spoken
  }
}