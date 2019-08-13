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
        bool template = true;

        private void Init() {
            template = false;
            ai = gameObject.GetComponent<NavMeshAgent>();
            site = SiteManager.instance.GetSite(group.site);
            transform.position = site.GetPosition();
            ai.destination = site.GetPosition();
            counter = 0;
        }

        public void UpdateGroup(Group g) {
            template = false;
            group = g;
            Init();
        }

        // Update is called once per frame
        void Update() {
            if (!template) {
                counter++;
                if (counter > 150) {
                    counter = 0;
                    if (site != null) {
                        ai.destination = site.GetPosition();
                    } else {
                        ai.destination = PramManager.instance.GetPosition();
                    }
                }
            }
        }
    }

}
