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

function checkListType(name, key,isActive) {
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
    self.IsActive = (checkListItem.IsActive == "1") ? "Active" : "Inactive";

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
    self.CheckListName = ko.observableArray();
    self.LabelID = ko.observable();
    self.LabelName = ko.observable();
    self.Control = ko.observable();
    self.SelectedOption = ko.observable();
    self.OptionsAdded = ko.observableArray();
    self.Optionsdata = ko.observableArray(['Textbox', 'Radiobutton', 'Checkbox', 'Button', 'Selectbox']);
    self.isVisible = ko.observable(false);
    self.IsActive = ko.observable(false);
    self.message = ko.observable();
    self.messageVisible = ko.observable(false);
    self.formID = ko.observable();
    self.formname = ko.observable();
    self.formstatus = ko.observable(false);
    self.formmessage = ko.observable();
    self.formmessageVisible = ko.observable(false);

    self.addForm = function () {

        var data = new Object();
        data.configID = self.formID();
        data.configName = self.formname();
        data.isActive = (self.formstatus() == true) ? 1 : 0;
        data.userID = self.userID();
        self.formmessage('');
        self.formmessageVisible(false);

        if ($.trim(self.formname()).length == 0) {
            self.formmessage("Form name cannot be empty");
            self.formmessageVisible(true);
            return false;
        }
        var match = ko.utils.arrayFirst(self.CheckListName(), function (item) {
            if (item.name.toLowerCase() == self.formname().toLowerCase()) {
                return true;
            }
            else {
                return false;
            }
        });
        if (!match) {
            $.ajax({
                type: 'POST',
                url: self.basewebApiURl + '/Admin/CreateUpdateConfigHeader',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data, textStatus, xhr) {
                    if (parseInt(data) > 0) {
                        self.GetCheckListType()
                        self.formmessage('New form created');
                        self.formmessageVisible(true);
                    }
                },
                error: function (xhr, textStatus, errorThrown) {
                    self.formmessage("Unable to create new form");
                    self.formmessageVisible(true);
                }
            });
        }
        else {
            self.formmessage("Form name should not be repeated");
            self.formmessageVisible(true);
        }


    }
    self.OpenAddForm = function () {
        self.formname('');
        self.formstatus(false);
        self.formID('');
        self.formmessage('');
        self.formmessageVisible(false);
    }


    self.OpenPopup = function () {
        self.LabelID("");
        self.LabelName("");
        self.Control("");
        self.SelectedOption("");
        self.OptionsAdded.removeAll();
        self.message("");
        self.messageVisible(false);
        self.IsActive(false);

    }

    self.ControlTypeChange = function () {
        //if ((self.SelectedOption()!=undefined && self.SelectedOption()!=null) && self.SelectedOption().toLowerCase() != "textbox") {
        //    self.isVisible(true);
        //    self.OptionsAdded.push(new CheckListOptions('', '', '0', '1'));
        //}
        //else {
        //    self.isVisible(false);
        //    self.OptionsAdded.removeAll();
        //}
    }
    self.AddNewOptions = function () {
        self.OptionsAdded.push(new CheckListOptions('', '', '0', '1'));
    }
    self.removeOption = function (obj, event) {
        var Id = this
        if (obj.CheckListOptionsID == "") {
            self.OptionsAdded.remove(this);
        }
        else {
            var data = new Object();
            data.CheckListOptionsID = obj.CheckListOptionsID;
            data.CheckListOptionsValue = obj.CheckListOptionsValue;

            $.ajax({
                type: 'POST',
                url: self.basewebApiURl + '/Admin/DeleteOptions',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data, textStatus, xhr) {
                    if (parseInt(data) > 0)
                        self.OptionsAdded.remove(obj);
                    self.GetCheckListData(self.tabName());
                },
                error: function (xhr, textStatus, errorThrown) {
                    self.message("Unable to remove option");
                    self.messageVisible(true);
                }
            });
        }


    }
    self.Edit = function () {
        //self.LabelID("");
        //self.LabelName("");
        //self.Control("");
        //self.SelectedOption("");
        //self.OptionsAdded.removeAll();
        //self.message("");
        //self.messageVisible(false);

        self.LabelID(this.CheckListItemId);
        self.LabelName(this.CheckListItemName);
        //self.Control();        
        self.SelectedOption(this.ControlType);
        self.OptionsAdded(this.Options);
        self.IsActive((this.IsActive.toLowerCase() == "active") ? true : false);
        self.message("");
        self.messageVisible(false);

    }
    self.SelectedOption.subscribe(function (newValue) {
        if ((self.SelectedOption() != undefined && self.SelectedOption() != null) && (self.SelectedOption().toLowerCase() != "textbox" && self.SelectedOption().toLowerCase() != "button")) {
            self.isVisible(true);
            if (self.OptionsAdded().length == 0)
                self.OptionsAdded.push(new CheckListOptions('', '', '0', '1'));
        }
        else {
            self.isVisible(false);
            self.OptionsAdded.removeAll();
        }
    });

    self.Save = function (obj) {


        if ($.trim(self.LabelName()).length == 0) {
            self.message("Please enter mandatory fields");
            self.messageVisible(true);
            return false;
        }
        else if (self.SelectedOption() == undefined) {
            self.message("Please enter mandatory fields");
            self.messageVisible(true);
            return false;
        }
        else if (self.SelectedOption().toLowerCase() != 'textbox' || self.SelectedOption().toLowerCase() != 'button') {
            var status = true;
            if (self.OptionsAdded().length == 0) {
                self.message("Please enter options");
                self.messageVisible(true);
                status = false;
            }
            else {
                
                ko.utils.arrayForEach(self.OptionsAdded(), function (item) {
                    if ($.trim(item.CheckListOptionsValue).length == 0) {
                        self.message("Please enter option name");
                        self.messageVisible(true);
                        status = false;
                    }
                });
                

            }
            if(!status)
            return status;
        }

        
        
        var value = this;
        var itemData = new Object();
        itemData.ChecklistItemId = self.LabelID();
        itemData.CheckListItemName = self.LabelName();
        itemData.CheckListControlType = self.SelectedOption();
        itemData.ChecklistType = self.tabName();
        itemData.isActive = self.IsActive();
        itemData.UserID = self.userID();
        itemData.OptionData = JSON.stringify(self.OptionsAdded());

        $.ajax({
            type: 'POST',
            url: self.basewebApiURl + '/Admin/InsertUpdateCheckListItems',
            data: JSON.stringify(itemData),
            contentType: 'application/json',
            success: function (data, textStatus, xhr) {

                if (parseInt(data) > 0) {
                    self.GetCheckListData(self.tabName());
                }
                self.message("New item created succesfully.");
                self.messageVisible(true);
            },
            error: function (xhr, textStatus, errorThrown) {
                self.message("Error in retrieving form Checklist items");
                self.messageVisible(true);
               // alert("Error in retrieving form Checklist items");
            }
        });


    }
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
            },
            error: function (xhr, textStatus, errorThrown) {
                self.formmessage("Error in retrieving form list");
                self.formmessageVisible(true);
                //alert("Error in retrieving form list");
            }
        });
    }
    self.GetCheckListType();
    self.EditCheckListType = function () {
        $("#addFormAnc").click();
        ko.utils.arrayForEach(self.CheckListName(), function(item) {
            if (item.name == self.tabName()) {
                self.formID (item.key);                
                self.formname (item.name);                
                self.formstatus((item.isActive == 1) ? true : false);
            }
        });

    }
    self.DeleteCheckListType = function () {
        
        self.formmessageVisible(false);
        if (self.checkListData().length > 0) {
            self.formmessage("Remove check list items from form.");
            self.formmessageVisible(true);
           // alert("Remove check list items from form.")
            return false;
        }
        ko.utils.arrayForEach(self.CheckListName(), function (item) {
            if (item.name == self.tabName()) {
                self.formID(item.key);
                return false;
            }
        });

        $.ajax({
            type: 'POST',
            url: self.basewebApiURl + '/Admin/DeleteConfigHeader',
            data: '"' + self.formID() + '"',
            contentType: 'application/json',
            success: function (data, textStatus, xhr) {
                if (parseInt(data) > 0) {
                    self.GetCheckListType();
                    $("#addFormAnc").click();
                }
            },
            error: function (xhr, textStatus, errorThrown) {
                // alert("Unableto delete the form");
                self.formmessage("Unableto delete the form");
                self.formmessageVisible(true);
            }
        });
    }

    


    self.checkListChosen = function () {
        self.tabName(this.name);
        self.GetCheckListData(this.name);

    }

    self.GetCheckListData = function (type) {
        self.formmessageVisible(false);
        var data = new Object();
        data.Key = type;
        data.Value = "";
        var jsonString = JSON.stringify(data);

        $.ajax({
            type: 'POST',
            url: self.basewebApiURl + '/Admin/GetCheckListItems',
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

    self.DeleteCheckListData = function (obj, event) {
        
        var data = new Object();
        data.CheckListItemID = obj.CheckListItemId;
        var values = JSON.stringify(data);
        $.ajax({
            type: 'POST',
            url: self.basewebApiURl + '/Admin/DeleteCheckListItem',
            data: '"' + obj.CheckListItemId + '"',
            contentType: 'application/json',
            success: function (data, textStatus, xhr) {
                if (parseInt(data) > 0) {
                    self.GetCheckListData(self.tabName());
                }
            },
            error: function (xhr, textStatus, errorThrown) {
                // alert("Error in retrieving form Checklist items");
            }
        });
    }

    

}

// Activates knockout.js
ko.applyBindings(new AppViewModel());