import React from "react";
import styles from "./Exercise.scss";

import { Block, If } from "components";
import { Word } from "./Word";
import { Toolbar } from "./Toolbar";
import { Explanation } from "./Explanation";
import { Preloader } from "./Preloader";

import { CssBuilder } from "utils/CssBuilder";

export function Exercise(props) {
    const {
        lesson,
        word,
        explanation,

        onSpeak,
        onExplain,
        onDontKnow,
        onNext
    } = props;

    const controlContainerCss = new CssBuilder()
        .append(styles.controlContainer)
        .append(styles.leftBorder, explanation.visible)
        .build();

    return (
        <Block rounded={true}>
            <If condition={!lesson.fetching && !word.fetching}>
                <Word
                    word={word}
                    onSpeak={onSpeak}
                />
            </If>

            <If condition={word.fetching || lesson.fetching}>
                <Preloader />
            </If>

            <div className={controlContainerCss}>
                <Toolbar
                    lesson={lesson}
                    word={word}
                    explanation={explanation}
                    onExplain={onExplain}
                    onDontKnow={onDontKnow}
                    onNext={onNext}
                />

                <If condition={explanation.visible}>
                    <Explanation
                        items={explanation.meanings}
                    />
                </If>
            </div>
        </Block>
    )
}
