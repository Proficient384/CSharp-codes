using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThinkLib;

namespace Prac2_PartB_My_Strings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int Length(string s)
        {
            int counter = 0;
            foreach (char t in s)
            {
                counter++;
            }
            return counter;
        }
        bool contains(string s, string subs)
        {
            int size1 = Length(s);
            int size2 = Length(subs);
            bool ans = false;
            string s1 = "";
            string s2 = "";
            if (size2 <= size1)
            {
                for (int i = 0; i < size1; i++)
                {
                    for (int j = 0; j < size2; j++)
                    {
                        if ((j + i) < size1)
                        {
                            s1 += s[j + i];
                        }
                        else
                        {
                            s1 += s[j];
                        }
                        s2 += subs[j];
                    }
                    if (s1 == s2)
                    {
                        ans = true;
                        break;
                    }
                    s1 = "";
                    s2 = "";
                }
            }
            return ans;
        }
        int indexOf(string s, string subs)
        {
            bool IsContained = contains(s, subs);
            int ans = -1;
            if (IsContained)
            {
                int size1 = Length(s);
                int size2 = Length(subs);
                string pp = "";
                for (int i = 0; i < size1; i++)
                {
                    for (int j = 0; j < size2; j++)
                    {
                        if (s[i] == subs[j])
                        {
                            if (j == 0)
                            {
                                ans = i;
                            }
                            pp += s[i];
                            break;
                        }
                    }
                    if (pp == subs)
                    {
                        break;
                    }
                    for(int f=0;f<Length(pp);f++)
                    {
                        if(pp[f]!=subs[f])
                         {
                            pp = "";
                            break;
                         }
                    }
                }
            }
            return ans;
        }
        string insertSubString(string s, string x, int pos)
        {
            string ans = "";
            int size = Length(s);
            for (int i = 0; i < size; i++)
            {
                if (i != pos)
                {
                    ans += s[i];
                }
                if (i == pos)
                {
                    ans += x;
                    ans += s[i];
                }
            }
            return ans;
        }
        string replaceSubString(string s, string New, string old)
        {
            bool isContained = contains(s, old);
            string ans = "";
            if (isContained)
            {
                int index = indexOf(s, old);
                string t = insertSubString(s, New, index);
                for (int i = 0; i < Length(t); i++)
                {
                    if (i < index)
                    {
                        ans += t[i];
                    }
                    if(i==index)
                    {
                        ans += New;
                    }
                    if (i > index)
                    {
                        int myNewLength = i + Length(old) + Length(New)-1;
                        for(int k = myNewLength;k<Length(t);k++)
                        {
                            ans += t[k];
                        }
                        break;
                    }
                }
            }
            else
            {
                ans = s;
            }
            return ans;
        }
        string deleteSubString(string s, string subs)
        {
            string ans = "";
            bool isContained = contains(s, subs);
            if(isContained)
            {
                int index = indexOf(s, subs);
                for(int i=0;i<Length(s);i++)
                {
                    if(i<index)
                    {
                        ans += s[i];
                    }
                    else
                    {
                        int myNewIndex = i + Length(subs);
                        for(int j=myNewIndex;j<Length(s);j++)
                        {
                            ans += s[j];
                        }
                        break;
                    }
                }
            }
            else
            {
                ans = s;
            }
            return ans;
        }
        List<string> split(string s, char c)
        {
            List<string> myList = new List<string>() { };
            string ans = "";
            string ans2 = "";
            for (int i=0;i<Length(s);i++)
            {
                if(s[i]!=c)
                {
                    ans += s[i];
                    ans2 = ans;
                }
                else
                {
                    myList.Add(ans);
                    ans = "";
                    continue;
                }
            }
            if(s[Length(s) -1]==c)
            {
                ans2 = "";
            }
            myList.Add(ans2);
            return myList;
        }
        int stringCompare(string s1, string s2)
        {
            int counter = 0;
            for(int i=0;i<Length(s1);i++)
            {
                if(s1[i]==s2[i])
                {
                    counter++;
                }
            }
            if(counter==Length(s1) && counter==Length(s2))
            {
                return 0;
            }
            else
            {
                int smaller = 0;
                int valOfS1 = 0;
                int valOfS2 = 0;
                if(Length(s1)>Length(s2))
                {
                    smaller = Length(s2);
                }
                else
                {
                    smaller = Length(s1);
                }
                for(int i=0;i<smaller;i++)
                {
                    valOfS1 = (int)s1[i];
                    valOfS2 = (int)s2[i];
                    if(valOfS1<97)
                    {
                        valOfS1 += 32;
                    }
                    if(valOfS2<97)
                    {
                        valOfS2 += 32;
                    }
                    if (valOfS1 < valOfS2)
                    {
                        return 1;
                    }
                    else if(valOfS1>valOfS2)
                    {
                        return -1;
                    }
                    else if(valOfS1==valOfS2)
                    {
                        continue;
                    }
                }
            }
            return 99999;
        }
        string toLower(string s)
        {
            string ans = "";
            for (int i = 0; i < Length(s); i++)
            {
                if ((s[i] >= 'A') && (s[i] <= 'Z'))
                {
                    ans += (char)((int)s[i] + 32);
                }
                else
                {
                    ans += s[i];
                }
            }
            return (ans);
        }
        string toUpper(string s)
        {
            string ans = "";
            for (int i = 0; i < Length(s); i++)
            {
                if ((s[i] >= 'a') && (s[i] <= 'z'))
                {
                    ans += (char)((int)s[i] - 32);
                }
                else
                {
                    ans += s[i];
                }
            }
            return (ans);
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Length //
            Tester.TestEq(Length("xxx"), 3);
            Tester.TestEq(Length("Proficient"), 10);
            Tester.TestEq(Length(""), 0);
            Tester.TestEq(Length("Mkansi"), 6);
            Tester.TestEq(Length("My name is Ndhuvazi"), 19);
            // Contains //
            Tester.TestEq(contains("xxyxx", "y"), true);
            Tester.TestEq(contains("xxyxx", "yx"), true);
            Tester.TestEq(contains("xxyxx", "yxx"), true);
            Tester.TestEq(contains("Proficient", "ficient"), true);
            Tester.TestEq(contains("mkansi", "mkansi"), true);
            Tester.TestEq(contains("mkansi", "mkansgf"), false);
            Tester.TestEq(contains("", ""), false);
            // Index Of //
            Tester.TestEq(indexOf("xxyxx", "y"), 2);
            Tester.TestEq(indexOf("xxyxx", "yx"), 2);
            Tester.TestEq(indexOf("Proficient", "ient"), 6);
            Tester.TestEq(indexOf("mkansi", "mkansi"), 0);
            Tester.TestEq(indexOf("Proficient", "ficient"), 3);
            Tester.TestEq(indexOf("Proficient", "Cuba"), -1);
            Tester.TestEq(indexOf("mkansi", "mkansgf"), -1);
            Tester.TestEq(indexOf("I will get 0percent for CSC102","0percent"), 11);
            // Insert SubString //
            Tester.TestEq(insertSubString("", "Profi", 0), "");
            Tester.TestEq(insertSubString("i", "Prof", 0), "Profi");
            Tester.TestEq(insertSubString("Pro", "ficient", 2), "Prficiento");
            Tester.TestEq(insertSubString("Pro", "ficient", 3), "Pro");
            Tester.TestEq(insertSubString("xxxx", "y", 2), "xxyxx");
            Tester.TestEq(insertSubString("I do love fish", " not", 4), "I do not love fish");
            Tester.TestEq(insertSubString("Proficient", " Mkansi", 9), "Proficien Mkansit");
            Tester.TestEq(insertSubString("My name is Ndhuvazi", "Proficient ", 11), "My name is Proficient Ndhuvazi");
            // Replace SubString //
            Tester.TestEq(replaceSubString("xxyxx", "ooo", "y"), "xxoooxx");
            Tester.TestEq(replaceSubString("xxyxx", "ooo", "z"), "xxyxx");
            Tester.TestEq(replaceSubString("xxy1xx", "ooo", "y1"), "xxoooxx");
            Tester.TestEq(replaceSubString("my name is Proficient", "Ndhuvazi", "Proficient"), "my name is Ndhuvazi");
            Tester.TestEq(replaceSubString("I love Chocolate and programming", "KFC", "Chocolate"), "I love KFC and programming");
            Tester.TestEq(replaceSubString("I will get 0% for CSC102", "100%", "0%"), "I will get 100% for CSC102");
            // Delete SubString //
            Tester.TestEq(deleteSubString("xxyxx", "y"), "xxxx");
            Tester.TestEq(deleteSubString("xxyxx", "z"), "xxyxx");
            Tester.TestEq(deleteSubString("xxy1xx", "y1"), "xxxx");
            Tester.TestEq(deleteSubString("I do not love programming", "not "), "I do love programming");
            Tester.TestEq(deleteSubString("I can't code all night", "'t"), "I can code all night");
            // Split //
            Tester.TestEq(split("x xx xxx",' '), new List<string>() { "x", "xx", "xxx" });
            Tester.TestEq(split("Profi Ndhuvazi Mkansi", ' '), new List<string>() { "Profi", "Ndhuvazi", "Mkansi" });
            Tester.TestEq(split("Profi Ndhuvazi Mkansi", 'i'), new List<string>() { "Prof"," Ndhuvaz", " Mkans","" });
            Tester.TestEq(split("Programming is amaizing", 'i'), new List<string>() { "Programm", "ng ", "s ama", "z", "ng" });
            // String Compare //
            Tester.TestEq(stringCompare("",""), 0);
            Tester.TestEq(stringCompare("xxx", "xxx"), 0);
            Tester.TestEq(stringCompare("Prof", "Prof"), 0);
            Tester.TestEq(stringCompare("Prof", "aProf"), -1);
            Tester.TestEq(stringCompare("banna", "apple"), -1);
            Tester.TestEq(stringCompare("apple", "banna"), 1);
            Tester.TestEq(stringCompare("applee", "applea"), -1);
            // To Lower//
            Tester.TestEq(toLower(""), "");
            Tester.TestEq(toLower("HeLLo"), "hello");
            Tester.TestEq(toLower("ProfICIent MKAnsI"), "proficient mkansi");
            Tester.TestEq(toLower("I LOVe ProGRAMming So SOO mUcH"), "i love programming so soo much");
            Tester.TestEq(toLower("THIS meTHod WORks jusT FinE"), "this method works just fine");
            // to Upper //
            Tester.TestEq(toUpper("HeLLo"), "HELLO");
            Tester.TestEq(toUpper("ProfICIent MKAnsI"), "PROFICIENT MKANSI");
            Tester.TestEq(toUpper("I say LOVe ProGRAMming So SOO mUcH"), "I SAY LOVE PROGRAMMING SO SOO MUCH");
            Tester.TestEq(toUpper("heyy i say THIS meTHod WORks jusT FinE"), "HEYY I SAY THIS METHOD WORKS JUST FINE");
        }
    }
}
