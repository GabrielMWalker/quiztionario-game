using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class MouseTrigger : MonoBehaviour
{

	public Camera camera;
	public MeshCollider trueButton;
	public MeshCollider falseButton;
	
	[Header("Lixo")] 
	[SerializeField] private TMP_Text textQuest;
	[SerializeField] private Timer timer;

	// Update is called once per frame
	void Update()
	{
		if (!Input.GetMouseButtonDown(0)) return;

		bool bateu = trueButton.Raycast(camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 1000);
		bool bateu2 = falseButton.Raycast(camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit2, 1000);

		if (bateu)
        {
			textQuest.text = $"clicou True {hit}";
			StartCoroutine(nameof(Rotina));
			print("esperou 2.2 segundos");
		}
		if (bateu2)
		{
			textQuest.text = $"clicou False {hit2}";
			StopCoroutine(nameof(Rotina));
			print("esperou 2.2 segundos");
		}
	}

	IEnumerator Rotina()
    {
		yield return new WaitForSeconds(2.2f);
		print("esperou 2.2 segundos");
    }
}
