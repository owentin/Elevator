namespace Elevator.Models;

public class Elevator
{
    private readonly Person _person;
    private readonly int _totalStories;
    
    public Elevator(Person person, int totalStories)
    {
        _person = person;
        _totalStories = totalStories;
    }

    public void GoToFloor(int floor)
    {
        if (floor < 1 || floor > _totalStories)
        {
            Console.WriteLine($"No {floor} floor in the building");
        }
        else if (_person.HasAccess(floor))
        {
            Console.WriteLine($"Elevating to floor {floor}");
        }
        else
        {
            Console.WriteLine($"No Access to floor {floor}");
        }
    }
}