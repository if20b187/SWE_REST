# BRZAKALA					MCTG-PROTOKOLL

### Technische Schritte

#### Design



Auf der Linken Seite Die Objekte die ein User hat und speichern kann. Wie zum Beispiel: Packages, Cards, Decks, UserDaten, Userstats,...



**Rechts die  Objekte die sich um die Funktionalität kümmern.** 

Response schickt dem User die richtige Response raus.

Dbconn stellt die Verbindung zur Datenbank her und liefert das gewünschte Ergebnis, das gefragt wird im HttpServer.

Battle kümmert sich um die Logik, wie die Karten gegeneinander spielen.

RequestSplit zerstückelt den Request der vom User kommt. 

Die HttpServer Klasse ist das Herz des Ganzen. Die Methode StartServer() kümmert sich um alle Anfragen die reinkommen GET,POST,PUT,... 

#### Was kann das Programm?

###### 1) User können sich Registrieren:

```bash
curl -X POST http://localhost:8080/users --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"daniel\"}"
```

###### 2) User können sich Anmelden:

```bash
curl -X POST http://localhost:8080/sessions --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\",    \"Password\":\"daniel\"}"
```

###### 3) Der Admin (nur er) kann neue Karten erstellen:

```bash
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 1, \"name\": \"Goblin\", \"damage\": 37, \"element\": \"water\", \"type\": \"spell\"}"
```

###### 4) Random Packages können erstellt werden, diese bekommen eine bestimmte id:

```bash
curl -X POST http://localhost:8080/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken"  
```

###### 5) Packages können gekauft werden (solange sie 5 Coins dafür haben):

Die Packages werden dabei zufällig gewählt.

```bash
curl -X POST http://localhost:8080/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken"
```

###### 6) User kann sich alle seine gekauften Karten ansehen:

```bash
curl -X GET http://localhost:8080/cards --header "Authorization: Basic kienboec-mtcgToken"
```

###### 7) User kann sein Deck konfigurieren:

Die Karten müssen in seinem Besitz sein, ansonsten kommt ein Fehler.

```bash
curl -X PUT http://localhost:8080/deck --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d "[\"1\", \"3\", \"6\", \"9\"]" 
```

###### 8) User kann sein Deck sich anzeigen lassen:

```bash
curl -X GET http://localhost:8080/deck --header "Authorization: Basic kienboec-mtcgToken"
```

###### 9) User kann sein Deck sich anzeigen lassen im Plain Text:

```bash
curl -X GET http://localhost:8080/deck?format=plain --header "Authorization: Basic kienboec-mtcgToken"
```

###### 10) User kann seine Daten bearbeiten:

```bash
curl -X PUT http://localhost:8080/users/kienboec --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d "{\"Name\": \"Kienboeck\",  \"Bio\": \"me playin...\", \"Image\": \":-)\"}"
```

###### 11) User kann seine Daten anzeigen lassen:

```bash
curl -X GET http://localhost:8080/users/kienboec --header "Authorization: Basic kienboec-mtcgToken"
```

###### 12) User kann sich seine Stats anschauen (wins,draws,loses):

```bash
curl -X GET http://localhost:8080/stats --header "Authorization: Basic kienboec-mtcgToken"
```

###### 13) User kann sich den Scoreboard anzeigen lassen: 

```bash
curl -X GET http://localhost:8080/score --header "Authorization: Basic kienboec-mtcgToken"
```

###### 14) User kann Battlen:

Dabei wird sein Deck in eine Liste hinzugefügt.

```bash
curl -X POST http://localhost:8080/battle --header "Authorization: Basic testuser1-mtcgToken"
```

sobald ein zweiter Spieler auch sich in die Battleliste anmeldet kämpfen sie.

```bash
curl -X POST http://localhost:8080/battle --header "Authorization: Basic testuser2-mtcgToken"
```

###### 15) User können sich die Battle History anzeigen lassen mit der Matchid die sie bekommen:

```bash
curl -X GET http://localhost:8080/battle/1 --header "Authorization: Basic kienboec-mtcgToken" 
```

###### 16) User können sich ihr ELO anzeigen lassen (+3 bei win, -5 bei lose):

```bash
curl -X GET http://localhost:8080/elo/kienboec --header "Authorization: Basic kienboec-mtcgToken"
```

###### 17) User kann sich die aktuellen Trades anzeigen lassen:

```bash
curl -X GET http://localhost:8080/tradings --header "Authorization: Basic testuser1-mtcgToken"
```

###### 18) User kann ein Trade erstellen:

```bash
curl -X POST http://localhost:8080/tradings --header "Content-Type: application/json" --header "Authorization: Basic testuser1-mtcgToken" -d "{\"Tradingid\": \"1\", \"Karte\": \"1\", \"MinDamage\": \"30\", \"Type\": \"spell\"}"
```

###### 19) User kann seine Trades löschen:

```bash
curl -X DELETE http://localhost:8080/tradings/1 --header "Authorization: Basic kienboec-mtcgToken"
```

###### 18) User kann einen Trade von jemanden annehmen wenn seine Karte den Voraussetzungen zustimmen die Gefordert werden.

```bash
curl -X POST http://localhost:8080/tradings/1 --header "Content-Type: application/json" --header "Authorization: Basic testuser2-mtcgToken" -d "11"

```

#### Failures:

##### Failure 1:

Anfangs hab ich mir schwer getan eine Response zu Json zu serializieren. Jedoch nach paar Fehltritten bin ich drauf gekommen das ich einfach Objekte in dem Stil erstellen muss in dem ich sie zurückgeben möchte. 

##### Failure 2:

Trading. War eine Herausforderung da man so vieles beachten muss. 

##### Failure 3:

Habe sehr lang überlegt wie ich das Batteln von 2 Spielern handhaben möchte. Habe mich für die Variante entschieden, dass ich 2 Listen erstelle. Wenn der erste Spieler sich fürs Battle anmeldet dann bekommt er die Response zurück: 

"Dein Spiel startet in kürze - deine Matchid: 1 " - auf battle/1 Ergebnis entgegennehmen.

Dabei wird sein Deck in die erste Liste eingefügt.

Sobald der 2te User sich für die Battleliste anmeldet wird gekämpft. Er bekommt auch die Matchid als Rückgabe. Wer der Gewinner war können sie in der battlehistory (battle/id) ansehen.

Dabei wird vom 2ten User das Deck in die zweite Liste eingefügt.

Es werden auch dabei die Userstats geändert und der ELO wert.

#### Was wurde getestet?

Getestet wurde die Battle Logic. Vorallem der Aspekt das Goblins zu sehr Angst haben vor Dragons usw..

Damit ein User gewinnen oder verlieren kann muss die Funktionalität der Battlelogik auch stimmen. Von dem her wurde sie getestet.

#### Time spend:

Über 100 Stunden sind in das Projekt eingeflossen.

#### Github:

https://github.com/if20b187/SWE_REST
 
