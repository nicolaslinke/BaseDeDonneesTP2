USE BaseDeDonnees_TP2
GO
/*VUE*/
/*Création d'une vue qui va sélectionner toutes les unités ainsi que d'autres informations importante*/
CREATE VIEW Unites.vw_attributsDUnites AS
SELECT U.UniteID, F.Nom AS [Nom de faction], U.Nom AS [Nom de l'unité], U.CoutEnPoint AS [Coût en point], U.FactionID
FROM Factions.Faction F
INNER JOIN Unites.Unite U
ON U.FactionID = F.FactionID
GO
