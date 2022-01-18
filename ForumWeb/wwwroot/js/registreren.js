const geboortePlaatsButton = document.getElementById("GeboortePlaatsButton");
geboortePlaatsButton.naam = "Geboorte";
geboortePlaatsButton.onclick = FilterGemeenten;

const woonPlaatsButton = document.getElementById("WoonPlaatsButton");
woonPlaatsButton.naam = "Woon";
woonPlaatsButton.onclick = FilterGemeenten;

document.getElementById("StraatButton").onclick = FilterStraten;

async function FilterGemeenten(e)
{
    const naam = e.currentTarget.naam;
    const filter = document.getElementById(naam + "PlaatsInput").value;
    const select = document.getElementById(naam + "PlaatsSelect");

    const response = await fetch(`http://localhost:5000/Select/Gemeenten/${filter}`);
    const items = await response.json();
    console.log(items);
    for (const i of items)
    {
        const option = document.createElement("option");
        option.value = i.value;
        option.text = i.text;
        select.appendChild(option);
    }
    document.getElementById(naam + "PlaatsDiv").hidden = false;
    if (naam == "Woon")
    {
        document.getElementById("SearchStraatDiv").hidden = false;
    }
}

async function FilterStraten()
{
    const gemeenteId = document.getElementById("WoonPlaatsSelect").value;
    const filter = document.getElementById("StraatInput").value;
    const select = document.getElementById("StraatSelect");

    const response = await fetch(`http://localhost:5000/Select/Straten/${gemeenteId}/${filter}`);
    const items = await response.json();


    for (const i of items)
    {
        const option = document.createElement("option");
        option.value = i.value;
        option.text = i.text;
        select.appendChild(option);
    }
    document.getElementById("StraatDiv").hidden = false;
}