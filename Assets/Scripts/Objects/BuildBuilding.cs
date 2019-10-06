using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBuildingParameters {

}

public class BuildBuilding : IActionable
{
	// Start is called before the first frame update
	public override void Activate(SelectableOption option)
	{
        option.parameter.building.Build();
    }
}
