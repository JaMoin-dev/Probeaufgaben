# FormatWith 

## Anwendungsfall
- wir haben Email-Templates, die mit Inhalt gefüllt werden sollen
- dafür implementieren wir eine Methode, die für alle erdenklichen C# Objekte Platzhalter in den Templates mit Daten füllt

## Rahmenbedingung
- Tief verschachtelte Objekte sollen möglich sein
- (Nice-to-Have) Zirkulär verschachtelte Objekte sollen funktionieren

## Aufgabe
Implementiere die Extension-Methode StringExtensions.FormatWith so, dass 
- so viele UnitTests wie möglich grün sind