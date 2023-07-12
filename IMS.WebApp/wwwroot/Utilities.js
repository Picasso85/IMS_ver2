function focusById(elementId) {
    var element = document.getElementById(elementId);
    if (element) {
        element.focus();
    }
}

function PreventFormSubmition(formId) {

    document.getElementById(`${formId}`).addEventListener("keydown", function (event) {
        if (event.keycode == 13) {
            event.preventDefault();
            return false;
        }
    });
}