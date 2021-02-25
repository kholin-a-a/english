import React from "react";
import { Button } from "./Button";
import { ButtonType } from "./consts";

export function FlatButton(props) {
  return (
    <Button
      {...props}
      type={ButtonType.flat}
    />
  )
}
