import React from "react";
import "./App.scss";

import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { AppRoutes } from "./routes";
import { Lesson, Home } from "pages";

export function App() {
  return (
    <Router>
      <Switch>
        <Route path={AppRoutes.lesson.path()}>
          <Lesson />
        </Route>

        <Route path={AppRoutes.home.path()}>
          <Home />
        </Route>
      </Switch>
    </Router>
  )
}
