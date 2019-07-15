using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Pram {

    public class Agent : MonoBehaviour {
        public Group group;
        public Site site;
        private NavMeshAgent ai;
        private int counter;

        private void Awake() {
            group = gameObject.GetComponent<Group>();
        }

        private void Init() {
            ai = gameObject.GetComponent<NavMeshAgent>();
            site = SiteManager.instance.GetSite(group.site);
            transform.position = site.GetPosition();
            ai.destination = site.GetPosition();
            counter = 0;
        }

        public void UpdateGroup(Group g) {
            group = g;
            Init();
        }

        // Update is called once per frame
        void Update() {
            counter++;
            if (counter > 150) {
                counter = 0;
                ai.destination = site.GetPosition();
            }
        }
    }

}
