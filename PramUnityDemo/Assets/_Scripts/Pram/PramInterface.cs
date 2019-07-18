﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Pram {

    public class PramInterface : MonoBehaviour {
        string url = "http://127.0.0.1:5000/run_simulation";

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
            recentRuns = new Queue<ProbeInfo>();
        }

        /// <summary>
        /// Run a pram simulation
        /// </summary>
        /// <param name="groups">The groups present at the start of the simulation.</param>
        /// <param name="rules">The rules that make up the simulation.</param>
        /// <param name="probe">The probe that defines which data is retrieved for each step of the simulation.</param>
        /// <param name="runCount">The number of 'steps' the simulation is run for. The length of time defining one 'step' is defined by the rules.</param>
        /// <returns>An array of ProbeInfos, representing the results given by the probe for the given number of steps.</returns>
        public void RunSimulation(Group[] groups, Rule[] rules, Probe probe, int runCount) {
            WWWForm form = new WWWForm();

            string groups_s = JsonUtility.ToJson(groups);
            string rules_s = JsonUtility.ToJson(rules);
            string probe_s = JsonUtility.ToJson(probe);

            form.AddField("groups", groups_s);
            form.AddField("rules", rules_s);
            form.AddField("probe", probe_s);
            form.AddField("runs", runCount);

            StartCoroutine(RunSimulation(form));
        }


        IEnumerator RunSimulation(WWWForm form) {
            // Create a download object
            var download = UnityWebRequest.Post(url, form);

            // Wait until the download is done
            yield return download.SendWebRequest();

            if (download.isNetworkError || download.isHttpError) {
                print("Error downloading: " + download.error);
            } else {
                //Get data returned from post request
                //TODO: Handle this returned data (parse it into ProbeInfo[])
                Debug.Log(download.downloadHandler.text);
            }
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
        /// Dequeues a single ProbeInfo from the queue
        /// </summary>
        /// <returns>The ProbeInfo that was dequeued</returns>
        public ProbeInfo DequeueRecentRun() {
            return recentRuns.Dequeue();
        }

        /// <summary>
        /// Clear the recent run queue
        /// </summary>
        public void ClearRunQueue() {
            recentRuns.Clear();
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
