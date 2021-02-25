import React from "react";
import { Else } from "./Else";

export function If(props) {
  const {
    children,
    condition
  } = props

  const childArray = children.length && children || [ children ]

  return (
    <React.Fragment>
      {
        condition ?
        childArray.filter(c => c.type !== Else) :
        childArray.filter(c => c.type === Else)
      }
    </React.Fragment>
  )
}