using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearningGame.Cameras
{
    public class TopDown_Camera : MonoBehaviour
    {
        #region Variables
        public Transform target;
        #endregion


        #region Main Methods
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(target);
        }
        #endregion

    }
}