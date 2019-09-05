using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {
    [System.Serializable]
    public class RunRequest {
        public List<GroupJsonifiable> groups;
        public List<string> rules;
        public int runs;

        public RunRequest(Group[] g, string[] r, int run) {
            GroupJsonifiable[] gj = new GroupJsonifiable[g.Length];

            for (int i = 0; i < g.Length; i++) {
                gj[i] = new GroupJsonifiable(g[i]);
            }

            groups = new List<GroupJsonifiable>(gj);
            rules = new List<string>(r);
            runs = run;
        }

        public RunRequest(GroupJsonifiable[] g, string[] r, int run) {
            groups = new List<GroupJsonifiable>(g);
            rules = new List<string>(r);
            runs = run;
        }
    }
}
