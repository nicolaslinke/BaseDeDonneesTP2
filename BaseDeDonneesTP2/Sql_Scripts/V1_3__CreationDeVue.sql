USE BaseDeDonnees_TP2
GO
/*VUE*/
/*Cr�ation d'une vue qui va s�lectionner toutes les unit�s ainsi que d'autres informations importante*/
CREATE VIEW Unites.vw_attributsDUnites AS
SELECT U.UniteID, F.Nom AS [Nom de faction], U.Nom AS [Nom de l'unit�], U.CoutEnPoint AS [Co�t en point], SUM(MU.NbModele) AS [Nombre de mod�le], U.FactionID
FROM Unites.Unite U
INNER JOIN Unites.ModeleDansUnite MU
ON U.UniteID = MU.UniteID
INNER JOIN Modeles.Modele M
ON M.ModeleID = MU.ModeleID
INNER JOIN Factions.Faction F
ON U.FactionID = F.FactionID
GROUP BY U.UniteID

GO
