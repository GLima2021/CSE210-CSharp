using System;
using System.Collections.Generic;

#region Activity Class
// Base class representing a generic activity with date and duration
public class Activity
{
    protected DateTime Date;
    protected int Duration; // in minutes

    public Activity(DateTime date, int duration)
    {
        Date = date;
        Duration = duration;
    }

    // Virtual methods to be overridden by derived classes
    public virtual double GetDistance() => 0;
    public virtual double GetSpeed() => 0;
    public virtual double GetPace() => 0;

    // Provides a summary of the activity
    public virtual string GetSummary()
    {
        return $"{Date.ToShortDateString()} Activity ({Duration} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}
#endregion

#region Running Class
// Derived class representing a running activity
public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int duration, double distance) : base(date, duration)
    {
        _distance = distance;
    }

    // Overrides to provide specific calculations for running
    public override double GetDistance() => _distance;
    public override double GetSpeed() => (_distance / Duration) * 60;
    public override double GetPace() => Duration / _distance;

    // Provides a summary specific to running
    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Running ({Duration} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}
#endregion

#region Cycling Class
// Derived class representing a cycling activity
public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int duration, double speed) : base(date, duration)
    {
        _speed = speed;
    }

    // Overrides to provide specific calculations for cycling
    public override double GetDistance() => (_speed * Duration) / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / _speed;

    // Provides a summary specific to cycling
    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Cycling ({Duration} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}
#endregion

#region Swimming Class
// Derived class representing a swimming activity
public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthInMiles = 50.0 / 1000 * 0.62; // 50 meters converted to miles

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        _laps = laps;
    }

    // Overrides to provide specific calculations for swimming
    public override double GetDistance() => _laps * LapLengthInMiles;
    public override double GetSpeed() => (GetDistance() / Duration) * 60;
    public override double GetPace() => Duration / GetDistance();

    // Provides a summary specific to swimming
    public override string GetSummary()
    {
        return $"{Date.ToShortDateString()} Swimming ({Duration} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
    }
}
#endregion

#region Program Class
// Main program to create and display different activities
public class Program
{
    public static void Main(string[] args)
    {
        // List to store various activities
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 5, 1), 30, 3.0),
            new Cycling(new DateTime(2024, 5, 2), 45, 15.0),
            new Swimming(new DateTime(2024, 5, 3), 60, 20)
        };

        // Displaying the summary of each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
#endregion
