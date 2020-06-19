using Circustrein;
using Circustrein.Animals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CircustreinTests {

    [TestClass]
    public class SorterTests {

        private Sorter sorter;


        [TestMethod]
        public void IsWagonListCreated() {
            List<IAnimal> animals = new List<IAnimal>();
            animals.Add(AnimalCreator.CreateHerbivore(Sizes.Middle));
            sorter = new Sorter(animals);

            Assert.IsNotNull(sorter.wagons);
        }

        [TestMethod]
        public void AddsAnimalsToList() {
            List<IAnimal> animals = new List<IAnimal>();
            animals.Add(AnimalCreator.CreateHerbivore(Sizes.Middle));
            animals.Add(AnimalCreator.CreateHerbivore(Sizes.Middle));
            animals.Add(AnimalCreator.CreateHerbivore(Sizes.Middle));

            sorter = new Sorter(animals);

            foreach (IAnimal animal in animals) {
                Assert.IsTrue(sorter.Animals.Contains(animal));
            }
        }

        [TestMethod]
        public void OptimalSort() {
            List<IAnimal> animals = new List<IAnimal>();
            animals.Add(AnimalCreator.CreateCarnivore(Sizes.Large));
            animals.Add(AnimalCreator.CreateCarnivore(Sizes.Small));
            animals.Add(AnimalCreator.CreateCarnivore(Sizes.Small));
            animals.Add(AnimalCreator.CreateHerbivore(Sizes.Large));
            animals.Add(AnimalCreator.CreateHerbivore(Sizes.Middle));
            animals.Add(AnimalCreator.CreateHerbivore(Sizes.Middle));

            sorter = new Sorter(animals);
            List<Wagon> wagons = sorter.Sort();

            //Wagon 1
            Assert.IsTrue(wagons[0].Animals[0] is Carnivore);
            Assert.AreEqual(wagons[0].Animals[0].Size, Sizes.Large);

            //Wagon 2
            Assert.IsTrue(wagons[1].Animals[0] is Carnivore);
            Assert.AreEqual(wagons[1].Animals[0].Size, Sizes.Small);
            Assert.IsTrue(wagons[1].Animals[1] is Herbivore);
            Assert.AreEqual(wagons[1].Animals[1].Size, Sizes.Large);
            Assert.IsTrue(wagons[1].Animals[2] is Herbivore);
            Assert.AreEqual(wagons[1].Animals[2].Size, Sizes.Middle);

            //Wagon 4
            Assert.IsTrue(wagons[2].Animals[0] is Carnivore);
            Assert.AreEqual(wagons[2].Animals[0].Size, Sizes.Small);
            Assert.IsTrue(wagons[2].Animals[1] is Herbivore);
            Assert.AreEqual(wagons[2].Animals[1].Size, Sizes.Middle);
        }

    }
}
