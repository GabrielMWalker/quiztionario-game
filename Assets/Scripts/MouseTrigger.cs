using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class MouseTrigger : MonoBehaviour
{
	[Header("Componentes básicos")]
	public Camera mainCamera;
	[Space]
	[Header("Botões")]
	public MeshCollider trueButton;
	public MeshCollider falseButton;
	public MeshCollider restartButton;
	[Space]
	[Header("Textos")]
	[SerializeField] private TMP_Text textQuest;
	[SerializeField] private TMP_Text answerResult;
	[SerializeField] private TMP_Text resultText;

	int perguntaAtual = 0;
	int score = 0;

	string[] perguntas = new string[] { "1) A soma dos quadrados dos catetos de um triângulo é igual ao quadrado de sua hipotenusa",
		"2) O quadrado da hipotenusa é igual a diferença dos quadrados dos catetos",
		"3) Hipotenusa: é o lado oposto ao ângulo reto, sendo considerado o maior lado do triângulo retângulo",
		"4)Catetos: são os lados do triângulo que formam o ângulo reto. São classificados em: cateto adjacente e cateto oposto",
		"5)A trigonometria é a ciência responsável pelas relações estabelecidas entre os triângulos. Estes são figuras geométricas espaciais compostas de três lados e três ângulos internos",
		""
	};

	string[] respostas = new string[] { "true", "false", "true", "true", "false","" };

    void Reset()
    {
		textQuest.text = perguntas[0];
		score = 0;
		perguntaAtual = 0;
	}

    void Start()
    {
		Reset();
	}

    // Update is called once per frame
    void Update()
	{
		if (!Input.GetMouseButtonDown(0)) return;

		bool trueButtonClick = trueButton.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 1000);
		bool falseButtonClick = falseButton.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit2, 1000);
		bool resetButtonClick = restartButton.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit3, 1000);


		if (resetButtonClick)
        {
			Reset();
		}

		textQuest.text = perguntas[perguntaAtual];


		if (trueButtonClick && perguntaAtual < 5)
		{
			resultText.text = $"Sua resposta da questão {perguntaAtual + 1} está:";
			if (respostas[perguntaAtual].Contains("true"))
            {
				score += 10;
				answerResult.text = "Correta";
				print(score);
			}
            else
            {
				answerResult.text = "Errada";
			}
			perguntaAtual++;
			if (perguntaAtual < 5)
			{
				textQuest.text = perguntas[perguntaAtual];
			}
		}
		if (falseButtonClick && perguntaAtual < 5)
		{
			resultText.text = $"Sua resposta da questão {perguntaAtual + 1} está:";
			if (respostas[perguntaAtual].Contains("false"))
			{
				score += 10;
				answerResult.text = "Correta";
				print(score);
			}
			else
			{
				answerResult.text = "Errada";
			}
			perguntaAtual++;
			if (perguntaAtual < 5)
			{
				textQuest.text = perguntas[perguntaAtual];
			}
		}

		if(perguntaAtual > 4)
        {
			textQuest.text = $"Seu Desempenho foi de {score}/50";
		}
	}
}
