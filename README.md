# ProjektRekrutacjaCore

## Opis projektu

Aplikacja okienkowa (WPF) stworzona w technologii .NET 8, umożliwiająca wyszukiwanie produktów w bazie danych systemu magazynowo-handlowego (Subiekt Nexo).

---

## Technologie

* .NET 8 (WPF)
* Entity Framework Core
* SQL Server
* MVVM (Model-View-ViewModel)

---

## Architektura

Projekt został zorganizowany zgodnie z wzorcem MVVM:

* **Models** – klasy odwzorowujące strukturę bazy danych oraz model widoku (`Product`)
* **ViewModels** – logika aplikacji oraz obsługa wyszukiwania
* **Views** – warstwa UI (XAML)
* **Commands** – implementacja `ICommand` (RelayCommand)

---

## Konfiguracja

Aplikacja wykorzystuje plik konfiguracyjny:

```text
appsettings.json
```

### Connection String

Przed uruchomieniem należy uzupełnić connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING_HERE"
  }
}
```

Przykład:

```json
"Server=YOUR_SERVER;Database=YOUR_DATABASE;Trusted_Connection=True;TrustServerCertificate=True;"
```

---

## Uruchomienie projektu

1. Otwórz projekt w Visual Studio 2022
2. Uzupełnij connection string w `appsettings.json`
3. Upewnij się, że baza danych jest dostępna
4. Uruchom aplikację (F5)

---

## Działanie aplikacji

* wpisanie tekstu w pole wyszukiwania automatycznie filtruje wyniki
* wyszukiwanie jest niewrażliwe na wielkość liter
* przycisk „X” czyści pole wyszukiwania


