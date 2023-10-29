class Switch extends HTMLElement {

    constructor() {
        super();
        var switchStyle = document.createElement("link");
        switchStyle.rel = "stylesheet";
        switchStyle.href = "/js/Components/Switch/Switch.css";


        var isChecked = this.dataset.checked;
        var switchLable = document.createElement("label");
        switchLable.className = "switch col-6-xs";

        var switchInput = document.createElement("input");
        switchInput.type = "checkbox";
        switchInput.checked = isChecked;
        switchInput.id = this.id + "-" + "art-switch";


        var switchSpan = document.createElement("span");
        switchSpan.className = "slider round";
        document.head.appendChild(switchStyle);
        switchLable.appendChild(switchInput);
        switchLable.appendChild(switchSpan);
        this.appendChild(switchLable);
    }

    set onswitchchanged(onchange) {
        document.getElementById(`${this.id}-art-switch`).onchange = (e) => onchange(e);
    }

    check() {
        document.getElementById(`${this.id}-art-switch`).checked = true;
    }
    unCheck() {
        document.getElementById(`${this.id}-art-switch`).checked = false;
    }

    toggle() {
        var isChecked = document.getElementById(`${this.id}-art-switch`).checked;
        if (isChecked)
            this.unCheck();
        else
            this.check();
    }

    get status() {
        return document.getElementById(`${this.id}-art-switch`).checked;
    }
}

customElements.define("art-switch", Switch);
