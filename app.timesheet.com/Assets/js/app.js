const options = { "backdrop": "static", keyboard: true };

// Window Load
$(document).ready(function () {
    //set up bootstrap theme
    $.fn.select2.defaults.set("theme", "bootstrap4");
  
    $('#GlobalPopup').on('hidden.bs.modal', function (event) {
        $('#GlobalPopup').modal('hide');
        $('#GlobalPopupBody').html('');
    })

    $(document).on('click', '.global-modal-close', function () {
        $('#GlobalPopup').modal('hide');
        $('#GlobalPopupBody').html('');
    })

})

function getNotifier() {
    return new Notyf({
        duration: 4000,
        dismissible: true,
        position: {
            'x': 'right',
            'y': 'top'
        }
    });;
}

function SetGlobalPopup(body) {
    $('#GlobalPopupBody').html(body);
    $('#GlobalPopup').modal(options);
}

function OpenGlobalPopup(viewUrl) {
    $.ajax({
        type: "GET",
        url: viewUrl,
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        success: function (data) {
            SetGlobalPopup(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}

//Customer Add - Update
function SaveCustomerDetails(data, callback) {
    const model = ConvertURIToJson(data);
    $.ajax({
        type: "POST",
        url: "Save",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}

function UpdateCustomerDetails(ID, data, callback) {
    let model = ConvertURIToJson(data);
    model["ID"] = ID;
    $.ajax({
        type: "POST",
        url: "Update",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}

//Product Add - Update
function SaveProductDetails(data, callback) {
    const model = ConvertURIToJson(data);
    $.ajax({
        type: "POST",
        url: "Save",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}

function UpdateProductDetails(ID, data, callback) {
    
    let model = ConvertURIToJson(data);
    model["ID"] = ID;
    $.ajax({
        type: "POST",
        url: "Update",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}


// Department Add - Update
function SaveDepartmentDetails(data, callback) {
    const model = ConvertURIToJson(data);
    $.ajax({
        type: "POST",
        url: "Save",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}

function UpdateDepartmentDetails(ID, data, callback) {
    let model = ConvertURIToJson(data);
    model["ID"] = ID;
    $.ajax({
        type: "POST",
        url: "Update",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}

// Designation Add - Update
function SaveDesignationDetails(data, callback) {
    const model = ConvertURIToJson(data);
    $.ajax({
        type: "POST",
        url: "Save",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}

function UpdateDesignationDetails(ID, data, callback) {
    let model = ConvertURIToJson(data);
    model["ID"] = ID;
    $.ajax({
        type: "POST",
        url: "Update",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}


// CustomerProductMapping Add - Update
function SaveCustomerProductMappingDetails(data, callback) {
    
    const model = ConvertURIToJson(data);
    $.ajax({
        type: "POST",
        url: "Save",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}

function UpdateCustomerProductMappingDetails(ID, data, callback) {
    
    let model = ConvertURIToJson(data);
    model["ID"] = ID;
    $.ajax({
        type: "POST",
        url: "Update",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}


// Task Add - Update
function SaveTaskDetails(data, callback) {
    const model = ConvertURIToJson(data);
    $.ajax({
        type: "POST",
        url: "Save",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}

function UpdateTaskDetails(ID, data, callback) {
    let model = ConvertURIToJson(data);
    model["ID"] = ID;
    $.ajax({
        type: "POST",
        url: "Update",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}
 
// Activity Add - Update
function SaveActivityDetails(data, callback) {
    const model = ConvertURIToJson(data);
    $.ajax({
        type: "POST",
        url: "Save",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}

function UpdateActivityDetails(ID, data, callback) {
    let model = ConvertURIToJson(data);
    model["ID"] = ID;
    $.ajax({
        type: "POST",
        url: "Update",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}

// Account Add - Update
function SaveAccountDetails(data, callback) {
    const model = ConvertURIToJson(data);
    $.ajax({
        type: "POST",
        url: "Save",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}

function UpdateAccountDetails(ID, data, callback) {
    let model = ConvertURIToJson(data);
    model["ID"] = ID;
    $.ajax({
        type: "POST",
        url: "Update",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}

//TimeSheet Add - Update
function SaveTimeSheetDetails(data, callback) {
    const model = ConvertURIToJson(data);
    $.ajax({
        type: "POST",
        url: "Save",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}

//User Authenticate
function Authenticate(data, callback) {
    const model = ConvertURIToJson(data);
    $.ajax({
        type: "POST",
        url: "Authenticate",
        contentType: "application/json; charset=utf-8",
        datatype: "json",
        data: JSON.stringify(model),
        success: function (data) {
            callback(data)
        },
        error: function () {
            getNotifier().error("Something Went Wrong");
        }
    });
}



function ConvertURIToJson(data) {
    const uri = decodeURIComponent(data)
    let obj = {};
    uri.split('&').map((x, i) => {
        const [key, value] = x.split('=');
        obj[key] = value
    })
    return obj;
}





