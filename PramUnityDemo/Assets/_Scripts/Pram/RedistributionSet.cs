using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {
    [System.Serializable]
    public class RedistributionSet {
        public Redistribution[] redistributions;

        public RedistributionSet(Redistribution[] r) {
            redistributions = r;
        }

        public string ToString() {
            string s = "";
            foreach (Redistribution r in redistributions) {
                s += r.ToString() + "\n";
            }
            return s;
        }
    }
}
