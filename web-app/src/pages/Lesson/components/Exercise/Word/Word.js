import React from "react";
import css from "./Word.scss";

import { Text, TextSize } from "components";

export function Word(props) {
    const {
        word,
        onSpeak
    } = props;

    return (
        <div
            className={css.container}
            onClick={onSpeak}
        >
            <div>
                <Text value="🔊" size={TextSize.large} />
            </div>

            <div>
                <Text value={word.text} size={TextSize.giant} />
            </div>
        </div>
    )
}
