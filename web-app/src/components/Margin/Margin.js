import React from "react";
import styles from "./Margin.scss";

import { CssBuilder } from "utils/CssBuilder";

export function Margin(props) {
  const {
    children,
    top,
    bottom
  } = props;

  const css = new CssBuilder()
    .append(styles.margin)
    .append(styles[`top-${top}`], !!top)
    .append(styles[`bottom-${bottom}`], !!bottom)
    .build()
  
  return (
    <div className={css}>
      { children }
    </div>
  )
}