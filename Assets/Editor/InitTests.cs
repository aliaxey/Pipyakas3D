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
            gridManager = new GridManager(objectCreator,new LevelLoader(1) );
            objectStorage = new ObjectStorage();
            cameraManager = new CameraManager();
            weaponManager = new WeaponManager(objectStorage);
            objectStorage.ObjectCreator = objectCreator;
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
        [Test]
        public void PlayerTest() {
            Player player = new Player(objectStorage, new Vector2(0,0));
            Assert.NotNull(player);
        }
        [Test]
        public void ParserTest() {
            var parser = new LevelLoader(1);
            parser.ReadLevel(1);

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
