
USE BaseDeDonnees_TP2
GO


ALTER TABLE Unites.Unite ADD
Identifiant uniqueidentifier NOT NULL ROWGUIDCOL DEFAULT newid();
GO

ALTER TABLE Unites.Unite ADD CONSTRAINT UC_Unite_Identifiant
UNIQUE (Identifiant);
GO

ALTER TABLE Unites.Unite ADD
Photo varbinary(max) FILESTREAM NULL;
GO