USE PetStore

SELECT
	s.Name,
	(SELECT COUNT(*) 
	FROM Products p 
	JOIN SpeciesProducts sp
		ON p.Id = sp.ProductId AND sp.SpeciesId = s.Id) AS [ProductCount]
FROM Species s
ORDER BY [ProductCount]