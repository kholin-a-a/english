import React from "react";
import css from "./OrderedList.scss";

export function OrderedList({ children }) {
    return (
        <ol className={css.list}>
            { children }
        </ol>
    )
}