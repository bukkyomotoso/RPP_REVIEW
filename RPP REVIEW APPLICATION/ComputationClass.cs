using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPP_REVIEW_APPLICATION
{
    class ComputationClass
    {
        public ComputationClass()
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
            String str1 =  removeCommas(str2);
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
           // else
               // revstr = "0";

            if (str != "" && str[0] == '-')
                finalstr = "-" + revstr;
            else
                finalstr = revstr;


            return finalstr;



        }
      

        public double validate (string str)
        {
            if (str == "")
                return 0;
           
            else
                return Math.Round(double.Parse((removeCommas(str))),2);
           // return double.Parse( roundoff(removeCommas(str)));
        }
        

        public double roundoff(string str)
        {
            
            //string[] input = Math.Round(validate(str),2).ToString().Split('.');
            string str1 = "";
            string[] input = validate(str).ToString().Split('.');
           if (input.Length == 1)
            {
                 str1 =str+ ".00";
            }
            else
                if (input.Length == 2 && input[1].Length == 1)
                     str1 =str + "0";
           if (input.Length == 2 && input[1].Length > 2)
              str1= input[0] + "." + input[1].Substring(0, 2);
           //else  if (mystr.Length == 1)
           //return mystr[1] += "00";
           else
               str1= validate(str).ToString();

           return double.Parse(str1);

        }

        
     
    }

}
