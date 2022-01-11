document.getElementById("GeboortePlaatsButton").onclick = FilterGemeenten;

function SetHidden(element, sleutel) {
    if (element.value.includes(sleutel)) {
        element.hidden = false;
    }
    else {
        element.hidden = true;
    }
}

function FilterGemeenten()
{
    const sleutel = document.getElementById("GeboortePlaatsInput").value.toString();
    const select = document.getElementById("GeboortePlaatsSelect");

    for (const element of select.children) {
        SetHidden(element, sleutel);
    }

    //selected index wijzigen
}