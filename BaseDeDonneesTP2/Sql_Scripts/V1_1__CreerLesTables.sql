GO

USE BaseDeDonnees_TP2;

GO

CREATE SCHEMA Unites;

GO

CREATE SCHEMA Factions;

GO 

CREATE SCHEMA Armes;

GO

CREATE SCHEMA Modeles;

GO

CREATE SCHEMA Abilites;

GO

CREATE TABLE Factions.Faction(
	FactionID int IDENTITY(1,1),
	Nom nvarchar(30),
	CONSTRAINT PK_Faction_FactionID PRIMARY KEY (FactionID),
);

GO

CREATE TABLE Unites.Unite(
	UniteID int IDENTITY(1,1),
	FactionID int,
	Nom nvarchar(30),
	CoutEnPoint int,
	CONSTRAINT PK_Unite_UniteID PRIMARY KEY (UniteID),
);

GO

CREATE TABLE Armes.Arme(
	ArmeID int IDENTITY(1,1),
	Nom nvarchar(30),
	Attaques int,
	Force int,
	PenetrationDArmure int,
	Degats int
	CONSTRAINT PK_Arme_ArmeID PRIMARY KEY (ArmeID),
);

GO

CREATE TABLE Modeles.Modele(
	ModeleID int IDENTITY(1,1),
	Nom nvarchar(30),
	Endurance int,
	Pv int,
	Mouvement int,
	Commandement int,
	Sauvegarde int,
	Co int,
	CONSTRAINT PK_Modele_ModeleID PRIMARY KEY (ModeleID)
);

GO

CREATE TABLE Abilites.Abilite(
	AbiliteID int IDENTITY(1,1),
	Nom nvarchar(30),
	Description nvarchar(1000),
	CONSTRAINT PK_Abilite_AbiliteID PRIMARY KEY (AbiliteID)
);

GO

CREATE TABLE Unites.ModeleDansUnite(
	ModeleDansUniteID int IDENTITY(1,1),
	UniteID int,
	ModeleID int,
	NbModele int,
	CONSTRAINT PK_ModeleDansUnite_ModeleDansUniteID PRIMARY KEY (ModeleDansUniteID),
);

GO

CREATE TABLE Modeles.ArmeDeModele(
	ArmeDeModeleID int IDENTITY(1,1),
	ModeleID int,
	ArmeID int,
	CONSTRAINT PK_ArmeDeModele_ArmeDeModeleID PRIMARY KEY (ArmeDeModeleID),
);

GO

CREATE TABLE Armes.ArmeDistance(
	ArmeDistanceID int IDENTITY(1,1),
	ArmeID int,
	Porte int,
	AbiliteDeTire int,
	CONSTRAINT PK_ArmeDistance_ArmeDistanceID PRIMARY KEY (ArmeDistanceID)
);

GO

CREATE TABLE Armes.ArmeRapproche(
	ArmeRapprocheID int IDENTITY(1,1),
	ArmeID int,
	AbiliteDeFrappe int,
	CONSTRAINT PK_ArmeRapproche_ArmeRapprocheID PRIMARY KEY (ArmeRapprocheID)
);

GO

CREATE TABLE Unites.AbiliteDUnite(
	AbiliteDUniteID int IDENTITY(1,1),
	AbiliteID int,
	UniteID int,
	CONSTRAINT PK_AbiliteDUnite_AbiliteDUniteID PRIMARY KEY (AbiliteDUniteID)
);

GO

--Contraintes

ALTER TABLE  Unites.Unite ADD CONSTRAINT FK_Unite_FactionID FOREIGN KEY (FactionID) REFERENCES Factions.Faction(FactionID);

GO

ALTER TABLE Unites.ModeleDansUnite ADD CONSTRAINT FK_ModeleDansUnite_UniteID FOREIGN KEY (UniteID) REFERENCES Unites.Unite(UniteID) ON DELETE CASCADE;
ALTER TABLE Unites.ModeleDansUnite ADD CONSTRAINT FK_ModeleDansUnite_ModeleID FOREIGN KEY (ModeleID) REFERENCES Modeles.Modele(ModeleID) ON DELETE CASCADE;

GO

ALTER TABLE Modeles.ArmeDeModele ADD CONSTRAINT FK_ArmeeDeModele_ArmeID FOREIGN KEY (ArmeID) REFERENCES Armes.Arme(ArmeID) ON DELETE CASCADE;
ALTER TABLE Modeles.ArmeDeModele ADD CONSTRAINT FK_ModeleDansUnite_ModeleID FOREIGN KEY (ModeleID) REFERENCES Modeles.Modele(ModeleID) ON DELETE CASCADE;

GO

ALTER TABLE Armes.ArmeRapproche ADD CONSTRAINT FK_ArmeRapproche_ArmeID FOREIGN KEY (ArmeID) REFERENCES Armes.Arme(ArmeID) ON DELETE CASCADE;

GO

ALTER TABLE Armes.ArmeDistance ADD CONSTRAINT FK_ArmeDistance_ArmeID FOREIGN KEY (ArmeID) REFERENCES Armes.Arme(ArmeID) ON DELETE CASCADE;

GO

ALTER TABLE Unites.AbiliteDUnite ADD CONSTRAINT FK_AbiliteDUnite_AbiliteID FOREIGN KEY (AbiliteID) REFERENCES Abilites.Abilite(AbiliteID) ON DELETE CASCADE;
ALTER TABLE Unites.AbiliteDUnite ADD CONSTRAINT FK_AbiliteDUnite_UniteID FOREIGN KEY (UniteID) REFERENCES Unites.Unite(UniteID) ON DELETE CASCADE;

GO