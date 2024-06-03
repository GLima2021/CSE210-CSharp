using System;
using System.Collections.Generic;

public class Activity
{
    protected DateTime Date;
    protected int Duration; // in minutes

    public Activity(DateTime date, int duration)
    {
        Date = date;
        Duration = duration;
    }

    public virtual double GetDistance() => 0;
    public virtual double GetSpeed() => 0;
    public virtual double GetPace() => 0;

    public virtual string GetSummary()
    {
        return $"{Date.ToShortDateString()} Activity ({Duration} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / Duration) * 60;
    public override double GetPace() => Duration / _distance;

    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Running ({Duration} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * Duration) / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / _speed;

    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Cycling ({Duration} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthInMiles = 50.0 / 1000 * 0.62; // 50 meters converted to miles

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * LapLengthInMiles;
    public override double GetSpeed() => (GetDistance() / Duration) * 60;
    public override double GetPace() => Duration / GetDistance();

    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Swimming ({Duration} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 5, 1), 30, 3.0),
            new Cycling(new DateTime(2024, 5, 2), 45, 15.0),
            new Swimming(new DateTime(2024, 5, 3), 60, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
