const geboortePlaatsButton = document.getElementById("GeboortePlaatsButton");
geboortePlaatsButton.naam = "Geboorte";
geboortePlaatsButton.onclick = FilterGemeenten;

const woonPlaatsButton = document.getElementById("WoonPlaatsButton");
woonPlaatsButton.naam = "Woon";
woonPlaatsButton.onclick = FilterGemeenten;

async function FilterGemeenten(e)
{
    const filter = document.getElementById(e.currentTarget.naam + "PlaatsInput").value;
    const select = document.getElementById(e.currentTarget.naam + "PlaatsSelect");

    const response = await fetch(`http://localhost:5000/select/${filter}`);
    const items = await response.json();
    console.log(items);
    for (const i of items)
    {
        const option = document.createElement("option");
        option.value = i.value;
        option.text = i.text;
        select.appendChild(option);
    }
    select.hidden = false;
}