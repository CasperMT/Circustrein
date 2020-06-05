using System;
using System.Collections.Generic;

namespace Circustrein {
    class Program {
        static void Main(string[] args) {

            List<Animal> animals = new List<Animal>();
            animals.Add(new Animal("Leeuw", true, Sizes.Large));
            animals.Add(new Animal("Leeuw", true, Sizes.Large));
            animals.Add(new Animal("Spin", true, Sizes.Small));
            animals.Add(new Animal("Spin", true, Sizes.Small));
            animals.Add(new Animal("Giraffe", false, Sizes.Large));
            animals.Add(new Animal("Giraffe", false, Sizes.Large));

            Sorter sorter = new Sorter(animals);
            List<Wagon> wagons = sorter.Sort();
            foreach (Wagon w in wagons) {
                Console.WriteLine("Wagon");
                foreach (Animal a in w.GetAnimals()) {
                    Console.WriteLine($"{a.Name}:{a.EatsMeat}:{a.Size}");
                }

                Console.WriteLine();
            }

        }
    }
}
