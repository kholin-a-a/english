import React, { useEffect } from "react";
import css from "./Lesson.scss";

import { useAppNavigation } from "hooks";

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
  Explanation
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
      .then((spoken) => word.complete(lesson.id, spoken))
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
        .fetch(word.id)
        .then(() => explanation.show())
    }
  }

  const onSpeakHandler = () => {
    speaker.speak(word.text)
  }

  const btnDisabled = lesson.fetching || word.fetching

  return (
    <div className={css.page}>
      <div className={css.content}>
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
          <If condition={lesson.fetching || word.fetching}>
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

          <If condition={explanation.visible}>
            <Margin top={MarginSize.small}>
              <Explanation
                meanings={explanation.meanings}
              />
            </Margin>
          </If>
        </Block>
      </div>
    </div>
  )
}
