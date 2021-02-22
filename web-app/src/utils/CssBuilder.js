export class CssBuilder {
    constructor() {
        this.classes = [];
    }

    append(css, condition = true) {
        if (condition) {
            this.classes.push(css);
        }

        return this
    }

    build() {
        return this.classes.join(" ")
    }
}
