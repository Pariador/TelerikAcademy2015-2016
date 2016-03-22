USE PetStore

GO 
CREATE PROC usp_SeedColors
AS
BEGIN
	DECLARE @colorsCount INT = (SELECT COUNT(*) FROM Colors)

	IF (@colorsCount = 0)
	BEGIN
		INSERT INTO Colors VALUES
		('black'),
		('white'),
		('red'),
		('mixed')
	END
END

GO
DELETE FROM Colors
EXEC usp_SeedColors
SELECT * FROM Colors