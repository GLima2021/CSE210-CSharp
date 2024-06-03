using System;

#region Address Class
// Represents an address with street, city, state, and country
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

    // Provides a string representation of the address
    public override string ToString() => $"{street}, {city}, {state}, {country}";
}
#endregion

#region Event Base Class
// Base class for all types of events
public abstract class Event
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

    // Returns the standard details of the event
    public virtual string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}";
    }

    // Returns the full details of the event including specific details
    public abstract string GetFullDetails();

    // Returns a short description of the event
    public virtual string GetShortDescription()
    {
        return $"Event Type: {GetType().Name}\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}
#endregion

#region Lecture Class
// Represents a lecture event
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

    // Returns the full details of the lecture
    public override string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nEvent Type: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}
#endregion

#region Reception Class
// Represents a reception event
public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    // Returns the full details of the reception
    public override string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nEvent Type: Reception\nRSVP Email: {rsvpEmail}";
    }
}
#endregion

#region OutdoorGathering Class
// Represents an outdoor gathering event
public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    // Returns the full details of the outdoor gathering
    public override string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nEvent Type: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }
}
#endregion

#region Workshop Class
// Represents a workshop event
public class Workshop : Event
{
    private string instructor;
    private int duration;

    public Workshop(string title, string description, DateTime date, string time, Address address, string instructor, int duration)
        : base(title, description, date, time, address)
    {
        this.instructor = instructor;
        this.duration = duration;
    }

    // Returns the full details of the workshop
    public override string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nEvent Type: Workshop\nInstructor: {instructor}\nDuration: {duration} hours";
    }
}
#endregion

#region Program Class
// Main program to create and display event details
public class Program
{
    public static void Main(string[] args)
    {
        // Creating addresses for events
        Address address1 = new Address("123 Park Ave", "New York", "NY", "USA");
        Address address2 = new Address("456 Ocean Blvd", "Los Angeles", "CA", "USA");
        Address address3 = new Address("789 Mountain Rd", "Denver", "CO", "USA");
        Address address4 = new Address("101 River St", "Chicago", "IL", "USA");

        // Creating different types of events
        Event lecture = new Lecture("Tech Talk", "An in-depth look at modern technology.", new DateTime(2024, 6, 15), "10:00 AM", address1, "Dr. Smith", 100);
        Event reception = new Reception("Networking Event", "An opportunity to connect with professionals.", new DateTime(2024, 6, 20), "6:00 PM", address2, "rsvp@example.com");
        Event outdoorGathering = new OutdoorGathering("Hiking Adventure", "Join us for a day of hiking and fun.", new DateTime(2024, 6, 25), "9:00 AM", address3, "Sunny and warm");
        Event workshop = new Workshop("Photography Workshop", "Learn the art of photography.", new DateTime(2024, 7, 1), "1:00 PM", address4, "Jane Doe", 3);

        // Storing events in an array
        Event[] events = { lecture, reception, outdoorGathering, workshop };

        // Displaying details for each event
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
#endregion
