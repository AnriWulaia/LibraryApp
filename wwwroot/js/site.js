function returnToDefaultPage() {
    window.location.href = '/'; 
}

document.addEventListener("DOMContentLoaded", function () {

    var successMessageDiv = document.getElementById("success");

    if (successMessageDiv) {
        setTimeout(function () {
            successMessageDiv.style.display = "none";
        }, 3000);
    }
});
