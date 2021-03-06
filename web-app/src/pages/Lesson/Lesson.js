import React, { useEffect } from "react";
import css from "./Lesson.scss";

import {
  Block,
  FlexRow,
  Text,
  TextSize,
  FlatButton,
  If,
  Else,
  Spinner,
  SpinnerSize,
  Margin,
  MarginSize
} from "components";

import {
  Word,
  WordPreloader,
  WordDefinitions
} from "./components";

import { useAppNavigation } from "hooks";

import {
  useLesson,
  useWord,
  useWordDefinitions,
  useSpeaker,
  useListener
} from "./hooks";

export function Lesson() {
  const navigation = useAppNavigation()
  const lesson = useLesson()
  const word = useWord()
  const wordDefinitions = useWordDefinitions()
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
    listener
      .stop()
      .then(() => navigation.home())
  }

  const onNextWordHandler = () => {
    listener
      .stop()
      .then(() => wordDefinitions.hide())
      .then(() => listener.spoken())
      .then((spoken) => word.complete(lesson.id, spoken))
      .then(() => word.next())
      .then(() => listener.start())
  }

  const onUnknownWordHandler = () => {
    listener
      .stop()
      .then(() => wordDefinitions.hide())
      .then(() => word.unknown(lesson.id))
      .then(() => word.next())
      .then(() => listener.start())
  }

  const onExplainWordHandler = () => {
    if (wordDefinitions.visible) {
      wordDefinitions.hide()
    } else {
      wordDefinitions
        .fetch(word.id)
        .then(() => wordDefinitions.show())
    }
  }

  const onSpeakHandler = () => {
    speaker.speak(word.text)
  }

  const btnDisabled = lesson.fetching || listener.pending

  return (
    <div className={css.page}>
      <div className={css.content}>
        <Margin top={MarginSize.small} />

        <Block rounded={true}>
          <FlexRow>
            <If condition={lesson.fetching}>
              <Spinner size={SpinnerSize.large} />

              <Else>
                <Text
                  value={`Lesson ${lesson.number}`}
                  size={TextSize.large}
                />
              </Else>
            </If>

            <FlatButton
              value="Stop"
              disabled={lesson.fetching}
              onClick={onStopLessonHandler}
            />
          </FlexRow>
        </Block>

        <Margin top={MarginSize.medium} />

        <Block rounded={true}>
          <If condition={lesson.fetching || word.fetching || listener.pending}>
            <WordPreloader />

            <Else>
              <Word text={word.text} onSpeak={onSpeakHandler} />
            </Else>
          </If>

          <Margin top={MarginSize.large} />

          <FlexRow>
            <FlatButton
              value="Explain"
              onClick={onExplainWordHandler}
              disabled={btnDisabled}
            />

            <FlatButton
              value="I don't know"
              onClick={onUnknownWordHandler}
              disabled={btnDisabled}
            />

            <FlatButton
              value="Next"
              onClick={onNextWordHandler}
              disabled={btnDisabled}
            />
          </FlexRow>

          <If condition={wordDefinitions.visible}>
            <Margin top={MarginSize.small}>
              <WordDefinitions
                definitions={wordDefinitions.definitions}
              />
            </Margin>
          </If>
        </Block>
      </div>
    </div>
  )
}
