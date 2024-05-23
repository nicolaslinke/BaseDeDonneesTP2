USE BaseDeDonnees_TP2
GO

CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'P4assw0rd!2P4assw0rd!2P4assw0rd!2'
GO

CREATE CERTIFICATE MyCertificate WITH SUBJECT = 'AbilitesChiffrement'
GO

CREATE SYMMETRIC KEY MaSuperCle WITH ALGORITHM = AES_256 ENCRYPTION BY CERTIFICATE MyCertificate
GO

ALTER TABLE Abilites.Abilite ADD DescriptionEncrypt varbinary(max);
GO

OPEN SYMMETRIC KEY MaSuperCle
	DECRYPTION BY CERTIFICATE MyCertificate

UPDATE Abilites.Abilite
SET DescriptionEncrypt = EncryptByKey(KEY_GUID('MaSuperCle'), Description);

CLOSE SYMMETRIC KEY MaSuperCle
GO

ALTER TABLE Abilites.Abilite
DROP COLUMN Description;
GO

CREATE PROCEDURE Abilites.USP_DecryptDescription
	@AbiliteID int
AS
BEGIN
	OPEN SYMMETRIC KEY MaSuperCle DECRYPTION BY CERTIFICATE MyCertificate;

	SELECT CONVERT (nvarchar(max), DecryptByKey(DescriptionEncrypt)) AS Description FROM Abilites.Abilite WHERE AbiliteID=@AbiliteID

	CLOSE SYMMETRIC KEY MaSuperCle
END
GO

CREATE TABLE Abilites.Description(Description nvarchar(max))