using Circustrein.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Circustrein {
    public class Sorter {

        public List<IAnimal> Animals { get; private set; } = new List<IAnimal>();
        public List<Wagon> wagons { get; private set; }


        public Sorter(List<IAnimal> animals) {
            wagons = new List<Wagon>();
            this.Animals = animals;
        }

        public List<Wagon> Sort() {

            foreach (IAnimal animal in (from animal in Animals where animal is Carnivore && animal.Size == Sizes.Large select animal)) {
                this.wagons.Add(new Wagon(animal));
            }

            SortAnimalList((from animal in Animals where animal is Carnivore && animal.Size == Sizes.Middle select animal).ToList());
            SortAnimalList((from animal in Animals where animal is Carnivore && animal.Size == Sizes.Small select animal).ToList());
            SortAnimalList((from animal in Animals where animal is Herbivore && animal.Size == Sizes.Large select animal).ToList());
            SortAnimalList((from animal in Animals where animal is Herbivore && animal.Size == Sizes.Middle select animal).ToList());
            SortAnimalList((from animal in Animals where animal is Herbivore && animal.Size == Sizes.Small select animal).ToList());

            return wagons;
        }

        private void SortAnimalList(List<IAnimal> animals) {
            foreach (IAnimal a in animals) {
                if (!CheckIfSpace(a)) {
                    this.wagons.Add(new Wagon(a));
                }
            }
        }

        private bool CheckIfSpace(IAnimal animal) {
            bool space = false;
            foreach (Wagon wagon in this.wagons) {
                if (wagon.AddAnimal(animal)) {
                    space = true;
                    break;
                }
            }
            return space;
        }

    }

    
}
