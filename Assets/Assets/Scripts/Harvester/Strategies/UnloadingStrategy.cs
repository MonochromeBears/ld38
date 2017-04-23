using System;

public class UnloadingStrategy: StrategyInterface
{
	public Sylo sylo;

	public void action(HarvesterController harvester) {
		if (this.sylo == null) {
			return;
		}

		int part = System.Math.Min (harvester.getCapacity (), harvester.maxCapacity);
		this.sylo.load (part);

		harvester.unload (part);

		if (harvester.isEmpty ()) {
			harvester.stay ();
		}
	}
}
