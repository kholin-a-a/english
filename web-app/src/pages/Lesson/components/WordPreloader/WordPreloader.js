import React from "react";
import css from "./WordPreloader.scss";

import {
  Spinner,
  SpinnerSize,
  Text,
  TextSize
} from "components";

export function WordPreloader() {
    return (
        <div className={css.container}>
            <div className={css.icon}>
                <Text value="Icon placeholder" size={TextSize.large} />
            </div>
            <div>
                <Spinner size={SpinnerSize.giant} />
            </div>
        </div>
    )
}