using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {

    public class ProbeInfo {
        public Redistribution[] redistributions;
        public Rule[] rules;
        public int steps;

        public ProbeInfo(Redistribution[] r) {
            this.redistributions = r;
            this.rules = null;
            this.steps = 1;
        }
    }

}