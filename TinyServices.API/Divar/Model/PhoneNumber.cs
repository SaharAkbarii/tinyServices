namespace TinyServices.API.Divar.Model;

public class PhoneNumber
{
    public PhoneNumber(string value)
    {
        Value = value;
    }

    public string Value { get; set; }

    public override string ToString() => Value;
}
