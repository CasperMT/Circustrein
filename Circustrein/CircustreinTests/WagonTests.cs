using Circustrein;
using Circustrein.Animals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CircustreinTests {

    [TestClass]
    public class WagonTests {

        private Wagon wagon;

        [TestInitialize]
        public void Setup() {
            this.wagon = new Wagon();
        }

        [TestMethod]
        public void ConctructorAddsAnimal() {
            Carnivore animal = AnimalCreator.CreateCarnivore(Sizes.Large);

            wagon = new Wagon(animal);

            Assert.IsTrue(wagon.Animals.Contains(animal));
        }

        [TestMethod]
        public void WagonIsCreated() {
            Wagon wagon = new Wagon();

            Assert.IsNotNull(wagon);
        }

        [TestMethod]
        public void CanAddAnimal() {
            Carnivore animal = AnimalCreator.CreateCarnivore(Sizes.Large);

            wagon.AddAnimal(animal);

            Assert.IsTrue(wagon.Animals.Contains(animal));
        }

        [TestMethod]
        public void NoSmallerHerbivoreWithCarnivore() {
            wagon.AddAnimal(AnimalCreator.CreateCarnivore(Sizes.Large));

            Assert.IsFalse(wagon.AddAnimal(AnimalCreator.CreateHerbivore(Sizes.Middle)));
        }

        [TestMethod]
        public void NoCarnivoresTogether() {
            wagon.AddAnimal(AnimalCreator.CreateCarnivore(Sizes.Large));

            Assert.IsFalse(wagon.AddAnimal(AnimalCreator.CreateCarnivore(Sizes.Middle)));
        }

        [TestMethod]
        public void CapacityLowers() {
            int capacity = wagon.Capacity;

            wagon.AddAnimal(AnimalCreator.CreateCarnivore(Sizes.Large));

            Assert.IsTrue(wagon.Capacity < capacity);
        }

        [TestMethod]
        public void MaxCapacity() {
            double capacity = (double)wagon.Capacity;
            int amountOfAnimals = Convert.ToInt32(Math.Floor(capacity / (double)Sizes.Small));

            for (int i=0; i < amountOfAnimals; i++) {
                wagon.AddAnimal(AnimalCreator.CreateHerbivore(Sizes.Small));
            }

            Assert.IsFalse(wagon.AddAnimal(AnimalCreator.CreateHerbivore(Sizes.Small)));
        }

        [TestMethod]
        public void AddHandlerAddsAnimal() {
            
        }

    }
}
