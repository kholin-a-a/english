import React from "react";
import styles from "./Toolbar.scss";

import {
  Block,
  Text,
  TextSize,
  If,
  Button,
  ButtonType,
  Spinner,
  SpinnerSize
} from "components";

export function Toolbar(props) {
    const {
        lesson,
        onStop
    } = props;

    return (
        <Block rounded={true}>
            <div className={styles.primaryLine}>
                <If condition={!lesson.fetching && lesson.number}>
                    <Text
                        value={`Lesson ${lesson.number}`}
                        size={TextSize.large}
                    />
                </If>

                <If condition={lesson.fetching}>
                    <Spinner size={SpinnerSize.large} />
                </If>

                <Button
                    value="Stop"
                    type={ButtonType.flat}
                    disabled={lesson.fetching}
                    onClick={onStop}
                />
            </div>
        </Block>
    )
}
