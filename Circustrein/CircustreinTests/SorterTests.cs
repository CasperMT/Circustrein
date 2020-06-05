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

        
    }
}
