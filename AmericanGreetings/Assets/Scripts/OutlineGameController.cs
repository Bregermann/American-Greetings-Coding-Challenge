using UnityEngine;
using UnityEngine.UI;

public class OutlineGameController : MonoBehaviour
{
	private bool isScoring;
	public int changeOutline;
	public int whichOutline;

	public string[] colorTexts;
	public Text colorText;
	public static int points;
	public int outlineTimer;

	public GameObject[] outlineThis;

	private void Start()
	{
		isScoring = true;
		changeOutline = 2;
		points = 0;
		outlineTimer = 100;
		ChangeCorrectColor();
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		outlineTimer--;
		if (outlineTimer == 0)
		{
			outlineTimer = 100;
		}
		if (changeOutline == 0)
		{
			var outline = outlineThis[whichOutline].GetComponent<Outline>();

			outline.OutlineMode = Outline.Mode.OutlineAll;
			outline.OutlineColor = Color.yellow;
			outline.OutlineWidth = 10f;
		}
		else if (changeOutline == 1)
		{
			var outline = outlineThis[whichOutline].GetComponent<Outline>();

			outline.OutlineMode = Outline.Mode.OutlineAll;
			outline.OutlineColor = Color.blue;
			outline.OutlineWidth = 10f;
		}
		else if (changeOutline == 2)
		{
			var outline = outlineThis[whichOutline].GetComponent<Outline>();

			outline.OutlineMode = Outline.Mode.OutlineAll;
			outline.OutlineColor = Color.green;
			outline.OutlineWidth = 10f;
		}
		else if (changeOutline == 3)
		{
			var outline = outlineThis[whichOutline].GetComponent<Outline>();

			outline.OutlineMode = Outline.Mode.OutlineAll;
			outline.OutlineColor = Color.red;
			outline.OutlineWidth = 10f;
		}
	}

	private void WhenClicked()
	{
		if (isScoring == true)
		{
			points++;
			changeOutline = 0;
			ChangeCorrectColor();
		}
	}

	public void ChangeCorrectColor()
	{
		whichOutline = Random.Range(0, 3);
		colorText.text = colorTexts[whichOutline].ToString();
	}
}
