import React from "react";
import css from "./Score.scss";

import {
  Text,
  TextSize,
  If,
  Else
} from "components";

export function Score(props) {
  const {
    count
  } = props;

  return (
    <div className={css.container}>
      <If condition={!!count}>
        <Text value="You have done" size={TextSize.giant} />
        <br />
        <Text value={count} size={TextSize.giant} />
        <br />
        <Text value="lessons" size={TextSize.giant} />

        <Else>
          <Text value="You have done no lessons yet" size={TextSize.giant} />
          <br />
          <Text value="😢" size={TextSize.giant} />
        </Else>
      </If>
    </div>
  )
}