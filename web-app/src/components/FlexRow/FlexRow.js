import React from "react";
import css from "./FlexRow.scss";

export function FlexRow({ children }) {
  return (
    <div className={css.row}>
      {children}
    </div>
  )
}