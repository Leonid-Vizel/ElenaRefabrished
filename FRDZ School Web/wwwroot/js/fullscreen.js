function makeFullScreen() {
    var divObj = document.getElementById("image");
    if (divObj.requestFullscreen) {
        divObj.requestFullscreen();
    }
    else if (divObj.msRequestFullscreen) {
        divObj.msRequestFullscreen();
    }
    else if (divObj.mozRequestFullScreen) {
        divObj.mozRequestFullScreen();
    }
    else if (divObj.webkitRequestFullscreen) {
        divObj.webkitRequestFullscreen();
    } else {
        window.open(divObj.getAttribute("src"), '_blank').focus();
    }
}