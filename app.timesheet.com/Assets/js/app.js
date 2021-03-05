const options = { "backdrop": "static", keyboard: true };

// Window Load
$(document).ready(function () {

    //Define DataTable.
    $('.custom-datatables').DataTable();

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
    debugger;
    const model = ConvertToJson(data);
    $.ajax({
        type: "POST",
        url: "Customer/Save",
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
    debugger;
    let model = ConvertToJson(data);
    model["ID"] = ID;
    $.ajax({
        type: "POST",
        url: "Customer/Update",
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
    debugger;
    const model = ConvertToJson(data);
    $.ajax({
        type: "POST",
        url: "Product/Save",
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
    debugger;
    let model = ConvertToJson(data);
    model["ID"] = ID;
    $.ajax({
        type: "POST",
        url: "Product/Update",
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
    debugger;
    const model = ConvertToJson(data);
    $.ajax({
        type: "POST",
        url: "Department/Save",
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
    debugger;
    let model = ConvertToJson(data);
    model["ID"] = ID;
    $.ajax({
        type: "POST",
        url: "Department/Update",
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
    debugger;
    const model = ConvertToJson(data);
    $.ajax({
        type: "POST",
        url: "Designation/Save",
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
    debugger;
    let model = ConvertToJson(data);
    model["ID"] = ID;
    $.ajax({
        type: "POST",
        url: "Designation/Update",
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

function ConvertToJson(data) {
    let obj = {};
    data.split('&').map((x, i) => {
        const [key, value] = x.split('=');
        obj[key] = value
    })
    return obj;
}





