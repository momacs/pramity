﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {

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
            for (int i = 0; i < poolSize; i++) {
                GameObject obj = Instantiate(pooledObject, transform);
                obj.SetActive(false);
                pool.Add(obj);
                if (i == 0) { site = obj.GetComponent<Agent>().site; }
            }
        }

        public void DeactivateObject(GameObject obj) {
            activePool.Remove(obj);
            activePoolSize--;
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
                    activePoolSize++;
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
                    activePoolSize++;
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
    }

}
