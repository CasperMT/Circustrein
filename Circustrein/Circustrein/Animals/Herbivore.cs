using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein.Animals {
    public class Herbivore : IAnimal {
        public Sizes Size { get; set; }

        public Herbivore(Sizes size) {
            this.Size = size;
        }
    }
}
