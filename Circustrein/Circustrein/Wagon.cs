using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein {
    public class Wagon {
        List<Animal> animals;
        Animal largestAnimal;

        bool containsMeatEater;
        private int points;

        public Wagon() {
            animals = new List<Animal>();
            points = 0;
        }

        public Wagon(Animal animal) {
            animals = new List<Animal>();
            AddHandler(animal);

            if (animal.EatsMeat && animal.Size == Sizes.Large) {
                SetFull();
            }
        }
        
        public List<Animal> GetAnimals() {
            return this.animals;
        }

        public bool AddAnimal(Animal animal) {
            if (((10-points) - animal.Size) >= 0) {
                if (animal.EatsMeat) {
                    if (!containsMeatEater) {
                        AddHandler(animal);
                        return true;
                    } else {
                        return false;
                    }
                } else if (largestAnimal == null) {
                    AddHandler(animal);
                    return true;
                } else if ((int)animal.Size > (int)largestAnimal.Size) {
                    AddHandler(animal);
                    return true;
                } else {
                    return false;
                }    
            } else {
                return false;
            }
            
        }

        private void AddHandler(Animal animal) {
            if (animal.EatsMeat) {
                containsMeatEater = true;
                largestAnimal = animal;
            }

            this.animals.Add(animal);
            points += (int)animal.Size;
        }

        private void SetFull() {
            points = 10;
        }

    
    }
}
