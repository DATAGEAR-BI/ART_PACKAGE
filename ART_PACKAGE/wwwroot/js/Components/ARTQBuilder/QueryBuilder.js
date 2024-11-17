import { Filters } from "../../Modules/ExternalFilters.js";
import { getChartType } from "../Charts/Charts.js";
import { URLS as Urls } from "../.././URLConsts.js";
import { Spinner } from "../../../lib/spin.js/spin.js";

const charts = document.getElementById("charts");
let exRules = [];

class ARTExternalFilter extends HTMLElement {
    filterRulesObject = [];
    //onApplyFilters; //= (rules) => { };
    constructor() {
        super();
        this.initializeComponent();
    }

    initializeComponent() {
        this.applyStyle();
        this.createSpinnerStyle();
        const filterControl = this.createFilterControl();
        const applyButton = this.createApplyButton(filterControl);

        this.append(filterControl, applyButton);
        this.initializeQueryBuilder(filterControl);
    }

    applyStyle() {
        this.style.display = "flex";
        this.style.justifyContent = "center";
        this.style.alignItems = "center";
        this.style.padding = "1%";
        this.className = "row";
    }

    createSpinnerStyle() {
        const spinnerStyle = document.createElement("link");
        spinnerStyle.rel = "stylesheet";
        spinnerStyle.href = "../lib/spin.js/spin.css";
        this.appendChild(spinnerStyle);
    }

    createFilterControl() {
        const filterControl = document.createElement("div");
        filterControl.id = "filters";
        filterControl.classList.add("col-xs-8", "col-md-8", "col-sm-8");
        return filterControl;
    }

    createApplyButton(filterControl) {
        const applyButton = document.createElement("button");
        applyButton.innerText = "Apply";
        applyButton.classList.add("col-xs-2", "col-md-2", "col-sm-2", "btn", "btn-primary");

        applyButton.addEventListener("click", () => this.applyFilters(filterControl));
        return applyButton;
    }

    initializeQueryBuilder(filterControl) {
        const key = this.dataset.key.toString();
        const { filters, rules } = Filters[key];
        exRules = rules;

        $(filterControl).queryBuilder({
            filters: [...filters],
            rules: [...rules],
            lang: { add_rule: 'Add filter' },
            conditions: ["AND"],
            allow_groups: false,
            operators: ['equal', 'in'],
        });

        this.bindQueryBuilderEvents(filterControl);
    }

    bindQueryBuilderEvents(filterControl) {
        $(filterControl).on('afterCreateRuleFilters.queryBuilder', (e, rule) => {
            this.filterRulesObject.push({ id: rule.id });
            this.updateHiddenFilters();
        });

        $(filterControl).on('beforeDeleteRule.queryBuilder', (e, rule) => {
            this.filterRulesObject = this.filterRulesObject.filter(obj => obj.id !== rule.id);
            if (rule.filter) this.showFilterOption(rule.filter.field);
        });

        $(filterControl).on('afterUpdateRuleValue.queryBuilder', (e, rule) => {
            const ruleInput = rule.$el[0].querySelector('.rule-value-container')
                .querySelector(`[name='${rule.id}_value_0']`);
            if (!ruleInput.value) {
                const prevRule = this.getAndReplaceRule(rule);
                this.showFilterOption(prevRule.field);
                this.updateHiddenFilters();
            }
        });
    }

    applyFilters(filterControl) {
        const rules = $(filterControl).queryBuilder('getRules');
        if (!rules || !this.validateFilters(rules)) return;

        this.processRules(rules);
        this.onApplyFilters(exRules);
        //this.refreshUI();
    }

    validateFilters(rules) {
        if (!rules || !rules.rules) return this.showValidationMessage("Please add report filters");

        const key = this.dataset.key.toString();
        const filters = Filters[key].filters;

        for (const filter of filters) {
            if (!rules.rules.some(rule => rule.id === filter.id)) {
                return this.showValidationMessage(`Please add ${filter.label} filter`);
            }
        }
        return true;
    }

    processRules(rules) {
        const groupedRules = this.groupRulesById(rules.rules);
        const validRules = Array.prototype.concat.apply([], Object.values(groupedRules));

        exRules = validRules.map(rule => {
            if (Array.isArray(rule.value)) rule.value = rule.value.join(",");
            return rule;
        });
    }

    refreshUI() {
        if (document.getElementById("grid")) {
            const grid = $("#grid").data("kendoGrid");
            grid.dataSource.read();
            grid.dataSource.view();
        } else if (document.getElementById("charts")) {
            const url = Urls[this.dataset.chartsurl];
            callDefinedCharts(url);
        }
    }

    groupRulesById(rules) {
        return rules.reduce((group, rule) => {
            group[rule.id] = group[rule.id] || [];
            group[rule.id].push(rule);
            return group;
        }, {});
    }

    showValidationMessage(message) {
        const toastObj = {
            icon: 'error',
            text: message,
            heading: "Apply Filter Status",
        };
        $.toast(toastObj);
        return false;
    }

    getAndReplaceRule(rule) {
        const index = this.filterRulesObject.findIndex(obj => obj.id === rule.id);
        const prevRule = this.filterRulesObject[index];
        this.filterRulesObject[index] = { field: rule.filter.field, id: rule.id };
        return prevRule;
    }

    updateHiddenFilters() {
        const rulesField = this.filterRulesObject.map(rule => rule.field);
        this.filterRulesObject.forEach(rule => {
            const otherFields = rulesField.filter(field => field !== rule.field);
            this.toggleOptions(rule.id, otherFields, false);
        });
    }

    showFilterOption(field) {
        this.filterRulesObject.forEach(rule => {
            const options = $(`#${rule.id}`).find(`option[value='${field}']`);
            options.show();
        });
    }

    toggleOptions(ruleId, fields, hide) {
        fields.forEach(field => {
            const options = $(`#${ruleId}`).find(`option[value='${field}']`);
            options.toggle(!hide);
        });
    }

    onApplyFilters(callback) {
        //callback(exRules);
    }
}

function callDefinedCharts(url) {
    const spinner = new Spinner().spin(charts);
    fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
        },
        body: JSON.stringify({ req: null, procFilters: exRules }),
    }).then(res => res.json()).then(data => {
        data.forEach(chartData => renderChart(chartData));
        spinner.stop();
    });
}

function renderChart(chartData) {
    let chart = document.getElementById(chartData.ChartId);

    if (chart) {
        chart.setdata(chartData.Data);
        return;
    }

    chart = document.createElement(getChartType(chartData.Type));
    chart.id = chartData.ChartId;
    chart.dataset.value = chartData.Val;
    chart.dataset.title = chartData.Title;
    chart.dataset.category = chartData.Cat;
    chart.style.height = "700px";
    chart.classList.add("col-sm-12", "col-md-12", "col-xs-12");
    charts.appendChild(chart);
}

customElements.define("art-filters-control", ARTExternalFilter);
