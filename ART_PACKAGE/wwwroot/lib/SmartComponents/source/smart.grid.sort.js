
/* Smart UI v15.0.0 (2023-01-23) 
Copyright (c) 2011-2023 jQWidgets. 
License: https://htmlelements.com/license/ */ //

Smart.Utilities.Assign("Grid.Sort",class{clearSort(){const t=this;if(!t._isSorting&&t.dataSource){t._isSorting=!0,t.dataSource.clearSort(),t._sortedColumns||(t._sortedColumns=[]);for(let r=0;r<t._sortedColumns.length;r++){const o=t._sortedColumns[r],e=t.columnByDataField[o.dataField];e&&(e.setProperty("sortOrder",null),e.setProperty("sortIndex",null))}t._sortedColumns=[],t.rowById=[];for(let r=0;r<t.dataSource.length;r++){const o=t.rows[r],e=t.dataSource[r];o&&(o.data=e,e&&e.$&&(o.id=e.$.id,o._updateData()),t.rowById[o.id]=o)}t._recycle(),t._refreshHeaderBar(),t._isSorting=!1}}getSortedColumns(){const t=this,r=[];if(t._sortedColumns)for(let o=0;o<t._sortedColumns.length;o++){const e=t._sortedColumns[o];r[e.dataField]={sortOrder:e.sortOrder,sortIndex:e.sortIndex},r.length++}return r}addSort(t,r){this.sortBy(t,r)}removeSort(t){this.sortBy(t,null)}refreshSort(){this._refreshSort(this._sortedColumns)}_refreshSort(t){const r=this;if(r._isSorting||!t)return;if(r._suppressSort)return;if(!1===r.sorting.maintainSort)return;const o=[],e=[],s=[];r._isSorting=!0;let a=[];for(let n=0;n<t.length;n++){const d=t[n],i=r.columnByDataField[d.dataField];i&&(i.setProperty("sortOrder",d.sortOrder),i.sortComparator&&(a[i.dataField]=i.sortComparator),o.push(d.dataField),e.push(d.sortOrder),s.push(d.dataType||"string"))}!function(){if(r.dataSource&&(r.dataSource.sortComparators=a),r.dataSource&&r.dataSource.virtualDataSource)r._virtualDataRequest("sort");else{if(r.dataSource.sortBy(o,s,e),r.dataSource.boundHierarchy)r._refreshRowHierarchy(),r.dataSource.groupBy.length>0&&(r._refreshRowHierarchy(!0,!0),r.refresh());else{r.rowById=[];for(let t=0;t<r.dataSource.length;t++){const o=r.rows[t],e=r.dataSource[t];o.data=e,o.id=e.$.id,o._updateData(),r.rowById[o.id]=o}}r._recycle()}}(),r._refreshHeaderBar(),r._isSorting=!1,r._sortedColumns=t}sortBy(t,r){const o=this,e=o.columnByDataField[t],s=[],a=[],n=[],d=void 0===r;if(o._isSorting||!e)return;o._isSorting=!0,"descending"===r&&(r="desc"),void 0!==r&&"ascending"!==r||(r="asc");const i=function(t){t&&(t.setProperty("sortOrder",null),t.setProperty("sortIndex",null))},l=function(){if(o._sortedColumns.length>0)for(let t=0;t<o._sortedColumns.length;t++){const r=o._sortedColumns[t],e=o.columnByDataField[r.dataField];i(e)}o._sortedColumns=[]};if(null===e)return l(),void(o._isSorting=!1);if(!o.sorting.enabled||!o.dataSource||!e.allowSort||o._sortAnimation)return void(o._isSorting=!1);i(e),o._sortedColumns||(o._sortedColumns=[]);let u="string";for(let r=0;r<o.dataSource.dataFields.length;r++){const e=o.dataSource.dataFields[r];if(e.name===t){u=e.dataType;break}}let c=!0;for(let s=0;s<o._sortedColumns.length;s++){const a=o._sortedColumns[s];if(a.dataField===t)if(c=!1,a.sortIndex=e.sortIndex,d){if("asc"===a.sortOrder)a.sortOrder="desc",r="desc";else if("desc"===a.sortOrder){o.sorting.sortToggleThreeStates?(o._sortedColumns.splice(s,1),i(e),r=null):(a.sortOrder="asc",r="asc");break}}else a.sortOrder=r,null===r&&(o._sortedColumns.splice(s,1),i(e))}c&&("one"===o.sorting.mode&&l(),"many"===o.sorting.mode&&!1===o._canSort&&l(),null!==r&&o._sortedColumns.push({dataField:t,sortOrder:r,sortIndex:e.sortIndex,dataType:u})),e.setProperty("sortOrder",r),o._sortedColumns.sort(((t,r)=>"string"==typeof t.sortIndex&&"string"==typeof r.sortIndex?0:"number"==typeof t.sortIndex&&"string"==typeof r.sortIndex?-1:"string"==typeof t.sortIndex&&"number"==typeof r.sortIndex?1:"number"==typeof t.sortIndex&&"number"==typeof r.sortIndex?t.sortIndex-r.sortIndex:void 0));const m=[];for(let t=0;t<o._sortedColumns.length;t++){const r=o._sortedColumns[t];s.push(r.dataField),a.push(r.sortOrder),n.push(r.dataType||"string");const e=o.columnByDataField[r.dataField];e.sortComparator&&(m[e.dataField]=e.sortComparator)}const f=function(){if(o.dataSource.sortComparators=m,o.dataSource&&o.dataSource.virtualDataSource)o._virtualDataRequest("sort");else{if(o.dataSource.sortBy(s,n,a),o.dataSource.boundHierarchy)o._refreshRowHierarchy(),o.dataSource.groupBy.length>0&&o._refreshRowHierarchy(!0,!0),o.refresh();else{o.rowById=[];for(let t=0;t<o.dataSource.length;t++){const r=o.rows[t],e=o.dataSource[t];r&&(r.data=e,e&&e.$&&(r.id=e.$.id,r._updateData()),o._filters&&o._filters.length>0&&(r.filtered=void 0===r.data.$.filtered||r.data.$.filtered),o.rowById[r.id]=r)}o._filters&&o._filters.length>0&&o.refresh()}o._recycle()}const t=[],r=[];for(let e=0;e<o._sortedColumns.length;e++){const s=o.columnByDataField[o._sortedColumns[e].dataField];s&&(s.setProperty("sortIndex",e),t.push(s),r.push(s.sortIndex),o._sortedColumns[e].sortIndex=e)}o._refreshHeaderBar(),o.$.fireEvent("sort",{sortDataFields:s,sortOrders:a,sortDataTypes:n,sortIndexes:r,columns:t,data:o._sortedColumns}),o._onSort&&o._onSort()};if(o.appearance.allowSortAnimation){let t=[],r=[];o.rows.canNotify=!1,o._sortAnimation=!0;const e=function(){for(let r=0;r<o._rowElements.length;r++){const e=o._rowElements[r];e.classList.remove("smart-grid-sort-animation"),o.removeTransformMoveStyle(e),e.offsetHeight>0&&t.push(e.offsetTop)}};e(),o._sortTimer=setTimeout((function(){e(),o._sortAnimation=!1,o.rows.canNotify=!0}),o.appearance.sortAnimationDuration),o._sortTimer2=setTimeout((function(){f()}),o.appearance.sortAnimationDuration/2);for(let e=0;e<t.length;e++){const s=o._rowElements[e];s.classList.remove("smart-grid-sort-animation"),o.removeTransformMoveStyle(s);let a=Math.floor(Math.random()*t.length-1+1);for(;r[a];)a=Math.floor(Math.random()*t.length-1+1);r[a]=!0,o.addTransformMoveStyle(s,"0ms",0,-s.offsetTop+t[a],0,.5),s.classList.add("smart-grid-sort-animation"),setTimeout((function(){o.addTransformMoveStyle(s,o.appearance.sortAnimationDuration+"ms",0,0,0,1)})),setTimeout((function(){s.classList.remove("smart-grid-sort-animation")}),o.appearance.sortAnimationDuration)}}else f();o._isSorting=!1}});