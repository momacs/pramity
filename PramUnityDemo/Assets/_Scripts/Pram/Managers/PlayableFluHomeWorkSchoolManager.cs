using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pram.Entities;
using Pram.Data;

namespace Pram.Managers {
    public class PlayableFluHomeWorkSchoolManager : PramManager {
        int step = 0;

        public Text counter;
        public bool clock = false;
        int minute = 0;
        int hour = 0;
        public Transform theSun;

        BoxSite s;

        public Text status;

        public float timeScale = 0.12f;
        
        private new void Start() {
            base.Start();
            s = gameObject.GetComponent<BoxSite>();
            if (clock) { StartCoroutine(ClockTick()); }
        }

        override public void DefineGroups() {
            Dictionary<string, string> g1Relations = new Dictionary<string, string>();
            Dictionary<string, string> g2Relations = new Dictionary<string, string>();
            Dictionary<string, string> g3Relations = new Dictionary<string, string>();
            Dictionary<string, string> g4Relations = new Dictionary<string, string>();

            g1Relations.Add("home", "home");
            g1Relations.Add("work", "work-a");
            g1Relations.Add("store", "store-a");

            g2Relations.Add("home", "home");
            g2Relations.Add("work", "work-b");
            g2Relations.Add("store", "store-b");

            g3Relations.Add("home", "home");
            g3Relations.Add("work", "work-c");

            Dictionary<string, string> g1Attributes = new Dictionary<string, string>();
            Dictionary<string, string> g2Attributes = new Dictionary<string, string>();
            Dictionary<string, string> g3Attributes = new Dictionary<string, string>();
            Dictionary<string, string> g4Attributes = new Dictionary<string, string>();

            g1Attributes.Add("flu-status", "s");
            g2Attributes.Add("flu-status", "s");
            g3Attributes.Add("flu-status", "s");
            g4Attributes.Add("flu-status", "s");
            g4Attributes.Add("playable", "yes");

            Group g1 = new Group(g1Attributes, g1Relations, "home", 100);
            Group g2 = new Group(g2Attributes, g2Relations, "home", 100);
            Group g3 = new Group(g3Attributes, g3Relations, "home", 10);
            Group g4 = new Group(g4Attributes, g4Relations, "", 1);

            this.groups = new Group[] { g1, g2, g3, g4 };
        }

        override public void DefineRules() {
            this.rules = new string[] { "Home-Work-School Rules", "Simple Flu Progress Rule" };
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

        IEnumerator ClockTick() {
            while (true) {
                if (minute == 30) {
                    this.SimStep();
                }
                counter.text = FilledIn(hour) + ":" + FilledIn(minute);
                yield return new WaitForSeconds(timeScale);
                float spinD = ((minute + hour * 60f) / 1440.0f) * 360f;
                theSun.eulerAngles = new Vector3(spinD-90, 0f, 0f);
                minute++;
                if (minute == 60) {
                    minute = 0;
                    hour++;
                    if (hour == 24) {
                        hour = 0;
                    }
                    this.time = hour;
                }
            }
        }

        public void Update() {
            if (!clock && Input.GetKeyDown(KeyCode.N)) {
                this.SimStep();
                step++;
                counter.text = "Step: " + step;
            }
        }

    }
}
