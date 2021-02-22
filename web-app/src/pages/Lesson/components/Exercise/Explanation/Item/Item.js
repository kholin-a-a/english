import React from "react";

import {
  Text,
  TextType,
  Repeat,
  OrderedList
} from "components";

import { Meaning } from "./Meaning";

export function Item(props) {
    const {
        item
    } = props;

    return (
        <div>
            <div>
                <Text value={item.part} type={TextType.secondary} />
            </div>

            <OrderedList>
                <Repeat
                    items={item.meanings}
                    render={(meaning, index) => (
                        <li key={index}>
                            <Meaning
                                meaning={meaning.meaning}
                                example={meaning.example}
                                synonyms={meaning.synonyms}
                            />
                        </li>
                    )}
                />
            </OrderedList>
        </div>
    )
}
