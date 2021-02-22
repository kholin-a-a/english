import React from "react";
import css from "./Meaning.scss";

import { Text, TextType, TextSize } from "components";

export function Meaning(props) {
    let {
        meaning,
        example,
        synonyms
    } = props;

    synonyms = synonyms.join(", ")

    return (
        <div>
            <div>
                <Text value={meaning} />
            </div>

            <div>
                <Text value={synonyms}  size={TextSize.small} type={TextType.secondary} />
            </div>

            <div className={css.example}>
                <Text value={example} type={TextType.italic} />
            </div>
        </div>
    )
}
