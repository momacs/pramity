using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {

    public abstract class PramManager : MonoBehaviour {

        public static PramManager instance;
        public string[] rules;
        public Group[] groups;
        public int time = 0;

        public int stepChunk = 10;

        public void Awake() {
            if(PramManager.instance != null) { Destroy(PramManager.instance); }
            instance = this;
        }

        public void Start() {
            this.DefineGroups();
            this.DefineRules();
            GroupManager.instance.InitializeGroupConfigurations();
            GroupManager.instance.InitializeGroups(this.groups);
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
        /// Defines the position of the default site.
        /// </summary>
        /// <returns></returns>
        public abstract Vector3 GetPosition();

        /// <summary>
        /// Takes the parameters of the simulation defined in this class and sends them to the pram interface to run the simulation.
        /// </summary>
        /// <param name="steps"></param>
        public void RunSimulation(int steps) {
            groups = GroupManager.instance.GetGroups();
            PramInterface.instance.RunSimulation(groups, rules, steps, time);
        }

        /// <summary>
        /// Gets the next step of the simulation and updates groups based on it. This is for when nothing external to pram is going to affect group populations.
        /// </summary>
        public bool SimStep() {
            RedistributionSet recent = PramInterface.instance.DequeueRecentRun();

            if (recent == null) {
                this.RunSimulation(stepChunk);
                StartCoroutine(WaitAndUpdateGroups());
                return false;
            }

            GroupManager.instance.UpdateGroups(recent);
            return true;
        }

        IEnumerator WaitAndUpdateGroups() {
            RedistributionSet recent = PramInterface.instance.DequeueRecentRun();
            while (recent == null) {
                yield return new WaitForFixedUpdate();
                recent = PramInterface.instance.DequeueRecentRun();
            }

            GroupManager.instance.UpdateGroups(recent);
        }

        /// <summary>
        /// Run the simulation for exactly one step based on the current populations of the groups. This is for when something external to pram is going to affect group population.
        /// </summary>
        public void DiscreteSimStep() {
            PramInterface.instance.ClearRunQueue();
            RedistributionSet recent = PramInterface.instance.DequeueRecentRun();
            this.RunSimulation(1);
            recent = PramInterface.instance.DequeueRecentRun();
            GroupManager.instance.UpdateGroups(recent);
        }
    }

}
