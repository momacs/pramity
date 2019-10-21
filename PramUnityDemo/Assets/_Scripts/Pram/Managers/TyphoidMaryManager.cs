using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pram.Entities;
using Pram.Data;

namespace Pram.Managers {
    public class TyphoidMaryManager : PramManager {
        int step = 0;

        public Text counter;
        int minute = 0;

        BoxSite s;

        public Text status;

        public float timeScale = 0.12f;

        bool hasStarted = false;
        
        private new void Start() {
            base.Start();
            s = gameObject.GetComponent<BoxSite>();
            //if (clock) { StartCoroutine(ClockTick()); }
        }

        override public void DefineGroups() {
            string[] siteNames = new string[] { "big_theater", "down_store1", "down_store2", "down_store3", "down_store4", "down_store5", "down_store6", "down_store7", "down_store8", "down_store9", "big_down_store10", "big_down_store11", "big_down_store12", "up_store1", "up_store2", "up_store3", "up_store4", "up_store5", "up_store6", "up_store7", "up_store8", "up_store9", "big_down_courtyard_1", "big_down_courtyard_2", "big_down_courtyard_3", "big_down_courtyard_4"};
            this.groups = new Group[siteNames.Length];

            for (int i = 0; i < siteNames.Length; i++) {
                Dictionary<string,string> rels = new Dictionary<string, string>();
                Dictionary<string, string> atts = new Dictionary<string, string>();
                atts.Add("flu-status", "s");
                if (siteNames[i].Contains("big")) {
                    this.groups[i] = new Group(atts, rels, siteNames[i], 10);
                } else {
                    this.groups[i] = new Group(atts, rels, siteNames[i], 5);
                }
            }

            //Because there are playable groups, this must be 1
            PramManager.instance.stepChunk = 1;
        }

        override public void DefineRules() {
            //this.rules = new string[] { "Mall Movement", "Mall Flu"};
            this.rules = new string[] { "Mall Flu" };
        }

        public override void NotifyPlayableGroupChange(PlayableAgent a) {
            string fluStatus = a.dominantGroup.attributes()["flu-status"];
            if (fluStatus.Equals("i")) {
                this.status.text = "Infected!";
                this.status.color = Color.green;
            } else if (fluStatus.Equals("r")) {
                this.status.text = "Recovered";
                this.status.color = Color.red;
            } else {
                this.status.text = "Susceptible";
                this.status.color = Color.blue;
            }
        }

        public override Vector3 GetPosition() {
            if (s == null) {
                s = gameObject.GetComponent<BoxSite>();
            }
            return s.GetPosition();
        }

        string FilledIn(int n) {
            if (n < 10) {
                return "0" + n;
            }
            return "" + n;
        }


        public void FixedUpdate() {
            /*if (!clock && Input.GetKeyDown(KeyCode.N)) {
                this.SimStep();
                step++;
                counter.text = "Step: " + step;
            }*/

            if (!hasStarted && Input.GetKeyDown(KeyCode.E)) {
                hasStarted = true;
                StartCoroutine("PramCycles");
            }
        }

        IEnumerator PramCycles() {
            while (true) {
                this.SimStep();
                yield return new WaitForSeconds(5);
            }
        }

    }
}
