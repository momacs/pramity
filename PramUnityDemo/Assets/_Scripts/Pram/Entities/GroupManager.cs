using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pram.Data;
using Pram.Managers;
using UnityEngine.AI;

namespace Pram.Entities {

    public class GroupManager : MonoBehaviour {
        public static GroupManager instance;
        public Dictionary<Group, GameObject> groupConfigurations;

        public List<Group> groups;
        public Dictionary<Group, AgentPool> pools;
        public List<PlayableAgent> players;

        private void Awake() {
            if (GroupManager.instance != null) { Destroy(GroupManager.instance); }
            instance = this;
            pools = new Dictionary<Group, AgentPool>();
        }

        void TransferObject(AgentPool a, AgentPool b) {
            GameObject placed = b.GetPooledObject();
            GameObject removed = a.GetActiveObject();
            placed.transform.SetPositionAndRotation(removed.transform.position, removed.transform.rotation);
            placed.SetActive(true);
            a.DeactivateObject(removed);
        }

        void SpawnObject(AgentPool a, AgentPool b, string destinationSite) {
            GameObject placed = b.GetPooledObject();
            placed.SetActive(true);
            Site destSite = SiteManager.instance.GetSite(destinationSite);
            if (destSite == null) {
                placed.transform.SetPositionAndRotation(PramManager.instance.GetPosition(), transform.rotation);
                placed.GetComponent<NavMeshAgent>().Warp(PramManager.instance.GetPosition());

            } else {
                placed.transform.SetPositionAndRotation(destSite.GetPosition(), transform.rotation);
                placed.GetComponent<NavMeshAgent>().Warp(destSite.GetPosition());
            }
            if (a != null) {
                if (a.site == null) {
                    placed.transform.SetPositionAndRotation(PramManager.instance.GetPosition(), transform.rotation);
                    placed.GetComponent<NavMeshAgent>().Warp(PramManager.instance.GetPosition());
                } else {
                    placed.transform.SetPositionAndRotation(a.site.GetPosition(), transform.rotation);
                    placed.GetComponent<NavMeshAgent>().Warp(a.site.GetPosition());
                }
            }
        }

        void RemoveObject(AgentPool a) {
            GameObject removed = a.GetActiveObject();
            a.DeactivateObject(removed);
        }

        void TransferMass(AgentPool a, AgentPool b, double mass, string destinationSite) {
            if (mass == 0) { return; }
            if (a != null && a.n < mass) { mass = a.n; }

            int removedCount = 0;
            if (a != null) {
                removedCount = (int)(mass * a.objectPerMass);
                if (removedCount > a.activePoolSize) {
                    removedCount = a.activePoolSize;
                }
            }
            int placedCount = 0;
            if(b != null) { placedCount = (int)(mass * b.objectPerMass); }
            int excessPlaced = placedCount - removedCount;
            int excessRemoved = removedCount - placedCount;

            
            if (a != null) { a.n -= mass; }
            if (b != null) { b.n += mass; }

            for (int i = 0; i < removedCount && i < placedCount; i++) {
                TransferObject(a, b);
            }

            for (int i = 0; i < excessPlaced && b != null; i++) {
                SpawnObject(a, b, destinationSite);
            }

            for (int i = 0; i < excessRemoved && a != null; i++) {
                RemoveObject(a);
            }
        }

        void TransferPlayableMass(Redistribution r) {
            List<PlayableAgent> applicablePlayers = new List<PlayableAgent>();
            foreach (PlayableAgent a in players) {
                if (a.ContainsGroup(r.source) || (r.source == null && a.ContainsGroup(r.destination))) {
                    applicablePlayers.Add(a); }
            }

            r.mass = r.mass / applicablePlayers.Count;
            foreach (PlayableAgent a in applicablePlayers) {
                a.TransferMass(r);
            }
        }

        /// <summary>
        /// Creates a pool for a given group
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        AgentPool CreatePool(Group group) {
            GameObject poolObject = new GameObject("Pool");
            poolObject.transform.SetPositionAndRotation(transform.position, transform.rotation);
            poolObject.transform.SetParent(transform);

            foreach (Group g in groupConfigurations.Keys) {
                if (g.EquivalentAttributesAndRelations(group)) {
                    AgentPool pool = poolObject.AddComponent(typeof(AgentPool)) as AgentPool;
                    pool.site = SiteManager.instance.GetSite(group.site);
                    pool.pooledObject = groupConfigurations[g];
                    pool.pooledObject.GetComponent<Agent>().group = group;
                    pool.CreatePool();
                    pools.Add(group, pool);
                    bool represented = false;
                    foreach (Group gg in groups) {
                        if (gg.Equivalent(group)) { represented = true; }
                    }
                    if (!represented) {
                        groups.Add(group);
                    }
                    return pool;
                }
            }

            Debug.Log("EXCEPTION: Group missing agent configuration.");
            Debug.Log(group.ToString());
            foreach (Group g in groupConfigurations.Keys) {
                Debug.Log(g.EquivalentRelations(group));
                Debug.Log(g.ToString());
            }

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
        public void UpdateGroups(RedistributionSet recentRun) {
            if(recentRun == null) { return; }
            Redistribution[] groupDifference = recentRun.redistributions;
            if (groupDifference == null) { return; }

            string toPrint = "";
            //Start with non-change-in-site
            foreach (Redistribution r in groupDifference) {
                if (r.source == null || (!r.source.Equivalent(r.destination) && r.source.site.Equals(r.destination.site))) {
                    if (r.destination.IsPlayable()) {
                        TransferPlayableMass(r);
                    } else {
                        //print("Trasferring nonplayable mass: " + r.destination.ToString());
                        TransferMass(GetEquivalentPool(r.source), GetEquivalentPool(r.destination), r.mass, r.destination.site);
                    }
                    toPrint += r.ToString() + "\n";
                }
            }

            //Movements across sites
            foreach (Redistribution r in groupDifference) {
                if (r.source != null && !r.source.Equivalent(r.destination) && !r.source.site.Equals(r.destination.site)) {
                    TransferMass(GetEquivalentPool(r.source), GetEquivalentPool(r.destination), r.mass, r.destination.site);
                    toPrint += r.ToString() + "\n";
                }
            }
            //print(toPrint);

            double totalMass = 0;
            foreach (AgentPool p in pools.Values) {
                p.CleanPool();
                totalMass += p.n;
            }
            //print("Total mass: " + totalMass);
        }

        public void InitializeGroupConfigurations() {
            groupConfigurations = new Dictionary<Group, GameObject>();

            GameObject configParent = GameObject.FindGameObjectWithTag("GroupConfiguration");
            if (configParent == null) {
                Debug.Log("EXCEPTION: GroupConfiguration not set!");
                return;
            }

            Agent[] agents = configParent.transform.GetComponentsInChildren<Agent>();
            for (int i = 0; i < agents.Length; i++) {
                groupConfigurations.Add(agents[i].group, agents[i].gameObject);
                //print("Group config set: " + agents[i].group.ToString() + "\n");
                agents[i].gameObject.SetActive(false);
            }
        }

        List<Group> NonPlayableSubset(Group[] g) {
            List<Group> tmp = new List<Group>();
            foreach (Group gr in g) {
                if (!gr.IsPlayable()) {
                    tmp.Add(gr);
                }
            }
            return tmp;
        }

        List<Group> PlayableSubset(Group[] g) {
            List<Group> tmp = new List<Group>();
            foreach (Group gr in g) {
                if (gr.IsPlayable()) {
                    tmp.Add(gr);
                }
            }
            return tmp;
        }

        public void InitializeGroups(Group[] g) {
            //Debug.Log("Init groups!");
            groups = NonPlayableSubset(g);
            Redistribution[] initialRedistributions = new Redistribution[groups.Count];
            for (int i = 0; i < initialRedistributions.Length; i++) {
                initialRedistributions[i] = new Redistribution(null, groups[i], groups[i].n);
            }
            UpdateGroups(new RedistributionSet(initialRedistributions));

            List<Group> playableGroups = PlayableSubset(g);
            //print(playableGroups.Count);
            initialRedistributions = new Redistribution[playableGroups.Count];
            for (int i = 0; i < initialRedistributions.Length; i++) {
                initialRedistributions[i] = new Redistribution(null, playableGroups[i], playableGroups[i].n);
            }
            UpdateGroups(new RedistributionSet(initialRedistributions));
        }

        /// <summary>
        /// Updates masses in groups based on pools
        /// </summary>
        void UpdateMasses() {
            for (int i = 0; i < groups.Count; i++) {
                AgentPool currentPool = this.GetEquivalentPool(groups[i]);
                if (currentPool == null) { continue; }
                groups[i].n = currentPool.n;
            }
        }

        List<Group> GetPlayableGroups() {
            // Notice: This does not merge groups of equivalent attributes+relations because PRAM should do that automatically for us.
            List<Group> playableGroups = new List<Group>();
            foreach (PlayableAgent a in this.players) {
                foreach (Group g in a.GetInternalConflict()) {
                    playableGroups.Add(g);
                }
            }
            return playableGroups;
        }

        public Group[] GetGroups() {
            UpdateMasses();
            List <Group> g = this.GetPlayableGroups();
            g.AddRange(groups);
            return g.ToArray();
        }
    }

}
