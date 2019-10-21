using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pram.Data;
using Pram.Managers;
using UnityEngine.AI;

namespace Pram.Entities {

    public class Agent : MonoBehaviour {
        public Group group;
        public Site site;
        private NavMeshAgent ai;
        private int counter = 0;
        bool template = true;
        Collider col;
        Rigidbody rb;

        bool placed = false;

        public float objectPerMass = 1f;

        public Vector3 destination;

        public void Init() {
            template = false;
            ai = gameObject.GetComponent<NavMeshAgent>();
            col = gameObject.GetComponent<Collider>();
            rb = gameObject.GetComponent<Rigidbody>();

            site = SiteManager.instance.GetSite(group.site);

            if (!ai.isOnNavMesh) {
                if (site != null) {
                    transform.position = site.GetPosition();
                } else {
                    transform.position = PramManager.instance.GetPosition();
                }
                gameObject.SetActive(false);
                gameObject.SetActive(true);
                KeepOnNavMesh();
            }

            SetNewDestination(false);
        }

        public void SetNewDestination(bool debug) {
            if (debug) {
                print("Setting new destination: " + Time.fixedTime);
            }

            if (site != null) {
                destination = site.GetPosition();
            } else {
                destination = PramManager.instance.GetPosition();
            }

            ai.destination = destination;
        }

        void KeepOnNavMesh() {
            if (!ai.isOnNavMesh) {
                NavMeshHit myNavHit;
                if (NavMesh.SamplePosition(transform.position, out myNavHit, 100, -1)) {
                    ai.Warp(myNavHit.position);
                }
            }
        }

        // Update is called once per frame
        void Update() {
            if (!template) {
                ai.destination = destination;
                if (Vector3.Distance(transform.position, destination) < 1 && ai.remainingDistance < 0.5f) {
                    this.SetNewDestination(false);
                } 
            }
        }
    }

}
