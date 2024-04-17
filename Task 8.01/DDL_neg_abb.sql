USE task_neg_abb;

DROP TABLE IF EXISTS Ordine;
DROP TABLE IF EXISTS Galleria;
DROP TABLE IF EXISTS Prodotto;
DROP TABLE IF EXISTS Utente;
DROP TABLE IF EXISTS Prezzo_Offerta;
DROP TABLE IF EXISTS Prezzo_Pieno;
DROP TABLE IF EXISTS Categoria;

-- DDL
CREATE TABLE Categoria(
	categoriaID INT PRIMARY KEY IDENTITY(1,1),
	nome NVARCHAR(50) NOT NULL UNIQUE,
	descrizione TEXT
);

CREATE TABLE Prezzo_Pieno(
	prezzo_pienoID INT PRIMARY KEY IDENTITY(1,1),
	valore FLOAT NOT NULL,
);

CREATE TABLE Prezzo_Offerta(
	prezzo_offertaID INT PRIMARY KEY IDENTITY(1,1),
	valore FLOAT NOT NULL,
	data_inizio DATE NOT NULL,
	data_fine DATE NOT NULL,
);

CREATE TABLE Utente (
    utenteID INT PRIMARY KEY IDENTITY(1,1),
    nome NVARCHAR(100) NOT NULL,
    cognome NVARCHAR(100) NOT NULL ,
    mail NVARCHAR(100),
	codice_utente VARCHAR(50) NOT NULL UNIQUE,
	deleted DATETIME			-- SOFT DELETE
);
CREATE TABLE Prodotto (
    prodottoID INT PRIMARY KEY IDENTITY(1,1),
    isDisponibile BIT DEFAULT 1,
	quantita_prodotto INT NOT NULL,
	colore NVARCHAR(100) NOT NULL,
	taglia NVARCHAR (100) NOT NULL,
	categoriaRIF INT NOT NULL,
	prezzo_pienoRIF INT NOT NULL,
	prezzo_offertaRIF INT NOT NULL,
	FOREIGN KEY (categoriaRIF) REFERENCES Categoria(categoriaID),
	FOREIGN KEY (prezzo_pienoRIF) REFERENCES Prezzo_Pieno(prezzo_pienoID),
	FOREIGN KEY (prezzo_offertaRIF) REFERENCES Prezzo_Offerta(prezzo_offertaID),
	deleted DATETIME,
	codice_prodotto VARCHAR(50) NOT NULL UNIQUE

);
CREATE TABLE Galleria(
	galleriaID INT PRIMARY KEY IDENTITY(1,1),
	prodottoRIF INT NOT NULL,
	FOREIGN KEY (prodottoRIF) REFERENCES Prodotto(prodottoID),
	deleted DATETIME
);
CREATE TABLE Ordine (
    ordineID INT PRIMARY KEY IDENTITY(1,1),
    data_ordine DATE DEFAULT CURRENT_TIMESTAMP,
	quantita_prodotti INT NOT NULL,
	utenteRIF INT NOT NULL,
	prodottoRIF INT NOT NULL,
	FOREIGN KEY (utenteRIF) REFERENCES Utente(utenteID),
	FOREIGN KEY (prodottoRIF) REFERENCES Prodotto(prodottoID),
	deleted DATETIME
);
