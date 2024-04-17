const stampaTabella = () => {
    $.ajax(
        {
            url: "https://localhost:7071/api/prodotti",
            type: "GET",
            success: function(risultato){
                let contenuto = "";

                for(let [idx, item] of risultato.entries()){
                    contenuto += `
                        <tr>
                            <td>${item.nome}</td>
                            <td>${item.descrizione}</td>
                            <td>${item.prezzo}</td>
                            <td>${item.quantita}</td>
                            <td>${item.categoria}</td>
                            <td>
                                <button class="btn btn-danger" onclick="elimina('${item.codice}')">Elimina</button>
                            </td>
                        </tr>
                    `;
                }

                $("#corpo-tabella").html(contenuto);
            }, 
            error: function(errore){
                alert("Errore");
                console.log(errore)
            }
        }
    );
}

const elimina = (codice) => {
    
    $.ajax(
        {
            url: "https://localhost:7071/api/prodotti/codice/" + codice,
            type: "POST",
            success: function(){
                alert("Successo");
                stampaTabella();
            },
            error: function(errore){
                alert("Errore");
                console.log(errore);
            }
        }
    )

}

const salvaElemento = () => {
    let nom = $("#input-nome").val();
    let des = $("#input-descrizione").val();
    let prz = $("#input-prezzo").val();
    let qnt = $("#input-quantita").val();
    let cat = $("#input-categoria").val();

    $.ajax(
        {
            url: "https://localhost:7071/api/prodotti",
            type: "POST",
            data: JSON.stringify({
                nome: nom,
                descrizione: des,
                prezzo: prz,
                quantita: qnt,
                categoria: cat
            }),
            contentType: "application/json",
            dataType: "json",
            success: function(){
                alert("Successo");
                stampaTabella();
            },
            error: function(errore){
                alert("Errore");
                console.log(errore);
            }
        
        }
    )
}

$(document).ready(
    function(){

        stampaTabella();

        $(".salva").on("click", () => {
            salvaElemento();
        })
    }
);