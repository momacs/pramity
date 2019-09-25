using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram.Entities {

    public class AgentPool : MonoBehaviour {
        public GameObject pooledObject;
        public int poolSize = 10;
        public int activePoolSize;

        public double n = 0;

        public double objectPerMass = 1;
        public Site site;

        private System.Random rnd;

        List<GameObject> pool = new List<GameObject>();
        List<GameObject> activePool = new List<GameObject>();

        private void Awake() {
            rnd = new System.Random();
        }

        public void CreatePool() {
            objectPerMass = pooledObject.GetComponent<Agent>().objectPerMass;
            for (int i = 0; i < poolSize; i++) {
                GameObject obj = Instantiate(pooledObject, transform);
                
                obj.SetActive(false);
                pool.Add(obj);
                if (i == 0) { site = obj.GetComponent<Agent>().site; }
            }
        }

        public void DeactivateObject(GameObject obj) {
            activePool.Remove(obj);
            activePoolSize = activePool.Count;
            obj.SetActive(false);
        }

        public GameObject GetActiveObject() {
            if (activePoolSize == 0) { return null; }
            return activePool[rnd.Next(activePool.Count)];
        }

        public GameObject GetPooledObject() {
            for (int i = 0; i < pool.Count; i++) {
                if (pool[i] != null && !pool[i].activeSelf) {
                    activePool.Add(pool[i]);
                    activePoolSize = activePool.Count;
                    pool[i].GetComponent<Agent>().Init();
                    return pool[i];
                }
            }

            for (int i = 0; i < poolSize; i++) {
                GameObject obj = Instantiate(pooledObject, transform);
                obj.SetActive(false);
                pool.Add(obj);
            }
            poolSize = poolSize * 2;

            for (int i = 0; i < pool.Count; i++) {
                if (pool[i] != null && !pool[i].activeSelf) {
                    activePool.Add(pool[i]);
                    activePoolSize = activePool.Count;
                    pool[i].GetComponent<Agent>().Init();
                    return pool[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Destroys an active object and adjusts mass accordingly
        /// </summary>
        public void KillObject(GameObject toKill) {
            this.DeactivateObject(toKill);
            n -= 1.0 / this.objectPerMass;
        }

        /// <summary>
        /// Creates an active object, adding to mass accordingly
        /// </summary>
        /// <returns></returns>
        public GameObject BirthObject() {
            n += 1.0 / this.objectPerMass;
            return this.GetPooledObject();
        }

        /*public void AdoptPlayableAgent(PlayableAgent p) {
            activePlayableAgents.Add(p);
            p.pool = this;
            playable_n = activePlayableAgents.Count / objectPerMass;
        }

        public void AbandonPlayableAgent(PlayableAgent p) {
            activePlayableAgents.Remove(p);
            p.pool = null;
            playable_n = activePlayableAgents.Count / objectPerMass;
        }*/

        public void CleanPool() {
            if (n < 0) {
                n = 0;
            }

            activePoolSize = activePool.Count;

            while (activePoolSize > n * objectPerMass) {
                this.DeactivateObject(this.GetActiveObject());
            }
        }
    }

}
