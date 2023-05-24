import { Filters, GoToDeatailsUrls } from "./Modules/ExternalFilters.js"
import { makedynamicChart } from "./Modules/MakeDynamicChart.js"
import { URLS as Urls } from "./URLConsts.js"
import { Spinner } from "../lib/spin.js/spin.js"


var exRules = [];
class ExternalFilter extends HTMLElement {
    f = [];
    filterRulesObject = [];
    constructor() {
        super();
        var spinnerstyle = document.createElement("link");
        spinnerstyle.rel = "stylesheet";
        spinnerstyle.href = "../lib/spin.js/spin.css"
        var key = this.dataset.key.toString();
        var filters = Filters[key].filters;
        var rules = Filters[key].rules;
        exRules = rules;
        this.style = `display:flex;
                    justify-content:center;
                    align-items:center;
                    padding:1%`;
        this.className = "row";
        var filtercontrol = document.createElement("div");

        var btn = document.createElement("button");
        btn.innerText = "apply";
        filtercontrol.classList.add("col-xs-8", "col-md-8", "col-sm-8");
        btn.classList.add("col-xs-2", "col-md-2", "col-sm-2", "btn", "btn-primary");
        filtercontrol.id = "filters";
        $(filtercontrol).queryBuilder({
            filters: [...filters],
            rules: [...rules],
            lang: {
                add_rule: 'Add filter'
            },
            conditions: ["AND"],
            allow_groups: false,
            operators: ['equal', 'in']
        });



        $(filtercontrol).on('afterCreateRuleFilters.queryBuilder', (e, rule) => {
            this.filterRulesObject.push({ id: rule.id });
            this.hiddenFiltersRules();
        });
        $(filtercontrol).on('beforeDeleteRule.queryBuilder', (e, rule) => {
            this.filterRulesObject = this.filterRulesObject.filter(x => x.id != rule.id);             // remove element in filterRulesObject
            if (rule.filter) {
                this.showFilterRule(rule.filter.field);
            }
        });
        $(filtercontrol).on('afterUpdateRuleValue.queryBuilder', (e, rule) => {
            var ruleinput = rule.$el[0].querySelector('.rule-value-container').querySelector(`[name = '${rule.id}_value_0']`);


            if (!ruleinput.value) {
                var index = this.filterRulesObject.findIndex(x => x.id == rule.id);
                var prevRule = this.filterRulesObject[index];
                this.filterRulesObject[index] = { field: rule.filter.field, id: rule.id };
                this.showFilterRule(prevRule.field);
                this.hiddenFiltersRules();
            }
        });

        var goToDetailsBtn = document.createElement("button");
        goToDetailsBtn.innerText = "Go to details";
        goToDetailsBtn.classList.add("col-xs-2", "col-md-2", "col-sm-2", "btn", "btn-primary");


        goToDetailsBtn.onclick = () => {

            var rlz = []
            var rules = $(filtercontrol).queryBuilder('getRules');

            var g = [...rules.rules].reduce((group, product) => {
                const { id } = product;
                group[id] = !group[id] ? [] : group[id];
                group[id].push(product);
                return group;
            }, {});
            var arr = [];
            for (var prop in g) {
                arr.push(g[prop]);
            }
            if (arr.some(x => x.length > 1)) {
                console.log("error");
            } else {
                rlz = Array.prototype.concat.apply([], arr);
                rlz = [...exRules].map(x => {
                    if (Array.isArray(x.value)) {
                        x.value = [...x.value].join(",");
                    }
                    return x;
                });
            }
            var fils = GoToDeatailsUrls[key].filtersOrder;
            var detailsUrl = GoToDeatailsUrls[key].url;
            [...fils].forEach(x => {
                if (rlz.some(f => f.id == x)) {
                    var rl = rlz.filter(f => f.id == x);
                    detailsUrl += `${rl[0].id}=${rl[0].value}&`
                }
            });
            window.open(detailsUrl, "_blank");
        }




        btn.onclick = () => {

            var rules = $(filtercontrol).queryBuilder('getRules');
            console.log(rules);
            var g = [...rules.rules].reduce((group, product) => {
                const { id } = product;
                group[id] = !group[id] ? [] : group[id];
                group[id].push(product);
                return group;
            }, {});
            var arr = [];
            for (var prop in g) {
                arr.push(g[prop]);
            }
            if (arr.some(x => x.length > 1)) {
                console.log("error");
            } else {
                exRules = Array.prototype.concat.apply([], arr);
                exRules = [...exRules].map(x => {
                    if (Array.isArray(x.value)) {
                        x.value = [...x.value].join(",");
                    }
                    return x;
                });
                if (document.getElementById("grid")) {
                    $("#grid").data("kendoGrid").dataSource.read();
                    $("#grid").data("kendoGrid").dataSource.view();
                } else if (document.getElementById("charts")) {
                    var url = this.dataset.chartsurl;
                    var chartsurl = Urls[url];
                    callDefinedCharts(chartsurl);
                }
            }
        }
        this.appendChild(spinnerstyle);
        this.appendChild(filtercontrol);
        this.appendChild(btn);
        this.appendChild(goToDetailsBtn);
        this.f = this.getAppliedFiltersNames();
        //this.appendChild(goToDetailsBtn);
        var rules = $(filtercontrol).queryBuilder('getRules');
        var g = [...rules.rules].reduce((group, product) => {
            const { id } = product;
            group[id] = !group[id] ? [] : group[id];
            group[id].push(product);
            return group;
        }, {});
        var arr = [];
        for (var prop in g) {
            arr.push(g[prop]);
        }
        if (arr.some(x => x.length > 1)) {
            console.log("error");
        } else {
            exRules = Array.prototype.concat.apply([], arr);
            exRules = [...exRules].map(x => {
                if (Array.isArray(x.value)) {
                    x.value = [...x.value].join(",");
                }
                return x;
            });


            if (document.getElementById("charts") && !document.getElementById("grid")) {
                var url = this.dataset.chartsurl;
                var chartsurl = Urls[url];
                callDefinedCharts(chartsurl);
            }

        }
    }
    connectedCallback() { // this function is called when DOM is Created 
        this.initialFiltersRule();
        this.hiddenFiltersRules();
    }
    getAppliedFiltersNames() {
        var filtercontrol = document.getElementById('filters');
        var rules = $(filtercontrol).queryBuilder('getRules');

        if (rules) {
            var g = [...rules.rules].reduce((group, product) => {
                const { id } = product;
                group[id] = !group[id] ? [] : group[id];
                group[id].push(product);
                return group;
            }, {});
            var arr = [];
            for (var prop in g) {
                arr.push(g[prop]);
            }
            var flattened = arr.reduce((acc, val) => acc.concat(val), []);
            var f = flattened.map(x => x.id);
            return f;

            //$(filtercontrol).queryBuilder('removeFilter', f, true);
            //$(filtercontrol).queryBuilder('setRules', rules);
            //$(filtercontrol).queryBuilder('ChangeFilters',newFilters);

        }
        return [];
    }
    initialFiltersRule() {
        var rules = this.getAppliedFiltersNames();
        var selects = this.getElementsByTagName(`select`);

        [...rules].forEach((x) => {
            var index;
            [...selects].forEach(y => {
                if (x == y.value)
                    index = y.name.replace("filters_rule_", "").replace("_filter", "");
            });


            this.filterRulesObject.push({ field: x, id: `filters_rule_${index}` });
        }
        );
    }
    showFilterRule(field) { // Show All Filter in  field rule
        [...this.filterRulesObject].forEach(x => {

            var opts = $(`#${x.id}`).find(`option[value=${field}]`);
            [...opts].forEach(opt => {
                $(opt).show();
            });
        });
    }
    hiddenFiltersRules() { // hidden duplicate filters in rules
        console.log(this.filterRulesObject);
        var rulesField = [...this.filterRulesObject].map(x => x.field);
        [...this.filterRulesObject].forEach(x => {
            var arrRulesField = [...rulesField].filter(t => t != x.field);
            [...arrRulesField].forEach(t => {
                var opts = $(`#${x.id}`).find(`option[value=${t}]`);
                [...opts].forEach(opt => {
                    $(opt).hide();
                })
            });
        });
    }
}

function callDefinedCharts(url) {
    var spinner = new Spinner().spin(document.getElementById("charts"));
    fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            Accept: "application/json",
        },
        body: JSON.stringify({ req: null, procFilters: exRules }),
    }).then(x => x.json()).then(data => {
        [...data].forEach(x => {
            var charttype = document.getElementById(x.ChartId).dataset.type;

            makedynamicChart(parseInt(charttype), x.Data, x.Title, x.ChartId, x.Val, x.Cat)

        });
        $(".spinner").remove();
    })
}
customElements.define("filters-control", ExternalFilter);