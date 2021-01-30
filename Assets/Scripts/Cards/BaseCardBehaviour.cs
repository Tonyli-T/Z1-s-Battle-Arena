using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCardBehaviour : MonoBehaviour
{
	public IEnumerator MoveCards(GameObject card, Transform cardDestroyPos)
	{
		while (card.transform.position.x <= cardDestroyPos.transform.position.x)
		{
			card.transform.position += new Vector3(1 * Time.deltaTime, 0, 0);
			yield return null;
		}

		GameObject.Destroy(card);
	}
}

