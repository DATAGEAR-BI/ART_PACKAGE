//class Select extends HTMLElement {
//    select = document.createElement("select");
//    label = document.createElement("label");
//    isMulti;

//    constructor() {
//        super();
//    }

//    connectedCallback() {
//        var id = this.id;
//        this.classList.add("form-floating", "form-floating-outline");

//        var attrs = Object.keys(this.dataset);

//        var isSearchable = attrs.includes("searchable");
//        if (isSearchable) this.classList.add("searchable");

//        var isMulti = attrs.includes("multiple");
//        if (isMulti) {
//            this.isMulti = isMulti;
//            this.classList.add("multi-select");
//            this.select.multiple = true;
//        } else {
//            this.select.appendChild(document.createElement("option"));
//        }

//        this.select.id = id + "-Select";
//        this.select.classList.add("form-select");

//        if (attrs.includes("disabled")) this.select.disabled = true;

//        this.label.innerText = this.dataset.title;

//        this.appendChild(this.select);
//        this.appendChild(this.label);
//        this.initialize();

//        // Initialize selectpicker after everything is appended
//        $(this.select).selectpicker();
//    }

//    initialize() {
//        let children = this.querySelectorAll("option");
//        children.forEach(x => this.select.appendChild(x));
//    }

//    reset() {
//        this.select.innerHTML = '';
//    }

//    update(options) {
//        this.reset();
//        options.forEach(x => {
//            const option = document.createElement("option");
//            option.text = x.text;
//            option.value = x.value;
//            this.select.appendChild(option);
//        });
//        $(this.select).selectpicker("refresh");  // Refresh selectpicker after updating options
//    }

//    setDefaultValues(defaultValues) {
//        [...this.select.options].forEach(option => {
//            option.selected = defaultValues.includes(option.value);
//        });
//        $(this.select).selectpicker("refresh");  // Refresh selectpicker after setting default values
//    }

//    get value() {
//        if (!this.isMulti) return this.select.options[this.select.selectedIndex];
//        return [...this.select.options].filter(x => x.selected && x.value != "");
//    }

//    enable() {
//        this.select.disabled = false;
//        $(this.select).selectpicker("refresh");
//    }

//    disable() {
//        this.select.disabled = true;
//        $(this.select).selectpicker("refresh");
//    }

//    toggleDisable() {
//        if (this.select.disabled) this.enable();
//        else this.disable();
//    }

//    deSelect() {
//        [...this.select.options].forEach(x => x.selected = false);
//        $(this.select).selectpicker("refresh");
//    }
//}

//customElements.define("m-select", Select);
