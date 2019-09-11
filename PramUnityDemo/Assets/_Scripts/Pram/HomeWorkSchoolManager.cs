using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pram {
    public class HomeWorkSchoolManager : PramManager {

        int step = 0;
        public Text counter;
        BoxSite s;

        private new void Start() {
            base.Start();
            s = gameObject.GetComponent<BoxSite>();
        }

        override public void DefineGroups() {
            Dictionary<string, string> g1Relations = new Dictionary<string, string>();
            Dictionary<string, string> g2Relations = new Dictionary<string, string>();
            Dictionary<string, string> g3Relations = new Dictionary<string, string>();

            g1Relations.Add("Site.AT", "home");
            g1Relations.Add("home", "home");
            g1Relations.Add("work", "work-a");
            g1Relations.Add("store", "store-a");

            g2Relations.Add("Site.AT", "home");
            g2Relations.Add("home", "home");
            g2Relations.Add("work", "work-b");
            g2Relations.Add("store", "store-b");

            g3Relations.Add("Site.AT", "home");
            g3Relations.Add("home", "home");
            g3Relations.Add("work", "work-c");

            Group g1 = new Group(g1Relations, "home", 1000);
            Group g2 = new Group(g2Relations, "home", 1000);
            Group g3 = new Group(g3Relations, "home", 100);

            this.groups = new Group[] { g1, g2, g3 };
        }

        override public void DefineRules() {
            this.rules = new string[] { "Home-Work-School Rules" };
        }

        public override Vector3 GetPosition() {
            if (s == null) {
                s = gameObject.GetComponent<BoxSite>();
            }
            return s.GetPosition();
        }

        public void Update() {
            if (Input.GetKeyDown(KeyCode.N)) {
                bool success = this.SimStep();
                if (success) {
                    step++;
                    counter.text = "Step: " + step;
                }
            }
        }

    }
}
