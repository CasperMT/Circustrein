using Circustrein;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircustreinTests {

    [TestClass]
    public class WagonTests {

        private Wagon wagon;

        [TestInitialize]
        public void Setup() {
            this.wagon = new Wagon();
        }

        [TestMethod]
        public void WagonIsCreated() {
            Wagon wagon = new Wagon();

            Assert.IsNotNull(wagon);
        }

        [TestMethod]
        public void CanAddAnimal() {
            Animal animal = new Animal("Leeuw", true, Sizes.Large);

            this.wagon.AddAnimal(animal);

            Assert.IsTrue(this.wagon.GetAnimals().Contains(animal));
        }

        [TestMethod]
        public void NoSmallerPlantWithMeat() {
            Animal animal = new Animal("Leeuw", true, Sizes.Large);
            this.wagon.AddAnimal(animal);

            bool added = this.wagon.AddAnimal(new Animal("Giraffe", false, Sizes.Large));

            Assert.IsFalse(added);
        }

        [TestMethod]
        public void MaxCapacity() {
            this.wagon.AddAnimal(new Animal("Giraffe", false, Sizes.Large));
            this.wagon.AddAnimal(new Animal("Giraffe", false, Sizes.Large));

            bool added = this.wagon.AddAnimal(new Animal("Giraffe", false, Sizes.Large));

            Assert.IsFalse(added);
        }


    }
}
