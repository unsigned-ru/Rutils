using Newtonsoft.Json;

namespace Rutils;

public enum TimeUnit
{
    Years,
    Quarters,
    Months, 
    Weeks, 
    Days,
    Hours, 
    Minutes, 
    Seconds, 
    Milliseconds, 
    Nanoseconds, 
    Microseconds
}

public struct TimeUnitCount
{
    [JsonProperty("timeUnit")]
    public TimeUnit Unit { get; set; }
    
    [JsonProperty("unitCount")]
    public double Count { get; set; }

    public TimeUnitCount() {}
    public TimeUnitCount(int count, TimeUnit unit)
    {
        Count = count;
        Unit = unit;
    }

    public override string ToString()
    {
        int countInt = (int)Count;
        return $"{countInt} {ToString(Unit, Math.Abs(countInt) > 1)}";
    }  

    public static string ToString(TimeUnit unit, bool plural = true)
    {
        string enumValue = Enum.GetName(unit)!.ToLower();
        return plural ? enumValue : enumValue.Substring(0, enumValue.Length - 1);
    }

}