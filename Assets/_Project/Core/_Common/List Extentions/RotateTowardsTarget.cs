using System;
using System.Collections;
using UnityEngine;

namespace ListExtentions
{
    public class RotateTowardsTarget : MonoBehaviour
    {
        const float RotationSpeed = 3f;
        const float AngleThreshold = 1f;
        public bool Rotate = true;

        public IEnumerator RotateTowards(Transform thisPos, Transform target)
        {
            Rotate = true;

            Vector3 dir = (target.position - thisPos.position).normalized;
            dir.y = 0;

            while (true)
            {
                dir = (target.position - thisPos.position).normalized;
                dir.y = 0;

                if (dir == Vector3.zero)
                    yield break;

                Quaternion targetRot = Quaternion.LookRotation(dir);
                thisPos.rotation = Quaternion.Slerp(thisPos.rotation, targetRot, Time.deltaTime * RotationSpeed);

                float angle = Vector3.Angle(thisPos.forward, dir);
                if (angle < AngleThreshold)
                    break;

                Rotate = false;
                yield return null;
            }
        }
    }
}