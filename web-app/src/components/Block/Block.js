import React from "react";
import styles from "./Block.scss";
import { CssBuilder } from "utils/CssBuilder";

export function Block({ children, rounded }) {
    const css = new CssBuilder()
        .append(styles.block)
        .append(styles.rounded, !!rounded)
        .build();
    
    return (
        <div className={css}>
            { children }
        </div>
    )
}
