import React from "react";
import styles from "./Text.scss";
import { TextSize, TextType } from "./consts";

import { CssBuilder } from "utils/CssBuilder";

export function Text(props) {
    const {
        value,
        type = TextType.primary,
        size = TextSize.medium
    } = props;

    const css = new CssBuilder()
        .append(styles.text)
        .append(styles[size])
        .append(styles[type])
        .build()

    return (
        <span className={css}>
            { value }
        </span>
    )
}
