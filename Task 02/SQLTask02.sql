CREATE TABLE Albergo(
	albergoID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	indirizzo VARCHAR(250) NOT NULL,
	valutazione VARCHAR(250) NOT NULL CHECK (VALUTAZIONE BETWEEN '1' AND '5')
);

CREATE TABLE Camera(
	cameraID INT PRIMARY KEY IDENTITY(1,1),
	numeroUnico VARCHAR(250) NOT NULL UNIQUE,
	tipo VARCHAR(250) NOT NULL CHECK (tipo IN ('Singola','Doppia','Suite')),
	capacitaMax INT NOT NULL,
	tariffa DECIMAL (5,2) NOT NULL,
	albergoRIF INT NOT NULL,
	FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID) ON DELETE CASCADE
);

CREATE TABLE Cliente(
	clienteID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	contatto VARCHAR(250) NOT NULL
);

CREATE TABLE Prenotazione(
	prenotazioneID INT PRIMARY KEY IDENTITY(1,1),
	checkin DATE NOT NULL,
	checkout DATE NOT NULL,
	cameraRIF INT NOT NULL,
	clienteRIF INT NOT NULL,
	FOREIGN KEY (cameraRIF) REFERENCES Camera(cameraID) ON DELETE CASCADE,
	FOREIGN KEY (clienteRIF) REFERENCES Cliente(clienteID) ON DELETE CASCADE,
	UNIQUE (checkin, checkout, cameraRIF, clienteRIF)
);

CREATE TABLE Dipendente(
	dipendenteID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	posizione VARCHAR(250) NOT NULL CHECK (posizione IN ('Receptionist','Pulizie','Manager')),
	contatto VARCHAR(250) NOT NULL,
	albergoRIF INT NOT NULL,
	FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID) ON DELETE CASCADE
);

CREATE TABLE Facility(
	facilityID INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL CHECK (nome IN ('Palestra','Piscina','SPA')),
	descrizione VARCHAR(250) NOT NULL,
	orari TIME NOT NULL,
	albergoRIF INT NOT NULL,
	FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID) ON DELETE CASCADE
);

INSERT INTO Albergo(nome, indirizzo, valutazione) VALUES
('Hotel Dei Fiori', 'Via Dei Platani, 15, Roma, Italia', '4'),
('Hotel Amazzonia', 'Via Dei Colombi, 16, Milano, Italia', '3'),
('Hotel Sunset', 'Via Delle Calendule, 17, Torino, Italia', '4'),
('Grand Hotel Magnificent', 'Via Dei Marmi, 18, Roma, Italia', '5');

INSERT INTO Camera(numeroUnico, tipo, capacitaMax, tariffa, albergoRIF) VALUES
('110', 'Doppia', 2, 200, 3),
('111', 'Suite', 4, 350, 2),
('112', 'Suite', 4, 350, 1),
('113', 'Singola', 1, 150, 1),
('114', 'Doppia', 2, 200, 1),
('115', 'Singola', 1, 150, 2),
('116', 'Singola', 1, 150, 3),
('117', 'Suite', 4, 350, 2),
('118', 'Doppia', 2, 200, 3),
('119', 'Singola', 1, 150, 1);

INSERT INTO Cliente(nome, cognome, contatto) VALUES
('Mario', 'Rossi', '333 1234567'),
('Roberto', 'Verdi', '345 2345678'),
('Gianluca', 'Cuomolo', '333 3456789'),
('Lino', 'Esposito', '345 4567890'),
('Davide', 'Di Felice', '333 5678901'),
('Gianni', 'Bianco', '345 6789012'),
('Mario', 'Dimoli', '345 8901234');

INSERT INTO Prenotazione(checkin, checkout, cameraRIF, clienteRIF) VALUES
('2024-04-11', '2024-04-15', 3, 1),
('2024-04-13', '2024-04-20', 6, 2),
('2024-04-17', '2024-04-24', 5, 3),
('2024-05-22', '2024-05-26', 2, 4),
('2024-05-27', '2024-05-30', 4, 5),
('2024-06-05', '2024-06-11', 1, 6),
('2024-06-16', '2024-06-19', 2, 7);

INSERT INTO Dipendente(nome, cognome, posizione, contatto, albergoRIF) VALUES
('Guido', 'Longhi', 'Manager', '333 2345876', 1),
('Giada', 'Buritti', 'Pulizie', '345 1234765', 2),
('Alessia', 'Fondi', 'Receptionist', '339 3456789', 1),
('Luigi', 'Carvi', 'Pulizie', '338 7689435', 2),
('Marco', 'Rosci', 'Receptionist', '339 2354336', 2),
('Maria', 'Nanni', 'Receptionist', '345 5674239', 3),
('Carlo', 'Mori', 'Manager', '333 3425678', 3);

INSERT INTO Facility(nome, descrizione, orari, albergoRIF) VALUES
('Palestra', 'La palestra è attrezzata per il sollevamento pesi e contiene varie sale per le attività di cardio.', 'Lun-Ven 8:00-18:00, Sab-Dom 9:00-19:00', 2),
('Piscina', 'La piscina ha una vasca olimpionica ed una per bambini e prevede lezioni per i neofiti.', 'Lun-Ven 8:00-18:00, Sab-Dom 9:00-19:00', 3),
('Spa', 'La spa è molto ampia e contiene vasche idromassaggio, sauna, bagno turco e postazioni da massaggio.', 'Lun-Ven 8:00-18:00, Sab-Dom 9:00-19:00', 1);

SELECT * FROM Albergo
SELECT * FROM Camera
SELECT * FROM Cliente
SELECT * FROM Dipendente