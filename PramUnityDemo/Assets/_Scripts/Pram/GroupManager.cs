using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {

    public class GroupManager : MonoBehaviour {
        public static GroupManager instance;
        public Dictionary<Group, GameObject> groupConfigurations;

        public List<Group> groups;
        public Dictionary<Group, AgentPool> pools;

        private void Awake() {
            if (GroupManager.instance != null) { Destroy(GroupManager.instance); }
            instance = this;
        }

        void TransferMass(AgentPool a, AgentPool b, double mass) {
            int removedCount = 0;
            if (a != null) { removedCount = (int)(mass * a.objectPerMass); }
            int placedCount = 0;
            if(b != null) { placedCount = (int)(mass * b.objectPerMass); }
            int excessPlaced = placedCount - removedCount;
            int excessRemoved = removedCount - placedCount;

            for (int i = 0; i < removedCount && i < placedCount; i++) {
                GameObject placed = b.GetPooledObject();
                GameObject removed = a.GetActiveObject();
                placed.transform.SetPositionAndRotation(removed.transform.position, removed.transform.rotation);
                placed.SetActive(true);
                a.DeactivateObject(removed);
            }

            for (int i = 0; i < excessPlaced && b != null; i++) {
                GameObject placed = b.GetPooledObject();
                placed.SetActive(true);
                placed.transform.SetPositionAndRotation(b.site.GetPosition(), transform.rotation);
                if (a != null) {
                    placed.transform.SetPositionAndRotation(a.site.GetPosition(), transform.rotation);
                }
            }

            for (int i = 0; i < excessRemoved && a != null; i++) {
                GameObject removed = a.GetActiveObject();
                a.DeactivateObject(removed);
            }
        }

        AgentPool CreatePool(Group group) {
            GameObject poolObject = Instantiate(new GameObject(), transform.position, transform.rotation, transform);

            foreach (Group g in groupConfigurations.Keys) {
                if (g.Equivalent(group)) {
                    AgentPool pool = poolObject.AddComponent(typeof(AgentPool)) as AgentPool;
                    pool.pooledObject = groupConfigurations[g];
                    pool.CreatePool();
                    return pool;
                }
            }

            Debug.Log("EXCEPTION: Group missing agent configuration.");
            return null;
        }

        AgentPool GetEquivalentPool(Group group) {
            if (group == null) {
                return null;
            }

            foreach (Group g in pools.Keys) {
                if (group.Equivalent(g)) {
                    return pools[g];
                }
            }

            return CreatePool(group);
        }

        /// <summary>
        /// Update the masses of groups in the visible simulation.
        /// </summary>
        /// <param name="recentRun">A probeinfo containing info from a step of a pram simulation</param>
        public void UpdateGroups(ProbeInfo recentRun) {
            Redistribution[] groupDifference = recentRun.redistributions;
            foreach (Redistribution r in groupDifference) {
                TransferMass(GetEquivalentPool(r.source), GetEquivalentPool(r.destination), r.mass);
            }
        }

        public void InitializeGroupConfigurations() {
            GameObject configParent = GameObject.FindGameObjectWithTag("GroupConfiguration");
            if (configParent == null) {
                Debug.Log("EXCEPTION: GroupConfiguration not set!");
                return;
            }

            Agent[] agents = configParent.transform.GetComponentsInChildren<Agent>();
            for (int i = 0; i < agents.Length; i++) {
                groupConfigurations.Add(agents[i].group, agents[i].gameObject);
            }
        }

        public void InitializeGroups() {
            Redistribution[] initialRedistributions = new Redistribution[groups.Count];
            for (int i = 0; i < initialRedistributions.Length; i++) {
                initialRedistributions[i] = new Redistribution(null, groups[i], groups[i].n);
            }
            UpdateGroups(new ProbeInfo(initialRedistributions));
        }

        /// <summary>
        /// TODO: Update masses in groups based on pools
        /// </summary>
        void UpdateMasses() {

        }

        public Group[] GetGroups() {
            UpdateMasses();
            return groups.ToArray();
        }
    }

}
