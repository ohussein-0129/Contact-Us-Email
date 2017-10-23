setTextBoxEvents();
var textBoxPropoerty = {
    clicked: [0, 0, 0],
};

function setTextBoxEvents() {
    var i;
    var tb = document.getElementsByClassName("tbox");
    for (i = 0; i < tb.length; i++) {
        tb[i].addEventListener('click', tbClick, false);
        tb[i].addEventListener('blur', tbBlur, false);
        tb[i].addEventListener('mouseover', tbmOver, false);
        tb[i].addEventListener('mouseout', tbmOut, false);
    }
}

function tbClick(e) {
    var tb = document.getElementsByClassName("tbox");
    var el = document.getElementById(e.target.id);
    el.style.borderColor = "#ADC2EA";
    el.style.backgroundColor = "#FDFDFE";

    var i;
    for (i = 0; i < tb.length; i++) if (tb[i].id == e.target.id) break;
    textBoxPropoerty.clicked[i] = 1;
}

function tbBlur(e) {
    var tb = document.getElementsByClassName("tbox");
    var el = document.getElementById(e.target.id);
    el.style.backgroundColor = "#F8F8F8";
    el.style.borderColor = "#F8F8F8";

    var i;
    for (i = 0; i < tb.length; i++) if (tb[i].id == e.target.id) break;
    textBoxPropoerty.clicked[i] = 0;
}

function tbmOver(e) {
    var tb = document.getElementsByClassName("tbox");
    var el = document.getElementById(e.target.id);
    var i;
    for (i = 0; i < tb.length; i++) if (tb[i].id == e.target.id) break;
    if (textBoxPropoerty.clicked[i] == 0) {
        el.style.backgroundColor = "#FDFDFE";
        el.style.borderColor = "#A1D7ED";
    }
}

function tbmOut(e){
    var tb = document.getElementsByClassName("tbox");
    var el = document.getElementById(e.target.id);
    var i;
    for (i = 0; i < tb.length; i++) if (tb[i].id == e.target.id) break;
    if (textBoxPropoerty.clicked[i] == 0) {
        el.style.backgroundColor = "#F8F8F8";
        el.style.borderColor = "#F8F8F8";
    }
}
