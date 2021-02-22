import React from "react";
import styles from "./Spinner.scss";

import { SpinnerSize } from "./consts";
import { CssBuilder } from "utils/CssBuilder";

export function Spinner(props) {
    const {
        size = SpinnerSize.medium
    } = props;

    const css = new CssBuilder()
        .append(styles.spinner)
        .append(styles[size])
        .build()
    
    return (
        <div className={css}>
        </div>
    )
}