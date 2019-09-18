using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pram.Entities {

    public class Site : MonoBehaviour {
        public virtual Vector3 GetPosition() {
            return transform.position;
        }
    }

}
