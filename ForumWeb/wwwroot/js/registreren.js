//prepare caller for listener identification and assign listener
const geboortePlaatsButton = document.getElementById("GeboortePlaatsButton");
geboortePlaatsButton.naam = "GeboortePlaats";
geboortePlaatsButton.onclick = FilterItems;

const woonPlaatsButton = document.getElementById("WoonPlaatsButton");
woonPlaatsButton.naam = "WoonPlaats";
woonPlaatsButton.onclick = FilterItems;

const straatButton = document.getElementById("StraatButton");
straatButton.naam = "Straat";
straatButton.onclick = FilterItems;

async function FilterItems(e)
{
    //identify caller and prepare target
    const naam = e.currentTarget.naam;
    const select = document.getElementById(naam + "Select");

    //prepare source url
    const domain = naam == "Straat" ? "Straten" : "Gemeenten";
    const gemeenteIdSlash = naam == "Straat" ? document.getElementById("WoonPlaatsSelect").value + "/" : "";
    const filter = document.getElementById(naam + "Input").value;

    //read source
    const response = await fetch(`http://localhost:5000/Select/${domain}/${gemeenteIdSlash}${filter}`);
    if (response.ok)
    {
        //clear target of previous items if necessary
        while (select.firstChild)
        {
            select.removeChild(select.lastChild);
        }
    
        //remove warning previous read source fail if necessary
        const warning = document.getElementById(naam + "Warning");
        if (warning)
        {
            document.getElementById("Search" + naam + "Div").removeChild(warning);
        }

        //assign values to target from source
        const items = await response.json();
        for (const i of items)
        {
            const option = document.createElement("option");
            option.value = i.value;
            option.text = i.text;
            select.appendChild(option);
        }

        //reveal next step in process to user
        document.getElementById(naam + "Div").hidden = false;
        if (naam == "WoonPlaats")
        {
            document.getElementById("SearchStraatDiv").hidden = false;
        }
    }
    else
    {
        //issue warning if read source failed, if necessary
        var warning = document.getElementById(naam + "Warning");
        if (!warning)
        {
            warning = document.createElement("p");
            warning.id = naam + "Warning";
            warning.textContent = "Er werden geen "
                + (naam == "Straat" ? "straten" : "gemeenten")
                + " gevonden met deze letters.";
            warning.classList.add("font-weight-bold");
            warning.classList.add("text-danger");
            document.getElementById("Search" + naam +"Div").appendChild(warning);
        }

        //hide next step in process from user
        document.getElementById(naam + "Div").hidden = true;
        if (naam == "WoonPlaats")
        {
            document.getElementById("SearchStraatDiv").hidden = true;
        }

        //clear target of previous items if necessary
        while (select.firstChild)
        {
            select.removeChild(select.lastChild);
        }
    }
}