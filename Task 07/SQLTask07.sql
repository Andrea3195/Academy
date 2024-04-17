USE acc_task07

DROP TABLE IF EXISTS Prodotto

CREATE TABLE Prodotto(
	prodottoID INT PRIMARY KEY IDENTITY(1,1),
	codice VARCHAR(250) NOT NULL,
	nome VARCHAR(250) NOT NULL,
	descrizione VARCHAR(250),
	prezzo DECIMAL(10, 2) NOT NULL,
	quantita INT CHECK (quantita >= 0),
	categoria VARCHAR(250) NOT NULL CHECK (Categoria IN ('Bricolage', 'Idraulica', 'Fissaggi', 'Saldatura', 'Coperture')),
	data_cre DATE
);