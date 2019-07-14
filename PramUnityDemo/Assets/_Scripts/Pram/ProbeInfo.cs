using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {

    public class ProbeInfo {
        public Group[] resultingGroups;
        public Group[] initialGroups;
        public Rule[] rules;
        public int steps;

        public Group[] GetGroupDifference() {
            Group[] diff = new Group[resultingGroups.Length + initialGroups.Length];
            int k = 0;

            for (int i = 0; i < resultingGroups.Length; i++) {
                bool shared = false;
                for (int j = 0; j < initialGroups.Length; j++) {
                    if (resultingGroups[i].Equivalent(initialGroups[j])) {
                        Group tmp = resultingGroups[i].GetCopy();
                        tmp.n -= initialGroups[j].n;
                        diff[k++] = tmp;
                        shared = true;
                        j = initialGroups.Length;
                    }
                }

                if (!shared) {
                    diff[k++] = resultingGroups[i].GetCopy();
                }
            }

            for (int i = 0; i < initialGroups.Length; i++) {
                bool shared = false;
                for (int j = 0; j < resultingGroups.Length; j++) {
                    if (initialGroups[i].Equivalent(resultingGroups[j])) {
                        shared = true;
                        j = resultingGroups.Length;
                    }
                }

                if (!shared) {
                    Group tmp = initialGroups[i].GetCopy();
                    tmp.n = -tmp.n;
                    diff[k++] = tmp;
                }
            }

            return diff;
        }
    }

}