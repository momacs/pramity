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

        /// <summary>
        /// Creates the groups specific to this simulation
        /// </summary>
        public abstract void DefineGroups();

        /// <summary>
        /// Creates the rules specific to this simulation
        /// </summary>
        public abstract void DefineRules();

        /// <summary>
        /// Creates the probe specific to this simulation
        /// </summary>
        public abstract void DefineProbe();

        /// <summary>
        /// Takes the parameters of the simulation defined in this class and sends them to the pram interface to run the simulation.
        /// </summary>
        /// <param name="steps"></param>
        public void RunSimulation(int steps) {
            groups = GroupManager.instance.GetGroups();
            PramInterface.instance.RunSimulation(groups, rules, probe, steps);
        }

        /// <summary>
        /// Gets the next step of the simulation and updates groups based on it. This is for when nothing external to pram is going to affect group populations.
        /// </summary>
        public void SimStep() {
            ProbeInfo recent = PramInterface.instance.DequeueRecentRun();

            if (recent == null) {
                this.RunSimulation(stepChunk);
                recent = PramInterface.instance.DequeueRecentRun();
            }

            GroupManager.instance.UpdateGroups(recent);
        }

        /// <summary>
        /// Run the simulation for exactly one step based on the current populations of the groups. This is for when something external to pram is going to affect group population.
        /// </summary>
        public void DiscreteSimStep() {
            PramInterface.instance.ClearRunQueue();
            ProbeInfo recent = PramInterface.instance.DequeueRecentRun();
            this.RunSimulation(1);
            recent = PramInterface.instance.DequeueRecentRun();
            GroupManager.instance.UpdateGroups(recent);
        }
    }

}
