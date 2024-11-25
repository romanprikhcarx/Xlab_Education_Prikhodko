using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ
{
    public class CloudController : MonoBehaviour
    {
        private int n_targetIndex;
        private bool n_moved = false;
        public float moveSpeed = 18f;
        public Cloud cloud;
        public Transform[] targets;

        public void Action()
        {
            Debug.Log("Cloud", this);
            if (n_moved)
            {
                return;
            }

            n_moved = true;
            cloud.StopFX();
            n_targetIndex++;
            if (n_targetIndex >= targets.Length) { n_targetIndex = 0; }
        }
        void Update()
        {
            if (!n_moved)
            {
                return;
            }

            Transform target = targets[n_targetIndex];
            Vector3 targetPosition = new Vector3(target.position.x, cloud.transform.position.y, target.position.z);

            Vector3 offset = (targetPosition - cloud.transform.position).normalized * Time.deltaTime * moveSpeed;
            if (Vector3.Distance(cloud.transform.position, targetPosition) < 0.1)
            {
                cloud.transform.position = targetPosition;
                n_moved = false;
                cloud.PlayFX();
            }
            else
            {
                cloud.transform.Translate(offset);
            }
        }
    }
}