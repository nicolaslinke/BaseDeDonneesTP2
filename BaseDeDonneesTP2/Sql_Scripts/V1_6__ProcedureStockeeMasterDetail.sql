USE BaseDeDonnees_TP2
GO

CREATE VIEW Unites.vw_dataSheet AS
SELECT U.UniteID, U.Nom [NomUnite], U.CoutEnPoint, MU.NbModele, M.Nom as [NomModele], M.Mouvement, M.Endurance, M.Sauvegarde, M.Pv, M.Commandement, M.Co as [ControleObjectif], U.Photo
	FROM Unites.Unite U
	INNER JOIN Unites.ModeleDansUnite MU
	ON U.UniteID = MU.UniteID
	INNER JOIN Modeles.Modele M
	ON M.ModeleID = MU.ModeleID

GO

CREATE PROCEDURE Unites.usp_dataSheet
(@UniteID int)
AS
BEGIN
	SELECT U.UniteID, U.Nom [NomUnite], U.CoutEnPoint, MU.NbModele, M.Nom as [NomModele], M.Mouvement, M.Endurance, M.Sauvegarde, M.Pv, M.Commandement, M.Co as [ControleObjectif], U.Photo
	FROM Unites.Unite U
	INNER JOIN Unites.ModeleDansUnite MU
	ON U.UniteID = MU.UniteID
	INNER JOIN Modeles.Modele M
	ON M.ModeleID = MU.ModeleID
	WHERE U.UniteID = @uniteID
END

GO

CREATE PROCEDURE Unites.usp_armeDistance
(@UniteID int)
AS
BEGIN
	SELECT M.Nom AS [NomModele], A.Nom AS [NomArme], AD.Porte AS [Portee], A.Attaques, AD.AbiliteDeTire, A.Force, A.PenetrationDArmure, A.Degats
	FROM Unites.Unite U
	INNER JOIN Unites.ModeleDansUnite MU
	ON U.UniteID = MU.UniteID
	INNER JOIN Modeles.Modele M
	ON M.ModeleID = MU.ModeleID
	INNER JOIN Modeles.ArmeDeModele AM
	ON M.ModeleID = AM.ModeleID
	INNER JOIN Armes.Arme A
	ON AM.ArmeID = A.ArmeID
	INNER JOIN Armes.ArmeDistance AD
	ON A.ArmeID = AD.ArmeID
	WHERE U.UniteID = @uniteID
	ORDER BY M.Nom
END

GO 

CREATE PROCEDURE Unites.usp_armeRapproche
(@UniteID int)
AS
BEGIN
	SELECT M.Nom AS [NomModele], A.Nom AS [NomArme], A.Attaques, AR.AbiliteDeFrappe, A.Force, A.PenetrationDArmure, A.Degats
	FROM Unites.Unite U
	INNER JOIN Unites.ModeleDansUnite MU
	ON U.UniteID = MU.UniteID
	INNER JOIN Modeles.Modele M
	ON M.ModeleID = MU.ModeleID
	INNER JOIN Modeles.ArmeDeModele AM
	ON M.ModeleID = AM.ModeleID
	INNER JOIN Armes.Arme A
	ON AM.ArmeID = A.ArmeID
	INNER JOIN Armes.ArmeRapproche AR
	ON A.ArmeID = AR.ArmeID
	WHERE U.UniteID = @uniteID
	ORDER BY M.Nom
END

GO