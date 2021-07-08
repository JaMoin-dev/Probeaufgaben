# Mac Integration

## Die Situation
- wir haben eine Anwendung mit .NET Core API, EF.Core, MS SQL Datenbank
- drei Umgebungen sind vorhanden
-- local Development (geht auf localDB unter localhost, wird ja mit VS mit geliefert)
-- Staging Datenbank mit Staging API Server läuft in Azure, damit der Kunde die nächsten Features testen kann
-- Production Datenbank mit Production API Server läuft in Azure

## Problem
- es soll ein neuer Mitarbeiter aufs Projekt. Der benutzt aber Mac und das soll so auch bleiben
- was müssen wir tun, damit der neue Mitarbeiter auch einfach `git checkout` machen kann und seine localhost test-Umgebung läuft?

## Aufgabe
Skizziere, was geändert werden muss bzw was gegeben sein muss, damit 
- Entwickler mit Windows und mit Mac das Projekt direkt nach dem `git checkout` compilieren und testen können