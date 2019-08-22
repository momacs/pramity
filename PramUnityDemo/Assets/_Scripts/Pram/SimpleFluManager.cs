using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pram {
    public class SimpleFluManager : PramManager {

        /*private void Awake() {
            base.Awake();
        }

        private void Start() {
            base.Start();
        }*/

        int step = 0;
        public Text counter;

        override public void DefineGroups() {
            Dictionary<string, string> g1Attributes = new Dictionary<string, string>();
            Dictionary<string, string> g2Attributes = new Dictionary<string, string>();
            Dictionary<string, string> g3Attributes = new Dictionary<string, string>();

            g1Attributes.Add("flu-status", "s");
            g2Attributes.Add("flu-status", "i");
            g3Attributes.Add("flu-status", "r");

            Group g1 = new Group(g1Attributes, "", 1000);
            Group g2 = new Group(g2Attributes, "", 0);
            Group g3 = new Group(g3Attributes, "", 0);

            this.groups = new Group[] { g1, g2, g3 };
        }

        override public void DefineRules() {
            Rule r1 = new Rule("Simple Flu Progress Rule");
            this.rules = new Rule[] { r1 };
        }

        public override Vector3 GetPosition() {
            return transform.position;
        }

        public void Update() {
            if (Input.GetKeyDown(KeyCode.N)) {
                this.SimStep();
                step++;
                counter.text = "Step: " + step;
            }
        }

    }
}
