using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class LevelTests
    {
        IObjectCreator objectCreator;
        IGridManager gridManager;

        [SetUp]
        public void Init() {
            objectCreator = new ObjectCreator();
            SceneManager.LoadScene("TestScene");
        }
        [UnityTest]
        public IEnumerator Level1Test(){
            gridManager = new GridManager(objectCreator, new LevelLoader(1));
            yield return new WaitForSeconds(10);
        }
        [UnityTest]
        public IEnumerator Level2Test() {
            gridManager = new GridManager(objectCreator, new LevelLoader(2));
            yield return new WaitForSeconds(10);
        }



    }
}
