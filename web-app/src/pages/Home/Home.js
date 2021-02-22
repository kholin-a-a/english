import React from "react";
import css from "./Home.scss";

import { Button } from "components";
import { Score } from "./components";
import { useAppNavigation } from "hooks";
import { useStats } from "./hooks";

export function Home() {
    const navigation = useAppNavigation()
    const stats = useStats();

    const onStartHandler = () => {
        navigation.lesson()
    }

    return (
        <div className={css.container}>
            <div className={css.score}>
                <Score stats={stats} />
            </div>

            <div>
                <Button
                    value="Start a new lesson"
                    onClick={onStartHandler}
                />
            </div>
        </div>
    )
}
