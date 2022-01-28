Programowanie ASP. NET" - projekt

Konfiguracja

1.Po pobraniu uruchamiamy "Projekt-ASP.sln".

2.Zmieniamy "ConnectionString" w pliku "appsetings.json" znajdującym się wewnątrz projektu pod nazwą "Data" >> "BookShop" >> "IdentityConnectionString".

Tworzenie bazy danych

1.W konsoli menedżera pakietów wpisać kolejno komendy: „add-migration <tutaj nazwa>”, a następnie  „update-database”. Po ich wpisaniu powinna stworzyć się baza danych.

2.Sprawdamy czy pobrały się wszystkie niezbędne pakiety.

Opis projektu

Aplikacja służy do zarządzania książkami (taki sklep z książkami). 

Funkcjonalności

Każdy użytkownik ma możliwość sprawdzenie listy książek. Jako zalogowany użytkownik z rolą "User" możemy dodawać lub usuwać książki z koszyka. Natomiast jako administrator lub menager można dodawać, usuwać lub edytować dowolny element bazy danych. Administrator ma także jako jedyny dostęp do strony admina (nie ma ona funkcjonalności).

Użytkownicy

|Login|Hasło|Rola|
| :-: | :-: | :-: |
|admin|Admin123\*|Admin|
|dawid|Dawid123\*|Manager|
|endriu|Endriu123\*|User|




Gdy stworzymy użytkownika logujemy się za pomocą maila i hasła.

