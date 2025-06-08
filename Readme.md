# Booking System - ASP.NET Core Web API

## Общее описание

Этот проект является модульной системой бронирования, 
реализованной на ASP.NET Core Web API. 
Основная цель проекта — постепенное расширение системы на бронирование 
ресторанов, отелей, авиабилетов и др.

## Структура проекта

* **/Controllers** — API-контроллеры
* **/Models** — доменные модели
* **/Data** — контекст базы данных (BookingContext)
* **/Services** — для добавления логики (в будущем)

## Структура слоёв

BookingSystem/
 - Controllers/          <-- Обрабатывают HTTP-запросы
 - Data/                 <-- Контекст БД и сущности
 - Repositories/         <-- Интерфейсы и реализации репозиториев
 - Services/             <-- Интерфейсы и реализации бизнес-логики
 - Program.cs            <-- Конфигурация приложения


## Базовые объекты

### Reservation.cs

```csharp
public class Reservation
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string BookingType { get; set; } // hotel, flight, restaurant
    public DateTime ReservationDate { get; set; }
}
```

### BookingContext.cs

```csharp
public class BookingContext : DbContext
{
    public BookingContext(DbContextOptions<BookingContext> options) : base(options) { }

    public DbSet<Reservation> Reservations { get; set; }
}
```

### ReservationController.cs

```csharp
[ApiController]
[Route("api/[controller]")]
public class ReservationController : ControllerBase
{
    private readonly BookingContext _context;

    public ReservationController(BookingContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetReservations() =>
        Ok(_context.Reservations.ToList());

    [HttpPost]
    public IActionResult CreateReservation(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        _context.SaveChanges();
        return Ok(reservation);
    }
}
```

## База данных

База данных развернута через LocalDB, настроена в appsettings.json:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BookingSystemDb;Trusted_Connection=True;"
}
```

## Развитие

* Все модули (ресторан, отель, авиабилет) будут добавляться постепенно
* Планируется добавление Repository-слоя, DTO объектов, Service Layer
* Добавим Swagger, аутентификацию и роли в будущем

## Запуск

* `dotnet ef migrations add InitialCreate`
* `dotnet ef database update`
* `dotnet run`

"# BookingSystem" 
"# BookingSystem" 
