using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {

    public abstract class PramManager : MonoBehaviour {

        public static PramManager instance;
        Rule[] rules;
        Group[] groups;
        Probe probe;

        public int stepChunk = 10;

        private void Awake() {
            if(PramManager.instance != null) { Destroy(PramManager.instance); }
            instance = this;
        }

        public abstract void DefineGroups();
        public abstract void DefineRules();
        public abstract void DefineProbe();

        public void RunSimulation(int steps) {
            PramInterface.instance.RunSimulation(groups, rules, probe, steps);
        }

        /// <summary>
        /// TODO - make grab from PramInterface and update groups
        /// </summary>
        public void SimStep() {

        }

    }

}
