insert into dbo.Members(FirstName, LastName, Email, Street, StreetNumber, City, PostalCode)
VALUES
('Lage', 'Hjärta', 'lage.heart@gmail.com', 'Jakobsgatan', 4, 'Örebro', 74321),
('Ann',	'Johansson', 'ann.johansson@viper.nu', 'Storgatan', 5, 'Norrköping', 43211),
('Nils', 'Dunder', 'nils.dunder@flashback.org', 'Drottninggatan', 32, 'Stockholm', 12366),
('Morfar', 'Svensson', 'morfar.svensson@norrland.se', 'Tjälstigen', 13, 'Övre Kågedalen', 43666),
('Carl', 'Bonde', 'carl.bonde@spray.se', 'Nygatan', 15, 'Flen', 33476)



insert into dbo.Boardgames(Title, Manufactor, Players, Duration, Difficulty)
VALUES
('Prepper', 'Ninja Print', '2-4', '60-90', 'Easy'),
('Texas Holdem', '200pcs', '2-6', '30-120', 'Medium'),
('Terraforming Mars', 'FryxGames', '1-5', '120+', 'Medium'),
('Journeys in Middle Earth', 'Fantasy Flight Games','1-5', '60+', 'Medium'),
('Axis & Allies: Europe 1940', 'Hasbro', '2-5', '240+',	'Hard'),
('Drakborgen', 'Alga', '2-4', '60+', 'Medium')

insert into dbo.Puzzles(Title, Theme, Manufactor, Bits, Difficulty)
VALUES
('Santa Claus is here!', 'Christmas', 'Schmidt', 1000, 'Medium'),
('Magical DragonForest', 'Fantasy', 'Ravensburger',	9000, 'Hard'),
('Sagohuset', 'Fantasy', 'Tildas', 1000, 'Medium'),
('Grävmaskin', 'Children', 'Kärnan', 12, 'Easy'),
('Wild Life', 'Nature',	'Educa', 33600,	'Very Hard'),
('Amsterdam', 'City', 'Schmidt', 500,	'Medium')