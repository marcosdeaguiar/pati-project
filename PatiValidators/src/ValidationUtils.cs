namespace Pati.Validators;

public class ValidationUtils
{
    public static bool IsCPFValid(string cpfString)
    {
        if (string.IsNullOrEmpty(cpfString) || cpfString.Length != 11 || !StringUtil.IsDigitsOnly(cpfString))
        {
            return false;
        }
        
        int[] cpfArray = StringUtil.ToIntArray(cpfString);
        int sum = 0;
        int multi = 10;
        bool allTheSame = true;
        int firstVal = cpfArray[0];

        for (int i = 0; i < 9; i++)
        {
            sum += multi * cpfArray[i];
            multi--;

            if (allTheSame && cpfArray[i] != firstVal) { allTheSame = false; }
        }

        if (allTheSame)
        {
            return false;
        }

        int digit = (sum * 10) % 11;

        if (digit == 10)
        {
            digit = 0;
        }

        if (digit != cpfArray[9])
        {
            return false;
        }

        multi = 11;
        sum = 0;

        for (int i = 0; i < 10; i++)
        {
            sum += multi * cpfArray[i];
            multi--;
        }

        digit = (sum * 10) % 11;

        if (digit == 10)
        {
            digit = 0;
        }

        if (digit != cpfArray[10])
        {
            return false;
        }

        return true;
    }
    
    public static bool IsCNPJValid(string cpnjString)
    {
        if (string.IsNullOrEmpty(cpnjString) || cpnjString.Length != 14 || !StringUtil.IsDigitsOnly(cpnjString))
        {
            return false;
        }

        int[] cnpjArray = StringUtil.ToIntArray(cpnjString);
        
        int sum = 0;
        int firstDigit = 0;
        int secondDigit = 0;
        bool allTheSame = true;
        int[] multiArray1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiArray2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int firstVal = cnpjArray[0];


        for (int i = 0; i < 12; i++)
        {
            sum += multiArray1[i] * cnpjArray[i];
                
            if (allTheSame && cnpjArray[i] != firstVal) { allTheSame = false; }
        }

        if (allTheSame)
        {
            return false;
        }

        int sumMod = sum % 11;
        if (sumMod > 1)
        {
            firstDigit = 11 - sumMod;
        }            

        if (firstDigit != cnpjArray[12])
        {
            return false;
        }

        sum = 0;

        for (int i = 0; i < 13; i++)
        {
            sum += multiArray2[i] * cnpjArray[i];
        }

        sumMod = sum % 11;

        if (sumMod > 1)
        {
            secondDigit = 11 - sumMod;
        }

        if (secondDigit != cnpjArray[13])
        {
            return false;
        }

        return true;
    }
}