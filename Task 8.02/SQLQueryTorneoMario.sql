USE DB_torneo_mario;

DROP TABLE IF EXISTS Personaggio;
DROP TABLE IF EXISTS Squadra;

CREATE TABLE Squadra(
	squadraID INT PRIMARY KEY IDENTITY(1,1),
	codiceS VARCHAR(250),
	nomeS VARCHAR(250) NOT NULL UNIQUE,
	budget INT NOT NULL 
);

CREATE TABLE Personaggio(
	personaggioID INT PRIMARY KEY IDENTITY (1,1),
	codiceP VARCHAR(250),
	nomeP VARCHAR(250) NOT NULL UNIQUE,
	categoria VARCHAR(250) NOT NULL,
	crediti INT,
	squadraRIF INT,
	FOREIGN KEY (squadraRIF) REFERENCES Squadra(squadraID) ON DELETE SET NULL
);


INSERT INTO Squadra(nomeS, budget) VALUES
('x', 10),
('y', 10),
('z', 10);

INSERT INTO Personaggio(nomeP, categoria, crediti, squadraRIF) VALUES
('Mario', '50cc', 2, 1),
('Bowser', '100cc', 3, 2),
('Wario', '150cc', 4, 3);

SELECT * FROM Squadra
	JOIN Personaggio ON Squadra.squadraID=Personaggio.squadraRIF; 
