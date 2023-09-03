function returnToDefaultPage() {
    window.location.href = '/'; 
}
function returnToUserPage() {
    window.location.href = "/Users";
}

document.addEventListener("DOMContentLoaded", function () {

    var successMessageDiv = document.getElementById("success");

    if (successMessageDiv) {
        setTimeout(function () {
            successMessageDiv.style.display = "none";
        }, 3000);
    }
});
