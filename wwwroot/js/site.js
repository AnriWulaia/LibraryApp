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


/*Users javascript*/
async function deleteBook(button) {
    var userName = button.getAttribute('data-user-name');
    var bookToDelete = button.getAttribute('data-book');
    console.log(userName, bookToDelete);

    try {
        // Send an AJAX request to delete the book
        await $.ajax({
            type: 'POST',
            url: '/Users/DeleteBook',
            data: { userName: userName, bookToDelete: bookToDelete },
        });

        var bookItem = button.closest('.book-item')

        if (bookItem) {
            bookItem.classList.add('hidden');
        }
    } catch (error) {
        console.log(error);
        console.error("Error: " + error.responseText);
    }
} 


function addBooks() {
    var checkboxes = document.querySelectorAll('input[name="Borrowed"]');
    var userName = document.getElementById("userName").innerText;

    var selectedBooks = [];

    checkboxes.forEach(function (checkbox) {
        if (checkbox.checked) {
            selectedBooks.push(checkbox.value); 
        }
    });


    console.log("Selected Books: " + selectedBooks.join(', '), userName);

    $.ajax({
        type: 'POST',
        url: '/Users/addBooks',
        data: { userName: userName, selectedBooks: selectedBooks },
        success: function (response) {

            console.log("Success: " + response);

            // Reload the page
            window.location.reload();
        },
        error: function (error) {
            console.log(error);
            console.error("Error: " + error.responseText);
        }
    });
};


