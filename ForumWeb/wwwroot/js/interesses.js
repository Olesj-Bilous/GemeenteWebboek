//eliminate use of classes for event programming
//hide dropdown list when empty

const select = document.getElementById("Select");
const button = document.getElementById("Button");
const submit = document.getElementById("Submit");
const table = document.getElementById("Table");
const tbody = table.children[1];
const msg = document.getElementById("Msg");

if (tbody.children) {
    table.hidden = false;
}

//assign listeners
button.onclick = ToonRij;
for (img of document.getElementsByClassName("delete")) {
    img.addEventListener("click", VerbergRij);
}
for (row of Array.from(tbody.children).filter(c => c.classList.contains("old"))) {
    row.children[1].firstElementChild.addEventListener("change", WijzigRij);
}
submit.onclick = Opslaan;

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

    msg.hidden = true;
}

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

        if (row.classList.contains("old")) {
            //disable submit if all changes now reverted
            submit.disabled = !TestChanged();
        } else {
            submit.disabled = false;
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
        img.width = 20;
        img.classList.add("img-fluid");
        img.classList.add("thumbnail");
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

    msg.hidden = true;
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
    option.text = row.firstElementChild.textContent;

    //append option, hide row
    select.appendChild(option);
    row.hidden = true;

    //hide table if only hidden rows in body
    if (Array.from(tbody.children).filter(c => !c.hidden).length < 1) {
        table.hidden = true;
    }

    //enable submit if hidden row is old
    if (row.classList.contains("old")) {
        submit.disabled = false;
    //disable submit if all changes now reverted
    } else {
        submit.disabled = !TestChanged();
    }

    msg.hidden = true;
}

async function Opslaan() {
    //prepare submission
    const toegevoegd = [];
    const aangepast = [];
    const verwijderd = [];

    for (row of tbody.children) {
        const tekst = row.children[1].firstElementChild.value;
        if (row.classList.contains("old"))
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
    if (response.ok) {
        msg.textContent = "Uw wijzigingen werden doorgevoerd.";
        msg.hidden = false;
        AcceptChanges();
    } else {
        msg.textContent = "Er was een probleem bij het doorvoeren van uw wijzigingen.";
        msg.hidden = false;
    }
}

function AcceptChanges() {
    for (child of tbody.children) {
        const classList = child.classList;
        if (!classList.contains("old")) {
            if (!child.hidden) {
                classList.add("old");
                child.children[3].textContent = child.children[1].firstElementChild.value;
                row.children[1].firstElementChild.addEventListener("change", WijzigRij);
            }
        } else {
            if (child.hidden) {
                classList.remove("old");
                row.children[1].firstElementChild.removeEventListener("change", WijzigRij);
            }
        }
    }
    submit.disabled = true;
}

function TestChanged() {
    //enable submit if at least one old value != original || at least one old row == hidden || at least one new row not hidden
    for (child of tbody.children) {
        if (child.classList.contains("old")) {
            //at least one old row is hidden
            if (child.hidden) {
                return true;
            }
            //at least one old description != original
            if (child.children[1].firstElementChild.value != child.children[3].textContent) {
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