function uniqueNumber() {
    var date = Date.now();
    if (date <= uniqueNumber.previous) {
        date = ++uniqueNumber.previous;
    } else {
        uniqueNumber.previous = date;
    }
    return date;
}

const stampa = () => {
    let elenco = JSON.parse( localStorage.getItem('oggetti_olvd') );

    let stringaTabella = '';
    for(let [idx, item] of elenco.entries()){
        stringaTabella += `
            <tr>
                <td>${idx + 1}</td>
                <td>${item.cod}</td>
                <td>${item.mat}</td>
                <td>${item.nuc}</td>
                <td>${item.lun}</td>
                <td>${item.res}</td>
                <td>${item.mag}</td>
                <td>${item.cas}</td>
                <td class="text-right">
                    <button class="btn btn-outline-warning" onclick="modifica(${idx})">
                        <i class="fa-solid fa-pencil"></i>
                    </button>
                    <button class="btn btn-outline-danger" onclick="elimina(${idx})">
                        <i class="fa-solid fa-trash"></i>
                    </button>
                </td>
            </tr>
        `;
    }

    document.getElementById("corpo-tabella").innerHTML = stringaTabella;
}

const salva = () => {
    
    let mat = document.getElementById("input-materiale").value;
    let nuc = document.getElementById("input-nucleo").value;
    let lun = document.getElementById("input-lunghezza").value;
    let res = document.getElementById("input-resistenza").value;
    let mag = document.getElementById("input-mago").value;
    let cas = document.getElementById("select-casata").value;

    let ogg = {
        cod : uniqueNumber(),
        mat,
        nuc,
        lun,
        res,
        mag,
        cas,
    }

    let elenco = JSON.parse( localStorage.getItem('oggetti_olvd') );
    elenco.push(ogg);
    localStorage.setItem('oggetti_olvd', JSON.stringify(elenco));

    document.getElementById("input-codice").value = "";
    document.getElementById("input-materiale").value = "";
    document.getElementById("input-nucleo").value = "";
    document.getElementById("input-lunghezza").value = "";
    document.getElementById("input-resistenza").value = "";
    document.getElementById("input-mago").value = "";
    document.getElementById("select-casata").value = "";

    stampa();

    $("#modaleInserimento").modal("hide");
}

const elimina = (indice) => {
    let elenco = JSON.parse( localStorage.getItem('oggetti_olvd') );
    elenco.splice(indice, 1);
    localStorage.setItem('oggetti_olvd', JSON.stringify(elenco));

    stampa();
}

const modifica = (indice) => {

    let elenco = JSON.parse( localStorage.getItem('oggetti_olvd') );
    console.log(elenco[indice])

    document.getElementById("update-codice").value = elenco[indice].cod;
    document.getElementById("update-materiale").value = elenco[indice].mat;
    document.getElementById("update-nucleo").value = elenco[indice].nuc;
    document.getElementById("update-lunghezza").value = elenco[indice].lun;
    document.getElementById("update-resistenza").value = elenco[indice].res;
    document.getElementById("update-mago").value = elenco[indice].mag;
    document.getElementById("update-casata").value = elenco[indice].cas;

    $("#modaleModifica").data("identificativo", indice)

    $("#modaleModifica").modal("show");
}

const update = () => {
    
    let mat = document.getElementById("update-materiale").value;
    let nuc = document.getElementById("update-nucleo").value;
    let lun = document.getElementById("update-lunghezza").value;
    let res = document.getElementById("update-resistenza").value;
    let mag = document.getElementById("update-mago").value;
    let cas = document.getElementById("update-casata").value;

    let ogg = {
        cod : uniqueNumber(),
        mat,
        nuc,
        lun,
        res,
        mag,
        cas,
    }

    let indice = $("#modaleModifica").data("identificativo")

    let elenco = JSON.parse( localStorage.getItem('oggetti_olvd') );
    elenco[indice] = ogg;
    localStorage.setItem('oggetti_olvd', JSON.stringify(elenco));

    $("#modaleModifica").modal("hide");
}

let elencoString = localStorage.getItem('oggetti_olvd');
if(!elencoString)
    localStorage.setItem('oggetti_olvd', JSON.stringify([]) );

setInterval(() => {
    stampa(); 
}, 1000);

stampa();