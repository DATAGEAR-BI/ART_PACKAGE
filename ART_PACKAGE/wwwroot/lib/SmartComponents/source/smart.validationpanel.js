
/* Smart UI v15.0.0 (2023-01-23) 
Copyright (c) 2011-2023 jQWidgets. 
License: https://htmlelements.com/license/ */ //

Smart.Utilities.Assign("ValidationPanel",class{constructor(e,t="en",a=""){const n=this;n._setLocalizationSettings(t,a),n.dataValidationModal=document.querySelector(e),n.criteriaType={Number:{between:{numberOfInputs:2,textBetweenInputs:n.messages[n.locale].andTextBetweenInput?n.messages[n.locale].andTextBetweenInput:n.defaultMessages[n.defaultLocale].andTextBetweenInput,"placeholderInput-1":"10","placeholderInput-2":"100",validationText:n.messages[n.locale].numberBetweenValidationText?n.messages[n.locale].numberBetweenValidationText:n.defaultMessages[n.defaultLocale].numberBetweenValidationText},not_between:{numberOfInputs:2,textBetweenInputs:n.messages[n.locale].andTextBetweenInput?n.messages[n.locale].andTextBetweenInput:n.defaultMessages[n.defaultLocale].andTextBetweenInput,"placeholderInput-1":"10","placeholderInput-2":"100",validationText:n.messages[n.locale].numberNotBetweenValidationText?n.messages[n.locale].numberNotBetweenValidationText:n.defaultMessages[n.defaultLocale].numberNotBetweenValidationText},less_than:{numberOfInputs:1,"placeholderInput-1":"10",validationText:n.messages[n.locale].numberLessThanValidationText?n.messages[n.locale].numberLessThanValidationText:n.defaultMessages[n.defaultLocale].numberLessThanValidationText},less_than_or_equal_to:{numberOfInputs:1,"placeholderInput-1":"10",validationText:n.messages[n.locale].numberLessThanOrEqualToValidationText?n.messages[n.locale].numberLessThanOrEqualToValidationText:n.defaultMessages[n.defaultLocale].numberLessThanOrEqualToValidationText},greater_than:{numberOfInputs:1,"placeholderInput-1":"10",validationText:n.messages[n.locale].numberGreaterThanValidationText?n.messages[n.locale].numberGreaterThanValidationText:n.defaultMessages[n.defaultLocale].numberGreaterThanValidationText},greater_than_or_equal_to:{numberOfInputs:1,"placeholderInput-1":"10",validationText:n.messages[n.locale].numberGreaterThanOrEqualToValidationText?n.messages[n.locale].numberGreaterThanOrEqualToValidationText:n.defaultMessages[n.defaultLocale].numberGreaterThanOrEqualToValidationText},equal_to:{numberOfInputs:1,"placeholderInput-1":"10",validationText:n.messages[n.locale].numberEqualToValidationText?n.messages[n.locale].numberEqualToValidationText:n.defaultMessages[n.defaultLocale].numberEqualToValidationText},not_equal_to:{numberOfInputs:1,"placeholderInput-1":"10",validationText:n.messages[n.locale].numberNotEqualToValidationText?n.messages[n.locale].numberNotEqualToValidationText:n.defaultMessages[n.defaultLocale].numberNotEqualToValidationText}},Text:{contains:{numberOfInputs:1,"placeholderInput-1":"Approved",validationText:n.messages[n.locale].textContainsValidationText?n.messages[n.locale].textContainsValidationText:n.defaultMessages[n.defaultLocale].textContainsValidationText},does_not_contain:{numberOfInputs:1,"placeholderInput-1":"Approved",validationText:n.messages[n.locale].textNotContainsValidationText?n.messages[n.locale].textNotContainsValidationText:n.defaultMessages[n.defaultLocale].textNotContainsValidationText},equals:{numberOfInputs:1,"placeholderInput-1":"Approved",validationText:n.messages[n.locale].textEqualsValidationText?n.messages[n.locale].textEqualsValidationText:n.defaultMessages[n.defaultLocale].textEqualsValidationText},is_valid_email:{numberOfInputs:0,validationText:n.messages[n.locale].textValidEmailValidationText?n.messages[n.locale].textValidEmailValidationText:n.defaultMessages[n.defaultLocale].textValidEmailValidationText},is_valid_url:{numberOfInputs:0,validationText:n.messages[n.locale].textValidUrlValidationText?n.messages[n.locale].textValidUrlValidationText:n.defaultMessages[n.defaultLocale].textValidUrlValidationText}},Date:{is_valid_date:{numberOfInputs:0,validationText:n.messages[n.locale].dateValidDateValidationText?n.messages[n.locale].dateValidDateValidationText:n.defaultMessages[n.defaultLocale].dateValidDateValidationText},equal_to:{numberOfInputs:1,"placeholderInput-1":"11/2017",validationText:n.messages[n.locale].dateEqualToValidationText?n.messages[n.locale].dateEqualToValidationText:n.defaultMessages[n.defaultLocale].dateEqualToValidationText},before:{numberOfInputs:1,"placeholderInput-1":"11/2017",validationText:n.messages[n.locale].dateBeforeValidationText?n.messages[n.locale].dateBeforeValidationText:n.defaultMessages[n.defaultLocale].dateBeforeValidationText},on_or_before:{numberOfInputs:1,"placeholderInput-1":"11/2017",validationText:n.messages[n.locale].dateOnOrBeforeValidationText?n.messages[n.locale].dateOnOrBeforeValidationText:n.defaultMessages[n.defaultLocale].dateOnOrBeforeValidationText},after:{numberOfInputs:1,"placeholderInput-1":"11/2017",validationText:n.messages[n.locale].dateAfterValidationText?n.messages[n.locale].dateAfterValidationText:n.defaultMessages[n.defaultLocale].dateAfterValidationText},on_or_after:{numberOfInputs:1,"placeholderInput-1":"11/2017",validationText:n.messages[n.locale].dateOnOrAfterValidationText?n.messages[n.locale].dateOnOrAfterValidationText:n.defaultMessages[n.defaultLocale].dateOnOrAfterValidationText},between:{numberOfInputs:2,textBetweenInputs:n.messages[n.locale].andTextBetweenInput?n.messages[n.locale].andTextBetweenInput:n.defaultMessages[n.defaultLocale].andTextBetweenInput,"placeholderInput-1":"11/2017","placeholderInput-2":"11/2018",validationText:n.messages[n.locale].dateBetweenValidationText?n.messages[n.locale].dateBetweenValidationText:n.defaultMessages[n.defaultLocale].dateBetweenValidationText},not_between:{numberOfInputs:2,textBetweenInputs:n.messages[n.locale].andTextBetweenInput?n.messages[n.locale].andTextBetweenInput:n.defaultMessages[n.defaultLocale].andTextBetweenInput,"placeholderInput-1":"11/2017","placeholderInput-2":"11/2018",validationText:n.messages[n.locale].dateNotBetweenValidationText?n.messages[n.locale].dateNotBetweenValidationText:n.defaultMessages[n.defaultLocale].dateNotBetweenValidationText}},Boolean:{"":{numberOfInputs:0,validationText:n.messages[n.locale].booleanValidationText?n.messages[n.locale].booleanValidationText:n.defaultMessages[n.defaultLocale].booleanValidationText}}},n._initContainers(),n._initDataTypeCriterias()}detach(){this._removeEventListeners()}_removeEventListeners(){const e=this;e.removeValidationButton.removeEventListener("click",e.removeValidationButton["reset-validation-form"]),delete e.removeValidationButton["reset-validation-form"],e.submitButton.removeEventListener("click",e.submitButton["submit-validation-form"]),delete e.submitButton["submit-validation-form"],e.appearanceCheckbox.removeEventListener("click",e.appearanceCheckbox["appearance-checkbox-change"]),delete e.appearanceCheckbox["appearance-checkbox-change"],e.smartInputCriteriaType.removeEventListener("change",e.smartInputCriteriaType["criteria-type-change"]),delete e.smartInputCriteriaType["criteria-type-change"],e.smartInputCriteria.removeEventListener("change",e.smartInputCriteria["criteria-change"]),delete e.smartInputCriteria["criteria-change"]}_setLocalizationSettings(e,t){const a=this;a.locale=e,a.messages=t,a.defaultLocale="en",a.defaultMessages={en:{criteriaText:"Criteria:",onInavlidData:"On invalid data:",appearance:"Appearance:",showWarning:"Show warning",rejectInput:"Reject input",showValidationHelpText:"Show validation help text:",cancelButtonText:"cancel",removeValidationButtonText:"remove validation",saveButtonText:"save",andTextBetweenInput:"and",expectTrue:"Expect true",expectFalse:"Expect false",resetButtonText:"Reset",NumberDataTypeText:"Number",Number_between:"between",Number_not_between:"not between",Number_less_than:"less than",Number_less_than_or_equal_to:"less than or equal to",Number_greater_than:"greater than",Number_greater_than_or_equal_to:"greater than or equal to",Number_equal_to:"equal to",Number_not_equal_to:"not equal to",TextDataTypeText:"Text",Text_contains:"contains",Text_does_not_contain:"does not contain",Text_equals:"equals",Text_is_valid_email:"is valid email",Text_is_valid_url:"is valid url",DateDataTypeText:"Date",Date_is_valid_date:"is valid date",Date_equal_to:"equal to",Date_before:"before",Date_on_or_before:"on or before",Date_after:"after",Date_on_or_after:"on or after",Date_between:"between",Date_not_between:"not between",BooleanDataTypeText:"Boolean",numberBetweenValidationText:"Enter a number between",numberNotBetweenValidationText:"Enter a number not between",numberLessThanValidationText:"Enter a number less than",numberLessThanOrEqualToValidationText:"Enter a number less than or equal to",numberGreaterThanValidationText:"Enter a number greater than",numberGreaterThanOrEqualToValidationText:"Enter a number greater than or equal to",numberEqualToValidationText:"Enter a number equal to",numberNotEqualToValidationText:"Enter a number not equal to",textContainsValidationText:"Enter text that contains",textNotContainsValidationText:"Enter text that does not contain",textEqualsValidationText:"Enter text that equals",textValidEmailValidationText:"Enter a valid email",textValidUrlValidationText:"Enter a valid url",dateValidDateValidationText:"Enter a valid date",dateEqualToValidationText:"Enter a date equal to",dateBeforeValidationText:"Enter a date before",dateOnOrBeforeValidationText:"Enter a date on or before",dateAfterValidationText:"Enter a date after",dateOnOrAfterValidationText:"Enter a date on or after",dateBetweenValidationText:"Enter a date between",dateNotBetweenValidationText:"Enter a date not between",booleanValidationText:"Enter 'true' or 'false'"}},a.messages||(a.messages=a.defaultMessages),a.messages[a.locale]||(a.messages[a.defaultLocale]||(a.messages=a.defaultMessages),a.locale=a.defaultLocale)}getDataValidationFormat(){const e=this;let t=!1,a=e.smartInputCriteria.$.input.dataValue;a||(a=e.smartInputCriteria.label);let n="";e.smartInputCriteriaType&&(n=e.smartInputCriteriaType.$.input.dataValue,n||(n=e.smartInputCriteriaType.label));let i="",l=[],o=e.inputsCriteriaContainer.querySelectorAll("smart-text-box");if(o)for(let e=0;e<o.length;e++)l[e]=o[e].value;if(l[0]&&(i=l[0],l[1]&&(i=JSON.stringify({from:l[0],to:l[1]}))),e.firstTextBox&&(e.firstTextBox.style.border="",e.firstTextBox.querySelector("input.smart-input").style.border="",o.length>=1&&(!l[0]||l[0]&&"Number"===a&&parseFloat(l[0]).toString()!==l[0].toString())&&(e.firstTextBox.style.border="1px solid red",e.firstTextBox.querySelector("input.smart-input").style.border="none",t=!0)),e.secondTextBox&&(e.secondTextBox.style.border="",e.secondTextBox.querySelector("input.smart-input").style.border="",2===o.length&&(!l[1]||l[1]&&"Number"===a&&parseFloat(l[1]).toString()!==l[1].toString())&&(e.secondTextBox.style.border="1px solid red",e.secondTextBox.querySelector("input.smart-input").style.border="none",t=!0)),t)return"";let r=e.onInvalidDataRadioOne.checked,s=e.onInvalidDataRadioTwo.checked,d="";e.appearanceContainer.querySelector(".smart-checkbox-appearance").checked&&(d=e.appearanceContainer.querySelector(".smart-appearance-text-box-value").value),"Boolean"===a&&(e.smartBooleanRadioYes.checked?n=!0:e.smartBooleanRadioNo.checked&&(n=!1));let u={dataType:a.toLowerCase(),condition:n,value:i,showWarning:r,rejectInput:s,validationHelpText:d};return JSON.stringify(u)}resetDataValidationForm(){const e=this;e.smartInputCriteria.value=e.smartInputCriterias[0].label,e.smartInputCriteria.label=e.smartInputCriterias[0].value,e.smartInputCriteria.$.input.dataValue=e.smartInputCriterias[0].value;let t=e.smartInputCriteria;t.$.scrollView.attached=function(){requestAnimationFrame((()=>{t.$.scrollView.querySelector("ul li.active").classList.remove("active"),t.$.scrollView.querySelector('ul li[value="'+e.smartInputCriteria.label+'"]').classList.add("active")}))},e.onInvalidDataRadioOne.checked=!0,e.onInvalidDataRadioTwo.checked=!1,e.appearanceCheckbox.checked=!1,e.appearanceTextBox.classList.add("smart-hidden"),e._resetHandler(),e._initConditionCriterias()}_resetHandler(){const e=this;e.resetButton&&e.resetButton.remove(),e.appearanceTextBox.value=e.appearanceTextBox.dataset.defaultValue,e.appearanceTextBox.addEventListener("keydown",(()=>e._showResetButton()),{once:!0})}_showResetButton(){const e=this;void 0!==e.resetButton&&e.resetButton.remove(),e.resetButton=document.createElement("div"),e.resetButton.classList.add("reset-appearance"),e.resetButton.innerHTML=e.messages[e.locale].resetButtonText?e.messages[e.locale].resetButtonText:e.defaultMessages[e.defaultLocale].resetButtonText,e.resetButton.addEventListener("click",(()=>e._resetHandler()),{once:!0}),e.appearanceRightElementsResetContainer.appendChild(e.resetButton)}_initContainers(){const e=this;e.dataValidationContainer=document.createElement("div"),e.dataValidationContainer.classList.add("smart-data-validation-container"),e.criteriaContainer=document.createElement("div"),e.criteriaContainer.classList.add("smart-criteria-container"),e.criteriaTypeContainer=document.createElement("div"),e.criteriaTypeContainer.classList.add("smart-criteria-type-container"),e.inputsCriteriaContainer=document.createElement("div"),e.inputsCriteriaContainer.classList.add("smart-input-criteria-container"),e.textBetweenInputsHolder=document.createElement("div"),e.textBetweenInputsHolder.classList.add("smart-text-between-inputs-container"),e.onInvalidDataContainer=document.createElement("div"),e.onInvalidDataContainer.classList.add("smart-on-invalid-data-container"),e.appearanceContainer=document.createElement("div"),e.appearanceContainer.classList.add("smart-appearance"),e.footerButtonsContainer=document.createElement("div"),e.footerButtonsContainer.classList.add("smart-footer-buttons"),e._generateStaticElements()}_generateStaticElements(){const e=this;let t=document.createElement("div");t.classList.add("left-title"),e.footerButtonsContainer.appendChild(t);let a=document.createElement("div");a.classList.add("right-elements");let n=document.createElement("smart-button");n.classList.add("smart-cancel-footer-button"),n.innerHTML=e.messages[e.locale].cancelButtonText?e.messages[e.locale].cancelButtonText:e.defaultMessages[e.defaultLocale].cancelButtonText,a.appendChild(n),e.footerButtonsContainer.appendChild(a),e.removeValidationButton=document.createElement("smart-button"),e.removeValidationButton.classList.add("smart-remove-validation-footer-button"),e.removeValidationButton.innerHTML=e.messages[e.locale].removeValidationButtonText?e.messages[e.locale].removeValidationButtonText:e.defaultMessages[e.defaultLocale].removeValidationButtonText;const i=()=>e.resetDataValidationForm();e.removeValidationButton.addEventListener("click",i),e.removeValidationButton["reset-validation-form"]=i,a.appendChild(e.removeValidationButton),e.footerButtonsContainer.appendChild(a),e.submitButton=document.createElement("smart-button"),e.submitButton.classList.add("smart-save-footer-button"),e.submitButton.innerHTML=e.messages[e.locale].saveButtonText?e.messages[e.locale].saveButtonText:e.defaultMessages[e.defaultLocale].saveButtonText;const l=()=>e.getDataValidationFormat();e.submitButton.addEventListener("click",l),e.submitButton["submit-validation-form"]=l,a.appendChild(e.submitButton),e.footerButtonsContainer.appendChild(a),e.dataValidationModal.appendChild(e.footerButtonsContainer);let o=document.createElement("div");o.classList.add("left-title");let r=document.createElement("div");r.classList.add("smart-appearance-text"),r.innerHTML=e.messages[e.locale].appearance?e.messages[e.locale].appearance:e.defaultMessages[e.defaultLocale].appearance,o.appendChild(r),e.appearanceRightElementsTextContainer=document.createElement("div"),e.appearanceRightElementsTextContainer.classList.add("right-elements"),e.appearanceRightElementsResetContainer=document.createElement("div"),e.appearanceRightElementsResetContainer.classList.add("right-elements-reset"),e.appearanceCheckbox=document.createElement("smart-check-box"),e.appearanceCheckbox.classList.add("smart-checkbox-appearance"),e.appearanceCheckbox.innerHTML=e.messages[e.locale].showValidationHelpText?e.messages[e.locale].showValidationHelpText:e.defaultMessages[e.defaultLocale].showValidationHelpText,e.appearanceRightElementsTextContainer.appendChild(e.appearanceCheckbox),e.appearanceTextBox=document.createElement("smart-text-box"),e.appearanceTextBox.classList.add("smart-appearance-text-box-value"),e.appearanceTextBox.classList.add("smart-hidden"),e.appearanceRightElementsResetContainer.appendChild(e.appearanceTextBox);const s=()=>{e.appearanceTextBox.classList.toggle("smart-hidden"),e.resetButton&&e.resetButton.classList.toggle("smart-hidden")};e.appearanceCheckbox.addEventListener("click",s),e.appearanceCheckbox["appearance-checkbox-change"]=s,e.appearanceTextBox.addEventListener("keydown",(()=>e._showResetButton()),{once:!0}),e.appearanceContainer.appendChild(o),e.appearanceContainer.appendChild(e.appearanceRightElementsTextContainer),e.appearanceRightElementsTextContainer.appendChild(e.appearanceRightElementsResetContainer),e.dataValidationModal.appendChild(e.appearanceContainer);let d=document.createElement("div");d.classList.add("left-title");let u=document.createElement("div");u.innerHTML=e.messages[e.locale].onInavlidData?e.messages[e.locale].onInavlidData:e.defaultMessages[e.defaultLocale].onInavlidData,d.appendChild(u);let c=document.createElement("div");c.classList.add("right-elements"),e.onInvalidDataRadioOne=document.createElement("smart-radio-button"),e.onInvalidDataRadioOne.classList.add("smart-on-invalid-data-radio-button-show-warning"),e.onInvalidDataRadioOne.checked=!0,e.onInvalidDataRadioOne.innerHTML=e.messages[e.locale].showWarning?e.messages[e.locale].showWarning:e.defaultMessages[e.defaultLocale].showWarning,c.appendChild(e.onInvalidDataRadioOne),e.onInvalidDataRadioTwo=document.createElement("smart-radio-button"),e.onInvalidDataRadioTwo.classList.add("smart-on-invalid-data-radio-button-reject-input"),e.onInvalidDataRadioTwo.innerHTML=e.messages[e.locale].rejectInput?e.messages[e.locale].rejectInput:e.defaultMessages[e.defaultLocale].rejectInput,c.appendChild(e.onInvalidDataRadioTwo),e.onInvalidDataContainer.appendChild(d),e.onInvalidDataContainer.appendChild(c),e.dataValidationModal.appendChild(e.onInvalidDataContainer)}_initConditionValueCriterias(){const e=this;e.inputsCriteriaContainer.innerHTML="",e.textBetweenInputsHolder.innerHTML="";let t=e.smartInputCriteria.$.input.dataValue;t||(t=e.smartInputCriteria.label);let a=e.smartInputCriteriaType.$.input.dataValue;a||(a=e.smartInputCriteriaType.label);let n,i,l=Object.keys(e.criteriaType[t][a]);for(let o=0;o<l.length;o++){let r=l[o],s=e.criteriaType[t][a][l[o]];if("numberOfInputs"===r)for(let t=0;t<s;t++){let a=document.createElement("smart-text-box");a.classList.add("smart-text-box-value-"+(t+1)),e.inputsCriteriaContainer.appendChild(a)}else if("textBetweenInputs"===r){let t=document.createElement("div");t.classList.add("smart-text-between-inputs"),t.innerHTML=s,e.textBetweenInputsHolder=t}else"validationText"===r?(e.appearanceTextBox.value=s,e.appearanceTextBox.dataset.defaultValue=s):"placeholderInput-1"===r?n=s:"placeholderInput-2"===r&&(i=s)}e.inputsCriteriaContainer.appendChild(e.textBetweenInputsHolder),e.inputCriteriaRightElements.appendChild(e.inputsCriteriaContainer),e.dataValidationContainer.appendChild(e.inputCriteriaRightElements),e.dataValidationModal.appendChild(e.dataValidationContainer),e.firstTextBox=e.dataValidationModal.querySelector(".smart-text-box-value-1"),e.firstTextBox&&e.firstTextBox.setAttribute("placeholder",n),e.secondTextBox=e.dataValidationModal.querySelector(".smart-text-box-value-2"),e.secondTextBox&&e.secondTextBox.setAttribute("placeholder",i)}_initConditionCriterias(){const e=this;let t=e.smartInputCriteria.$.input.dataValue;if(t||(t=e.smartInputCriteria.label),e.criteriaTypeContainer.innerHTML="",e.inputsCriteriaContainer.innerHTML="",e.textBetweenInputsHolder.innerHTML="",e.smartInputCriteriaType=(e.smartInputCriteriaType,""),"Boolean"===t)e.smartBooleanRadioYes=document.createElement("smart-radio-button"),e.smartBooleanRadioYes.classList.add("smart-boolean-radio-yes"),e.smartBooleanRadioYes.checked=!0,e.smartBooleanRadioYes.innerHTML=e.messages[e.locale].expectTrue?e.messages[e.locale].expectTrue:e.defaultMessages[e.defaultLocale].expectTrue,e.smartBooleanRadioNo=document.createElement("smart-radio-button"),e.smartBooleanRadioNo.classList.add("smart-boolean-radio-no"),e.smartBooleanRadioNo.innerHTML=e.messages[e.locale].expectFalse?e.messages[e.locale].expectFalse:e.defaultMessages[e.defaultLocale].expectFalse,e.appearanceTextBox.value=e.criteriaType.Boolean[""].validationText,e.appearanceTextBox.dataset.defaultValue=e.criteriaType.Boolean[""].validationText,e.criteriaTypeContainer.appendChild(e.smartBooleanRadioYes),e.criteriaTypeContainer.appendChild(e.smartBooleanRadioNo),e.inputCriteriaRightElements.appendChild(e.criteriaTypeContainer),e.dataValidationContainer.appendChild(e.inputCriteriaRightElements),e.dataValidationModal.appendChild(e.dataValidationContainer);else{e.smartInputCriteriaType=document.createElement("smart-input"),e.smartInputCriteriaType.classList.add("smart-input-criteria-type"),e.smartInputCriteriaType.dropDownButtonPosition="right",e.smartInputCriteriaType.readonly=!0;let a=[];const n=()=>e._initConditionValueCriterias();e.smartInputCriteriaType.addEventListener("change",n),e.smartInputCriteriaType["criteria-type-change"]=n;for(let n=0;n<Object.keys(e.criteriaType).length;n++){if(Object.keys(e.criteriaType)[n]!==t)continue;let i=t,l=Object.keys(e.criteriaType[i]);for(let t=0;t<l.length;t++){let n=l[t],o=n.replace(/ /g,"_"),r=e.messages[e.locale][i+"_"+o]?e.messages[e.locale][i+"_"+o]:e.defaultMessages[e.defaultLocale][i+"_"+o];a.push({value:n,label:r})}}e.smartInputCriteriaType.dataSource=a,e.smartInputCriteriaType.value=a[0].label,e.smartInputCriteriaType.label=a[0].value,e.criteriaTypeContainer.appendChild(e.smartInputCriteriaType),e.inputCriteriaRightElements.appendChild(e.criteriaTypeContainer),e.dataValidationContainer.appendChild(e.inputCriteriaRightElements),e.dataValidationModal.appendChild(e.dataValidationContainer),e._initConditionValueCriterias()}}_initDataTypeCriterias(){const e=this;let t=document.createElement("div");t.classList.add("left-title");let a=document.createElement("div");a.classList.add("criteria-container"),a.innerHTML=e.messages[e.locale].criteriaText?e.messages[e.locale].criteriaText:e.defaultMessages[e.defaultLocale].criteriaText,t.appendChild(a),e.inputCriteriaRightElements=document.createElement("div"),e.inputCriteriaRightElements.classList.add("right-elements"),e.smartInputCriteria=document.createElement("smart-input"),e.smartInputCriteria.classList.add("smart-input-criteria"),e.smartInputCriteria.dropDownButtonPosition="right",e.smartInputCriteria.readonly=!0,e.smartInputCriterias=[];const n=()=>e._initConditionCriterias();e.smartInputCriteria.addEventListener("change",n),e.smartInputCriteria["criteria-change"]=n;for(let t=0;t<Object.keys(e.criteriaType).length;t++){let a=Object.keys(e.criteriaType)[t],n=e.messages[e.locale][a+"DataTypeText"]?e.messages[e.locale][a+"DataTypeText"]:e.defaultMessages[e.defaultLocale][a+"DataTypeText"];e.smartInputCriterias.push({value:a,label:n})}e.smartInputCriteria.dataSource=e.smartInputCriterias,e.smartInputCriteria.value=e.smartInputCriterias[0].label,e.smartInputCriteria.label=e.smartInputCriterias[0].value,e.criteriaContainer.appendChild(e.smartInputCriteria),e.inputCriteriaRightElements.appendChild(e.criteriaContainer),e.dataValidationContainer.appendChild(t),e.dataValidationContainer.appendChild(e.inputCriteriaRightElements),e.dataValidationModal.appendChild(e.dataValidationContainer),e.dataValidationModal.style.display="flex",e.dataValidationModal.style.flexDirection="column-reverse",e._initConditionCriterias()}});