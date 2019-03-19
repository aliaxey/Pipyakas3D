using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class InitTests
    {
        IObjectCreator objectCreator;
        IGridManager gridManager;
        IObjectStorage objectStorage;
        ICameraManager cameraManager;
        IWeaponManager weaponManager;

        [SetUp]
        public void Init() {
            objectCreator = new ObjectCreator();
            gridManager = new GridManager(objectCreator, Constants.MAP_WIDTH, Constants.MAP_HEIGHT);
            objectStorage = new ObjectStorage();
            cameraManager = new CameraManager(objectStorage);
            weaponManager = new WeaponManager(objectStorage);
        }

        [Test]
        public void TestManagersNotNull()
        {
            Assert.NotNull(objectCreator);
            Assert.NotNull(objectStorage);
            Assert.NotNull(gridManager);
            Assert.NotNull(cameraManager);
            Assert.NotNull(weaponManager);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
