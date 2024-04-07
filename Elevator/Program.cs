using Elevator.Models;

namespace Elevator;

class Program
{
    static void Main(string[] args)
    {
        const string exit = "EXIT";
        
        var stories = GetTotalStories();
        var guestAccessibleFloors = GetGuestAccessibleFloors();

        var guest = new Person(guestAccessibleFloors);
        var elevator = new Models.Elevator(guest, stories);

        var typedFloor = string.Empty;
        while (!typedFloor.Equals(exit, StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine();
            Console.WriteLine($"The building has {stories} stories, please choose the floor you would like to go. Type {exit} to leave.");
            typedFloor = Console.ReadLine() ?? string.Empty;

            if (!string.IsNullOrEmpty(typedFloor) && int.TryParse(typedFloor, out var floor))
            {
                elevator.GoToFloor(floor);
            }
        }
        
        Console.WriteLine("Elevator back to floor 1. See you.");
    }

    private static int GetTotalStories()
    {
        const int defaultStories = 10;

        int stories;
        var typedStories = ReadTotalStories();

        while (string.IsNullOrEmpty(typedStories) || !int.TryParse(typedStories, out stories) || stories < defaultStories)
        {
            Console.WriteLine();
            Console.WriteLine($"Building stories cannot less than {defaultStories}, please type again.");
            typedStories = ReadTotalStories();
        }

        return stories;
    }

    private static string ReadTotalStories()
    {
        Console.WriteLine();
        Console.WriteLine("Enter Total Stories of the Building: ");
        return Console.ReadLine() ?? string.Empty;
    }

    private static int[] GetGuestAccessibleFloors()
    {
        var typedStories = ReadGuestAccessibleFloors();

        if (!string.IsNullOrEmpty(typedStories) && int.TryParse(typedStories, out var stories))
        {
            return Enumerable.Range(1, stories).ToArray();
        }

        return Array.Empty<int>(); // no access to the building
    }

    private static string ReadGuestAccessibleFloors()
    {
        Console.WriteLine("Enter Stories where Guest is accessible: ");
        return Console.ReadLine() ?? string.Empty;
    }
}