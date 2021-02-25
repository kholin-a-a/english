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

export function Explanation(props) {
  const {
    meanings
  } = props;

  return (
    <div>
      <Repeat
        items={meanings}
        render={(item, index) => (
          <React.Fragment key={index}>
            <div>
              <Text value={item.part} type={TextType.secondary} />
            </div>

            <OrderedList>
              <Repeat
                items={item.meanings}
                render={(meaning, index) => (
                  <li key={index}>
                    <div>
                      <div>
                        <Text value={meaning.meaning} />
                      </div>

                      <div>
                        <Text
                          value={meaning.synonyms.join(", ")}
                          size={TextSize.small}
                          type={TextType.secondary}
                        />
                      </div>

                      <Margin top={MarginSize.small}>
                        <Text value={meaning.example} type={TextType.italic} />
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
