using Circustrein.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein {
    public class Wagon {
        public List<IAnimal> Animals { get; set; } = new List<IAnimal>();
        public int Capacity { get; set; }
        private Carnivore CarnivoreInWagon;

        public Wagon() {
            Capacity = 10;
        }

        public Wagon(IAnimal animal) {
            if (animal is Carnivore) {
                CarnivoreInWagon = (Carnivore)animal;
            }

            AddHandler(animal);
        }
       
        public bool AddAnimal(IAnimal animal) {
            bool added = false;

            if (Capacity > (int)animal.Size) {
                if (animal is Carnivore) {
                    if (CarnivoreInWagon == null) {
                        AddHandler(animal);
                        added = true;
                    }
                } else {
                    if (CarnivoreInWagon == null) {
                        AddHandler(animal);
                        added = true;
                    } else {
                        if (animal.Size > CarnivoreInWagon.Size) {
                            AddHandler(animal);
                            added = true;
                        }
                    }
                    
                }
            }

            return added;
        }

        private void AddHandler(IAnimal animal) {
            if (animal is Carnivore) {
                CarnivoreInWagon = (Carnivore)animal;
            }

            Animals.Add(animal);
            Capacity -= (int)animal.Size;
        }
    
    }
}
