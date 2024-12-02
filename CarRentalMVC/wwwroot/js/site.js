// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    const toggleButton = document.getElementById("menu-toggle");
    const sidebar = document.getElementById("sidebar");
    document.addEventListener("click", (event) => {
        if (toggleButton.contains(event.target)) {
            sidebar.classList.toggle("active");
        } else if (!sidebar.contains(event.target)) {
            sidebar.classList.remove("active");
        }
    });

    document.querySelectorAll('.nav-item.dropdown > a').forEach(item => {
        item.addEventListener('click', function (e) {
            const dropdownMenu = this.nextElementSibling;

            if (dropdownMenu.classList.contains('show')) {
                dropdownMenu.classList.remove('show');
            } else {
                document.querySelectorAll('.nav-item.dropdown .collapse.show').forEach(menu => {
                    menu.classList.remove('show');
                });
                dropdownMenu.classList.add('show');
            }
            e.preventDefault();
        });
    });
});
