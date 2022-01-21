//option moet verwijderd worden na toevoegen interesse

//tekst input onchanged instellen: 
//  table.hidden = false if at least one old value != original && no old rows == hidden && no new rows
//  ==> table must not be created by js, save option can be disabled when unnecessary

//image url must be changed


const select = document.getElementById("Select");
const button = document.getElementById("Button");
const submit = document.getElementById("Submit");
var table = document.getElementById("Table");
var msg = document.getElementById("Msg");

//prepare submission
const toegevoegd = [];
const aangepast = [];
const verwijderd = [];

//assign listeners
button.onclick = VoegRijToe;
for (img of document.getElementsByName("delete"))
{
    img.onclick = VerwijderRij;
}
submit.onclick = Opslaan;

async function Opslaan()
{
    for (row of table.childNodes)
    {
        if (row.name == "old")
        {
            if (row.hidden)
            {
                verwijderd.push(row.id);
            }
            else
            {
                const tekst = row.children[1].firstChild.value;
                const origineel = row.children[3].textContent;
                if (tekst != origineel)
                {
                    aangepast.push({ "Id" : row.id, "Tekst" : tekst });
                }
            }
        }
        else
        {
            if (!row.hidden)
            {
                toegevoegd.push({ "Id" : row.id, "Tekst" : tekst });
            }
        }
    }
    const profielId = document.getElementById("profielId").textContent;
    const data = { "ProfielId": profielId, "Toegevoegd": toegevoegd, "Aangepast": aangepast, "Verwijderd": verwijderd };

    const response = await fetch(
        `http://localhost:5000/Interesses`,
        {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data)
        });
    if (!msg) {msg = document.createElement("h3")
    document.insertBefore(msg, submit);}
    if (response.ok) {
        msg.textContent = "Uw wijzigingen werden doorgevoerd.";
    } else {
        msg.textContent = "Er was een probleem bij het doorvoeren van uw wijzigingen."
    }
}

function VoegRijToe()
{
    //check if table exist
    if (!table)
    {
        //create table and title row
        table = document.createElement("table");
        const titleRow = document.createElement("tr");

        //add name title to row
        const naamTitle = document.createElement("th");
        naamTitle.textContent = "Interesse";
        titleRow.appendChild(naamTitle);

        //add description title to row
        const tekstTitle = document.createElement("th");
        tekstTitle.textContent = "Beschrijving";
        titleRow.appendChild(tekstTitle);

        //add delete title to row
        const imgTitle = document.createElement("th");
        imgTitle.textContent = "Verwijder";
        titleRow.appendChild(imgTitle);

        //add hidden original title to row
        const originalTitle = document.createElement("th");
        originalTitle.hidden = true;
        titleRow.appendChild(originalTitle);

        //add row to table, add table to main
        table.appendChild(titleRow);
        document.querySelector("main").appendChild(table);
    }

    //check table for hidden rows with interest id
    var row;

    if (table.children) {
    row = Array.from(table.children).find(c => c.id == select.value);
    }
    if (row)
    {
        //reveal hidden row
        row.hidden = false;
    }
    else
    {
        //make new row
        row = document.createElement("tr");
        row.id = select.value;

        //add name data to row
        const naamData = document.createElement("td");
        naamData.textContent = select.options[select.selectedIndex].text;
        row.appendChild(naamData);

        //add description input data to row
        const tekstData = document.createElement("td");
        const tekstInput = document.createElement("input");
        tekstInput.type = "text";
        tekstData.appendChild(tekstInput);
        row.appendChild(tekstData);

        //add delete image to row
        const imgData = document.createElement("td");
        const img = document.createElement("img");
        img.src = "~/img/crossIcon.svg";
        img.alt = "verwijder";
        imgData.appendChild(img);
        row.appendChild(imgData);

        //add hidden original to row
        const originalData = document.createElement("td");
        originalData.hidden = true;
        row.appendChild(originalData);

        //add row to table
        table.appendChild(row);
    }
}

function VerwijderRij(e)
{
    //identify caller and ancestor row
    const caller = e.currentTarget;
    const row = document.parentNode.parentNode;

    //fill new option with row content and append
    //remember: row id was assigned InteresseId
    const option = document.createElement("option");
    option.value = row.id;
    option.text = row.firstChild.textContent;

    //append option, hide row
    select.appendChild(option);
    row.hidden = true;
}