function mostrarimagen(input) {
    if (input.file && input.file[0]) {
        var leer = new FileReader();
        leer.onload = function (e) {
            document.getElementsByTagName("img")[0].setAttribute("src", e.target.result);
        }
        leer.readAsDataURL(input.file[0]);
    }
//}
//$('.menu li a '.click(function () {
//    window.location.href = $(this).attr("href")
//})