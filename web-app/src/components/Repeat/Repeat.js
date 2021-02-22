export function Repeat({ render, items}) {
    return items.map(render)
}