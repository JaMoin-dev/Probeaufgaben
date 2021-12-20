# Vertragserfüllung

## Anwendungsfall
- in Einkaufsverträgen werden Stromlieferungen fürs nächste Jahr vereinbart.
- Strom kann verschiedene Qualitätsmerkmale haben (Windkraft, Wasserkraft, Fischtreppe, etc)
- Im Jahresverlauf wird Strom eingeliefert. 
- Am Ende des Jahres wird geprüft, ob der gelieferte Strom den vertraglichen Vereinbarungen entsprach
  - diese Prüfung ist Gegenstand dieser Aufgabe!

## Beispiel
- Vertraglich vereinbart fürs ganze Jahr: 
  - 100MWh Wasserkraft
  - 100MWh Windkraft
  - 100MWh Wasserkraft mit Fischtreppe

- Eingeliefert werden nach und nach im Laufe des Jahres
  - 150MWh Wasserkraft mit Fischtreppe
  - 50MWh Wasserkraft
  - 100MWh Windkraft

- Diese Einlieferung erfüllt die vertraglichen Vereinbarungen, denn höhere Qualität ist erlaubt. 
  - Wir haben wie vereinbart 100MWh Windkraft bekommen
  - Wir haben wie vereinbart 100MWh Wasserkraft mit Fischtreppe bekommen
  - Wir haben wie vereinbart 100MWh Wasserkraft  bekommen (50MWh davon haben sogar eine Fischtreppe, was besser ist als ohne)

## Rahmenbedingung
- Es dürfen größere Mengen eingeliefert werden, als vereinbart
- Es dürfen mehr Qualitätsmerkmale erfüllt sein, als vereinbart
- VertragsPositionen dürfen in den Einlieferungen beliebig gestückelt oder zusammengefasst werden
- Alle Einlieferungen zusammen müssen irgendwie alle Vertragspositionen abbilden, so dass mindestens alle Mengen mit ihren QualitätsmerkmalenMerkmalen erfüllt sind

## Aufgabe
- Implementiere die Methode "EinkaufsVertrag.WirdErfülltDurch(List<StromBundle> einlieferungen)" so, dass alle Unit-Tests grün sind