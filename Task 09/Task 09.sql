USE acc_task09;

DROP TABLE IF EXISTS Citta;
DROP TABLE IF EXISTS Provincia;
DROP TABLE IF EXISTS Reparto;
DROP TABLE IF EXISTS Impiegato;

CREATE TABLE Impiegato(
impiegatoID INT PRIMARY KEY IDENTITY (1,1),
matricola INT UNIQUE,
nome VARCHAR(250),
cognome VARCHAR(250),
data_nascita DATE,
ruolo VARCHAR(250),
indirizzo VARCHAR(250)
);

CREATE TABLE Reparto(
repartoID INT PRIMARY KEY IDENTITY (1,1),
nome VARCHAR(250),
);

CREATE TABLE Provincia(
provinciaID INT PRIMARY KEY IDENTITY (1,1),
sigla VARCHAR(3) NOT NULL,
nome VARCHAR(250) NOT NULL
);

CREATE TABLE Citta(
cittaID INT PRIMARY KEY IDENTITY (1,1),
nome VARCHAR(250) NOT NULL,
provinciaRIF INT NOT NULL,
FOREIGN KEY (provinciaRIF) REFERENCES PROVINCIA(provinciaID) ON DELETE CASCADE
);


INSERT INTO Provincia(sigla,nome) VALUES
('RM','Roma'),
('MI','Milano'),
('BO','Bologna'),
('TO','Torino'),
('FI','Firenze');

INSERT INTO Citta(nome,provinciaRIF) VALUES
('Roma', 1),
('Torino', 4),
('Firenze', 5);

INSERT INTO Impiegato (matricola, nome, cognome, data_nascita, ruolo, indirizzo) VALUES
('111', 'Mario', 'Rossi', '1980-05-10', 'Manager', 'Via Roma 1'),
('222', 'Giuseppe', 'Bianchi', '1985-05-20', 'Analista', 'Via Milano 1'),
('333', 'Antonio', 'Verdi', '1990-05-25', 'Sviluppatore', 'Via Firenze 1');

SELECT * FROM Impiegato