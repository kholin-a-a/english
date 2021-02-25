import React from "react";

import {
  FlexColumn,
  If,
  Else,
  Margin,
  MarginSize,
  Spinner,
  SpinnerSize,
  Button
} from "components";

import { Score } from "./components";
import { useAppNavigation } from "hooks";
import { useStats } from "./hooks";

export function Home() {
  const navigation = useAppNavigation()
  const stats = useStats();

  const onStartHandler = () => {
    navigation.lesson()
  }

  return (
    <FlexColumn>
      <Margin top={MarginSize.medium} bottom={MarginSize.medium}>
        <If condition={stats.fetching}>
          <Spinner size={SpinnerSize.giant} />

          <Else>
            <Score count={stats.totalLessons} />
          </Else>
        </If>
      </Margin>

      <Button
        value="Start a new lesson"
        onClick={onStartHandler}
      />
    </FlexColumn>
  )
}
