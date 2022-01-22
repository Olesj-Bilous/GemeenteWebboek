//enable submit if at least one old value != original || at least one old row == hidden || at least one new row not hidden

//fix img width and hover

const select = document.getElementById("Select");
const button = document.getElementById("Button");
const submit = document.getElementById("Submit");
const table = document.getElementById("Table");
const tbody = table.children[1];
var msg = document.getElementById("Msg");

if (tbody.children) {
    table.hidden = false;
}

//assign listeners
button.onclick = ToonRij;
for (img of document.getElementsByName("delete")) {
    img.onclick = VerbergRij;
}
for (row of Array.from(table.children).filter(c => c.name == "old")) {
    row.children[1].firstChild.onchange = WijzigRij;
}
submit.onclick = Opslaan;

function ToonRij()
{
    //identify selected option
    const selected = select.options[select.selectedIndex];

    //check table for hidden rows with interest id
    var row = Array.from(tbody.children).find(c => c.id == select.value);
    if (row)
    {
        //remove option
        select.removeChild(selected);

        //reveal hidden row
        row.hidden = false;

        if (row.name == "old") {
            //disable submit if all changes now reverted
            submit.disabled = !TestChanged();
        }
    }
    else
    {
        //make new row
        row = document.createElement("tr");
        row.id = selected.value;

        //add name data to row
        const naamData = document.createElement("td");
        naamData.textContent = selected.text;
        row.appendChild(naamData);

        //add description input data to row
        const tekstData = document.createElement("td");
        const tekstInput = document.createElement("input");
        tekstInput.type = "text";
        tekstInput.onchange = WijzigRij;
        tekstData.appendChild(tekstInput);
        row.appendChild(tekstData);

        //add delete image to row
        const imgData = document.createElement("td");
        const img = document.createElement("img");
        img.src = "/img/crossIcon.svg";
        img.alt = "verwijder";
        img.classList.add("img-fluid");
        img.onclick = VerbergRij;
        imgData.appendChild(img);
        row.appendChild(imgData);

        //add hidden original to row
        const originalData = document.createElement("td");
        originalData.hidden = true;
        row.appendChild(originalData);

        //remove option
        select.removeChild(selected);

        //add row to table
        tbody.appendChild(row);

        //enable submit
        submit.disabled = false;
    }
    //reveal table
    table.hidden = false;
}

function VerbergRij(e)
{
    //identify caller and ancestor row
    const caller = e.currentTarget;
    const row = caller.parentNode.parentNode;

    //fill new option with row content and append
    //remember: row id was assigned InteresseId
    const option = document.createElement("option");
    option.value = row.id;
    option.text = row.firstChild.textContent;

    //append option, hide row
    select.appendChild(option);
    row.hidden = true;

    //hide table if only hidden rows in body
    if (Array.from(tbody.children).filter(c => !c.hidden).length < 1) {
        table.hidden = true;
    }

    //enable submit if hidden row is old
    if (row.name == "old") {
        submit.disabled = false;
    //disable submit if all changes now reverted
    } else {
        submit.disabled = !TestChanged();
    }
}

function WijzigRij(e) {
    const caller = e.currentTarget;
    const original = caller.parentNode.parentNode.children[3].textContent;

    //enable submit if change is not to original
    if (caller.value != original) {
        submit.disabled = false;
    } else {
        //disable submit if all changes now reverted
        submit.disabled = !TestChanged();
    }
}

async function Opslaan() {
    //prepare submission
    const toegevoegd = [];
    const aangepast = [];
    const verwijderd = [];

    for (row of tbody.children) {
        const tekst = row.children[1].firstChild.value;
        if (row.name == "old")
        {
            //old and hidden: verwijderd
            if (row.hidden) {
                verwijderd.push(row.id);
            }
            else
            {
                const origineel = row.children[3].textContent;
                //old, not hidden and not original: aangepast
                if (tekst != origineel)
                {
                    aangepast.push({ "Id": row.id, "Tekst": tekst });
                }
            }
        }
        else
        {
            //new and not hidden: toegevoegd
            if (!row.hidden)
            {
                toegevoegd.push({ "Id": row.id, "Tekst": tekst });
            }
        }
    }
    //prepare data for post
    const profielId = document.getElementById("profielId").textContent;
    const data = { "ProfielId": profielId, "Toegevoegd": toegevoegd, "Aangepast": aangepast, "Verwijderd": verwijderd };

    //post to api
    const response = await fetch(
        `http://localhost:5000/Interesses`,
        {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(data)
        });

    //report on post
    if (!msg) {
        msg = document.createElement("h3")
        document.querySelector("main").insertBefore(msg, submit);
    }
    if (response.ok) {
        msg.textContent = "Uw wijzigingen werden doorgevoerd.";
    } else {
        msg.textContent = "Er was een probleem bij het doorvoeren van uw wijzigingen."
    }
}

function TestChanged() {
    //enable submit if at least one old value != original || at least one old row == hidden || at least one new row not hidden
    for (child of tbody.children) {
        if (child.name == "old") {
            //at least one old row is hidden
            if (child.hidden) {
                return true;
            }
            //at least one old description != original
            if (child.children[1].firstChild.value != child.children[3].textContent) {
                return true;
            }
        } else {
            //at least one new row is not hidden
            if (!child.hidden) {
                return true;
            }
        }
    }
    //no hidden old rows and no old rows with changed descriptions and no new rows that are not hidden
    return false;
}