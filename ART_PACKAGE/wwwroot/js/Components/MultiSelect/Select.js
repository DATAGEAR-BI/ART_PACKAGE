class Select extends HTMLElement {
    select = document.createElement("select");
    label = document.createElement("label");
    constructor() {
        super();

        var id = this.id;
        this.classList.add("form-floating", "form-floating-outline");

        var attrs = Object.keys(this.dataset);

        var isSearchable = attrs.includes("searchable");

        if (isSearchable)
            this.classList.add("searchable");

        var isMulti = attrs.includes("multiple");

        if (isMulti) {
            this.classList.add("multi-select");
            this.select.multiple = true;
        } else {
            this.select.appendChild(document.createElement("option"))
        }


        this.select.id = id + "-Select";
        this.select.classList.add("form-select");


        this.label.innerText = this.dataset.title;

        this.appendChild(this.select);
        this.appendChild(this.label);

    }

    intialize(options) {
        // Initialize
        options.forEach(x => {
            this.select.appendChild(x);
        })
        var selectnodelist = this.querySelectorAll(`#${this.id}-Select`);

        var selectList = [].slice.call(selectnodelist);

        var selectFields = selectList.map(function (s) {
            return new materialstyle.SelectField(s)
        })
    }


    reset() {
        this.select.innerHTML = '';
    }
}

customElements.define("m-select", Select);