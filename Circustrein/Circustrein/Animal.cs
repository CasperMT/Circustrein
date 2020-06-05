using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein {
    public class Animal {

        public bool EatsMeat { get; private set; }
        public Sizes Size { get; private set; }
        public string Name { get; private set; }
        public Animal(string name, bool eats, Sizes size) {
            this.Name = name;
            this.EatsMeat = eats;
            this.Size = size;
        }

    }
}
