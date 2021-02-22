import React from "react";
import css from "./Score.scss";

import {
  Text,
  TextSize,
  If,
  Spinner,
  SpinnerSize
} from "components";

export function Score(props) {
  const {
    stats
  } = props;

  return (
    <div className={css.container}>
      <If condition={stats.fetching}>
        <Spinner size={SpinnerSize.giant} />
      </If>

      <If condition={!stats.fetching && !!stats.totalLessons}>
        <div>
          <Text value="You have done" size={TextSize.giant} />
        </div>

        <div>
          <Text value={stats.totalLessons} size={TextSize.giant} />
        </div>

        <div>
          <Text value="lessons" size={TextSize.giant} />
        </div>
      </If>

      <If condition={!stats.fetching && !stats.totalLessons}>
        <div>
          <Text value="You have done no lessons yet" size={TextSize.giant} />
        </div>

        <div>
          <Text value="😢" size={TextSize.giant} />
        </div>
      </If>
    </div>
  )
}