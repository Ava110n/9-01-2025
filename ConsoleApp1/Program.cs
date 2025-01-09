using System.Globalization;

class Program
{
    static void Main()
    {
        Timer t = new Timer(1,2,3);
        Counter c = new Counter(5);
        c = (Counter)t;
        Console.WriteLine(c);
    }
}


class Timer
{
    public int hours;
    public int minutes;
    public int seconds;

    public Timer(int h, int m, int s)
    {
        hours = h;
        minutes = m;
        seconds = s;
    }

    public static explicit operator Timer(Counter c)
    {
        return new Timer(c/3600, c % 3600/60, c%60);
    }

}

class Counter
{
    public int seconds;

    public Counter(int s)
    {
        seconds = s;
    }

    public static explicit operator Counter(Timer t)
    {
        int s = t.hours * 3600 + t.minutes * 60 + t.seconds;
        return new Counter(s);
    }
    public static implicit operator int(Counter c)
    {
        return c.seconds;
    }

    public override string ToString()
    {
        return seconds.ToString();
    }
}