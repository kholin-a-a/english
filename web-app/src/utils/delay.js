export function delay(ms) {
    return new Promise((res, rej) => {
        window.setTimeout(() => {
            res()
        }, ms)
    })
}