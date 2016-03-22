USE PetStore

SELECT Price, Breed, BirthDate
FROM Pets
WHERE BirthDate >= '2012-01-01'
ORDER BY Price DESC