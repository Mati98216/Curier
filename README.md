# Nazwa aplikacji
Aplikacja portalu kurierskiego

# Opis aplikacji
Aplikacja portalu kurierskiego

# Getting Started
Panel logowania 
 - Logowanie użytkownika 
 - Rejestracja nowego użytkownika 

Panel Użytkownika 
 - Wysyłanie nowej paczki 
 - Śledzenie aktualnych paczek 
 - Sprawdzanie historii wysłanych przesyłek 

Panel Kuriera/Pracownika 
 - Zarządzanie przesyłkami (Przejmowanie przesyłki, aktualizowanie jej statusów) 

Panel admina 
 - Możliwość zarządzania kurierami (dodawanie, edycja, usuwanie) 

Możliwe funkcjonalności co mogły by powstać:
Informace o paczkach/zleceni o paczkach/Więcej informacji/Przypisanie pojazdu do kuriera/co w paczkach jest 

# Struktura plików
CurierProject: Frontend i backend

    - Controllers: Tutaj znajduje się backend odpowiedzialny za działanie strony np. tutaj stworzymy działanie przycisku i np wskażemy gdzie ma on nas przenieść

    - Models: Model danych który będzie używany na danej stronie

    - Views: Frontend projektu, każdy panel ma swój oddzielny folder gdzie tworzymy frontend pod daną kategorię
        - Account: sekcja odpowiedzialna za Panel logowania
        - Administrators: sekcja odpowiedzalna za Panel admina 
        - Couriers: sekcja odpowiedzalna za Panel Kuriera/Pracownika 
        - Users: sekcja odpowiedzialna za Panel Użytkownika 
        - Shared: Tutaj znajduje się domyślny layout strony, gdzie dzięki temu będziemy mieć np. pasek nawigacji
            - _layout - podstawowy layout strony z paskiem nawigacji
            - _layoutLogin - podstawowy layout strony bez paska nawigacji, używany w panelu logowania

        Informacja dotycząca layoutów i ich działania: Każda nowo utworzona strona będzie domyślnie stosować plik _layout, 
        jeśli chcemy używać innego to musimy na początku strony umieścić @{ Layout = "~/Views/Shared/NAZWALAYOUTU"; } lub dać tam null jeśli nie chcemy w ogóle używać layoutu

CurierProject.Domain: Backend skupiający się na zarządzaniu danymi

    - Contracts: Tutaj znajdziemy interfejsy które będą łączę modelów między tutejszym backendem a backednem z controllers

    - Handlers: Kwerendy odpowiedzialne za dostawanie, wstawianie, aktualizowanie danych w bazie
        - Commands: Tutaj znajdują się klasy z kwerendami odpowiedzialnymi tylko za wstawianie, aktualizowanie danych w bazie, klasy nazywać w sposób "CreateOrUpdateNAZWA_NA_JAKIEJ_TABELI_DZIAŁAMYCommand" np. "CreateOrUpdateUsersCommand"
        - Queries: Tutaj znajdują się klasy z kwerendami odpowiedzialnymi tylko za wydobywanie danych z bazy, klasy nazywać w sposób "GetNAZWA_NA_JAKIEJ_TABELI_DZIAŁAMYQuery" np. "GetUsersQuery"
    
    - Models: Model danych, w miarę możliwości nie ruszać gotowych już tam rzeczy gdyż istniejące tam pola odpowiadają aktualnej bazie, dzieki temu jest połączenie między bazą a programem (ps. jeśli gdzieś znajdzie się nagle literówka program może dosłownie wyjebać przez to :D)
    
    - Plik DomainContext: w skrócie serce połączenia między bazą a projektem, odradzał bym dotykania go ...

#technologie i pomoce:
W aplikacji używamy następujących rzeczy:

    - Bootstrap v5: Dzięki temu łatwiej będzie nam robić Front, przykłady znajdzie się pod tym linkiem: https://getbootstrap.com/docs/5.0/examples/

    - FontAwsome: Ikonki: https://fontawesome.com (Nie wszystkie ikonki są dostępne, nawet z tych darmowych, ale wyszukanie może dać +- jakieś lepsze rozpoznanie i tak)
    
    - Entityframework: Służy do połączenia między bazą a projektem
