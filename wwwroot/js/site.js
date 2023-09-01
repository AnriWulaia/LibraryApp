function returnToDefaultPage() {
    window.location.href = '/'; 
}

var successMessage = Cookies.get('success');

if (successMessage) {
    Cookies.remove("success");
    console.log("su");
    var successMessageDiv = document.getElementById("success");
    successMessageDiv.style.display = "flex";
    setTimeout(function () {
        successMessageDiv.style.display = "none";
    }, 3000);
}
