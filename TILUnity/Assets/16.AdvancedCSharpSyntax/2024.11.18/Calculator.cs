using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
	public Button equalButton;
	public Button plusButton;
	public Button minusButton;
	public Button multipleButton;
	public Button divisionButton;

	public TMP_InputField inputFieldA;
	public TMP_InputField inputFieldB;
	public TextMeshProUGUI resultText;
	
	delegate double CalculateSymbol(double a, double b);

	private CalculateSymbol calc;

	private double a, b, result;
	
	private void Calcutate(CalculateSymbol calc)
	{
		InputParse();
		result = calc.Invoke(a, b);
	}
	
	private void Start()
	{
		equalButton.onClick.AddListener(() => { resultText.text = result.ToString(); });
		plusButton.onClick.AddListener(() => { Calcutate(Plus); });
		minusButton.onClick.AddListener(() => { Calcutate(Minus); });
		multipleButton.onClick.AddListener(() => { Calcutate(Multiple); });
		divisionButton.onClick.AddListener(() => { Calcutate(Division); });
	}
	
	private void InputParse()
	{
		a = double.Parse(inputFieldA.text);
		b = double.Parse(inputFieldB.text);
	}

	private double Plus(double a, double b)
	{
		return a + b;
	}
	
	private double Minus(double a, double b)
	{
		return a - b;
	}
	
	private double Multiple(double a, double b)
	{
		return a * b;
	}
	
	private double Division(double a, double b)
	{
		return a / b;
	}
}
