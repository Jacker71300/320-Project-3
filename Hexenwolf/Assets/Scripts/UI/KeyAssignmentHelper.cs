using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyAssignmentHelper : MonoBehaviour
{
	Button[] children;

	private void Start()
	{
		children = GetComponentsInChildren<Button>();
		updateButtonText();
	}
	public void AssignKey(int index)
	{
		Controls.Instance.UpdateKeyOfIndex(index);
	}

	private void Update()
	{
		updateButtonText();
	}

	private void updateButtonText()
	{
		children[0].GetComponentInChildren<Text>().text = Controls.Instance.Left.ToString();
		children[1].GetComponentInChildren<Text>().text = Controls.Instance.Right.ToString();
		children[2].GetComponentInChildren<Text>().text = Controls.Instance.Up.ToString();
		children[3].GetComponentInChildren<Text>().text = Controls.Instance.Down.ToString();
		children[4].GetComponentInChildren<Text>().text = Controls.Instance.Fire.ToString();
	}
}
