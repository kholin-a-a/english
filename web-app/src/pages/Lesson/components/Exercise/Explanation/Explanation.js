import React from "react";
import css from "./Explanation.scss";

import { Repeat } from "components";
import { Item } from "./Item";

export function Explanation(props) {
    const {
        items
    } = props;

    return (
        <div className={css.container}>
            <Repeat
                items={items}
                render={(item, index) => (
                    <Item
                        key={index}
                        item={item}
                    />
                )}
            />
        </div>
    )
}
