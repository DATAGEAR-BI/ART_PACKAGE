class TextInput extends HTMLElement {
    input = document.createElement("input");
    label = document.createElement("label");
    container = document.createElement("div");
    constructor() {
        super();

        this.container.classList.add("form-floating");
        this.input.type = "text";
        this.input.classList.add("form-control");
        this.input.id = this.id + "-input";
        this.input.autocomplete = "off";
        if (this.dataset.palceholder)
            this.input.placeholder = this.dataset.palceholder;

        this.label.innerText = this.dataset.title;
        this.label.for = this.id + "-input";


        this.container.appendChild(this.input);
        this.container.appendChild(this.label);


        this.appendChild(this.container);
    }


    intialize(value) {
        var inputs = this.querySelectorAll(this.id + "-input");
        var textFieldList = [].slice.call(inputs)
        var textFields = textFieldList.map(function (textField) {
            return new materialstyle.TextField(textField)
        })
    }
}


customElements.define("m-input", TextInput);
