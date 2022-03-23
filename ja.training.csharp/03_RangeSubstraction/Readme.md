# RangeSubstraction 

## Anwendungsfall
- wir haben eine Liste mit Zertifikaten, die fortlaufend nummeriert sind
- von diesen Zertifikaten werden welche verkauft und sind dann nicht mehr in unserem Bestand vorhanden
- da es sehr viele Zertifikate sind, können wir nicht einfach die Nummern selbst speichern, sondern speichern gleich ganze Ranges

## Beispiel
- wir haben Range [1000-1200]
- wir verkaufen (subtrahieren) die Zertifikate von [1010-1030]
- dann bleiben uns die beiden Teil-Ranges [1000-1009] und [1031-1200] 

## Rahmenbedingung
- da die laufenden Nummern sehr groß sind (so dass sie in kein int oder long passen), müssen diese leider als String übergeben werden.
- z.B. IntRange("12345678901234567890123451000", "12345678901234567890123451200")
- wir können uns aber sicher sein, dass die Differenz (also End-Start) immer klein genug ist, um in ein int zu passen.
-- also in dem Beispiel 12345678901234567890123451000 - 12345678901234567890123451200 = 200

## Aufgabe
- Verändere die Klasse IntRange.cs so, dass sie mit sehr großen Zahlen umgehen kann
- Implementiere die Klasse IntRangeExtensions.cs so, dass die Unit-Tests grün sind

=> Der Name IntRange kommt daher, dass das Volumen (also die Differenz) immer in einen Integer passt