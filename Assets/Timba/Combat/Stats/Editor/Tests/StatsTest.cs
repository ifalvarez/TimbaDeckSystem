using NUnit.Framework;
using Timba.Combat;

public class StatsTest {

	[Test]
	public void StatsTestSimplePasses() {
        // Use the Assert class to test conditions.
        Stats a = Stats.zero;
        Stats b = Stats.zero;
        a.hp.Value = 1;
        b.hp.Value = 3;
        Stats c = a + b;
        Assert.AreEqual(4, c.hp.Value);
        Stats d = a - b;
        Assert.AreEqual(-2, d.hp.Value); 
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    /*[UnityTest]
	public IEnumerator StatsTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}*/
}
