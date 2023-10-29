import { EmailsInput, getEmailsList } from "../../../lib/EmailInput/emails-input.js"
var style = document.createElement("link");
style.href = "/lib/EmailInput/emails-input.css";
style.rel = "stylesheet";
document.head.appendChild(style);
class EmailInput extends HTMLElement {
    constructor() {
        super();
        var container = document.createElement("div");
        container.style.height = "10vh"
        EmailsInput(container)
        this.appendChild(container);
    }

    getMails() {
        return getEmailsList();
    }
}
customElements.define("email-input", EmailInput);