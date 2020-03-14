using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pram.Entities;
using Pram.Data;
using TMPro;
using UnityEngine.SceneManagement;

namespace Pram.Managers {
    public class TyphoidMaryManager : PramManager {
        int step = 0;
        int minute = 0;

        BoxSite s;

        public float timeScale = 0.12f;

        bool hasStarted = false;

        public TextMeshProUGUI txt;

        Coroutine running;

        List<GameObject> objects;
        public GameObject collectibleParent;

        bool ending = false;

        private new void Start() {
            base.Start();
            s = gameObject.GetComponent<BoxSite>();

            objects = new List<GameObject>();
            for (int i = 0; i < collectibleParent.transform.childCount; i++) {
                objects.Add(collectibleParent.transform.GetChild(i).gameObject);
            }

            for (int i = 0; i < 10; i++) {
                int index = Random.Range(0, objects.Count);
                GameObject tmp = objects[index];
                objects.RemoveAt(index);
                Destroy(tmp);
            }

            Time.timeScale = 0f;
        }

        override public void DefineGroups() {
            string[] siteNames = new string[] { "big_theater", "down_store1", "down_store2", "down_store3", "down_store4", "down_store5", "down_store6", "down_store7", "down_store8", "down_store9", "big_down_store10", "big_down_store11", "big_down_store12", "up_store1", "up_store2", "up_store3", "up_store4", "up_store5", "up_store6", "up_store7", "up_store8", "up_store9", "big_down_courtyard_1", "big_down_courtyard_2", "big_down_courtyard_3", "big_down_courtyard_4"};
            this.groups = new Group[siteNames.Length + 1];

            for (int i = 0; i < siteNames.Length; i++) {
                Dictionary<string,string> rels = new Dictionary<string, string>();
                Dictionary<string, string> atts = new Dictionary<string, string>();
                atts.Add("flu-status", "s");
                atts.Add("playable", "no");
                if (siteNames[i].Contains("big")) {
                    this.groups[i] = new Group(atts, rels, siteNames[i], 10);
                } else {
                    this.groups[i] = new Group(atts, rels, siteNames[i], 5);
                }
            }

            //One infected person
            Dictionary<string, string> infectedAtts = new Dictionary<string, string>();
            infectedAtts.Add("flu-status", "i");
            infectedAtts.Add("playable", "no");
            this.groups[this.groups.Length - 1] = new Group(infectedAtts, new Dictionary<string, string>(), siteNames[(int)(Random.value * siteNames.Length)], 1);

            //Because there are playable groups, this must be 1
            PramManager.instance.stepChunk = 1;
        }

        override public void DefineRules() {
            //this.rules = new string[] { "Mall Movement", "Mall Flu"};
            this.rules = new string[] { "Mall Flu", "Playable Mall Flu" };
        }

        public override void NotifyPlayableGroupChange(PlayableAgent a) {
            string fluStatus = a.dominantGroup.attributes()["flu-status"];
            if (fluStatus.Equals("i")) {
                txt.text = "<b><color=red>YOU'VE BEEN INFECTED!</color></b>\n\n";
                EndGame();
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


        public void Update() {
            if (!hasStarted && Input.GetKeyDown(KeyCode.E)) {
                Time.timeScale = 1;
                txt.text = "";
                hasStarted = true;
                running = StartCoroutine("PramCycles");
            }

            if (ending && Input.GetKeyDown(KeyCode.E)) {
                Time.timeScale = 1;
                txt.text = "";
                ending = false;
            }

            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        public void RemoveObject(GameObject obj) {
            objects.Remove(obj);
            Destroy(obj);

            if (objects.Count <= 0) {
                txt.text = "<b><color=green>YOU DIDN'T GET INFECTED!</color></b>\n\n";
                EndGame();
            }
        }

        IEnumerator PramCycles() {
            while (true) {
                this.SimStep();
                yield return new WaitForSeconds(5);
            }
        }

        void EndGame() {
            StopCoroutine(running);
            txt.text = txt.text + "<align=left>The simulation has stopped so you can walk around and see who was infected.</align>\n\nPress 'E' to make this message go away.\nPress 'R' to restart.";
            ending = true;
            Time.timeScale = 0f;

            HiddenFlu[] infecteds = GroupManager.instance.gameObject.GetComponentsInChildren<HiddenFlu>();
            foreach (HiddenFlu h in infecteds) {
                h.ShowFlu();
            }
        }

    }
}
