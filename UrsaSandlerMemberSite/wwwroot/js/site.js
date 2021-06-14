

//SideNav Code
function sideNavReveal() {
    var x = document.getElementById('mySideBar');
    x.classList.remove('-translate-x-full');
}

function sideNavHide() {
    var x = document.getElementById('mySideBar');
    x.classList.add('-translate-x-full');
}