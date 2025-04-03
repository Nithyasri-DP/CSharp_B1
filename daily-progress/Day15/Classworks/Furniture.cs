using System;
namespace AssignmentFour
{
    // Abstract class
    abstract class Furniture
    {
        public string Material { get; set; }
        public string Color { get; set; }
        public Furniture(string material, string color)
        {
            Material = material;
            Color = color;
        }
        public abstract void DisplayDetails();
    }
    // Chair class inheriting from Furniture
    class Chair : Furniture
    {
        public int Legs { get; set; }
        public Chair(string material, string color, int legs) : base(material, color)
        {
            Legs = legs;
        }
        public override void DisplayDetails()
        {
            Console.WriteLine($"Chair -> Material: {Material}, Color: {Color}, Legs: {Legs}");
        }
    }
    // Bookshelf class inheriting from Furniture
    class Bookshelf : Furniture
    {
        public int Shelves { get; set; }
        public Bookshelf(string material, string color, int shelves) : base(material, color)
        {
            Shelves = shelves;
        }
        public override void DisplayDetails()
        {
            Console.WriteLine($"Bookshelf -> Material: {Material}, Color: {Color}, Shelves: {Shelves}");
        }
    }
    // Main program
    class Furnitures
    {
        public static void furni()
        {
            Chair chair = new Chair("Wood", "Brown", 4);
            Bookshelf bookshelf = new Bookshelf("Metal", "Black", 5);
            // Viewing details
            chair.DisplayDetails();
            bookshelf.DisplayDetails();
        }
    }
}
