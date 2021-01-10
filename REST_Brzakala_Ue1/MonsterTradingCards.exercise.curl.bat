@echo off

REM --------------------------------------------------
REM Monster Trading Cards Game
REM --------------------------------------------------
title Monster Trading Cards Game
echo CURL Testing for Monster Trading Cards Game
echo.

REM --------------------------------------------------
echo 1) Create Users (Registration)
REM Create User
curl -X POST http://localhost:8080/users --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"daniel\"}"
echo.
curl -X POST http://localhost:8080/users --header "Content-Type: application/json" -d "{\"Username\":\"altenhof\", \"Password\":\"markus\"}"
echo.
curl -X POST http://localhost:8080/users --header "Content-Type: application/json" -d "{\"Username\":\"admin\",    \"Password\":\"istrator\"}"
echo.

echo should fail:
curl -X POST http://localhost:8080/users --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"daniel\"}"
echo.
curl -X POST http://localhost:8080/users --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"different\"}"
echo. 
echo.

REM --------------------------------------------------
echo 2) Login Users
echo.
curl -X POST http://localhost:8080/sessions --header "Content-Type: application/json" -d "{\"Username\":\"altenhof\", \"Password\":\"markus\"}"
echo.
curl -X POST http://localhost:8080/sessions --header "Content-Type: application/json" -d "{\"Username\":\"admin\",    \"Password\":\"istrator\"}"
echo.
curl -X POST http://localhost:8080/sessions --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\",    \"Password\":\"daniel\"}"
echo.

echo should fail:
curl -X POST http://localhost:8080/sessions --header "Content-Type: application/json" -d "{\"Username\":\"kienboec\", \"Password\":\"different\"}"
echo.
echo.

REM --------------------------------------------------
echo 3.1) create card (done by "admin")
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 1, \"name\": \"Goblin\", \"damage\": 37, \"element\": \"water\", \"type\": \"spell\"}"
echo.																																																																																 				    
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 2, \"name\": \"Dragon\", \"damage\": 42, \"element\": \"fire\", \"type\": \"monster\"}"
echo.																																																																																 				    
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 3, \"name\": \"Spell\", \"damage\": 11, \"element\": \"water\", \"type\": \"spell\"}"
echo.																																																																															 				    
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 4, \"name\": \"Ork\", \"damage\": 39, \"element\": \"water\", \"type\": \"monster\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 5, \"name\": \"Wizzard\", \"damage\": 9, \"element\": \"normal\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 6, \"name\": \"Knight\", \"damage\": 11, \"element\": \"normal\", \"type\": \"monster\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 7, \"name\": \"Kraken\", \"damage\": 43, \"element\": \"water\", \"type\": \"monster\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 8, \"name\": \"Elves\", \"damage\": 29, \"element\": \"fire\", \"type\": \"monster\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 9, \"name\": \"Troll\", \"damage\": 38, \"element\": \"fire\", \"type\": \"monster\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 10, \"name\": \"Goblin\", \"damage\": 33, \"element\": \"water\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 11, \"name\": \"Dragon\", \"damage\": 46, \"element\": \"fire\", \"type\": \"monster\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 12, \"name\": \"Spell\", \"damage\": 44, \"element\": \"fire\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 13, \"name\": \"Ork\", \"damage\": 46, \"element\": \"water\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 14, \"name\": \"Wizzard\", \"damage\": 17, \"element\": \"normal\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 15, \"name\": \"Knight\", \"damage\": 15, \"element\": \"normal\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 16, \"name\": \"Kraken\", \"damage\": 12, \"element\": \"water\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 17, \"name\": \"Elves\", \"damage\": 14, \"element\": \"fire\", \"type\": \"monster\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 18, \"name\": \"Troll\", \"damage\": 13, \"element\": \"fire\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 19, \"name\": \"Troll\", \"damage\": 18, \"element\": \"water\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 20, \"name\": \"Elves\", \"damage\": 11, \"element\": \"water\", \"type\": \"spell\"}"



echo should fail:
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{"id":1,"name":"WaterGoblin","damage":37,"element":"water","type": "spell"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 1, \"name\": \"WaterGoblin\", \"damage\": 37, \"element\": \"water\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" -d "{\"id\": 0, \"name\": \"WaterGoblin\", \"damage\": 37, \"element\": \"water\", \"type\": \"spell\"}"
echo.
curl -X POST http://localhost:8080/card --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d "{\"id\": 1, \"name\": \"WaterGoblin\", \"damage\": 37, \"element\": \"water\", \"type\": \"spell\"}"
REM --------------------------------------------------

echo 3.2) Random create packages (done by "admin")
curl -X POST http://localhost:8080/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken"  
echo.																																	
curl -X POST http://localhost:8080/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken"  
echo.																																
curl -X POST http://localhost:8080/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken"  
echo.																																
curl -X POST http://localhost:8080/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken"  
echo.																																
curl -X POST http://localhost:8080/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken"  
echo.																																
curl -X POST http://localhost:8080/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken"  
echo.
echo.

REM --------------------------------------------------
echo 4) acquire packages kienboec
curl -X POST http://localhost:8080/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" 
echo.
curl -X POST http://localhost:8080/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" 
echo.
curl -X POST http://localhost:8080/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" 
echo.
curl -X POST http://localhost:8080/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" 
echo.
echo should fail (no money):
curl -X POST http://localhost:8080/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" 
echo.
echo.

REM --------------------------------------------------
echo 5) acquire packages altenhof
curl -X POST http://localhost:8080/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" 
echo.
curl -X POST http://localhost:8080/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" 
echo.
echo should fail (no package):
curl -X POST http://localhost:8080/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" 
echo.
echo.

REM --------------------------------------------------
echo 6) add new packages
curl -X POST http://localhost:8080/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" 
echo.
curl -X POST http://localhost:8080/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" 
echo.
curl -X POST http://localhost:8080/packages --header "Content-Type: application/json" --header "Authorization: Basic admin-mtcgToken" 
echo.
echo.

REM --------------------------------------------------
echo 7) acquire newly created packages altenhof
curl -X POST http://localhost:8080/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" 
echo.
curl -X POST http://localhost:8080/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" 
echo.
echo should fail (no money):
curl -X POST http://localhost:8080/transactions/packages --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" 
echo.
echo.

REM --------------------------------------------------
echo 8) show all acquired cards kienboec
curl -X GET http://localhost:8080/cards --header "Authorization: Basic kienboec-mtcgToken"
echo should fail (no token)
curl -X GET http://localhost:8080/cards 
echo.
echo.

REM --------------------------------------------------
echo 9) show all acquired cards altenhof
curl -X GET http://localhost:8080/cards --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 10) show unconfigured deck
curl -X GET http://localhost:8080/deck --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:8080/deck --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 11) configure deck
curl -X PUT http://localhost:8080/deck --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d "[\"3\", \"4\", \"11\", \"9\"]"
echo.
curl -X GET http://localhost:8080/deck --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X PUT http://localhost:8080/deck --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d "[\"12\", \"14\", \"9\", \"10\"]"
echo.
curl -X GET http://localhost:8080/deck --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo.
echo should fail and show original from before:
curl -X PUT http://localhost:8080/deck --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d "[\"1\", \"2\", \"3\", \"4\"]"
echo.
curl -X GET http://localhost:8080/deck --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo.
echo should fail ... only 3 cards set
curl -X PUT http://localhost:8080/deck --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d "[\"1\", \"2\", \"3\"]"
echo should fail, bc card not in his posession.
curl -X PUT http://localhost:8080/deck --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d "[\"1\", \"2\", \"3\", \"4\"]"
echo.
echo should fail, bc he want to use 2 of the same cards.
curl -X PUT http://localhost:8080/deck --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d "[\"1\", \"2\", \"2\", \"4\"]"
echo.

REM --------------------------------------------------
echo 12) show configured deck 
curl -X GET http://localhost:8080/deck --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:8080/deck --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 13) show configured deck different representation
echo kienboec
curl -X GET http://localhost:8080/deck?format=plain --header "Authorization: Basic kienboec-mtcgToken"
echo.
echo.
echo altenhof
curl -X GET http://localhost:8080/deck?format=plain --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 14) edit user data
echo.
curl -X GET http://localhost:8080/users/kienboec --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:8080/users/altenhof --header "Authorization: Basic altenhof-mtcgToken"
echo.																																				
curl -X PUT http://localhost:8080/users/kienboec --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d "{\"Name\": \"Kienboeck\",  \"Bio\": \"me playin...\", \"Image\": \":-)\"}"
echo.
curl -X PUT http://localhost:8080/users/altenhof --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d "{\"Name\": \"Altenhofer\", \"Bio\": \"me codin...\",  \"Image\": \":-D\"}"
echo.
curl -X GET http://localhost:8080/users/kienboec --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:8080/users/altenhof --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo.
echo should fail:
curl -X GET http://localhost:8080/users/altenhof --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:8080/users/kienboec --header "Authorization: Basic altenhof-mtcgToken"
echo.
curl -X PUT http://localhost:8080/users/kienboec --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d "{\"Name\": \"Hoax\",  \"Bio\": \"me playin...\", \"Image\": \":-)\"}"
echo.
curl -X PUT http://localhost:8080/users/altenhof --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d "{\"Name\": \"Hoax\", \"Bio\": \"me codin...\",  \"Image\": \":-D\"}"
echo.
curl -X GET http://localhost:8080/users/someGuy  --header "Authorization: Basic kienboec-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 15) stats
curl -X GET http://localhost:8080/stats --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:8080/stats --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 16) scoreboard
curl -X GET http://localhost:8080/score --header "Authorization: Basic kienboec-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 17) battle
start /b "kienboec battle" curl -X POST http://localhost:8080/battles --header "Authorization: Basic kienboec-mtcgToken"
start /b "altenhof battle" curl -X POST http://localhost:8080/battles --header "Authorization: Basic altenhof-mtcgToken"

curl -X POST http://localhost:8080/battle --header "Authorization: Basic kienboec-mtcgToken" 
curl -X POST http://localhost:8080/battle --header "Authorization: Basic altenhof-mtcgToken" 

ping localhost -n 10 >NUL 2>NUL

REM --------------------------------------------------
echo 18) Stats 
echo kienboec
curl -X GET http://localhost:8080/stats --header "Authorization: Basic kienboec-mtcgToken"
echo.
echo altenhof
curl -X GET http://localhost:8080/stats --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 19) scoreboard
curl -X GET http://localhost:8080/score --header "Authorization: Basic kienboec-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 20) trade
echo check trading deals
curl -X GET http://localhost:8080/tradings --header "Authorization: Basic kienboec-mtcgToken"
echo.
echo create trading deal
curl -X POST http://localhost:8080/tradings --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d "{\"Tradingid\": \"1\", \"Karte\": \"15\", \"MinDamage\": \"10\", \"Type\": \"spell\"}"
echo.
echo check trading deals
curl -X GET http://localhost:8080/tradings --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:8080/tradings --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo delete trading deals
curl -X DELETE http://localhost:8080/tradings/1 --header "Authorization: Basic kienboec-mtcgToken"
echo.
echo.

REM --------------------------------------------------
echo 21) check trading deals
curl -X GET http://localhost:8080/tradings  --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X POST http://localhost:8080/tradings --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d "{\"Tradingid\": \"1\", \"Karte\": \"15\", \"MinDamage\": \"10\", \"Type\": \"spell\"}"
curl -X GET http://localhost:8080/tradings  --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:8080/tradings  --header "Authorization: Basic altenhof-mtcgToken"
echo.
echo try to trade with yourself (should fail)
curl -X POST http://localhost:8080/tradings/1 --header "Content-Type: application/json" --header "Authorization: Basic kienboec-mtcgToken" -d "3"
echo.
echo try to trade 
echo.
curl -X POST http://localhost:8080/tradings/1 --header "Content-Type: application/json" --header "Authorization: Basic altenhof-mtcgToken" -d "19"
echo.
curl -X GET http://localhost:8080/tradings --header "Authorization: Basic kienboec-mtcgToken"
echo.
curl -X GET http://localhost:8080/tradings --header "Authorization: Basic altenhof-mtcgToken"
echo.

REM --------------------------------------------------
echo end...

REM this is approx a sleep 
ping localhost -n 100 >NUL 2>NUL
@echo on
