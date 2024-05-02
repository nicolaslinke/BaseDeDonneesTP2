USE BaseDeDonnees_TP2
GO
/*VUE*/
/*Création d'une vue qui va sélectionner toutes les unités ainsi que d'autres informations importante*/
CREATE VIEW Unites.vw_attributsDUnites AS
SELECT U.UniteID, F.Nom AS [Nom de faction], U.Nom AS [Nom de l'unité], U.CoutEnPoint AS [Coût en point], SUM(MU.NbModele) AS [Nombre de modèle], U.FactionID
FROM Unites.Unite U
INNER JOIN Unites.ModeleDansUnite MU
ON U.UniteID = MU.UniteID
INNER JOIN Modeles.Modele M
ON M.ModeleID = MU.ModeleID
INNER JOIN Factions.Faction F
ON U.FactionID = F.FactionID
GROUP BY U.UniteID

GO
