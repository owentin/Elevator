namespace Elevator;

public class Person
{
    private IEnumerable<int> Floors { get; }
    
    public Person(IEnumerable<int> floors)
    {
        Floors = floors;
    }

    public bool HasAccess(int floor)
    {
        return Floors.Any(r => r == floor);
    }
}