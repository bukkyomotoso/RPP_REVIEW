using System;

public class RPPClass
{
	public RPPClass()
	{
	}
    public String removeCommas(String str)
    {
        String retstr = "";
        if (str != "")
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ',')
                    retstr += str[i];
            }
        else
            retstr = "0";
        return retstr;
    }
    public String commaSeparator(String str)
    {
        String retstr = "";
        String revstr = "";
        string finalstr = "";
        String str2 = "";
        if (str != "" && str[0] == '-')
        {
            for (int i = 1; i < str.Length; i++)
                str2 += str[i];
        }
        else
            str2 = str;
        String str1 = removeCommas(str2);
        // String str1 = Math.Round(double.Parse(str2), 2).ToString();
        //List<int> userinput = new List<int>();
        String[] userinput = str1.Split('.');
        String x1 = userinput[0];



        if (x1.Length > 3)
        {
            for (int i = 1; i <= x1.Length; i++)
            {
                if (i % 3 == 0 && i != (x1.Length))
                    retstr = retstr + x1[x1.Length - i] + ",";
                else
                    retstr = retstr + x1[x1.Length - i];

            }
            for (int i = retstr.Length - 1; i >= 0; i--)
            {
                revstr += retstr[i];
            }

        }

        else
            retstr = removeCommas(x1);




        if (userinput.Length > 1 && x1.Length > 3)
            revstr = revstr + "." + userinput[1];

        else if (userinput.Length > 1 && x1.Length <= 3)
            revstr = retstr + "." + userinput[1];
        else if (userinput.Length <= 1 && x1.Length <= 3 && str != "")
            revstr = str1;
        else if (userinput.Length <= 1 && x1.Length > 3)
            revstr = revstr + "";
        else
            revstr = "0";

        if (str != "" && str[0] == '-')
            finalstr = "-" + revstr;
        else
            finalstr = revstr;


        return finalstr;



    }
}
