# Umkreissuche

## Anwendungsfall
- wir haben eine Datenbank/Web-Anwendung mit ca. 50.000 Telefonzellen Deutschlandweit
- Jede Telefonzelle hat die Adresse in Form von Straße+Nr, Plz, Stadt 

## Aufgabe
- wir wollen eine Telefonzellen-Suche umsetzen, so dass ich online meine Adresse eingeben kann und
-- die dichtesten 100 Telefonzellen nach Abstand sortiert sehe

## Rahmenbedingungen
- Lizenzkosten dürfen anfallen, der Kunde zahlt. Aber gerne nicht so viel, denn das Budget ist erschöpflich.
- da wir 50.000 Einträge haben, spielt Performance eine Rolle
- wir haben das ganze System unter Kontrolle. D.h. wir können problemlos Tabellen in der Datenbank modifizieren/hinzufügen

## Aufgabe
Stell Dir vor, du hast einen Junior-Entwickler, der dir die Methoden und Klassen ausprogrammiert, die Du brauchst.
- Skizziere den Lösungsweg und die Datenmodelle in C#
- Der Code muss nicht kompilieren, denn dein Entwickler wird ja den Rest fertig stellen
- Arbeite ggf. mit Methoden-Stubs, die per Kommentar deinem Kollegen sagen, was er da hinein programmieren soll
- Du sollst Dich nur drum kümmern, dass der Entwickler genug Infos bekommt, um das Projekt fertig zu stellen
- Du kannst alles verändern, ein guter Startpunkt ist natürlich die Methode TelefonzellenRepository.Load(...)