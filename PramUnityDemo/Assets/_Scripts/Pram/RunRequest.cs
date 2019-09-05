using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {
    [System.Serializable]
    public class RunRequest {
        public List<GroupJsonifiable> groups;
        public List<string> rules;
        public int runs;

        public RunRequest(GroupJsonifiable[] g, string[] r, int run) {
            groups = new List<GroupJsonifiable>(g);
            rules = new List<string>(r);
            runs = run;
        }
    }
}
