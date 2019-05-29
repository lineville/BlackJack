using System;
public class Card
{
    public String Name { get; set; }
    public int Value { get; set; }

    public int OptionalValue { get; set; }
    public String Suite { get; set; }

    public Card(String name, int val, String suite)
    {
        Name = name;
        Value = val;
        Suite = suite;
        OptionalValue = val;
    }

}