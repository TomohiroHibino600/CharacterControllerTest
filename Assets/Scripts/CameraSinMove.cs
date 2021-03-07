using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hibino
{
    public class CameraSinMove : MonoBehaviour
    {
        // Update is called once per frame
        void Update( ) {
            transform.position = new Vector3( 0, 1.2f * Mathf.Sin( Time.realtimeSinceStartup ), 0 );
        }
    }
}
