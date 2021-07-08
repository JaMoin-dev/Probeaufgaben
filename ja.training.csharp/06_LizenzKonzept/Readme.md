# Lizenzkonzept 

## Anwendungsfall
- Kunde hat eine Desktop-Software von uns entwickeln lassen
- diese ist sehr teuer und soll sicher lizensiert werden

## Rahmenbedingung
- einmal lizensiert, soll die Software auch offline laufen (d.h. ein bei Programmstart erzwungener Server-Request geht nicht)
- es muss verhindert werden, dass der Kunde eine Lizenz auf mehreren Rechnern verwendet
- die Lizenz soll beim Kunden irgendwie "lesbar" sein. D.h. der Mitarbeiter, der die Software verwendet, soll sehen "Lizensiert für ..."
- es soll cryptografisch so sicher wie möglich sein, aber es geht hier nicht um Atomraketen. 
=> Der "Gegner" ist kein FBI sondern Systemadministratoren von knausrigen Kunden.
- wir haben Server und Datenbanken in der Cloud, wo wir eine Lizenz-API/Server einspielen können

## Aufgabe
schreibe ein Konzept, wie wir das umsetzen können. Kurz und knapp.
- so dass der Kunde versteht, warum das sicher ist
- so dass der Entwickler versteht, was und wie er das umsetzen kann.