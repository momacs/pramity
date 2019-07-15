using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {

    public class Redistribution : MonoBehaviour {
        public Group source;
        public Group destination;
        public double mass;

        public Redistribution(Group a, Group b, double n) {
            source = a;
            destination = b;
            mass = n;
        }
    }

}
