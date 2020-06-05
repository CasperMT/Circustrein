using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein {
    public class Sorter {

        List<Animal> animals;
        List<Wagon> wagons;

        List<Animal> animalsPlantLarge = new List<Animal>();
        List<Animal> animalsPlantMiddle = new List<Animal>();
        List<Animal> animalsPlantSmall = new List<Animal>();

        List<Animal> animalsMeatMiddle = new List<Animal>();
        List<Animal> animalsMeatSmall = new List<Animal>();

        public Sorter(List<Animal> animals) {
            this.animals = animals;
            this.wagons = new List<Wagon>();
        }

        public List<Wagon> Sort() {
            
            foreach (Animal a in animals) {
                if (a.EatsMeat && a.Size == Sizes.Large) {
                    this.wagons.Add(new Wagon(a));
                }

                if (!a.EatsMeat && a.Size == Sizes.Large) {
                    animalsPlantLarge.Add(a);
                }
                if (!a.EatsMeat && a.Size == Sizes.Middle) {
                    animalsPlantMiddle.Add(a);
                }
                if (!a.EatsMeat && a.Size == Sizes.Small) {
                    animalsPlantSmall.Add(a);
                }

                if (a.EatsMeat && a.Size == Sizes.Middle) {
                    animalsMeatMiddle.Add(a);
                }
                if (a.EatsMeat && a.Size == Sizes.Small) {
                    animalsMeatSmall.Add(a);
                }

            }

            MiddedleMeatAnimal();
            SmallMeatAnimal();
            LargePlantAnimal();
            MiddlePlantAnimal();
            SmallPlantAnimal();

            return this.wagons;
        }

        private void MiddedleMeatAnimal() {
            foreach (Animal a in animalsMeatMiddle) {
                if(this.wagons[this.wagons.Count - 1].AddAnimal(a)) {
                    
                } else {
                    this.wagons.Add(new Wagon(a));
                }
            }
        }

        private void SmallMeatAnimal() {
            foreach (Animal a in animalsMeatSmall) {
                if (!CheckIfSpace(a)) {
                    this.wagons.Add(new Wagon(a));
                }
            }
        }

        private void LargePlantAnimal() {
            foreach (Animal a in animalsPlantLarge) {
                if (!CheckIfSpace(a)) {
                    this.wagons.Add(new Wagon(a));
                }
            }
        }

        private void MiddlePlantAnimal() {
            foreach (Animal a in animalsPlantMiddle) {
                if (!CheckIfSpace(a)) {
                    this.wagons.Add(new Wagon(a));
                }
            }
        }

        private void SmallPlantAnimal() {
            foreach (Animal a in animalsPlantSmall) {
                if (!CheckIfSpace(a)) {
                    this.wagons.Add(new Wagon(a));
                }
            }
        }

        private bool CheckIfSpace(Animal a) {
            bool space = false;
            foreach (Wagon w in this.wagons) {
                if (w.AddAnimal(a)) {
                    space = true;
                    break;
                }
            }
            return space;
        }

    }

    
}
