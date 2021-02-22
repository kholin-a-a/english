import React from "react";
import styles from "./Button.scss";
import { ButtonType } from "./consts";

import { CssBuilder } from "utils/CssBuilder";

export function Button(props) {
    const {
        value,
        type = ButtonType.action,
        disabled,
        onClick = nop
    } = props;

    const css = new CssBuilder()
        .append(styles.button)
        .append(styles[type])
        .build()

    return (
        <button
            className={css}
            onClick={onClick}
            disabled={disabled}>
            { value }
        </button>
    )
}


function nop() {}