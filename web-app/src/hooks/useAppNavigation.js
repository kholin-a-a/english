import { useHistory } from "react-router-dom";
import { AppRoutes } from "routes";

export function useAppNavigation() {
    const history = useHistory();

    return {
        lesson: () => {
            history.push(AppRoutes.lesson.route())
        },

        home: () => {
            history.push(AppRoutes.home.route())
        }
    }
}
