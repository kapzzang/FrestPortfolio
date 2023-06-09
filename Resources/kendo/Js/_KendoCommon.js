var kendoCom = {}


//사업장 dialog html
function fnBusiDialogDraw(dLayoutId) {
    var html = "";
    html +=    '<div class="Dheader">'                                                                                             ;
    html +=        '<div class="Dtitle">'                                                                                          ;
    html +=            '<h1>사업장 조회</h1>'                                                                                      ;
    html +=        '</div>'                                                                                                        ;
    html +=        '<div class="Dbutton">'                                                                                         ;
    html +=            '<button id="confirm">확인</button>'                                                                        ;
    html +=        '</div>'                                                                                                        ;
    html +=    '</div>'                                                                                                            ;
    html +=        '<div class="DsearchLayout">'                                                                                   ;
    html +=            '<div class="DsearchBtn">'                                                                                  ;
    html +=                '<span class="k-icon k-i-search k-icon-32" id="BsearchBtn">'                                             ;
    html +=                '</span>'                                                                                               ;
    html +=            '</div>'                                                                                                    ;
    html +=            '<div class="DsearchDataArea">'                                                                             ;
    html +=                '<table>'                                                                                               ;
    html +=                    '<colgroup>'                                                                                        ;
    html +=                        '<col width="80px" />'                                                                          ;
    html +=                    '</colgroup>'                                                                                       ;
    html +=                    '<tr>'                                                                                              ;
    html +=                        '<th>사업장명</th>'                                                                             ;
    html +=                        '<td><input id="DbusiName" name="DbusiName" /></td>'                                            ;
    html +=                    '</tr>'                                                                                             ;
    html +=                '</table>'                                                                                              ;
    html +=            '</div>'                                                                                                    ;
    html +=        '</div>'                                                                                                        ;
    html +=        '<div class="DgridLayout">'                                                                                     ;
    html +=            '<div id="busiGrid"></div>'                                                                                 ;
    html +=            '<div class="loadingBar"></div>'                                                                            ;
    html += '</div>'                                                                                                               ;
    $("#" + dLayoutId).append(html);
}

//부서 dialog html
function fnDeptDialogDraw(dLayoutId) {
    var html = "";    
    html += '<div class="Dheader">'                                                                                               ;
    html +=         '<div class="Dtitle">'                                                                                        ;
    html +=             '<h1>부서 조회</h1>'                                                                                      ;
    html +=         '</div>'                                                                                                      ;
    html +=     '<div class="Dbutton">'                                                                                           ;
    html +=         '<button id="confirm">확인</button>'                                                                          ;
    html +=     '</div>'                                                                                                          ;
    html += '</div>'                                                                                                              ;
    html +=     '<div class="DsearchLayout">'                                                                                     ;
    html +=         '<div class="DsearchBtn">'                                                                                    ;
    html +=             '<span class="k-icon k-i-search k-icon-32" id="DsearchBtn">';
    html +=             '</span>'                                                                                                 ;
    html +=         '</div>'                                                                                                      ;
    html +=         '<div class="DsearchDataArea">'                                                                               ;
    html +=             '<table>'                                                                                                 ;
    html +=                 '<colgroup>'                                                                                          ;
    html +=                     '<col width="80px" />'                                                                            ;
    html +=                 '</colgroup>'                                                                                         ;
    html +=                 '<tr>'                                                                                                ;
    html +=                     '<th>부서</th>'                                                                                 ;
    html +=                     '<td><input id="DdeptName" name="DdeptName" /></td>'                                              ;
    html +=                 '</tr>'                                                                                               ;
    html +=             '</table>'                                                                                                ;
    html +=         '</div>'                                                                                                      ;
    html +=     '</div>'                                                                                                          ;
    html +=     '<div class="DgridLayout">'                                                                                       ;
    html +=         '<div id="deptGrid"></div>'                                                                                   ;
    html +=         '<div class="loadingBar"></div>'                                                                              ;
    html += '</div>'                                                                                                              ;
    $("#" + dLayoutId).append(html);
}

//SUG dialog html
function fnSUGDialogDraw(dLayoutId) {

    var html = "";

    html += '<div class="Dheader">                                                                                              ';
    html += '    <div class="Dtitle">                                                                                           ';
    html += '        <h1>SUG 조회</h1>                                                                                          ';
    html += '    </div>                                                                                                         ';
    html += '    <div class="Dbutton">                                                                                          ';
    html += '        <button id="confirm">확인</button>                                                                         ';
    html += '    </div>                                                                                                         ';
    html += '</div>                                                                                                             ';
    html += '                                                                                                                   ';
    html += '    <div class="DsearchLayout">                                                                                    ';
    html += '        <div class="DsearchBtn">                                                                                   ';
    html += '            <span class="k-icon k-i-search k-icon-32" id="SUGsearchBtn">            ';
    html += '            </span>                                                                                                ';
    html += '        </div>                                                                                                     ';
    html += '        <div class="DsearchDataArea">                                                                              ';
    html += '            <table>                                                                                                ';
    html += '                <colgroup>                                                                                         ';
    html += '                    <col width="80px" />                                                                           ';
    html += '                </colgroup>                                                                                        ';
    html += '                <tr>                                                                                               ';
    html += '                    <th>SUG명</th>                                                                                 ';
    html += '                    <td><input id="DSUGName" name="DSUGName" style="width:200px" /></td>                           ';
    html += '                </tr>                                                                                              ';
    html += '            </table>                                                                                               ';
    html += '        </div>                                                                                                     ';
    html += '    </div>                                                                                                         ';
    html += '    <div class="DgridLayout">                                                                                      ';
    html += '        <div id="SUGGrid"></div>                                                                                   ';
    html += '       <div class="loadingBar"></div>';
    html += '    </div>                                                                                                         ';
    $("#" + dLayoutId).append(html);
}

//Patch dialog html
function fnPatchDialogDraw(dLayoutId) {

    var html = "";                                                                                                                                   
    html +=' <div class="Dheader">                                                                                                 ';
    html +='    <div class="Dtitle">                                                                                               ';
    html +='        <h1>패치 조회</h1>                                                                                             ';
    html +='    </div>                                                                                                             ';
    html +='    <div class="Dbutton">                                                                                              ';
    html +='        <button id="confirm">확인</button>                                                                             ';
    html +='    </div>                                                                                                             ';
    html +='</div>                                                                                                                 ';
    html +='                                                                                                                       ';
    html +='    <div class="DsearchLayout">                                                                                        ';
    html +='        <div class="DsearchBtn">                                                                                       ';
    html +='            <span class="k-icon k-i-search k-icon-32" id="patchSearchBtn">            ';
    html +='            </span>                                                                                                    ';
    html +='        </div>                                                                                                         ';
    html +='        <div class="DsearchDataArea">                                                                                  ';
    html +='            <table>                                                                                                    ';
    html +='                <colgroup>                                                                                             ';
    html +='                    <col width="80px" />                                                                               ';
    html +='                </colgroup>                                                                                            ';
    html +='                <tr>                                                                                                   ';
    html +='                    <th>패치명</th>                                                                                    ';
    html +='                    <td><input id="DpatchName" name="DpatchName" style="width:400px;" /></td>                          ';
    html +='                </tr>                                                                                                  ';
    html +='            </table>                                                                                                   ';
    html +='        </div>                                                                                                         ';
    html +='    </div>                                                                                                             ';
    html +='    <div class="DgridLayout">                                                                                          ';
    html += '        <div id="patchGrid"></div>                                                                                    ';
    html += '       <div class="loadingBar"></div>';
    html += '    </div>                                                                                                            ';
    $("#" + dLayoutId).append(html);
}

/*사업장 dialog 그리드 
 *필요값(그리드 id, 사이트 - site)
*/
function fnBusiGrid(gridId, site) {
    $("#" + gridId).empty(); //그리드 초기화를 안해주면 해당 그리드에 계속 추가되어 페이징에서 스크립트 오류가 뜸
    var param = {
        DbusiName: $("#DbusiName").val() //사업장명
        , ty_GoupBusi: 1 // 조회 대상 (0:부서, 1:사업장)
        , ty_Control: 1  // 조회 결과 컨트롤 (0:Tree, 1:Grid)
        , SiteCodeC: site
    }

    // JavaScript에서 Virtual Directory Root의 절대 경로는 못찾을 듯...(따로 함수 만들까??) , 현재는 상대경로로 표시가 최선일 듯
    $.ajax({
        type: "POST",
        url: "../../Common/BussinessSearch",
        data: { param: JSON.stringify(param) },
        dataType: 'json',
        async: true,
        beforeSend: function () { // 조회 전
            kendo.ui.progress($(".loadingBar"), true);
        },
        complete: function () {//조회 후
            kendo.ui.progress($(".loadingBar"), false);                     
        },
        success: function (result) {
            $("#" + gridId).kendoGrid({
                dataSource: {
                    data: result != null ? result.data : result,
                    pageSize: 10
                },
                pageable: {
                    refresh: true,
                    pageSizes: [5, 10],
                    buttonCount: 3
                },
                height: 305,
                autoWidth: true,
                //groupable: true,
                //filterable: true,
                sortable: true,
                resizable: true,
                reorderable: true,
                selectable: "one", // multiple 다중 row선택, multiple cell 다중cell선택                
                //persistSelection: true, //선택한 값을 정렬, 페이징, 필터링 등을 수행 할 때 선택 항목이 유지 될지 여부를 나타내는 값을 설정합니다. 사용시 스키마 모델을 지정해줘야함 schema: { model: { id: "id" }}
                columns: [
                    { field: "BusiCode", title: "사업장코드", width: "100px" },
                    { field: "BusiName", title: "사업장명", width: "150px" }
                ]
            });
        }
    });   
}  

/*사업장 dialog evnet
 *필요값(dialogLayout ID, 그리드 id,사업장명 input ID, 사업장코드 hidden input ID, 버튼id, 사이트 input ID)
*/
function fnBusiEvnet(dlayoutId, gridId, inputId, hInputId, btnId, siteId) {  
    //dialog그리기
    fnBusiDialogDraw(dlayoutId);

    //다이얼로그 설정
    $("#" + dlayoutId).kendoDialog({
        width: 800,
        height: 550,
        animation: {
            open: {
                effects: "fade:in",
                duration: 450
            }
        },
        close: function (e) {
            $("#DbusiName").val(""); //초기화
            fnSearch();
        },
        visible: false
    });        

    //더블클릭시 사업장명 선택 후 dialog창 닫기
    $('#' + gridId).off("dblclick").on("dblclick", "tbody tr", function () {
        var grid = $("#" + gridId).data("kendoGrid"); //그리드 정보 담기
        var selectedData = grid.dataItem(grid.select()); //선택한 값 담기
        $("#" + hInputId).val(selectedData.BusiCode); //input box에 세팅
        $("#" + inputId).val(selectedData.BusiName); // hidden에 세팅
        $("#TyArea").val(1)//사업장 부서 구분
        $("#DbusiName").val(""); //초기화    
        $("#" + inputId).focus(); //enter key 이벤트를 위해 추가
        $("#" + dlayoutId).data("kendoDialog").close();//닫기
    });    

    //확정 버튼 클릭 시
    $("#" + dlayoutId).off("click").on("click","#confirm", function (e) {        
        var grid = $("#" + gridId).data("kendoGrid");
        var selectedData = grid.dataItem(grid.select());

        if (selectedData == null) { //선택한 값 없을시
            alert("사업장을 선택 해주세요.")
            return false;
        }

        $("#" + hInputId).val(selectedData.BusiCode);
        $("#" + inputId).val(selectedData.BusiName);
        $("#TyArea").val(1)//사업장 부서 구분
        $("#DbusiName").val(""); //초기화    
        $("#" + inputId).focus(); //enter key 이벤트를 위해 추가
        $("#" + dlayoutId).data("kendoDialog").close();
    });

    //사업장명 더블 클릭 시 초기화
    $('#' + inputId).off("dblclick").on("dblclick", function () {
        if ($("#TyArea").val() == '0') {
            $("#" + inputId).val("부서 전체");
            $("#" + hInputId).val("AllGroup");
        } else {
            $("#" + inputId).val("사업장 전체");
            $("#" + hInputId).val("AllBusi");
        }    
        fnSearch();
    });

    //버튼 클릭시 dialog 열기
    $("#" + btnId).off("click").on("click", function (e) {
        $("#" + dlayoutId).data("kendoDialog").open();
        fnBusiGrid(gridId, $("#" + siteId).val());
    });

    //검색 버튼
    $("#BsearchBtn").off("click").on("click", function (e) {        
        fnBusiGrid(gridId, $("#" + siteId).val());        
    });

    //엔터 시 조회
    $(".DsearchLayout").keydown(function (key) {//검색 영역에 focus가 있을 시에만 엔터키 이벤트 실행
        if (key.keyCode == 13) {//키가 13이면 실행 (엔터는 13)
            fnBusiGrid(gridId, $("#" + siteId).val());        
        }
    });
}

/*부서 dialog treeList
 *필요값(그리드 id ,사이트 - site)
*/
function fnDeptGrid(gridId,site) {
    $("#" + gridId).empty(); //treelist 초기화

    var param = {
          DdeptName: $("#DdeptName").val() //부서
        , ty_GoupBusi: 0 // 조회 대상 (0:부서, 1:사업장)
        , ty_Control: 1 // 조회 결과 컨트롤 (0:Tree, 1:Grid)
        , SiteCodeC: site
    }

    $.ajax({
        type: "POST",
        url: "../../Common/DeptSearch",
        data: { param: JSON.stringify(param) },
        dataType: 'json',
        async: true,
        beforeSend: function () { // 조회 전
            kendo.ui.progress($(".loadingBar"), true);
        },
        complete: function () {//조회 후
            kendo.ui.progress($(".loadingBar"), false);
        },
        success: function (result) {
            $("#" + gridId).kendoTreeList({
                dataSource: {
                    data: result != null ? result.data : result
                    , schema: {
                        model: {
                            id: "GroupID", 
                            parentId: "ParentGroupID", //부모 id
                            fields: {
                                ParentGroupID: { field: "ParentGroupID", nullable: true },
                                GroupID: { field: "GroupID" }
                            },
                            expanded: false //treelist 펼치기 (변경 x)
                        }
                    }
                },
                pageable: {
                    pageSize: 30,
                    pageSizes: [10, 20, 30, 50],
                    numeric: false
                },
                height: 430,
                autoWidth: true,
                sortable: true,                
                selectable: "one", // multiple 다중 row선택, multiple cell 다중cell선택   
                columns: [
                    { field: "GroupID", title: "부서ID", hidden: true },
                    { field: "GroupName", title: "부서", width: "200px" },
                ],
            });
        }
    });    

    //부서 검색 후 검색한 부서 select해주기
    var treeList = $("#" + gridId).data("kendoTreeList");    
    $("#" + gridId+" tbody>tr").each(function (index, item) {
        if (this.innerText == $("#DdeptName").val()) {
            treeList.select($(this));
        }
    });    
}  

/*부서 dialog evnet
 *필요값(dialogLayout ID, 그리드id, 부서 input ID, 부서코드 hidden input ID, 버튼id, 사이트 input ID)
*/
function fnDeptEvnet(dlayoutId, gridId, inputId, hInputId, btnId, siteId) {

    //dialog 그리기
    fnDeptDialogDraw(dlayoutId);

    //다이얼 로그 설정
    $("#" + dlayoutId).kendoDialog({
        width: 550,
            height: 700,
            animation: {
                open: {
                    effects: "fade:in",
                    duration: 450
                }
            },
            close: function (e) {
                $("#DdeptName").val(""); //초기화
                fnSearch();
            },
            visible: false       
    });
    

    //더블클릭시 부서 선택 후 dialog창 닫기
    $('#' + gridId).off("dblclick").on("dblclick", "tbody tr", function () {
        var treeList = $("#" + gridId).data("kendoTreeList");   // treelist 값 담기
        var selectedData = treeList.dataItem(treeList.select()); //선택한 값 담기
        $("#" + hInputId).val(selectedData.GroupID); //input에 넣기
        $("#" + inputId).val(selectedData.GroupName); // hidden 넣기
        $("#TyArea").val(0)//사업장 부서 구분
        $("#DdeptName").val(""); //초기화    
        $("#" + inputId).focus(); //enter key 이벤트를 위해 추가
        $("#" + dlayoutId).data("kendoDialog").close(); //닫기
    });

    //확정 버튼 클릭 시
    $("#" + dlayoutId).off("click").on("click", "#confirm", function (e) {
        var treeList = $("#" + gridId).data("kendoTreeList");         
        var selectedData = treeList.dataItem(treeList.select());

        if (selectedData == null) {
            alert("부서를 선택 해주세요.")
            return false;
        }

        $("#" + hInputId).val(selectedData.GroupID);
        $("#" + inputId).val(selectedData.GroupName);
        $("#TyArea").val(0)//사업장 부서 구분
        $("#DdeptName").val(""); //초기화    
        $("#" + inputId).focus(); //enter key 이벤트를 위해 추가
        $("#" + dlayoutId).data("kendoDialog").close();
    });

    //부서 더블 클릭 시 초기화
    $('#' + inputId).off("dblclick").on("dblclick", function () {
        if ($("#TyArea").val() == '0') {
            $("#" + inputId).val("부서 전체");
            $("#" + hInputId).val("AllGroup");
        } else {
            $("#" + inputId).val("사업장 전체");
            $("#" + hInputId).val("AllBusi");
        } 
        fnSearch();
    });

    //버튼 클릭시 dialog 열기
    $("#" + btnId).off("click").on("click", function (e) {
        $("#" + dlayoutId).data("kendoDialog").open();
        fnDeptGrid(gridId, $("#" + siteId).val());
    });

    //검색 버튼
    $("#DsearchBtn").off("click").on("click", function (e) {
        fnDeptGrid(gridId, $("#" + siteId).val());
    });

    //엔터 시 조회
    $(".DsearchLayout").keydown(function (key) {//검색 영역에 focus가 있을 시에만 엔터키 이벤트 실행
        if (key.keyCode == 13) {//키가 13이면 실행 (엔터는 13)
            fnDeptGrid(gridId, $("#" + siteId).val());
        }
    });
}

/*SUG dialog 그리드 
 *필요값(그리드 id, 사이트 - site)
*/
function fnSUGGrid(gridId, site) {
    $("#" + gridId).empty(); //그리드 초기화를 안해주면 해당 그리드에 계속 추가되어 페이징에서 스크립트 오류가 뜸

    var param = {
        DSUGName: $("#DSUGName").val() //SUG명
        , SiteCodeC: site
    }

    $.ajax({
        type: "POST",
        url: "../../Common/SUGSearch",
        data: { param: JSON.stringify(param) },
        dataType: 'json',
        async: true,
        beforeSend: function () { // 조회 전
            kendo.ui.progress($(".loadingBar"), true);
        },
        complete: function () {//조회 후
            kendo.ui.progress($(".loadingBar"), false);
        },
        success: function (result) {
            $("#" + gridId).kendoGrid({
                dataSource: {
                    data: result != null ? result.data : result,
                    pageSize: 10
                },
                pageable: {
                    pageSizes: [5, 10],
                    buttonCount: 3
                },
                height: 305,
                autoWidth: true,
                //groupable: true,
                //filterable: true,
                sortable: true,
                resizable: true,
                reorderable: true,
                selectable: "one", // multiple 다중 row선택, multiple cell 다중cell선택                
                //persistSelection: true, //선택한 값을 정렬, 페이징, 필터링 등을 수행 할 때 선택 항목이 유지 될지 여부를 나타내는 값을 설정합니다. 사용시 스키마 모델을 지정해줘야함 schema: { model: { id: "id" }}
                columns: [
                    { field: "SUGCode", title: "SUG코드", width: "100px" },
                    { field: "SUGName", title: "SUG명", width: "150px" }
                ]
            });
        }
    });   
}


/*SUG dialog evnet
 *필요값(dialogLayout ID, 그리드 id,SUG명 input ID, SUG코드 hidden input ID, 버튼id, 사이트 input ID)
*/
function fnSUGEvnet(dlayoutId, gridId, inputId, hInputId, btnId, siteId) {

    //SUG HTML그리기
    fnSUGDialogDraw(dlayoutId);

    //다이얼로그 설정
    $("#" + dlayoutId).kendoDialog({
        width: 800,
        height: 550,
        animation: {
            open: {
                effects: "fade:in",
                duration: 450
            }
        },
        close: function (e) {
            $("#DSUGName").val(""); //초기화
            fnSearch();
        },
        visible: false
    });

    //더블클릭시 SUG명 선택 후 dialog창 닫기
    $('#' + gridId).off("dblclick").on("dblclick", "tbody tr", function () {
        var grid = $("#" + gridId).data("kendoGrid"); //그리드 정보 담기
        var selectedData = grid.dataItem(grid.select()); //선택한 값 담기
        $("#" + hInputId).val(selectedData.SUGCode); //input box에 세팅
        $("#" + inputId).val(selectedData.SUGName); // hidden에 세팅        
        $("#DSUGName").val(""); //초기화    
        $("#" + inputId).focus(); //enter key 이벤트를 위해 추가
        $("#" + dlayoutId).data("kendoDialog").close();//닫기
    });

    //확정 버튼 클릭 시
    $("#" + dlayoutId).off("click").on("click", "#confirm", function (e) {
        var grid = $("#" + gridId).data("kendoGrid");
        var selectedData = grid.dataItem(grid.select());

        if (selectedData == null) { //선택한 값 없을시
            alert("SUG를 선택 해주세요.")
            return false;
        }

        $("#" + hInputId).val(selectedData.SUGCode);
        $("#" + inputId).val(selectedData.SUGName);        
        $("#DSUGName").val(""); //초기화    
        $("#" + inputId).focus(); //enter key 이벤트를 위해 추가
        $("#" + dlayoutId).data("kendoDialog").close();
    });

    //SUG명 더블 클릭 시 초기화
    $('#' + inputId).off("dblclick").on("dblclick", function () {
        $("#" + inputId).val("");
        $("#" + hInputId).val("");
        fnSearch();
    });

    //버튼 클릭시 dialog 열기
    $("#" + btnId).off("click").on("click", function (e) {
        $("#" + dlayoutId).data("kendoDialog").open();
        fnSUGGrid(gridId, $("#" + siteId).val());
    });

    //검색 버튼
    $("#SUGsearchBtn").off("click").on("click", function (e) {
        fnSUGGrid(gridId, $("#" + siteId).val());
    });

    //엔터 시 조회
    $(".DsearchLayout").keydown(function (key) {//검색 영역에 focus가 있을 시에만 엔터키 이벤트 실행
        if (key.keyCode == 13) {//키가 13이면 실행 (엔터는 13)
            fnSUGGrid(gridId, $("#" + siteId).val());
        }
    });
}


/*PATCH dialog 그리드 
 *필요값(그리드 id, 사이트 - site)
*/
function fnPatchGrid(gridId, site) {
    $("#" + gridId).empty(); //그리드 초기화를 안해주면 해당 그리드에 계속 추가되어 페이징에서 스크립트 오류가 뜸

    var param = {
        DpatchName: $("#DpatchName").val() //PATCH명
        , SiteCodeC: site
    }

    $.ajax({
        type: "POST",
        url: "../../Common/PatchSearch",
        data: { param: JSON.stringify(param) },
        dataType: 'json',
        async: true,
        beforeSend: function () { // 조회 전
            kendo.ui.progress($(".loadingBar"), true);
        },
        complete: function () {//조회 후
            kendo.ui.progress($(".loadingBar"), false);
        },
        success: function (result) {
            $("#" + gridId).kendoGrid({
                dataSource: {
                    data: result != null ? result.data : result,
                    pageSize: 10
                },
                pageable: {
                    pageSizes: [5, 10],
                    buttonCount: 3
                },
                height: 305,
                autoWidth: true,
                //groupable: true,
                //filterable: true,
                sortable: true,
                resizable: true,
                reorderable: true,
                selectable: "one", // multiple 다중 row선택, multiple cell 다중cell선택                
                //persistSelection: true, //선택한 값을 정렬, 페이징, 필터링 등을 수행 할 때 선택 항목이 유지 될지 여부를 나타내는 값을 설정합니다. 사용시 스키마 모델을 지정해줘야함 schema: { model: { id: "id" }}
                columns: [
                    { field: "PatchCode", title: "패치코드", width: "100px" },
                    { field: "PatchName", title: "패치명", width: "150px" }
                ]
            });
        }
    });
}


/*PATCH dialog evnet
 *필요값(dialogLayout ID, 그리드 id,패치명 input ID, 패치코드 hidden input ID, 버튼id, 사이트 input ID)
*/
function fnPatchEvnet(dlayoutId, gridId, inputId, hInputId, btnId, siteId) {
    //patch dialog 그리기
    fnPatchDialogDraw(dlayoutId);

    //다이얼로그 설정
    $("#" + dlayoutId).kendoDialog({
        width: 800,
        height: 550,
        animation: {
            open: {
                effects: "fade:in",
                duration: 450
            }
        },
        close: function (e) {
            $("#DpatchName").val(""); //초기화
            fnSearch();
        },
        visible: false
    });

    //더블클릭시 패치명 선택 후 dialog창 닫기
    $('#' + gridId).off("dblclick").on("dblclick", "tbody tr", function () {
        var grid = $("#" + gridId).data("kendoGrid"); //그리드 정보 담기
        var selectedData = grid.dataItem(grid.select()); //선택한 값 담기
        $("#" + hInputId).val(selectedData.PatchCode); //input box에 세팅
        $("#" + inputId).val(selectedData.PatchName); // hidden에 세팅        
        $("#DpatchName").val(""); //초기화    
        $("#" + inputId).focus(); //enter key 이벤트를 위해 추가
        $("#" + dlayoutId).data("kendoDialog").close();//닫기
    });

    //확정 버튼 클릭 시
    $("#" + dlayoutId).off("click").on("click", "#confirm", function (e) {
        var grid = $("#" + gridId).data("kendoGrid");
        var selectedData = grid.dataItem(grid.select());

        if (selectedData == null) { //선택한 값 없을시
            alert("패치를 선택 해주세요.")
            return false;
        }

        $("#" + hInputId).val(selectedData.PatchCode);
        $("#" + inputId).val(selectedData.PatchName);
        $("#DpatchName").val(""); //초기화    
        $("#" + inputId).focus(); //enter key 이벤트를 위해 추가
        $("#" + dlayoutId).data("kendoDialog").close();
    });

    //패치명 더블 클릭 시 초기화
    $('#' + inputId).off("dblclick").on("dblclick", function () {
        $("#" + inputId).val("");
        $("#" + hInputId).val("");
        fnSearch();
    });

    //버튼 클릭시 dialog 열기
    $("#" + btnId).off("click").on("click", function (e) {
        $("#" + dlayoutId).data("kendoDialog").open();
        fnPatchGrid(gridId, $("#" + siteId).val());
    });

    //검색 버튼
    $("#patchSearchBtn").off("click").on("click", function (e) {
        fnPatchGrid(gridId, $("#" + siteId).val());
    });

    //엔터 시 조회
    $(".DsearchLayout").keydown(function (key) {//검색 영역에 focus가 있을 시에만 엔터키 이벤트 실행
        if (key.keyCode == 13) {//키가 13이면 실행 (엔터는 13)
            fnPatchGrid(gridId, $("#" + siteId).val());
        }
    });
}

/*
 * 공통 datePicker
 * 필요값 : input ID , type(S일경우 앞쪽 input E일경우 뒷쪽 input) 
 */
kendoCom.fnDatePicker = function fnDatePicker(id,type) {
    var today = new Date(); 
    var start = new Date(today.getFullYear(), today.getMonth(), today.getDate() - 90);
    var end = today;

    var data="";          
    if (type == "S") {
        data = start;
    } else if (type == "E") {
        data = end;
    }    

    $("#"+id).kendoDatePicker({
        dateInput: true
        , value: data
        , format: "yyyy-MM-dd"
    });
}

/*****탭 관련 Start*****/
kendoCom.fnTab = function fnTab(tabLayoutId, dataSource, events, index) {
    fnTabCreate(tabLayoutId, dataSource, events, index);  //탭 및 content생성  
    fnTabEvents(events, index) //생성 된 탭의 content의 event 호출
}

//탭 생성
function fnTabCreate(tabLayoutId, dataSource, events, index) {
    //tab 생성
    $("#" + tabLayoutId).kendoTabStrip({
        animation: {
            close: {
                duration: 1000
            }
        },
        value: dataSource[index].Name,
        dataTextField: "Name",
        dataContentField: "Content",
        dataSource: dataSource
    });

    //탭 클릭 이벤트
    $('#' + tabLayoutId + ' li').on('click', function () {
        var index = $('#' + tabLayoutId + ' li').index(this); //선택한 li 즉 선택한 tab의 index값
        fnTabCreate(tabLayoutId, dataSource, events, index);
        fnTabEvents(events, index)
    });
}   

//탭 이벤트 실행 메서드
function fnTabEvents(event, index) {
    event[index]();
}
/*****탭 관련 End*****/


//필수값 체크
kendoCom.fnValidation = function fnValidation(validation) {
    var title = "";
    $(".searchDataArea table input").each(function (index, item) { // 해당 영역 input 조회
        if ($(".searchDataArea table input")[index].value == "" || $(".searchDataArea table input")[index].value == null) {      //input 중 null일경우
            $(".searchDataArea table input").each(function (idx, item) { //input 반복
                if ($(".searchDataArea table th").eq(idx).attr("for") != null) { //th중 for 속성이 있는경우
                    var forArray = []; //for 속성에 2개 이상 있을 경우
                    forArray = $(".searchDataArea table th").eq(idx).attr("for").split(",");
                    for (var i = 0; i < forArray.length; i++) {
                        if (forArray[i] == $(".searchDataArea table input")[index].id) { //for속성 값과 비어있는 input의 id 비교
                            title = $(".searchDataArea table th").eq(idx).text(); //for 속성의 th의 text값을 넣어줌
                            validation = false; // false로 바꾸어 더 이상 진행되지 않게
                            alert(title + " is required");
                            $(".searchDataArea table input")[index].focus();
                            return false;
                        }
                    }                    
                }                
            });           
        }
    });    
    return validation;
}

//resize
kendoCom.fnReSize = function fnReSize(type,idData) {
    if (type == 'grid') {        
        var section = $("body section");
        var searchLayout = $(".searchLayout");
        var gridLayout = $(".gridLayout");
        gridLayout.css("height", section.height() - searchLayout.height() - 30 + 'px');
        var gridElement = $(idData.grid);
        gridElement.data("kendoGrid").resize();
    } else if (type == 'tabGrid') { 
        var TabLayout = $(idData.tab + " .k-content");
        var gridLayout = $(idData.grid);
        gridLayout.css("height", TabLayout.height() - 5 + 'px');
        var gridElement = $(idData.grid);
        if (gridElement.data("kendoGrid") != null) {
            gridElement.data("kendoGrid").resize();
        }        
    }
}


//윈도우 창 변경시 resize ----- window.resize()는 한번 설정 된 메서드가 계속 실행되므로 메서드내용을 변경 해야되는경우 사용 할 수 있다.
kendoCom.fnWindowResize = function fnWindowResize(type, idData) {    
    $(window).off("resize"); //재설정을 위해 resize 이벤트를 off
    if (type != "none") { 
        $(window).resize(function () {
            kendoCom.fnReSize(type, idData);
        });       
    }      
}

/**
 * form에 담긴 데이터 서버로 보내기
 * @param {any} form
 * @param {any} url
 * @param {any} data
 * @param {any} key
 */
kendoCom.fnSubmit = function fnSubmit(form, url, data, key) {    
    if (form.length < 1) {        
        form = $('<form id="formData" name="formData"></form>');
        form.attr('method', 'post');
        form.appendTo('section');   
    }
    form.attr('action', url);      

    //key와 폼안에 있는 input id와 같은 경우 해당 key데이터로 value값 변경
    var formData = form[0];
    var cnt = 0; //중복체크를 통해 key가 form없는 id일 경우 form append 해주기위한 구분 값
    for (var i = 0; i < key.length; i++) {
        for (var j = 0; j < formData.length; j++) {        
            if (formData[j].id == key[i]) {
                formData[j].value = data[key[i]];
                cnt++;
            }
        }
        //중복된 값(key)이 없으면 form append
        if (cnt < 1) {
            var formHtml = "";    
                formHtml = '<input type="hidden" name="' + key[i] + '" value="' + data[key[i]] + '">';        
                form.append(formHtml);                
        }
        cnt = 0; //cnt를 초기화 해야 중복체크를 통해 hidden을 만들어줌
    }
    $(form).attr("onsubmit", null); // onsubmit 속성이 return false 인경우 null로 변경 --동적화면 CommonPage에서 form 속성으로 들어가 있음(엔터 시 submit 방지를 위해)
    form.submit();              
}

/**
 * 세션 history 페이지 정보(검색조건) 넣기
 * 
 */
kendoCom.fnHistorySet = function fnHistorySet() {    
    var form = $("form");
    var formData = form.serializeObject();
    $.ajax({
        type: "POST",
        url: "../../Common/PageHistorySet",
        data: { param: JSON.stringify(formData)},
        dataType: 'json',
        async: true
    });
}

/**
 * 해당 페이지의 세션값 가져오기(검색조건)
 * form이 없는 경우 또는 상세페이지 경우 paramData에있는 값을 가져다 파라미터로 사용한다 (ex: 컴퓨터상세는 input의 id값이 2개이상 존재하여 selector시 #paramData를 꼭 넣어 select 한다)
 */
kendoCom.fnHistoryGet = function fnHistoryGet() {    
    $.ajax({
        type: "POST",
        url: "../../Common/PageHistoryGet",
        data: {},
        dataType: 'json',
        async: false,
        success: function (result) {
            var resultJson = JSON.parse($.toJSON(result));
            //form이 없는 경우 생성(상세페이지 같이 조회만 있는 경우)
            //if ($("form").length < 1) {
            //    var $form = $('<form id="paramData" name="paramData"></form>');
            //    $form.appendTo('section');
            //}
            for (var key in resultJson) {
                //form에 있는 key존재 여부에 따라
                if ($("form #" + key)[0] != null) {
                    if ($("form #" + key)[0].name == key) {
                        $("form #" + key).val(resultJson[key])
                    }
                } else {
                    var formHtml = '<input type="hidden" id="' + key + '" name="' + key + '" value="' + resultJson[key] + '">';
                    $("form").append(formHtml);
                }     

                //dropdown일 경우 input에만 값을 넣어주면 dropdown이 select가 안됨
                //dropdown일 경우를 체크하여 select 해줘야함
                var dropdown = $("form #"+key).data("kendoDropDownList")
                if (dropdown != null) {
                    dropdown.value(resultJson[key]);
                }
            }
        }
    });
}

/**
 * 히스토리 목록 조회
 * */
function fnHistoryList() {
    $.ajax({
        type: "POST",
        url: "../../Common/HistoryList",
        data: {},
        dataType: 'json',
        async: true,
        success: function (result) {
            var html = "";
            for (var i = 0; i < result.length; i++) {
                html = "<button type='button' class='historyBtn' onclick='fnHistoryMove(this)'>" + result[i].nm_Menu + "</button>";
                $("#historyArea").append(html);

                //히스토리 버튼이 생겼을때 버튼 class 수정
                if ($("#historyArea button").length > 0) {
                    $("#historyBtn").attr("class", "k-icon k-i-more-horizontal k-icon-32")
                } else {
                    $("#historyBtn").attr("class", "k-icon k-i-more-vertical k-icon-32")
                }
            }
        }
    });
}

/**
 * 히스토리 클릭 시 페이지 이동
 * @param {any} btnData
 */
function fnHistoryMove(btnData) {
    var index = $(btnData).index();       
    $.ajax({
        type: "POST",
        url: "../../Common/HistoryMove",
        data: {index:index},
        dataType: 'json',
        async: true,
        success: function (result) {            
            var url = result[0].url_Menu.replace("~", "../..");            
            location.href = url;
        }
    });
}

/**
 * 폼 SessionStorege에 넣기
 * @param {any} formId
 */
function formSessionStorege(formId) {
    var formData = $("#" + formId).serializeArray();
    for (var i = 0; i < formData.length; i++) {
        sessionStorage.setItem(formData[i].name, formData[i].value);
    }
}

/**
 * 세션스토리지 값 받아 검색조건에 세팅하기
 * 
 */
function sessionStoregeSearchSet() {
    if (sessionStorage != null) {
        var session = sessionStorage;
        for (var i = 0; i < session.length; i++) {
                var key = sessionStorage.key(i);        
                $("#" + key).val(sessionStorage.getItem(key))
        }        
    }
}

/**
 * 차트 data create
 * 필요값:카테고리 ID, 값ID , 데이터, 색깔(카테고리 수만큼 넘겨야함)
 **/
kendoCom.chartDataCreate = function chartDataCreate(category, cntId, data, color,length) {
    var chartData = [];
    var dataLen = data.length;
    color  = color != null ? color : "";
    //if (length != null) {
    //    dataLen = length;
    //}  
    //if (dataLen > data.length) {
    //    dataLen = data.length;             
    //}
    for (var i = 0; i < dataLen; i++) {
        var jsonData = {};
        jsonData.category = data[i][category];
        jsonData.value = data[i][cntId];
        jsonData.color = color[i];
        chartData.push(jsonData);
    }
    return chartData;
}

/**
 *메뉴권한에 따른 jumpCell 설정
 * @param {any} pageId
 */
function fnMenuRoleJumpCell(pageId) {
    var className = "";    
        $.ajax({
            type: "POST",
            url: "../../Common/UserMenuRoleCheck",
            data: { pageId: pageId },
            dataType: 'json',
            async: false,
            success: function (result) {
                if (result) {
                    className = "jumpCell";
                }
            }
        });    
    return className;
}

/**
 * 페이지,정렬,필터 정보를 가져오는 메서드(*추가로 넘기는 데이터보다 앞에 사용해야함)
 * @param {any} grid
 */
kendoCom.gridDataSet = function gridDataSet(grid) {
    var param = {};
    var serverPaging = grid.options.serverPaging;
    var serverSorting = grid.options.serverSorting;
    var serverFiltering = grid.options.serverFiltering;

    if (serverPaging) {
        param.PAGE = grid.page();
        param.PAGESIZE = grid.pageSize();
    }

    if (serverSorting) {
        if (grid.sort().length > 0) {
            param.SORTFIELD = grid.sort()[0].field;
            param.SORTDIR = grid.sort()[0].dir;
        }
    }

    if (serverFiltering) {
        if (grid.filter() != null) {
            param.FILTER = grid.filter();
        }
    }
    return param;
}


/**
 * 그리드 컬럼 세팅
 * @param {any} colData
 */
kendoCom.fnGridColumsSet = function fnGridColumsSet(colData, gridColSetType) {
    if (colData != null) {

        //그리드 컬럼 세팅 타입에 따라 사용자별 저장 그리드 컬럼인지 프로시저에 기본값으로 저장된 그리드 컬럼인지 구분하여 알맞게 데이터를 세팅한다.        
        if (gridColSetType != "default") {

            //사용자가 변경한 (그리드 컬럼 순서) 데이터는 gridColums에 기존에 불러왔던 컬럼 데이터는 gridOptionColumns 있음
            //필요한 정보는 gridOptionColumns 데이터 이기 때문에 순서가 바뀌지 않는 gridOptionColumns을 gridColums 순서에 알맞게 배열을 재배치해야함
            var columns = []; //최종 컬럼 정보를 담는 변수
            var colJson = {}; //컬럼 정보를 json 으로 담는 변수
            var cnt = 0;

            //DB에서 받은 컬럼 정보 수만큼 반복
            for (var i = 0; i < colData.length; i++) {
                //맨 처음 데이터가 아니거나 컬럼데이터 중 전 필드 데이터가 현재 필드데이터가 같은 경우
                if (i > 0 && colData[i].Field == colData[i - 1].Field) {
                    //컬렘 데이터중 속성정보가 template인 경우
                    if (colData[i].Attribute == "template") {
                        //함수를 실행 할 수 있는 정보로 변경하여 값을 넣어준다.                        
                        if (colData[i].AttributeValue != null && colData[i].AttributeValue != "") {
                            //template 속성은 실행 되면서 해당 실행 함수명이 사라짐 사라진 함수명을 templateFnNm 담아둠                            
                            colJson["templateFnNm"] = colData[i].AttributeValue;
                            colJson[colData[i].Attribute] = (new Function('return ' + colData[i].AttributeValue))();
                        } else {
                            colJson[colData[i].Attribute] = (new Function('return null'))()                            
                        }      
                    } else {

                        //문자열로 boolean값이 string으로 들어간 경우 boolean값으로 다시 넣어준다.
                        if (colData[i].AttributeValue == "True") {
                            colData[i].AttributeValue = true;
                        }
                        if (colData[i].AttributeValue == "False") {
                            colData[i].AttributeValue = false;
                        }

                        //JSON으로 변경 되는 데이터 일 경우
                        try {
                            colJson[colData[i].Attribute] = JSON.parse(colData[i].AttributeValue);
                        } catch (e) {
                            colJson[colData[i].Attribute] = colData[i].AttributeValue;
                        }
                    }
                    columns[cnt - 1] = colJson; //데이터가 row로 쌓이기 때문에 같은 field의 데이터인경우 똑같은 컬럼 순서에 넣어줘야 되므로 -1
                }
                //맨 처음 데이터 이거나 컬럼데이터 중 전 필드 데이터가 현재 필드데이터가 다른 경우
                else {
                    colJson = {}; // colJson에 넣어둔 데이터를 초기화
                    colJson["field"] = colData[i].Field; //필드 부터 넣어준다.
                    //JSON으로 변경 되는 데이터 일 경우
                    try {
                        colJson[colData[i].Attribute] = JSON.parse(colData[i].AttributeValue);
                    } catch (e) {
                        colJson[colData[i].Attribute] = colData[i].AttributeValue;
                    }
                    columns[cnt] = colJson; //새로운 field로 시작 되기때문에 새로운 컬럼 순서에 넣어줌
                    cnt++; //새로운 field 일경우 cnt를 올려줘야 같은 필드 값들이 알맞은 컬럼 순서에 들어감
                }
            }
            return columns;

        } else {

            var value;
            for (var i = 0; i < colData.length; i++) {
                for (var key in colData[i]) {
                    try {
                        value = JSON.parse(colData[i][key]);
                        colData[i][key] = value;
                    } catch (e) {
                        value = colData[i][key];
                        colData[i][key] = value;
                    }
                    //attributes 중 class 가 존재하는 값중 fnMenuRoleJumpCell이라는 텍스트가 있을시 fnMenuRoleJumpCell() 함수를 실행
                    if (key == "attributes") {
                        if (colData[i][key].class != null) {
                            if (colData[i][key].class != "jumpCell") { //class가 jumpcell이 아닌경우
                                if (colData[i][key].class == 'dialogCell') {
                                    colData[i][key].class = 'dialogCell';
                                } else {
                                    if (colData[i][key].class.indexOf("fnMenuRoleJumpCell") != -1) { //해당 택스트가 있는경우
                                        colData[i][key].class = (new Function('return ' + colData[i][key].class))()
                                    } else {
                                        colData[i][key].class = (new Function('return null'))()
                                    }
                                }
                            } 
                        }
                    }
                    if (key == "template") {
                        //colData[i][key] = eval(colData[i][key]);
                        if (colData[i][key] != null && colData[i][key] != "") {
                            //template 속성은 실행 되면서 해당 실행 함수명이 사라짐 사라진 함수명을 templateFnNm 담아둠                            
                            colData[i]["templateFnNm"] = colData[i][key];
                            colData[i][key] = (new Function('return ' + colData[i][key]))()                            
                        } else {
                            colData[i][key] = (new Function('return null'))()
                        }                       
                    }
                }
            }
            return colData;

        }

    } else {
        alert("컬럼 정보가 없습니다. 프로시저를 확인 해주세요.")
    }
}

/**
 * 사용자 그리드 컬럼 정보 저장
 * @param {any} grid
 */
kendoCom.fnColumnSave = function fnColumnSave(grid) {

    //사용자가 변경한 (그리드 컬럼 순서) 데이터는 gridColums에 기존에 불러왔던 컬럼 데이터는 gridOptionColumns 있음
    //필요한 정보는 gridOptionColumns 데이터 이기 때문에 순서가 바뀌지 않는 gridOptionColumns을 gridColums 순서에 알맞게 배열을 재배치해야함
    var gridColums = grid.columns;
    var gridOptionColumns = grid.options.columns;

    var columns = [];

    //순서를 재배치 하는 로직
    for (var i = 0; i < gridColums.length; i++) {
        for (var j = 0; i < gridOptionColumns.length; j++) {
            //바뀐 컬럼 기준으로 기존 컬럼데이터를 새로운 배열에 쌓음
            if (gridColums[i].field == gridOptionColumns[j].field) {
                //template 속성은 실행 되면서 해당 실행 함수명이 사라짐 사라진 함수명을 templateFnNm 담아둠
                //담아둔 templateFnNm을 다시 template 속성으로 넣어 db에 저장 되게함
                if (gridOptionColumns[j].templateFnNm != null && gridOptionColumns[j].templateFnNm != "") {
                    gridOptionColumns[j].template = gridOptionColumns[j].templateFnNm;
                    delete gridOptionColumns[j].templateFnNm;
                }

                //저장시 변경된 width값으로 저장한다
                gridOptionColumns[j].width = gridColums[j].width;
                //저장시 변경된 hidden값으로 저장한다.
                gridOptionColumns[j].hidden = gridColums[j].hidden;

                columns[i] = gridOptionColumns[j];

                //템플릿 값이 있을경우 해당 값을 string 값으로(소스 그대로 넣어준다)
                if (columns[i].template != null && columns[i].template != "") {
                    columns[i].template = gridOptionColumns[j].template.toString();
                }
                break;
            }
        }
    }

    var param = [];

    //컬럼 정보를 param 배열에 넣어준다
    for (var i = 0; i < columns.length; i++) {
        param.push(JSON.stringify(columns[i]));
    }

    $.ajax({
        type: "POST",
        url: "../../Common/GridColumnSave",
        data: { param: param },
        beforeSend: function () { // 조회 전
            kendo.ui.progress($(".loadingBar"), true);
        },
        complete: function () {//조회 후
            kendo.ui.progress($(".loadingBar"), false);
        },
        dataType: 'json',
        async: true,
        success: function (result) {
            if (result != 0) {
                //alert("Grid Columns Save.");
                alert("컬럼 정보가 저장되었습니다.");
                window.location.reload();
            } else {
                //alert("Failed to save.");
                alert("컬럼 정보 저장을 실패했습니다.");
            }
        }
    });
}

/**
 * 그리드 컬럼 초기화
 * @param {any} 
 */
kendoCom.fnColumnReset = function fnColumnReset() {
    $.ajax({
        type: "POST",
        url: "../../Common/GridColumnReset",
        //data: { param: param },       
        dataType: 'json',
        async: true,
        success: function (result) {
            if (result != 0) {
                alert("초기화 되었습니다.");
                window.location.reload();
            } else {
                alert("초기화에 실패했습니다.");
            }
        }
    });
}

//엑셀 전체다운로드
kendoCom.fnExcelAllDownload = function fnExcelAllDownload(result, grid) {

    var data = result != null ? result.data : result; //데이터

    if (data == null) {
        alert("데이터가 없습니다.");
        return;
    }

    var columns = grid.columns; //그리드 컬럼정보

    var columnNm = []; //컬럼명 배열
    var colTitle = []; //타이틀 배열
    //그리드 컬럼 정보 만큼 반복
    for (var i = 0; i < columns.length; i++) {
        //그리드 컬럼정보 중 히든이 없거나 히든이 false인경우 컬럼명 배열에 넣는다.
        if (grid.columns[i].hidden == null || grid.columns[i].hidden == "") {
            if (!grid.columns[i].hidden) {
                columnNm.push(columns[i].field);
                colTitle.push(columns[i].title);
            }
        }       
    }

    //엑셀 head부분 (첫 줄 - 컬럼명)
    var cells = [];
    for (var i = 0; i < columnNm.length; i++) {
        //컬럼명 배열에 있는 만큼 cell배열에 넣어준다.
        cells.push({
            value: colTitle[i]
            , color: "#ffffff"
            , background: "#7a7a7a"            
            //bold: true,
            //vAlign: "center",
            //hAlign: "center"
        })
    }

    //엑셀 head부분 (첫 row에 cells배열 값을 넣는다)
    var rows = [{
        cells: cells        
    }];

    //데이터 만큼 반복
    for (var i = 0; i < data.length; i++) {
        //cells 배열 초기화
        var cells = [];
        //컬럼명 만큼 반복
        for (var j = 0; j < columnNm.length; j++) {
            var value = null;
            value = data[i][columnNm[j]] //cell 값

            //ajax로 datetime 값을 받아올때 long 형태로 넘어옴 ex) "/Date(1574144514000)/" 해당 값을 date로 바꾼 후 string으로 값 변환
            if (typeof value == "string" && value.indexOf("/Date(") != -1) {
                var start = value.indexOf("(");
                var end = value.lastIndexOf(")");
                value = value.substring(start + 1, end);
                value = parseInt(value); //숫자로 형변환
                var date = new Date(value);//날짜로 형변환   
                value = date.format("yyyy-MM-dd hh:mm:ss");//날짜 string형 날짜 포멧으로 변환
            }

            //cells 배열에 값을 넣어줌
            cells.push(
                { value: value }
            )
        }
        //rows 배열에 값 넣어줌
        rows.push({
            cells: cells
        })
    }    

    //컬럼 자동넓이 컬럼 개수만큼 세팅
    var autoWidth = [];
    for (var i = 0; i < columnNm.length; i++) {
        autoWidth.push({
            autoWidth: true
        })
    }

    var workbook = new kendo.ooxml.Workbook({
        sheets: [
            {
                // Column settings (width).
                columns: autoWidth,
                // The title of the sheet.
                title: "AllData",
                // The rows of the sheet.
                rows: rows,
                filter: { from: 0, to: columnNm.length-1 } //컬럼수 만큼 필터 기능 추가
            }
        ]
    });
    // Save the file as an Excel file with the xlsx extension.
    kendo.saveAs({ dataURI: workbook.toDataURL(), fileName: "All_"+grid.options.excel.fileName });
}



//IP 정규식
kendoCom.checkIP = function checkIP(ip) {
    var check = /^(1|2)?\d?\d([.](1|2)?\d?\d){3}$/;
    return check.test(ip);
}

//시간 정규식
kendoCom.checkTime = function checkTime(time) {
    var timeFormat = /^([01][0-9]|2[0-3]):([0-5][0-9])$/; // 시간형식 체크 정규화 hh:mm
    return timeFormat.test(time);
}

//날짜 포멧
Date.prototype.format = function (f) {

    if (!this.valueOf()) return " ";

    var weekKorName = ["일요일", "월요일", "화요일", "수요일", "목요일", "금요일", "토요일"];

    var weekKorShortName = ["일", "월", "화", "수", "목", "금", "토"];

    var weekEngName = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];

    var weekEngShortName = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

    var d = this;



    return f.replace(/(yyyy|yy|MM|dd|KS|KL|ES|EL|HH|hh|mm|ss|a\/p)/gi, function ($1) {

        switch ($1) {

            case "yyyy": return d.getFullYear(); // 년 (4자리)

            case "yy": return (d.getFullYear() % 1000).zf(2); // 년 (2자리)

            case "MM": return (d.getMonth() + 1).zf(2); // 월 (2자리)

            case "dd": return d.getDate().zf(2); // 일 (2자리)

            case "KS": return weekKorShortName[d.getDay()]; // 요일 (짧은 한글)

            case "KL": return weekKorName[d.getDay()]; // 요일 (긴 한글)

            case "ES": return weekEngShortName[d.getDay()]; // 요일 (짧은 영어)

            case "EL": return weekEngName[d.getDay()]; // 요일 (긴 영어)

            case "HH": return d.getHours().zf(2); // 시간 (24시간 기준, 2자리)

            case "hh": return ((h = d.getHours() % 12) ? h : 12).zf(2); // 시간 (12시간 기준, 2자리)

            case "mm": return d.getMinutes().zf(2); // 분 (2자리)

            case "ss": return d.getSeconds().zf(2); // 초 (2자리)

            case "a/p": return d.getHours() < 12 ? "오전" : "오후"; // 오전/오후 구분

            default: return $1;

        }

    });

};

String.prototype.string = function (len) { var s = '', i = 0; while (i++ < len) { s += this; } return s; };

String.prototype.zf = function (len) { return "0".string(len - this.length) + this; };

Number.prototype.zf = function (len) { return this.toString().zf(len); };


/**
 * @description validation체크(필수값)
 * @param {any} divId  div ID 
 */
kendoCom.Validation = function Validation(divId) {

    var check = false; //필수 값 체크 (필수 값이 모두 데이터가 있을경우 true)
    var checkCnt = 0; //필수 값이 채워질때마다 +1    
    var div = $("#" + divId); //div
    var validation = div.find("input[validation]"); //div안에 있는 input의 validation 속성 변수
    $("#" + divId + " input").css("border-color", ""); //input 테두리 원복
    validation.each(function (index) {
        var input = $(this); //해당 input jquery형태로 변수에 담기
        if (input.attr("validation")) { //해당 input이 validation 체크를 한다면
            var value = input.val();
            if (value == "") {
                input.css("border-color", "red"); //input 테두리 빨간색으로
                var popHtml = "<div id='required' style='width:50px; color:red;'>*필수값</div>" //다국어시 값 변경필요(*)
                input.append(popHtml); // 팝업 html 추가

                //팝업 html이 2개이상이면
                if ($("div #required").length > 1) {
                    $("div #required").remove(); //팝업html 다 삭제
                    input.append(popHtml); //다시 팝업 html추가
                } 

                //팝업 html에 kendoPopup 이벤트를 설정
                $("#required").kendoPopup({
                    anchor: this,
                    origin: "top right",
                    position: "top right"                    
                }).data("kendoPopup").open();
                input.focus(); //해당 input 포커스
                return false;
            } else {

                checkCnt++; //필수 값이 채워졌다면 ++

                input.css("border-color", ""); //input 테두리 원복

                //팝업html이 존재 할 경우 삭제
                if ($("div #required").length > 0) {
                    $("div #required").remove();                    
                }

                //다음 input으로 포커스 이동
                $("#" + divId + " input")[index+1].focus();
            }
        }
    });    

    //필수값으로 지정된 input의 수와 필수값 체크값이 같으면 필수값 체크 변수를 true로 변경
    if (checkCnt == validation.length) {
        check = true;
    }

    return check;
}
