using System.Text;
using UnityEngine;

internal class OperationGenerator
{
    private const int _minAdditionValue = 5, _substractionValueWVGC = 10;
    private const int _minMultiply = 2, _maxMultiply = 15;
    private const char _additionSymbol = '+', _multiplySymbol = 'x', _substractionSymbol = '-', _divisionSymbol = ':';
    private StringBuilder str1 = new StringBuilder();
    private StringBuilder str2 = new StringBuilder();

    public string[] GenerateOperations(bool positiveOperations)
    {
        str1.Clear();
        str2.Clear();
        int current = PlayerData.CurrentBitcoin;
        int value = 15 - Random.Range(1, 11);
        int i = 3;
        while (i > 0)
        {
            value += Random.Range(1, 21);
            i--;
        }
        int multiValue = 0;
        i = 3;
        while (i > 0)
        {
            multiValue += Random.Range(-1, 2);
            i--;
        }
        if (positiveOperations)
        {
            str1.Append(_additionSymbol);
            multiValue += (current + value) / current;
            str2.Append(_multiplySymbol);
        }
        else
        {
            if (value > current) value = Mathf.Max(current - _substractionValueWVGC, _minAdditionValue);
            value *= -1;
            multiValue += current / (Mathf.Max(current + value,1));
            if (multiValue > _maxMultiply) multiValue = _maxMultiply;
            str2.Append(_divisionSymbol);
        }
        if (multiValue <= 1) multiValue = _minMultiply;
        str1.Append(value.ToString());
        str2.Append(multiValue.ToString());
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