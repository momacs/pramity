using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pram {
    public class FluHomeWorkSchoolManager : PramManager {

        int step = 0;
        public Text counter;
        BoxSite s;
        public bool clock = false;
        int minute = 0;
        int hour = 0;
        public Transform theSun;

        private new void Start() {
            base.Start();
            s = gameObject.GetComponent<BoxSite>();
            if (clock) { StartCoroutine(ClockTick()); }
        }

        override public void DefineGroups() {
            Dictionary<string, string> g1Relations = new Dictionary<string, string>();
            Dictionary<string, string> g2Relations = new Dictionary<string, string>();
            Dictionary<string, string> g3Relations = new Dictionary<string, string>();

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

            g1Attributes.Add("flu-status", "s");
            g2Attributes.Add("flu-status", "s");
            g3Attributes.Add("flu-status", "s");

            Group g1 = new Group(g1Attributes, g1Relations, "home", 1000);
            Group g2 = new Group(g2Attributes, g2Relations, "home", 1000);
            Group g3 = new Group(g3Attributes, g3Relations, "home", 100);

            this.groups = new Group[] { g1, g2, g3 };
        }

        override public void DefineRules() {
            this.rules = new string[] { "Home-Work-School Rules", "Simple Flu Progress Rule" };
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
                yield return new WaitForSeconds(0.12f);
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
                bool success = this.SimStep();
                if (success) {
                    step++;
                    counter.text = "Step: " + step;
                }
            }
        }

    }
}
