using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram.Data {
    [System.Serializable]
    public class Redistribution {
        public Group source;
        public Group destination;
        public double mass;

        public Redistribution(Group a, Group b, double n) {
            source = a;
            destination = b;
            mass = n;
        }

        public string ToString() {
            if (source == null) {
                return "{ Source: null,\n Destination: " + destination.ToString() + ",\n Mass: " + mass + "}";
            }
            return "{ Source: " + source.ToString() + ",\n Destination: " + destination.ToString() + ",\n Mass: " + mass + "}";
        }
    }

}
