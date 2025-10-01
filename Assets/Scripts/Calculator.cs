using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public Text InputText, OutputText;

    public string InputString = "", OutputString = "", SelectedOperator = "";

    bool decimalHasBeenPlaced = false;
    // Start is called before the first frame update
    void Start()
    {
        InputText.text = "";
        OutputText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInput(string _input)
    {
        InputString += _input;
        UpdateUI();
    }

    public void UpdateUI()
    {
        InputText.text = InputString;
        OutputText.text = OutputString;
    }

    public void AddOperator(string _operator)
    {
        if(SelectedOperator == "")
        {
            InputString += _operator;
            SelectedOperator = _operator;
            decimalHasBeenPlaced = false;
        }
        UpdateUI();
    }
    public void AddDecimal()
    {
        //if (!InputString.Contains("."))
        if (!decimalHasBeenPlaced)
        {
            InputString += ".";
            decimalHasBeenPlaced = true;
        }
        
        UpdateUI();
    }

    public void AddNegative()
    {
        if(SelectedOperator == "")
        {
            if (InputString[0] == '-')
            {
                InputString = InputString.Substring(1, InputString.Length - 1);
            }
            else
            {
                InputString = '-' + InputString;
            }
        }
        else
        {
            char _operator = char.Parse(SelectedOperator);
            string[] inputValuesArray = InputString.Split(_operator);

            string firstInput = "";
            string secondInput = "";


            firstInput = inputValuesArray[0];
            secondInput = inputValuesArray[1];
            if (secondInput[0] == '-')
            {
                secondInput = secondInput.Substring(1, secondInput.Length - 1);
            }
            else
            {
                secondInput = '-' + secondInput;
            }
            InputString = firstInput + SelectedOperator + secondInput;

        }

        UpdateUI();
    }

    public void EraseCharacter()
    {
        string characterToErase = InputString[InputString.Length - 1].ToString();
        if (characterToErase == SelectedOperator)
        {
            SelectedOperator = "";
        }
        if (characterToErase == ".")
        {
            decimalHasBeenPlaced = false;
        }
        InputString = InputString.Substring(0, InputString.Length - 1);
        UpdateUI();
    }
    public void Clear()
    {
        InputString = "";
        SelectedOperator = "";
        UpdateUI();
    }

    
    public void DoCalculation()
    {
        char _operator = char.Parse(SelectedOperator);
        string[] inputValuesArray = InputString.Split(_operator);

        if(inputValuesArray.Length < 2)
        {
            Debug.Log("Please enter another number for calculation");
            return;
        }

        double inputOne = double.Parse(inputValuesArray[0]);
        double inputTwo = double.Parse(inputValuesArray[1]);
        double resultValue=0;

        switch (SelectedOperator)
        {
            case "+":
                resultValue = inputOne + inputTwo;
                break;
            case "-":
                resultValue = inputOne - inputTwo;
                break;
            case "/":
                resultValue = inputOne / inputTwo;
                break;
            case "*":
                resultValue = inputOne * inputTwo;
                break;

        }
        OutputString = resultValue.ToString();
        UpdateUI();
    }


}
