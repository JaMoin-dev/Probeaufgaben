# Vertragserfüllung

## Anwendungsfall
- in Einkaufsverträgen werden Stromlieferungen fürs nächste Jahr vereinbart.
- Strom kann verschiedene Qualitätsmerkmale haben (Windkraft, Wasserkraft, Fischtreppe, etc)
- Im Jahresverlauf wird Strom eingeliefert. 
- Am Ende des Jahres wird geprüft, ob der gelieferte Strom den vertraglichen Vereinbarungen entsprach
  - diese Prüfung ist Gegenstand dieser Aufgabe!

## Beispiel
- Vertraglich vereinbart: 
  - 100MWh Wasserkraft
  - 100MWh Windkraft
  - 100MWh Wasserkraft mit Fischtreppe

- Eingeliefert
  - 150MWh Wasserkraft mit Fischtreppe
  - 50MWh Wasserkraft
  - 100MWh Windkraft

- Diese Einlieferung erfüllt die vertraglichen Vereinbarungen, denn höhere Qualität ist erlaubt.

## Rahmenbedingung
- Es dürfen größere Mengen eingeliefert werden, als vereinbart
- Es dürfen mehr Qualitätsmerkmale erfüllt sein, als vereinbart
- VertragsPositionen dürfen in den Einlieferungen beliebig gestückelt oder zusammengefasst werden
- Es muss eine Zuordnung von Einlieferungen zu Vereinbarungen geben, so dass mindestens alle Mengen mit ihren Q-Merkmalen erfüllt sind

## Aufgabe
- Implementiere die Methode "EinkaufsVertrag.WirdErfülltDurch(List<StromBundle> einlieferungen)" so, dass alle Unit-Tests grün sind