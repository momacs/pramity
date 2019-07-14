using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {

    public class PramInterface : MonoBehaviour {
        /// <summary>
        /// Singleton instance of this PramInterface
        /// </summary>
        public static PramInterface instance;
        /// <summary>
        /// A queue holding all recent runs passed through this pram interface
        /// </summary>
        private Queue<ProbeInfo> recentRuns;

        /// <summary>
        /// On awake, become a singleton
        /// </summary>
        void Awake() {
            if (instance == null) {
                instance = this;
            } else {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Run a pram simulation
        /// </summary>
        /// <param name="groups">The groups present at the start of the simulation.</param>
        /// <param name="rules">The rules that make up the simulation.</param>
        /// <param name="probe">The probe that defines which data is retrieved for each step of the simulation.</param>
        /// <param name="runCount">The number of 'steps' the simulation is run for. The length of time defining one 'step' is defined by the rules.</param>
        /// <returns>An array of ProbeInfos, representing the results given by the probe for the given number of steps.</returns>
        public ProbeInfo[] RunSimulation(Group[] groups, Rule[] rules, Probe probe, int runCount) {
            return null;
        }

        /// <summary>
        /// Returns a queue of recent results from RunSimulation. In theory, this can contain rows from several different probes from completely distinct groups and rules.
        /// </summary>
        /// <param name="maxCount">The maximum number of recent 'steps' to be returned. If -1 is given, it will return the entire queue.</param>
        /// <returns>A queue of ProbeInfos, representing the results of simulation runs.</returns>
        public Queue<ProbeInfo> GetRecentRuns(int maxCount) {
            Queue<ProbeInfo> returnQ = new Queue<ProbeInfo>(recentRuns.ToArray());

            if (maxCount == -1) { return returnQ; } 

            int diff = returnQ.Count - maxCount;

            while (diff > 0) {
                returnQ.Dequeue();
                diff--;
            }

            return returnQ;
        }

        /// <summary>
        /// Returns a queue of ALL recent results from RunSimulation. In theory, this can contain rows from several different probes from completely distinct groups and rules.
        /// </summary>
        /// <returns>A queue of ProbeInfos, representing the results of simulation runs.</returns>
        public Queue<ProbeInfo> GetRecentRuns() {
            return GetRecentRuns(-1);
        }
    }

}
