using System;

public class UnloadingStrategy
{
	public Sylo sylo;

	public void action(HarvesterController harvester) {
		if (this.sylo == null) {
			return;
		}

		int part = System.Math.Min (harvester.getCapacity (), harvester.maxCapacity);
		this.sylo.load (part);

		harvester.unload (part);
	}
}
