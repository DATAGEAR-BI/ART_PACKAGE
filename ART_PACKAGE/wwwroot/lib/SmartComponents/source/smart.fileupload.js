
/* Smart UI v15.0.0 (2023-01-23) 
Copyright (c) 2011-2023 jQWidgets. 
License: https://htmlelements.com/license/ */ //

Smart("smart-file-upload",class extends Smart.BaseElement{static get properties(){return{accept:{value:null,type:"string?"},appendTo:{value:null,type:"any"},autoUpload:{value:!1,type:"boolean"},directory:{value:!1,type:"boolean"},dropZone:{value:null,type:"any"},hideFooter:{value:!1,type:"boolean"},itemTemplate:{value:null,type:"any"},messages:{value:{en:{browse:"Browse",uploadFile:"Upload File",cancelFile:"Cancel File",pauseFile:"Pause File",uploadAll:"Upload All",cancelAll:"Cancel All",pauseAll:"Pause All",totalFiles:"Total files: ",connectionError:"{{elementType}}: File Upload requires connection to the server.",wrongItemIndex:"{{elementType}}: There is no file with such an index in the list of uploaded files.",tooLongFileName:"{{elementType}}: File name is too long."}},type:"object",extend:!0},multiple:{value:!1,type:"boolean"},name:{value:"userfile[]",type:"string"},postData:{value:null,type:"object"},responseHandler:{value:null,type:"function?",reflectToAttribute:!1},setHeaders:{value:null,type:"function?",reflectToAttribute:!1},showProgress:{value:!1,type:"boolean"},validateFile:{value:null,type:"function?",reflectToAttribute:!1},uploadUrl:{value:"",type:"string",reflectToAttribute:!1},removeUrl:{value:"",type:"string",reflectToAttribute:!1}}}static get listeners(){return{"browseButton.click":"browse","browseButton.focus":"_focusHandler","browseButton.blur":"_blurHandler","browseInput.change":"_browseInputChangeHandler","selectedFiles.click":"_selectedFilesClickHandler","uploadAllButton.click":"uploadAll","cancelAllButton.click":"cancelAll","pauseAllButton.click":"pauseAll","dropZone.dragenter":"_dropZoneHandler","dropZone.dragleave":"_dropZoneHandler","dropZone.dragover":"_dropZoneHandler","dropZone.drop":"_dropZoneHandler",resize:"_handleComponentsByAvailableHeight"}}_blurHandler(){this.$.fireEvent("blur")}_focusHandler(){this.$.fireEvent("focus")}static get requires(){return{"Smart.Button":"smart.button.js","Smart.ProgressBar":"smart.progressbar.js"}}static get styleUrls(){return["smart.fileupload.css"]}template(){return'<div id="container" role="presentation">\n                    <div id="fileUploadHeader" class="smart-file-upload-header" role="presentation">\n                        <smart-button class="smart-browse-button" id="browseButton" disabled="[[disabled]]" theme="[[theme]]" right-to-left="[[rightToLeft]]"></smart-button>\n                        <input type="file" class="smart-browse-input" id="browseInput" name="[[name]]" animation="[[animation]]" disabled="[[disabled]]" unfocusable="[[unfocusable]]" multiple="[[multiple]]" webkitdirectory="[[directory]]" mozdirectory="[[directory]]" />\n                    </div>\n                    <div id="fileUploadContainer" class="smart-file-upload-container">\n                        <div id="dropZone" class="smart-drop-zone" aria-label="Drag files here"></div>\n                        <div id="selectedFiles" class="smart-selected-files" role="list" aria-label="Selected files"></div>\n                    </div>\n                    <div id="totalFiles" class="smart-total-files smart-hidden" role="presentation">Total flies: 0</div>\n                    <div id="fileUploadFooter" class="smart-file-upload-footer smart-hidden"><smart-button class="smart-upload-all-button success" id="uploadAllButton" animation="[[animation]]" disabled="[[disabled]]" unfocusable="[[unfocusable]]"" theme="[[theme]]" right-to-left="[[rightToLeft]]"></smart-button><smart-button class="smart-cancel-all-button error" id="cancelAllButton" animation="[[animation]]" disabled="[[disabled]]" unfocusable="[[unfocusable]]" theme="[[theme]]" right-to-left="[[rightToLeft]]"></smart-button><smart-button class="smart-pause-all-button primary" id="pauseAllButton" animation="[[animation]]" disabled="[[disabled]]" unfocusable="[[unfocusable]]" theme="[[theme]]" right-to-left="[[rightToLeft]]"></smart-button></div>\n                </div>'}propertyChangedHandler(e,t,l){const s=this;switch(super.propertyChangedHandler(e,t,l),e){case"accept":s.$.browseInput.accept=l;break;case"dropZone":case"appendTo":s._handleContainers();break;case"messages":case"locale":s._updateTextValues();break;case"multiple":s.$.browseButton.disabled=!!(!s.multiple&&s._selectedFiles.length>0||s.disabled),!l&&s._selectedFiles.length>1&&(s._selectedFiles.splice(1),s._renderSelectedFiles());break;case"itemTemplate":s._items.length>0&&(s._renderSelectedFiles(),s._handleComponentsByAvailableHeight());break;case"rightToLeft":s._items&&s._items.forEach((e=>{const t=e.querySelector("smart-progress-bar");t&&(t.rightToLeft=l),l?e.setAttribute("right-to-left",""):e.removeAttribute("right-to-left")})),l?s.$.dropZone.setAttribute("right-to-left",""):s.$.dropZone.removeAttribute("right-to-left")}}attached(){super.attached(),this._handleContainers()}detached(){super.detached();const e=this;e.$.fileUploadContainer.contains(e.$.dropZone)||e.$.fileUploadContainer.insertBefore(e.$.dropZone,e.$.fileUploadContainer.firstChild),e.$.fileUploadContainer.contains(e.$.selectedFiles)||e.$.fileUploadContainer.appendChild(e.$.selectedFiles)}ready(){super.ready();const e=this;e.$.dropZone.id||(e.$.dropZone.id=e.id+"DropZone"),e.$.selectedFiles.id||(e.$.selectedFiles.id=e.id+"SelectedFiles"),e.$.fileUploadContainer.setAttribute("aria-owns",e.$.dropZone.id+" "+e.$.selectedFiles.id),e.setAttribute("role","dialog"),e.rightToLeft?e.$.dropZone.setAttribute("right-to-left",""):e.$.dropZone.removeAttribute("right-to-left"),e._setInitialValues(),e._updateTextValues(),e._handleContainers(),e._handleComponentsByAvailableHeight()}browse(){const e=this;e.disabled||!e.multiple&&e._selectedFiles.length>0||e.$.browseInput.click()}addFile(e){const t=this,l=t.multiple;let s=t._selectedFiles;s&&(l||!s.length)&&e instanceof File&&("function"!=typeof t.validateFile||t.validateFile(e))&&(s=s.push(e),t._renderSelectedFiles([e]),t.$.browseButton.disabled=!!(!l&&s.length>0||t.disabled),t.$.browseInput.value="")}cancelAll(){const e=this;if(!e.disabled&&0!==e._items.length){for(let t=e._items.length-1;t>=0;t--)e.cancelFile(e._items[t].index);e.$.browseButton.disabled=!!(!e.multiple&&e._selectedFiles.length>0||e.disabled)}}cancelFile(e){const t=this,l=()=>{t.$.selectedFiles.removeChild(s),t._selectedFiles.splice(i,1),t._items.splice(i,1),t.$.fireEvent("uploadCanceled",{filename:s.file.name,type:s.file.type,size:s.file.size,index:s.index}),t.$.browseButton.disabled=!!(!t.multiple&&t._selectedFiles.length>0||t.disabled),0===t._selectedFiles.length&&t.$.fileUploadFooter.classList.add("smart-hidden"),t._handleComponentsByAvailableHeight()};if("number"!=typeof e||t.disabled||0===t._selectedFiles.length)return;const s=t._getFileItem(e,!0);if(!s)return void t.error(t.localize("wrongItemIndex",{elementType:t.nodeName.toLowerCase()}));const i=t._items.indexOf(s),a=t._selectedFiles[i];if(s&&s.xhr&&s.xhr.abort(),!t.removeUrl)return void l();let n=new FormData,r=new XMLHttpRequest;n.append(t.name,a),r.open("POST",t.removeUrl),t.setHeaders&&"function"==typeof t.setHeaders&&t.setHeaders(r,a),r.onload=function(){r.status>=200&&r.status<=299?l():t.$.fireEvent("uploadCanceledError",{filename:s.file.name,type:s.file.type,size:s.file.size,status:r.status,index:s.index})},r.onreadystatechange=function(){t.responseHandler&&"function"==typeof t.responseHandler&&t.responseHandler(r)},r.send(n)}get value(){return this._selectedFiles}get files(){return this._selectedFiles}pauseAll(){const e=this;if(!e.disabled&&0!==e._items.length)for(let t=e._items.length-1;t>=0;t--){let l=e._items[t];l.xhr&&l.xhr.abort()}}pauseFile(e){const t=this;if("number"!=typeof e&&"string"!=typeof e||t.disabled||0===t._items.length)return;const l=t._getFileItem(e,!0);l?(l.classList.remove("smart-uploading-start"),l&&l.xhr&&l.xhr.abort(),t.$.fireEvent("uploadPaused",{filename:l.file.name,type:l.file.type,size:l.file.size,index:l.index})):t.error(t.localize("wrongItemIndex",{elementType:t.nodeName.toLowerCase()}))}uploadAll(){const e=this;if(!e.disabled&&0!==e._items.length)for(let t=e._items.length-1;t>=0;t--)e._items[t].uploading||e.uploadFile(e._items[t].index)}uploadFile(e){const t=this;let l=!1;if("number"!=typeof e||t.disabled||0===t._selectedFiles.length)return;const s=t._getFileItem(e,!0);if(!s)return;let i=new FormData,a=t.showProgress?s.getElementsByTagName("smart-progress-bar")[0]:null,n=s.file,r="";t.postData?r=JSON.stringify(t.postData):t.getAttribute("post-data")&&(r=t.getAttribute("post-data")),r&&""!==r&&i.append("postData",r),s.classList.remove("smart-pause","smart-error"),s.classList.add("smart-uploading-start"),i.append(t.name,n);let o=new XMLHttpRequest;o.open("POST",t.uploadUrl),t.setHeaders&&"function"==typeof t.setHeaders&&t.setHeaders(o,n),t.$.fireEvent("uploadStarted",{filename:s.file.name,type:s.file.type,size:s.file.size,index:s.index}),o.upload.onprogress=function(e){l||(l=!0,s.classList.remove("smart-uploading-start"),s.classList.add("smart-uploading"),s.uploading=!0,s.xhr=o),a&&(a.value=Math.round(e.loaded/e.total*100)),s.classList.remove("smart-pause","smart-error")},o.onabort=function(){s.classList.remove("smart-uploading-start","smart-uploading"),s.classList.add("smart-pause"),s.addEventListener("animationend",(function(){s.classList.remove("smart-pause","smart-error")}))},o.onerror=function(){s.classList.remove("smart-uploading-start","smart-uploading"),s.classList.add("smart-error"),s.addEventListener("animationend",(function(){s.classList.remove("smart-pause","smart-error")}))},o.onload=function(){if(l=!1,s.classList.remove("smart-uploading-start","smart-uploading"),o.status>=200&&o.status<=299){let e=t._items.indexOf(s);t.$.selectedFiles.removeChild(s),t._selectedFiles.splice(t._selectedFiles.indexOf(n),1),t._items.splice(e,1),t.$.browseButton.disabled=!!(!t.multiple&&t._selectedFiles.length>0||t.disabled);let l=t.uploadUrl+"/"+s.file.name;o.fileURL&&(l=o.file_url);let i=!1;o.response&&("string"==typeof o.response?(i=o.response,i&&i.indexOf("[{")>=0&&(i=JSON.parse(i))):i=JSON.parse(o.response),i&&(Array.isArray(i)?i[0].file_url?l=i[0].file_url:i[0].fileURL&&(l=i[0].fileURL):i.file_url?l=i.file_url:i.fileURL&&(l=i.fileURL))),t.$.fireEvent("uploadCompleted",{filename:s.file.name,type:s.file.type,size:s.file.size,status:o.status,index:s.index,fileURL:l,serverResponse:i}),0===t._selectedFiles.length&&t.$.fileUploadFooter.classList.add("smart-hidden")}else{s.classList.add("smart-error"),s.classList.remove("smart-uploading");let e="no server response";o.response&&(e="string"==typeof o.response?o.response:JSON.parse(o.response)),t.$.fireEvent("uploadError",{filename:s.file.name,type:s.file.type,size:s.file.size,status:o.status,index:s.index,serverResponse:e})}},o.onreadystatechange=function(){t.responseHandler&&"function"==typeof t.responseHandler&&t.responseHandler(o)},o.send(i)}_selectedFilesClickHandler(e){const t=this;if(t.disabled)return;const l=e.target,s=l.closest(".smart-item-upload-button"),i=l.closest(".smart-item-cancel-button"),a=l.closest(".smart-item-pause-button"),n=l.closest(".smart-file");s?t.uploadFile(n.index):i?t.cancelFile(n.index):a&&t.pauseFile(n.index)}_browseInputChangeHandler(){const e=this,t=e._filterNewFiles(Array.from(e.$.browseInput.files));let l=[];e.disabled||0===t.length||(l=e.validateFile&&"function"==typeof e.validateFile?t.filter((t=>!!e.validateFile(t)||(e.$.fireEvent("validationError",{filename:t.name,type:t.type,size:t.size}),!1))):t,e._selectedFiles=e._selectedFiles.concat(l),0!==e._selectedFiles.length&&(e._renderSelectedFiles(l),e.$.browseButton.disabled=!!(!e.multiple&&e._selectedFiles.length>0||e.disabled),e.$.browseInput.value="",e.autoUpload&&e.uploadAll()))}_defaultItemTemplate(e,t){const l=this,s=l.localize("uploadFile"),i=l.localize("cancelFile"),a=l.localize("pauseFile"),n=l.rightToLeft?"right-to-left ":"";return`<span id="${l.id+"File"+t+"Name"}" class="smart-item-name">${e}</span><span class="smart-item-upload-button" title="${s}" role="button" aria-label="${s}"></span><span class="smart-item-cancel-button" title="${i}" role="button" aria-label="${i}"></span><span class="smart-item-pause-button" title="${a}" role="button" aria-label="${a}"></span><smart-progress-bar ${n}aria-label="Upload progress"></smart-progress-bar>`}_dropZoneHandler(e){const t=this;if(e.preventDefault(),e.stopPropagation(),!t.disabled)if("dragenter"!==e.type&&"dragleave"!==e.type){if("drop"===e.type){if(t.$.dropZone.classList.remove("smart-drag-over"),!t.multiple&&t._selectedFiles.length>0)return;if(e.dataTransfer&&e.dataTransfer.files&&e.dataTransfer.files.length){const l=t._filterNewFiles(Array.from(e.dataTransfer.files));if(0===l.length)return;t.multiple||l.splice(1);let s=[];if(t.disabled)return;if(s=t.validateFile&&"function"==typeof t.validateFile?l.filter((e=>!!t.validateFile(e)||(t.$.fireEvent("validationError",{filename:e.name,type:e.type,size:e.size}),!1))):l,t._selectedFiles=t._selectedFiles.concat(s),0===t._selectedFiles.length)return;t._renderSelectedFiles(l)}t.$.browseButton.disabled=!!(!t.multiple&&t._selectedFiles.length>0||t.disabled)}}else"dragenter"===e.type?t.$.dropZone.classList.add("smart-drag-over"):t.$.dropZone.classList.remove("smart-drag-over")}_filterNewFiles(e){const t=this;let l=[];for(let s=0;s<e.length;s++){let i=!0;for(let l=0;l<t._selectedFiles.length;l++){const a=t._selectedFiles[l],n=e[s];if(n.name===a.name&&n.size===a.size&&n.type===a.type&&n.lastModified===a.lastModified){i=!1;break}}i&&l.push(e[s])}return l}_getFileItem(e,t){const l=this;let s=null;if(e&&("string"==typeof e||"number"==typeof e)){if(!l._items||0===l._items.length)return null;for(let i=0;i<l._items.length;i++){const a=l._items[i];(t&&a.index===parseInt(e)||a.file.name===e)&&(s=a)}return s}}_handleContainers(){const e=this,t=e._validateDOMElement(e.dropZone),l=e._validateDOMElement(e.appendTo);t?t.appendChild(e.$.dropZone):e.$.fileUploadContainer.insertBefore(e.$.dropZone,e.$.fileUploadContainer.firstChild),l?l.appendChild(e.$.selectedFiles):e.$.fileUploadContainer.appendChild(e.$.selectedFiles)}_handleItemTemplate(e,t){const l=this;let s=l.itemTemplate;if("content"in document.createElement("template")){if(!s)return l._defaultItemTemplate(e,t);if("string"==typeof s&&(s=document.getElementById(s)),null!==s&&"content"in s)return s.innerHTML.replace(/{{\w+}}/g,e);l.error(l.localize("invalidTemplate",{elementType:l.nodeName.toLowerCase(),property:"template"}))}else l.error(l.localize("htmlTemplateNotSuported",{elementType:l.nodeName.toLowerCase()}))}_renderSelectedFiles(e){const t=this,l=document.createDocumentFragment(),s=e||t._selectedFiles;e||(t._items=[],t.$.selectedFiles.innerHTML="");for(let e=0;e<s.length;e++){const i=t.directory?s[e].webkitRelativePath:s[e].name,a=document.createElement("div");t._incrementIndex++,a.className="smart-file",a.index=t._incrementIndex,a.setAttribute("item-id",t._incrementIndex),a.innerHTML=t.itemTemplate?t._handleItemTemplate(i,t._incrementIndex):t._defaultItemTemplate(i,t._incrementIndex),a.file=s[e],a.uploading=!1,a.xhr=null,a.setAttribute("role","listitem"),a.setAttribute("aria-labelledby",t.id+"File"+t._incrementIndex+"Name"),t.rightToLeft&&a.setAttribute("right-to-left",""),l.appendChild(a),t._items.push(a),t.$.fireEvent("fileSelected",{filename:s[e].name,type:s[e].type,size:s[e].size,index:a.index})}t.$.selectedFiles.appendChild(l),t.$.fileUploadFooter.classList.remove("smart-hidden"),t._handleComponentsByAvailableHeight()}_setInitialValues(){const e=this;e.$.browseInput.accept=e.accept,e._selectedFiles=[],e._items=[],e._incrementIndex=0}_updateTextValues(){const e=this,t=["browse","uploadAll","cancelAll","pauseAll"];for(let l=0;l<t.length;l++){const s=t[l],i=s+"Button";e.$[i].innerHTML=e.localize(s)}for(let t=0;t<e._selectedFiles.length;t++){const l=e._items[t];l.querySelector(".smart-item-upload-button").title=e.localize("uploadFile"),l.querySelector(".smart-item-cancel-button").title=e.localize("cancelFile"),l.querySelector(".smart-item-pause-button").title=e.localize("pauseFile")}}_validateDOMElement(e){if(e)return"string"==typeof e?document.getElementById(e):e instanceof HTMLElement?e:void 0}refresh(){this._handleComponentsByAvailableHeight()}_handleComponentsByAvailableHeight(){const e=this;if(e._calculateAvailableContainerHeight(),e._elementsAutoHeight>e.offsetHeight){if(e.$.container.classList.add("smart-overflow"),e._containerOverflows=!0,e._rowHeight){const t=parseInt(e._availableHeight/e._rowHeight);for(let l=0;l<e._items.length;l++){const s=e._items[l];l<t?s.classList.remove("smart-hidden"):s.classList.add("smart-hidden")}e._items.length>t?(e.$.totalFiles.innerHTML=e.localize("totalFiles")+e._items.length,e.$.totalFiles.classList.remove("smart-hidden")):e.$.totalFiles.classList.add("smart-hidden")}}else""===e.dropZone&&e._elementsAutoHeight<e.offsetHeight&&(e.$.container.classList.remove("smart-overflow"),e._containerOverflows=!1)}_calculateAvailableContainerHeight(){const e=this,t=window.getComputedStyle(e.$.fileUploadContainer,null),l=parseInt(t.getPropertyValue("margin-top"))+parseInt(t.getPropertyValue("margin-bottom"))+parseInt(t.getPropertyValue("padding-top"))+parseInt(t.getPropertyValue("padding-bottom")),s=e.$.container.querySelector(".smart-file"),i=e.$.fileUploadHeader.offsetHeight,a=e.$.fileUploadFooter.offsetHeight,n=e.style.height;let r=0;s&&(e._rowHeight=s.offsetHeight),e.style.height="auto",e._containerOverflows&&e.$.container.classList.remove("smart-overflow"),e._elementsAutoHeight=e.offsetHeight,e.style.height=n,e._containerOverflows&&e.$.container.classList.add("smart-overflow"),e.$.totalFiles.classList.contains("smart-hidden")&&(e.$.totalFiles.classList.remove("smart-hidden"),r=e.$.totalFiles.offsetHeight,e.$.totalFiles.classList.add("smart-hidden")),e._availableHeight=e.offsetHeight-(i+a)-l-r}});