using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Test01
    {
        private GameObject player;
        private Vector3 cameraFake = new Vector3(0,0,-9);
        [UnityTest]
        public IEnumerator Test01WithEnumeratorPasses()
        {
            GameObject player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Player"));
            player.transform.position = new Vector3(0, 0, 0);
            Assert.That(player.transform.position.z == 0);
            player.gameObject.transform.position = new Vector3(1000, 1000, 1);
            Assert.That(player.transform.position.z != 0);
            yield return null;
        }
    }
}
