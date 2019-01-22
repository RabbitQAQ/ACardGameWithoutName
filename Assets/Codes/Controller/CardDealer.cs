using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDealer : MonoBehaviour
{

	public int handLimit;
	public int dealInterval;
	public GameObject cardObj;

	public static int currCardNum = 0;
	public static bool shouldCount = true;

	private int count;

	private int frames;

	void Start ()
	{
		count = 0;
		frames = Mathf.RoundToInt(1.0f / Time.fixedDeltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		if (shouldCount)
			count++;
		else
			count = 0;
		if (count >= frames * dealInterval && currCardNum < handLimit)
		{
			count = 0;
			currCardNum++;
			InstantiateCard("FireBall", "FireBall", "Cast A Fireball", "");
		}
	}

	private void InstantiateCard(string cardID, string cardName, string cardDescription, string cardImgSrc)
	{
		GameObject cardObjClone = Instantiate(cardObj, this.transform.position, this.transform.rotation);
		cardObjClone.transform.SetParent(this.transform);
		Text[] texts = cardObjClone.GetComponentsInChildren<Text>();
		texts[0].text = texts[0].name.Equals("CardTitle") ? cardName : cardDescription;
		texts[1].text = texts[1].name.Equals("CardDescription") ? cardDescription : cardName;
	}
}
