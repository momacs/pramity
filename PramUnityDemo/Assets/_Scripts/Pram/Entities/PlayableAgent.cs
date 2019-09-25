using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pram.Entities;
using Pram.Data;
using Pram.Managers;

public class PlayableAgent : MonoBehaviour
{
    private List<Group> internalConflict;
    public Site site;
    public Group dominantGroup;

    private void Awake() {
        internalConflict = new List<Group>();
        if (GroupManager.instance.players == null) { GroupManager.instance.players = new List<PlayableAgent>(); }
        GroupManager.instance.players.Add(this);
        if (!dominantGroup.IsPlayable()) { dominantGroup.MakePlayable(); }
        internalConflict.Add(dominantGroup);
    }

    public List<Group> GetInternalConflict() {
        return internalConflict;
    }

    public bool ContainsGroup(Group g) {
        if (g == null) {
            return false;
        }

        foreach (Group gr in internalConflict) {
            if (gr.Equivalent(g)) { return true; }
        }
        return false;
    }

    Group GetEquivalentGroup(Group g) {
        foreach (Group gr in internalConflict) {
            if (gr.Equivalent(g)) { return gr; }
        }
        return null;
    }

    void UpdateDominantGroup() {
        if (internalConflict.Count == 1) {
            this.dominantGroup = internalConflict[0];
            PramManager.instance.NotifyPlayableGroupChange(this);
            return;
        }

        Group dominant = this.dominantGroup;
        double maxMass = -1;
        foreach (Group g in internalConflict) {
            if (g.n > maxMass) {
                dominant = g;
                maxMass = g.n;
            }
        }
        if (!dominant.Equivalent(dominantGroup)) {
            PramManager.instance.NotifyPlayableGroupChange(this);
        }
        this.dominantGroup = dominant;
    }

    public void TransferMass(Redistribution r) {
        if (r.source != null) {
            Group source = this.GetEquivalentGroup(r.source);
            source.n = source.n - r.mass;
        }

        if (!this.ContainsGroup(r.destination)) {
            r.destination.n = r.mass;
            internalConflict.Add(r.destination);
        } else {
            Group destination = this.GetEquivalentGroup(r.destination);
            destination.n = destination.n + r.mass;
        }

        this.UpdateDominantGroup();
    }

    void UpdateGroupSites() {
        foreach (Group g in internalConflict) {
            if (site == null) {
                g.SetSite("");
            } else {
                g.SetSite(site.name);
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Site")) {
            site = other.gameObject.GetComponent<Site>();
        }
        this.UpdateGroupSites();
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Site")) {
            site = null;
        }
        this.UpdateGroupSites();
    }

}
