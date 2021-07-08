# TimeboxedCounter 

## Anwendungsfall
- Wir wissen wollen, wie viele Requests bei einen Webserver in der letzten Minute/Stunde eingegangen sind
- dafür implementieren wir eine Klasse, die die Summe aller Aufrufe innerhalb der letzten Minute/Stunde berechnet

## Rahmenbedingung
- Der Webserver ruft die Methode "Add" des Interfaces "TimeboxedCounter" in Echtzeit immer dann auf, wenn Requests eingegangen sind (ggf. ruft er die Methode für mehrere Requests nur einmal auf)
- es können zigtausend Calls pro Sekunde auftreten, daher ist Performance (Prozessor uns Speicherein großes Thema!

## Aufgabe
Implementiere die klasse TimeboxedCounter so, dass 
- alle UnitTests grün sind
- der Ressourcenverbrauch so gering wie möglich ist
=> hier geht es nicht darum, irgendeine Lösung zu finden, sondern die beste Lösung!