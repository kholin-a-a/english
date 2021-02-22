import React from "react";
import css from "./Toolbar.scss";

import { Button, ButtonType } from "components";
import { ExplainButton } from "./ExplainButton";

export function Toolbar(props) {
    const {
        lesson,
        word,
        explanation,
        onExplain,
        onDontKnow,
        onNext
    } = props;

    const disabled = lesson.fetching || word.fetching || explanation.fetching;

    return (
        <div className={css.container}>
            <ExplainButton
                onExplain={onExplain}
                disabled={disabled}
                explanation={explanation}
            />

            <Button
                value="I don't know"
                type={ButtonType.flat}
                onClick={onDontKnow}
                disabled={disabled}
            />

            <Button
                value="Next"
                type={ButtonType.flat}
                onClick={onNext}
                disabled={disabled}
            />
        </div>
    )
}
