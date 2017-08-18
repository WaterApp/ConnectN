var webApiURL = null;
$(document).ready(function () {
    //webApiURL = $("#webApiURL").val();
    $("#webApiURL").val('');
});


// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI


function checkList(name, key) {
    var self = this;
    self.name = name;
    self.key = key;
}

function checkListType(name, key, isActive) {
    var self = this;
    self.name = name;
    self.key = key;
    self.isActive = isActive;
}

function checkListItemDetails(checkListItem) {
    var self = this;
    self.CheckListItemId = checkListItem.CheckListItemId;
    self.CheckListItemName = checkListItem.CheckListItemName;
    self.ChecklistType = checkListItem.ChecklistType;
    self.ControlType = checkListItem.ControlType;
    self.Options = checkListItem.Options;
    self.IsActive = (checkListItem.IsActive == "1") ? true : false;

}

function checkListItemMapDetails(checkListItem) {
    var self = this;
    self.CheckListMapID = 0;
    self.CheckListItemId = checkListItem.CheckListItemId;
    self.Isdeleted = (checkListItem.IsActive == true) ? 0 : 1;
    self.orderNo = 0;
    

}


function CheckListOptions(CheckListOptionsID, CheckListOptionsValue, CheckListOptionGroupID, isDeleted) {
    var self = this;
    self.CheckListOptionsID = CheckListOptionsID.toString();
    self.CheckListOptionsValue = CheckListOptionsValue.toString();
    /* self.CheckListOptionGroupID = CheckListOptionGroupID.toString();
     self.isDeleted = isDeleted.toString();
     self.UserID = '1';*/
}


function AppViewModel() {
    var self = this;
    self.tabName = ko.observable();
    self.userID = ko.observable(1);
    self.basewebApiURl = $("#webApiURL").val();
    self.checkListData = ko.observableArray();
    self.wardData = ko.observableArray();
    self.ward = ko.observable();
    self.CheckListName = ko.observableArray();
    self.wardID = ko.observable();        
    self.isVisible = ko.observable(false);
    self.IsActive = ko.observable(false);    
    self.formID = ko.observable();
    self.formname = ko.observable();
    self.formstatus = ko.observable(false);
    self.formmessage = ko.observable();
    self.formmessageVisible = ko.observable(false);

    

    self.getWardData = function () {

        $.ajax({
            type: 'GET',
            url: self.basewebApiURl + '/Admin/GetWarddetails',
            data: null,
            contentType: 'application/json',
            success: function (data, textStatus, xhr) {
                self.wardData.removeAll();
                ko.utils.arrayForEach(data, function (item) {
                    self.wardData.push(new checkList(item.Key, item.Value));
                });
            },
            error: function (xhr, textStatus, errorThrown) {
                self.formmessage("Error in retrieving ward list");
                self.formmessageVisible(true);
                //alert("Error in retrieving form list");
            }
        });
    }

    self.wardChange = function () {
        if (self.ward() != "0") {
            self.GetCheckListData();
        }
        else {
            self.formmessage("Choose ward");
            self.formmessageVisible(true);
            self.checkListData.removeAll();
        }
    },

    
    self.GetCheckListType = function () {

        $.ajax({
            type: 'GET',
            url: self.basewebApiURl + '/Admin/GetCheckListType',
            data: null,
            contentType: 'application/json',
            success: function (data, textStatus, xhr) {
                self.CheckListName.removeAll();
                ko.utils.arrayForEach(data, function (item) {
                    self.CheckListName.push(new checkListType(item.Value, item.Key, item.IsActive));
                });
                self.getWardData();

            },
            error: function (xhr, textStatus, errorThrown) {
                self.formmessage("Error in retrieving form list");
                self.formmessageVisible(true);
                //alert("Error in retrieving form list");
            }
        });
    }
    self.GetCheckListType();
    


    self.AddUpdateWardMapping = function () {
        self.formmessageVisible(false);
        var dataList = new Array();
        var checkListData = new Object();
        checkListData.WardID = self.ward();
        checkListData.userID = self.userID();
        var values = self.checkListData;
        var data = null;
        ko.utils.arrayForEach(self.checkListData(), function (item) {
            dataList.push(new checkListItemMapDetails(item));
        });
        checkListData.data = dataList;
        $.ajax({
            type: 'POST',
            url: self.basewebApiURl + '/Admin/CreateUpdateCheckListDataMapping',
            data: JSON.stringify(checkListData),
            contentType: 'application/json',
            success: function (data, textStatus, xhr) {
                self.formmessage("Ward mapping details saved sucessfully");
                self.formmessageVisible(true);

            },
            error: function (xhr, textStatus, errorThrown) {
                self.formmessage("Uanble to save ward mapping details");
                self.formmessageVisible(true);
                //alert("Error in retrieving form list");
            }
        });

    }


    self.checkListChosen = function () {
        self.tabName(this.name);        
        self.GetCheckListData(this.name);

    }
    
    self.GetCheckListData = function (type) {
        
        self.formmessageVisible(false);
        if (type != "" || type!=undefined) {
            type = self.tabName();
        }
        if (type == "" || type == undefined)
        {
            self.formmessage("Choose check list type");
            self.formmessageVisible(true);
            if (self.checkListData() != null) {
                self.checkListData.removeAll();
            }
            return false;
        }
        if (self.ward() != undefined && self.ward()!="" ) {
            self.formmessageVisible(false);
            var data = new Object();
            data.Type = type;
            data.WardID = self.ward()
            var jsonString = JSON.stringify(data);

            $.ajax({
                type: 'POST',
                url: self.basewebApiURl + '/Admin/GetChecklistWardMappingMasterData',
                data: jsonString,
                contentType: 'application/json',
                success: function (data, textStatus, xhr) {
                    var cData = new Array();
                    ko.utils.arrayForEach(data, function (item) {
                        cData.push(new checkListItemDetails(item));
                    });
                    self.checkListData(cData);
                },
                error: function (xhr, textStatus, errorThrown) {
                    // alert("Error in retrieving form Checklist items");
                    self.formmessage("Error in retrieving form Checklist items");
                    self.formmessageVisible(true);
                }
            });
        }
        else {
            self.formmessage("Choose Ward");
            self.formmessageVisible(true);
        }
    }

    


}

// Activates knockout.js
ko.applyBindings(new AppViewModel());