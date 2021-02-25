import React from "react";
import css from "./FlexColumn.scss";

export function FlexColumn({ children }) {
  return (
    <div className={css.column}>
      { children }
    </div>
  )
}
