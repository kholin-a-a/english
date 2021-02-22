export function If({ children, condition }) {
    if (condition) {
        return children
    } else {
        return null
    }
}