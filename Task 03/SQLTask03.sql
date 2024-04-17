DROP TABLE IF EXISTS Employee
DROP TABLE IF EXISTS Review
DROP TABLE IF EXISTS Ticket
DROP TABLE IF EXISTS Customer
DROP TABLE IF EXISTS Showtime
DROP TABLE IF EXISTS Movie
DROP TABLE IF EXISTS Theater
DROP TABLE IF EXISTS Cinema

CREATE TABLE Cinema (
CinemaID INT PRIMARY KEY,
Name VARCHAR(100) NOT NULL,
Address VARCHAR(255) NOT NULL,
Phone VARCHAR(20)
);

CREATE TABLE Theater (
TheaterID INT PRIMARY KEY,
CinemaID INT,
Name VARCHAR(50) NOT NULL,
Capacity INT NOT NULL,
ScreenType VARCHAR(50),
FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
);

CREATE TABLE Movie (
MovieID INT PRIMARY KEY,
Title VARCHAR(255) NOT NULL,
Director VARCHAR(100),
ReleaseDate DATE,
DurationMinutes INT,
Rating VARCHAR(5)
);

CREATE TABLE Showtime (
ShowtimeID INT PRIMARY KEY,
MovieID INT,
TheaterID INT,
ShowDateTime DATETIME NOT NULL,
Price DECIMAL(5,2) NOT NULL,
FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
FOREIGN KEY (TheaterID) REFERENCES Theater(TheaterID)
);

CREATE TABLE Customer (
CustomerID INT PRIMARY KEY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Email VARCHAR(100),
PhoneNumber VARCHAR(20)
);

CREATE TABLE Ticket (
TicketID INT PRIMARY KEY,
ShowtimeID INT,
SeatNumber VARCHAR(10) NOT NULL,
PurchasedDateTime DATETIME NOT NULL,
CustomerID INT,
FOREIGN KEY (ShowtimeID) REFERENCES Showtime(ShowtimeID),
FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE Review (
ReviewID INT PRIMARY KEY,
MovieID INT,
CustomerID INT,
ReviewText TEXT,
Rating INT CHECK (Rating >= 1 AND Rating <= 5),
ReviewDate DATETIME NOT NULL,
FOREIGN KEY (MovieID) REFERENCES Movie(MovieID),
FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID)
);

CREATE TABLE Employee (
EmployeeID INT PRIMARY KEY,
CinemaID INT,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Position VARCHAR(50),
HireDate DATE,
FOREIGN KEY (CinemaID) REFERENCES Cinema(CinemaID)
);

INSERT INTO Cinema (CinemaID, Name, Address, Phone) VALUES
(1, 'Cinema Broadway', 'Via Dei Lauri 123', '06 1234567'),
(2, 'Cinema Tristar', 'Via Dei Gelsi 124', '06 4567891'),
(3, 'Cinema Adriano', 'Via Cavour 125', '06 2378359');
 
INSERT INTO Theater (TheaterID, CinemaID, Name, Capacity, ScreenType) VALUES
(1, 3, 'Sala 1', 120, '3D'),
(2, 1, 'Sala 2', 75, '2D'),
(3, 2, 'Sala 3', 200, 'IMAX');
 
INSERT INTO Movie (MovieID, Title, Director, ReleaseDate, DurationMinutes, Rating) VALUES
(1, 'Matrix', 'Andy & Larry Wachowski', '1999-05-20', 136, 'R'),
(2, 'Ritorno Al Futuro', 'Robert Zemeckis', '1985-04-19', 92, 'PG'),
(3, 'Alien', 'Ridley Scott', '1979-03-18', 117, 'R');
 
INSERT INTO Showtime (ShowtimeID, MovieID, TheaterID, ShowDateTime, Price) VALUES
(1, 1, 1, '2024-04-15 16:00:00', 13.00),
(2, 2, 3, '2024-04-16 21:00:00', 11.00),
(3, 3, 2, '2024-04-17 18:30:00', 14.00);
 
INSERT INTO Customer (CustomerID, FirstName, LastName, Email, PhoneNumber) VALUES
(1, 'Mario', 'Rossi', 'mario.rossi@gmail.com', '3392345678'),
(2, 'Luigi', 'Verdi', 'luigi.verdi@gmail.com', '3336789123'),
(3, 'Gianni', 'Bianchi', 'gianni.bianchi@gmail.com', '334128945');
 
INSERT INTO Ticket (TicketID, ShowtimeID, SeatNumber, PurchasedDateTime, CustomerID) VALUES
(1, 1, 'A10', '2024-04-14 16:30:00', 1),
(2, 2, 'B16', '2024-04-15 20:00:00', 2),
(3, 3, 'C4', '2024-04-16 19:30:00', 3);
 
INSERT INTO Review (ReviewID, MovieID, CustomerID, ReviewText, Rating, ReviewDate) VALUES
(1, 1, 1, 'Film incredibile!', 5, '2024-04-14 19:00:00'),
(2, 2, 2, 'Film davvero bellissimo!', 5, '2024-04-15 22:30:00'),
(3, 3, 3, 'Il film dell''anno!', 5, '2024-04-16 20:45:00');
 
INSERT INTO Employee (EmployeeID, CinemaID, FirstName, LastName, Position, HireDate) VALUES
(1, 1, 'Michele', 'Frulli', 'Manager', '2019-03-11'),
(2, 2, 'Giovanni', 'Fralli', 'Cassiere', '2020-04-12'),
(3, 3, 'Davide', 'Frolli', 'Pulizie', '2021-05-13');

-- VIEWS

CREATE VIEW FilmsInProgrammation AS
	SELECT Movie.Title, Movie.ReleaseDate, Movie.DurationMinutes, Movie.Rating
	FROM Movie
	
SELECT * FROM FilmsInProgrammation


CREATE VIEW AvailableSeatsForShow AS
	SELECT Theater.Capacity AS 'Posti Totali', (Theater.Capacity - COUNT(Ticket.TicketID)) AS 'Posti Disponibili'
	FROM Showtime
	JOIN Ticket ON Showtime.ShowtimeID = Ticket.ShowtimeID
	JOIN Theater ON Ticket.TicketID = Theater.TheaterID
	GROUP BY Theater.Capacity

SELECT * FROM AvailableSeatsForShow;


CREATE VIEW TotalEarningsPerMovie AS
	SELECT Title, SUM(Price) AS 'Prezzo Totale'
	FROM Movie
	JOIN Showtime ON Movie.MovieID = Showtime.MovieID
	GROUP BY Title

SELECT * FROM TotalEarningsPerMovie;


CREATE VIEW RecentReviews AS
	SELECT Review.ReviewText, Movie.Title, Review.Rating, Review.ReviewDate
	FROM Review
	JOIN Movie ON Review.MovieID = Movie.MovieID
	ORDER BY Review.ReviewDate DESC

SELECT * FROM RecentReviews

-- SP

DROP PROCEDURE IF EXISTS PurchaseTicket
CREATE PROCEDURE PurchaseTicket
    @TicketID INT,
    @ShowTimeID INT,
    @SeatNumber VARCHAR(10),
    @CustomerID INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
			DECLARE @Count INT
			SELECT @Count = COUNT(*)
			FROM Ticket
			WHERE SeatNumber = @SeatNumber

			IF @Count = 0
				BEGIN
					INSERT INTO Ticket (TicketID, ShowtimeID, SeatNumber, PurchasedDateTime, CustomerID)
					VALUES (@TicketID, @ShowTimeID, @SeatNumber, CURRENT_TIMESTAMP, @CustomerID)
					PRINT 'Biglietto acquistato'
				END
			ELSE
				BEGIN
					PRINT 'Posto non disponibile!'
				END
        COMMIT TRANSACTION
    END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			PRINT 'Si è verificato un errore: ' + ERROR_MESSAGE()
		END CATCH
END;

EXEC PurchaseTicket
		@TicketID = 3,
		@ShowTimeID = 2,
		@SeatNumber = 'C8',
		@CustomerID = 1


DROP PROCEDURE IF EXISTS UpdateMovieSchedule
CREATE PROCEDURE UpdateMovieSchedule
    @MovieID INT,
    @ShowDateTime DATETIME = NULL,
    @RemoveShowtime INT = 0
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
			IF @ShowDateTime IS NOT NULL
				BEGIN
					UPDATE Showtime
					SET ShowDateTime = @ShowDateTime
					WHERE MovieID = @MovieID
					PRINT 'Orari degli spettacoli aggiornati!'
				END
			ELSE
				BEGIN
					IF @RemoveShowtime = 1
						BEGIN
							DELETE FROM Ticket
							WHERE ShowtimeID IN (SELECT ShowtimeID FROM Showtime WHERE MovieID = @MovieID)

							DELETE FROM Showtime WHERE MovieID = @MovieID
							PRINT 'Spettacoli eliminati!'
						END
					ELSE
						BEGIN
							PRINT 'Nessuna modifica effettuata'
						END
				END
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Si è verificato un errore: ' + ERROR_MESSAGE()
    END CATCH
END;

EXEC UpdateMovieSchedule
		@RemoveShowTime = 3,
		@MovieID = 3,
		@ShowDateTime = '2024-04-15 20:30:00'


DROP PROCEDURE IF EXISTS InsertNewMovie
CREATE PROCEDURE InsertNewMovie 
    @Title VARCHAR(255),
    @Director VARCHAR(100),
    @ReleaseDate DATE = NULL,
    @DurationMinutes INT,
    @Rating VARCHAR(5)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION
			DECLARE @NewMovieID INT = 1
			WHILE EXISTS (SELECT * FROM Movie WHERE MovieID = @NewMovieID)
			BEGIN
				SET @NewMovieID = @NewMovieID + 1
			END
			INSERT INTO Movie (MovieID, Title, Director, ReleaseDate, DurationMinutes, Rating)
			VALUES (@NewMovieID, @Title, @Director, @ReleaseDate, @DurationMinutes, @Rating)
        COMMIT TRANSACTION
        PRINT 'Nuovo film inserito!'
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        PRINT 'Si è verificato un errore:' + ERROR_MESSAGE()
    END CATCH
END;

EXEC InsertNewMovie
    @Title = 'Aliens: Scontro Finale',
    @Director = 'Ridley Scott',
    @ReleaseDate = '1986-06-18',
    @DurationMinutes = 137,
    @Rating = 'R'