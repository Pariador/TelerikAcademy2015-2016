--19. Write SQL statements to insert several records in the Users and Groups tables.

USE TelerikAcademy

GO
INSERT INTO Groups VALUES
('Superheroes'),
('Jedi'),
('Sith')

GO
INSERT INTO Users VALUES
('Johnny123', 'adadaf31das', 'Lae Doz', GETDATE(), 'Superheroes'),
('Masazra', 'adbj1krdf', 'Maz Koerz', GETDATE(), 'Jedi'),
('Monoaz', 'bfvhiujeriowguiw', 'Ajaharad Smith', GETDATE(), 'Sith')

GO
SELECT u.Username, g.Name
FROM Users u
JOIN Groups g
	ON u.GroupName = g.Name