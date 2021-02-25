import React from "react";

import {
  Repeat,
  Text,
  TextType,
  TextSize,
  OrderedList,
  Margin,
  MarginSize
} from "components";

import { groupBy } from "utils/ArrayUtils";

export function WordDefinitions(props) {
  const {
    definitions
  } = props;

  const speechParts = Array.from(
    groupBy(definitions, d => d.speechPart)
  ).map(group => ({
    speechPart: group[0],
    definitions: group[1]
  }))

  return (
    <div>
      <Repeat
        items={speechParts}
        render={(part, index) => (
          <React.Fragment key={index}>
            <div>
              <Text
                value={part.speechPart}
                type={TextType.secondary}
              />
            </div>

            <OrderedList>
              <Repeat
                items={part.definitions}
                render={(definition, index) => (
                  <li key={index}>
                    <div>
                      <div>
                        <Text
                          value={definition.definition}
                        />
                      </div>

                      <div>
                        <Text
                          value={definition.synonyms.join(", ")}
                          size={TextSize.small}
                          type={TextType.secondary}
                        />
                      </div>

                      <Margin top={MarginSize.small}>
                        <Text
                          value={definition.example}
                          type={TextType.italic}
                        />
                      </Margin>
                    </div>
                  </li>
                )}
              />
            </OrderedList>
          </React.Fragment>
        )}
      />
    </div>
  )
}
