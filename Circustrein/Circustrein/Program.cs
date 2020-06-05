using Circustrein.Animals;
using System;
using System.Collections.Generic;

namespace Circustrein {
    class Program {
        static void Main(string[] args) {

            List<IAnimal> animals = new List<IAnimal>();
            animals.Add(AnimalCreator.CreateCarnivore(Sizes.Large));
            animals.Add(AnimalCreator.CreateCarnivore(Sizes.Small));
            animals.Add(AnimalCreator.CreateCarnivore(Sizes.Small));
            animals.Add(AnimalCreator.CreateHerbivore(Sizes.Large));
            animals.Add(AnimalCreator.CreateHerbivore(Sizes.Middle));
            animals.Add(AnimalCreator.CreateHerbivore(Sizes.Middle));

            Sorter sorter = new Sorter(animals);
            List<Wagon> wagons = sorter.Sort();


            foreach (Wagon wagon in wagons) {
                Console.WriteLine("Wagon");
                foreach (IAnimal animal in wagon.Animals) {
                    if (animal is Carnivore) {
                        Console.WriteLine($"Carnivore {animal.Size}");
                    } else {
                        Console.WriteLine($"Herbivore {animal.Size}");
                    }
                    
                }

                Console.WriteLine();
            }

        }
    }
}
