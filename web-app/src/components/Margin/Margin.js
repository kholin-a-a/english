import React from "react";
import styles from "./Margin.scss";

import { CssBuilder } from "utils/CssBuilder";

export function Margin(props) {
  const {
    children,
    top
  } = props;

  const css = new CssBuilder()
    .append(styles.margin)
    .append(styles[`top-${top}`], !!top)
    .build()
  
  return (
    <div className={css}>
      { children }
    </div>
  )
}