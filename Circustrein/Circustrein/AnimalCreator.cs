using Circustrein.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein {
    public class AnimalCreator {

        public static Carnivore CreateCarnivore(Sizes size) {
            return new Carnivore(size);
        }

        public static Herbivore CreateHerbivore(Sizes size) {
            return new Herbivore(size);
        }


    }
}
