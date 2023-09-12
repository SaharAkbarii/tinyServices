namespace TinyServices.API.Divar.Model;

public class Email
{
    public Email(string value)
    {
        Value = value;
    }

    public string Value { get; set; }

    public override string ToString() => Value;
}