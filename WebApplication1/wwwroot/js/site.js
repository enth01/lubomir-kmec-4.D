// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function zobraz_skry(){
    let text = document.getElementById("text");
    text.style.display = (text.style.disply == "none") ? text.style.display = "block" : text.style.display = "none";
}
let click_counter = 0;
function zmen_farbu() {
    let box = document.getElementById("uloha7");
    let klik = document.getElementById("klik");
    click_counter++;
    klik.innerHTML = "click counter: " + click_counter;
    if (click_counter == 5 && box.style.backgroundColor != "pink") {
        box.style.backgroundColor = "pink";
        click_counter = 0;
    } if (click_counter == 5) {
        box.style.backgroundColor = "white";
        click_counter = 0;
    }
}

let textarea = document.getElementById("textarea");

if (textarea) {
    textarea.addEventListener("input", () => {
        textcounter = (textarea.value).length
        if (textcounter > 20) {
            textarea.classList.add("ok");
        } else {
            textarea.classList.remove("ok");
        }
    })
}