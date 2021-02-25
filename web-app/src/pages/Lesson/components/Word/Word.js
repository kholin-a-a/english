import React from "react";
import css from "./Word.scss";

import { Text, TextSize } from "components";

export function Word(props) {
    const {
        text,
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
                <Text value={text} size={TextSize.giant} />
            </div>
        </div>
    )
}
