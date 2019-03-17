using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
namespace JRFrameWork
{
    public class V_0_0_4
    {
        [Test]
        public void SingletonTest()
        {
            var instance_1 = JeroClass.Instance;
            var instance_2 = JeroClass.Instance;
            Assert.AreEqual(instance_1.GetHashCode(), instance_2.GetHashCode());
        }


        class JeroClass:Single<JeroClass> {
            protected JeroClass() { }
        }
    }
}