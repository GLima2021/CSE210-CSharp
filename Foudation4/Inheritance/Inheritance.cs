using System;

public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public override string ToString() => $"{street}, {city}, {state}, {country}";
}

public class Event
{
    protected string title;
    protected string description;
    protected DateTime date;
    protected string time;
    protected Address address;

    public Event(string title, string description, DateTime date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Event Type: {GetType().Name}\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nEvent Type: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nEvent Type: Reception\nRSVP Email: {rsvpEmail}";
    }
}

public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nEvent Type: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Address address1 = new Address("123 Park Ave", "New York", "NY", "USA");
        Event lecture = new Lecture("Tech Talk", "An in-depth look at modern technology.", new DateTime(2024, 6, 15), "10:00 AM", address1, "Dr. Smith", 100);

        Address address2 = new Address("456 Ocean Blvd", "Los Angeles", "CA", "USA");
        Event reception = new Reception("Networking Event", "An opportunity to connect with professionals.", new DateTime(2024, 6, 20), "6:00 PM", address2, "rsvp@example.com");

        Address address3 = new Address("789 Mountain Rd", "Denver", "CO", "USA");
        Event outdoorGathering = new OutdoorGathering("Hiking Adventure", "Join us for a day of hiking and fun.", new DateTime(2024, 6, 25), "9:00 AM", address3, "Sunny and warm");

        Event[] events = { lecture, reception, outdoorGathering };

        foreach (var eventObj in events)
        {
            Console.WriteLine(eventObj.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(eventObj.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(eventObj.GetShortDescription());
            Console.WriteLine(new string('-', 50));
        }
    }
}
