# Die Story
Der bekannte Mafiosi Don ChaMoin feiert seinen 70. Geburtstag. Wie sich das gehört, sind alle eingeladen,
die in der Chicagoer Unterwelt einen Namen haben. Für das Abendessen sollen die Gäste mit Sitzordnung 
an einer langen Tafel nebeneinander platziert werden. Da Du dich mit Algorithmen auskennst, ist es Deine Aufgabe, die Sitzordnung
zu erstellen. 

Don ChaMoin schreibt Dir seine Wünsche auf eine Serviette. In die erste Zeile schreibt er 
die Liste aller Gäste. Damit das FBI nichts mit der Liste anfangen kann, sind die Namen gekürzt. 
Jeder Buchstabe steht für einen Gast. 

Da einige Gäste aus demselben Business (Drogen, Hehlerei, Waffen) stammen, sollen sich diese beim 
Abendessen besser kennen lernen. Daher wünscht sich Don ChaMoin, dass einige Menschen unbedingt 
nebeneinandersitzen. In die zweite Zeile schreibt er in eckige Klammern diese Gruppen. 

In der dritten Zeile stehen in spitzen Klammern die Gruppen von Gästen, die auf gar keinen Fall 
nebeneinander sitzen dürfen (Schießereien und Messerstechereien sollten dadurch vermieden werden).

# Ein Beispiel

    ABCDEF
    [ACD][AE]
    <BF><CEF>

Gesucht ist eine Reihenfolge der Gäste A,B,C,D,E, und F, die alle Bedingungen erfüllt.

Die triviale Reihenfolge `ABCDEF` passt also nicht, weil die Gruppe `[ACD]` nicht nebeneinandersitzt. 
Für eine korrekte Lösung ist es unerheblich, in welcher Reihenfolge die Personen `[ACD]` nebeneinandersitzen.
Hauptsache, sie sitzen nebeneinander. 

Die Lösung `ACDBEF` erfüllt zwar `[ACD]`, aber `[AE]` ist nicht erfüllt, denn A und E sitzen nicht nebeneinander.

Die Lösung `CDAEBF` erfüllt zwar `[ACD]` (A,C,D sitzen nebeneinander, die Reihenfolge untereinander ist egal) 
und auch `[AE]`, aber `<BF>` nicht, denn diese dürfen nicht nebeneinandersitzen.

Die Lösung `BCDAEF` erfüllt nun auch `<BF>`, aber leider `<CEF>` nicht. Keiner der Personen in den verbotenen Gruppen
dürfen neben einer anderen derselben Gruppe sitzen (hier sitzen E und F am Ende des Tisches).

- Die Lösung `BEACDF` erfüllt alle Bedingungen und ist korrekt. 
- Die Lösung `FDCAEB` erfüllt ebenfalls alle Bedingungen und ist korrekt. 

Hinweis: Da es eine lange Tafel und kein runder Tisch ist, sitzen bei den Lösungen die Personen B und F nicht nebeneinander!

# Die Aufgabe
So, nun hast Du verstanden, was sich Don ChaMoin wünscht. Viel Glück. Deine Aufgabe ist folgende Gästeliste:

    ABCDEFGHIJKLM
    [GBE][LK][FB][MI]
    <KFE><AC><JB><DE><CHIJ><FCK><CD><LC>

- Aufgabe 1: Berechne eine erlaubte Sitzordnung
- Aufgabe 2: Wie viele Sitzordnungen existieren, die alle Bedingungen erfüllen?
