import React, { useEffect } from "react";
import styles from "./Lesson.scss";

import { useAppNavigation } from "hooks";

import {
  Toolbar,
  Exercise
} from "./components";

import {
  useLesson,
  useWord,
  useExplanation,
  useSpeaker,
  useListener
} from "./hooks";

export function Lesson() {
  const navigation = useAppNavigation()
  const lesson = useLesson()
  const word = useWord()
  const explanation = useExplanation()
  const speaker = useSpeaker()
  const listener = useListener()

  const init = () => {
    lesson
      .start()
      .then(() => word.next())
      .then(() => listener.start())
  }

  useEffect(init, []);

  const onStopLessonHandler = () => {
    listener.stop()

    lesson
      .stop()
      .then(() => navigation.home())
  }

  const onNextWordHandler = () => {
    listener
      .stop()
      .then(() => explanation.hide())
      .then(() => listener.spoken())
      .then((spoken) => word.commit(lesson.id, spoken))
      .then(() => word.next())
      .then(() => listener.start())
  }

  const onUnknownWordHandler = () => {
    listener
      .stop()
      .then(() => explanation.hide())
      .then(() => word.unknown())
      .then(() => word.next())
      .then(() => listener.start())
  }

  const onExplainWordHandler = () => {
    if (explanation.visible) {
      explanation.hide()
    } else {
      explanation
        .fetch()
        .then(() => explanation.show())
    }
  }

  const onSpeakHandler = () => {
    speaker.speak(word.text)
  }

  return (
    <div className={styles.page}>

      <div className={styles.content}>
        <div className={styles.space}></div>

        <Toolbar
          lesson={lesson}
          onStop={onStopLessonHandler}
        />

        <div className={styles.space}></div>

        <Exercise
          lesson={lesson}
          word={word}
          explanation={explanation}
          onExplain={onExplainWordHandler}
          onDontKnow={onUnknownWordHandler}
          onNext={onNextWordHandler}
          onSpeak={onSpeakHandler}
        />
      </div>
    </div>
  )
}
