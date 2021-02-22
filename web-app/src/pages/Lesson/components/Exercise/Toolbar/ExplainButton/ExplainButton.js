import React from "react";
import css from "./ExplainButton.scss";

import {
  Button,
  ButtonType,
  If,
  Spinner
} from "components";

export function ExplainButton(props) {
    const {
        onExplain,
        disabled,
        explanation
    } = props;

    return (
        <div className={css.container}>
            <Button
                value="Explain"
                type={ButtonType.flat}
                onClick={onExplain}
                disabled={disabled}
            />

            <If condition={explanation.fetching}>
                <div className={css.spinner}>
                    <Spinner />
                </div>
            </If>
        </div>
    )
}
