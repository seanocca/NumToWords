using System;

namespace NumbersToWords
{
    class NumToWords
    {

        /// <summary>
        /// This is the functional part of the routine.
        /// It uses all of the other private functions in the class to 
        /// get the desired conversion of numbers to words 
        /// </summary>
        /// <param name="NumberString"></param>
        /// <returns></returns>
        public string ConvertNumbersToWords(string NumberString)
        {
            string val = "";
            string wholeNo = NumberString;
            string points = "";
            string andStr = "";
            string pointStr = "";
            string endStr = "";
            string dollStr = "DOLLARS ";
            try
            {
                int decimalPlace = NumberString.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = NumberString.Substring(0, decimalPlace);
                    points = NumberString.Substring(decimalPlace + 1);

                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "AND ";
                        endStr = "CENTS";
                        pointStr = ConvertNumber(points);
                    }
                }
                val = string.Format("{0} {1}{2}{3} {4}", ConvertNumber(wholeNo), dollStr, andStr, pointStr, endStr);
            }
            catch { }
            return val.Trim();
        }

        /// <summary>
        /// This method breaks down whole numbers and 
        /// forms them into the basic English speaking blocks 
        /// of numbers. (e.g. "ONE" "HUNDRED" AND "TWENTY-" "THREE")
        /// </summary>
        /// <param name="Number"></param>
        /// <returns> String of Provided Whole Number </returns>
        private string ConvertNumber(string Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;  
                bool isDone = false;
                double dblAmt = (Convert.ToDouble(Number));
                 
                if (dblAmt > 0)
                {   
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0; 
                    string place = "";
                    switch (numDigits)
                    {
                        case 1:
                            word = SingleDigits(Number);
                            isDone = true;
                            break;
                        case 2:  
                            word = TensDigits(Number);
                            isDone = true;
                            break;
                        case 3:   
                            pos = (numDigits % 3) + 1;
                            place = " HUNDRED AND ";
                            break;
                        case int n when n >= 4 && n <= 6:
                            pos = (numDigits % 4) + 1;
                            place = " THOUSAND ";
                            break;
                        case int n when n >= 7 && n <= 9:
                            pos = (numDigits % 7) + 1;
                            place = " MILLION ";
                            break;
                        case int n when n >= 10 && n <= 12:
                            pos = (numDigits % 10) + 1;
                            place = " BILLION ";
                            break;
                    }

                    if (!isDone)
                    {  
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertNumber(Number.Substring(0, pos)) + place + ConvertNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertNumber(Number.Substring(0, pos)) + ConvertNumber(Number.Substring(pos));
                        }


                    }
                }
            }
            catch { }
            return word;
        }

        /// <summary>
        /// This function just converts the single numbers
        /// ranging from one to ten
        /// </summary>
        /// <param name="Number"></param>
        /// <returns> String of the provided Number</returns>
        private string SingleDigits(string Number)
        {
            int _Number = Convert.ToInt32(Number);
            string name = "";
            switch (_Number)
            {

                case 1:
                    name = "ONE";
                    break;
                case 2:
                    name = "TWO";
                    break;
                case 3:
                    name = "THREE";
                    break;
                case 4:
                    name = "FOUR";
                    break;
                case 5:
                    name = "FIVE";
                    break;
                case 6:
                    name = "SIX";
                    break;
                case 7:
                    name = "SEVEN";
                    break;
                case 8:
                    name = "EIGHT";
                    break;
                case 9:
                    name = "NINE";
                    break;
            }
            return name;
        }

        /// <summary>
        /// This function gets the larger mathematical English words 
        /// between ten and twenty and then goign up in ten's.
        /// This allows the library to construct the basic output of the value.
        /// </summary>
        /// <param name="Number"></param>
        /// <returns> String of the provided Number in Ten's </returns>
        private string TensDigits(string Number)
        {
            int _Number = Convert.ToInt32(Number);
            string name = null;
            switch (_Number)
            {
                case 10:
                    name = "TEN";
                    break;
                case 11:
                    name = "ELEVEN";
                    break;
                case 12:
                    name = "TWELVE";
                    break;
                case 13:
                    name = "THIRTEEN";
                    break;
                case 14:
                    name = "FOURTEEN";
                    break;
                case 15:
                    name = "FIFTEEN";
                    break;
                case 16:
                    name = "SIXTEEN";
                    break;
                case 17:
                    name = "SEVENTEEN";
                    break;
                case 18:
                    name = "EIGHTEEN";
                    break;
                case 19:
                    name = "NINETEEN";
                    break;
                case 20:
                    name = "TWENTY-";
                    break;
                case 30:
                    name = "THIRTY-";
                    break;
                case 40:
                    name = "FORTY-";
                    break;
                case 50:
                    name = "FIFTY-";
                    break;
                case 60:
                    name = "SIXTY-";
                    break;
                case 70:
                    name = "SEVENTY-";
                    break;
                case 80:
                    name = "EIGHTY-";
                    break;
                case 90:
                    name = "NINETY-";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = TensDigits(Number.Substring(0, 1) + "0") + SingleDigits(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }
    }
}
