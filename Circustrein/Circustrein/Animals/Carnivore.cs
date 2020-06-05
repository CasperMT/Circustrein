using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein.Animals {
    public class Carnivore : IAnimal {
        public Sizes Size { get; set; }

        public Carnivore(Sizes size) {
            this.Size = size;
        }
    }
}
