using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesManager : ScrollingManager {

	public float minYVar = -6f;
	public float maxYVar = 6f;

	public override void OnObjectPlacement(GameObject goOnLastPosition)
	{
		// Define uma posicao aleatoria no eixo y
        Vector3 pipesPos = goOnLastPosition.transform.localPosition;
        pipesPos.y = Random.Range(minYVar, maxYVar);
        goOnLastPosition.transform.localPosition = pipesPos;
	}

	protected override Transform GenerateObject(Vector3 localPosition)
	{
		localPosition.y = Random.Range(minYVar, maxYVar);

		return base.GenerateObject(localPosition);
	}

}
