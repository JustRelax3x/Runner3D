using System.Text;
using UnityEngine;

internal class OperationGenerator
{
    private const int _maxAdditionValue = 250, _minAdditionValue = 1, _minSubstractionValue = 15;
    private readonly int[] _multiplyValues = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20 };
    private const char _additionSymbol = '+', _multiplySymbol = 'x', _substractionSymbol = '-', _divisionSymbol = '÷';
    private StringBuilder str1 = new StringBuilder();
    private StringBuilder str2 = new StringBuilder();

    public string[] GenerateOperations(bool positiveOperations)
    {
        str1.Clear();
        str2.Clear();
        if (positiveOperations)
        {
            str1.Append(_additionSymbol).Append(Random.Range(_minAdditionValue, _maxAdditionValue).ToString());
            str2.Append(_multiplySymbol).Append(_multiplyValues[Random.Range(0, _multiplyValues.Length)].ToString());
        }
        else
        {
            str1.Append(_substractionSymbol).Append(Random.Range(_minSubstractionValue, _maxAdditionValue).ToString());
            str2.Append(_divisionSymbol).Append(_multiplyValues[Random.Range(0, _multiplyValues.Length)].ToString());
        }
        string[] result = new string[2];
        int order = Random.Range(0, 2);
        result[order % 2] = str1.ToString();
        result[(order + 1) % 2] = str2.ToString();
        return result;
    }

    public void DoOperation(string operation, ref int value)
    {
        str1.Clear();
        str1.Append(operation.Substring(1));
        switch (operation[0])
        {
            case _additionSymbol:
                value += int.Parse(str1.ToString());
                break;

            case _multiplySymbol:
                value *= int.Parse(str1.ToString());
                break;

            case _substractionSymbol:
                value -= int.Parse(str1.ToString());
                break;

            case _divisionSymbol:
                value /= int.Parse(str1.ToString());
                break;

            default:
                Debug.LogError("Wrong operation symbol");
                return;
        }
    }

    private enum Operations
    {
        Addition,
        Multiply,
        Substraction,
        Division
    }
}