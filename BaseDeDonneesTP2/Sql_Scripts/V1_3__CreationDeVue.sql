USE BaseDeDonnees_TP2
GO
/*VUE*/
/*Cr�ation d'une vue qui va s�lectionner toutes les unit�s ainsi que d'autres informations importante*/
CREATE VIEW Unites.vw_attributsDUnites AS
SELECT U.UniteID, F.Nom AS [Nom de faction], U.Nom AS [Nom de l'unit�], U.CoutEnPoint AS [Co�t en point], U.FactionID
FROM Factions.Faction F
INNER JOIN Unites.Unite U
ON U.FactionID = F.FactionID
GO
