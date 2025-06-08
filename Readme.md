# Booking System - ASP.NET Core Web API

## ����� ��������

���� ������ �������� ��������� �������� ������������, 
������������� �� ASP.NET Core Web API. 
�������� ���� ������� � ����������� ���������� ������� �� ������������ 
����������, ������, ����������� � ��.

## ��������� �������

* **/Controllers** � API-�����������
* **/Models** � �������� ������
* **/Data** � �������� ���� ������ (BookingContext)
* **/Services** � ��� ���������� ������ (� �������)

## ��������� ����

BookingSystem/
 - Controllers/          <-- ������������ HTTP-�������
 - Data/                 <-- �������� �� � ��������
 - Repositories/         <-- ���������� � ���������� ������������
 - Services/             <-- ���������� � ���������� ������-������
 - Program.cs            <-- ������������ ����������


## ������� �������

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

## ���� ������

���� ������ ���������� ����� LocalDB, ��������� � appsettings.json:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BookingSystemDb;Trusted_Connection=True;"
}
```

## ��������

* ��� ������ (��������, �����, ���������) ����� ����������� ����������
* ����������� ���������� Repository-����, DTO ��������, Service Layer
* ������� Swagger, �������������� � ���� � �������

## ������

* `dotnet ef migrations add InitialCreate`
* `dotnet ef database update`
* `dotnet run`

"# BookingSystem" 
"# BookingSystem" 
