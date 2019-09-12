using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram {
    public class BoxSite : Site {
        public float x_width;
        public float z_width;

        public override Vector3 GetPosition() {
            return transform.position + new Vector3(Random.Range(-x_width, x_width), 0f, Random.Range(-z_width, z_width));
        }
    }
}
