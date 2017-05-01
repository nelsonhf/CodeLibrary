using CodeLibrary;
using System;
using System.Collections.Generic;

public static class MangoSellers
{
    public static void Example()
    {
        var you = new Friend("You", false);
        var alice = new Friend("Alice", false);
        var anuj = new Friend("Anuj", false);
        var bob = new Friend("Bob", false);
        var claire = new Friend("Claire", false);
        var jonny = new Friend("Jonny", false);
        var peggy = new Friend("Peggy", false);
        var tom = new Friend("Tom", true);

        var graph = new Node<Friend, string>(you,
                        new Node<Friend, string>(alice,
                            new Node<Friend, string>(peggy)),
                        new Node<Friend, string>(bob,
                            new Node<Friend, string>(anuj),
                            new Node<Friend, string>(peggy)),
                        new Node<Friend, string>(claire,
                            new Node<Friend, string>(jonny),
                            new Node<Friend, string>(tom)));
        // Console.WriteLine(graph.Dump(0));

        var toCheck = new Queue<Node<Friend,string>>();
        toCheck.Enqueue(graph);
        var done = new List<string>(); // Remove duplicates
        while (toCheck.Count != 0)
        {
            var thisOne = toCheck.Dequeue();
            if (done.Contains(thisOne.Id)) continue;

            if (thisOne.ThisNode.SellsMango)
            {
                Console.WriteLine($"{thisOne.Id} sells mangoes!");
                break;
            }
            else
            {
                Console.WriteLine($"Bad Luck! {thisOne.Id} does not sell mangoes!");
            }

            done.Add(thisOne.Id);
            foreach (var node in thisOne.SubNodes)
            {
                toCheck.Enqueue(node);
            }
        }
    }

    // Define other methods and classes here
    private class Friend : IIdentifiable<string>
    {
        public string Id => Name;
        public string Name { get; private set; }
        public bool SellsMango { get; private set; }

        public Friend(string name, bool sellsMango)
        {
            Name = name;
            SellsMango = sellsMango;
        }
    }
}
