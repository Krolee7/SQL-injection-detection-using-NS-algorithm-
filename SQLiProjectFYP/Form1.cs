using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MFMarhusin;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;

namespace SQLiProjectFYP
{
    public partial class Form1 : Form
    {
        string targetfile = "";
        //string pathToFile = "";
        string val;
        int viruses;
        public int flag = 0;
        //public string text1 = "";
        Stopwatch stopwatch = new Stopwatch();
        List<int> key = new List<int>();
        public static double SumTotal = 0;
        public double total;
        public double valuetext;
        public double valuetext1;
        public double valuetext2;
        public double valuetext3;
        public double valuetext4;
        static double total1 = 0;
        static double total2 = 0;
        static double total3 = 0;
        static double total4 = 0;
        private int a;
        private int b;
        
        //dah berubah
        //public int s;

        public object Windows { get; private set; }

        //static int NO_OF_CHARS = 256;



        public Form1()
        {
            InitializeComponent();
            this.button1.MouseHover += button1_MouseHover;
            this.button2.MouseHover += button2_MouseHover;
            this.button3.MouseHover += button3_MouseHover;
            this.button4.MouseHover += button4_MouseHover;
            this.button5.MouseHover += button5_MouseHover;
            //this.button6.MouseHover += button6_MouseHover;
            this.button7.MouseHover += button7_MouseHover;
            //this.button8.MouseHover += button8_MouseHover;
        }



        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void Button7_Click(object sender, EventArgs e)
        {
            string rifile = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\malware.txt";
            string refile = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\malware2.txt";
            File.WriteAllText(rifile, String.Empty);
            File.WriteAllText(refile, String.Empty);
            string textFile = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\SQLiProjectFYP\datasets\test.txt";
            string learning = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\pattern2.txt";
            

            progressBar1.Value = 0;
            progressBar1.Maximum = 200;
            backgroundWorker1.RunWorkerAsync();

            if (File.Exists(textFile))
            {
                using (StreamReader sr = new StreamReader(textFile))
                {
                    string text = sr.ReadToEnd();

                    string[] lines = Regex.Split(text, "\n");
                    double line = lines.Count();

                    for (int i = 0; i < line; i++)
                    {
                        string str = lines[i].Trim().Replace("\r\n", "");
                        if (File.Exists(learning))
                        {
                            using (StreamReader sr2 = new StreamReader(learning))
                            {
                                string text2 = sr2.ReadToEnd();

                                string[] lines2 = Regex.Split(text2, "\n");
                                double line2 = lines2.Count();

                                for (int a = 0; a < line2; a++)
                                {

                                    string pat = lines2[a].Trim().Replace("\r\n", "");
                                    SearchString2(str, pat, rifile, refile);
                                    Console.WriteLine("i value is :" + lines[i]);
                                    Console.WriteLine("a value is :" + lines2[a]);


                                }

                            }

                        }
                       


                    }



                }

            }
            //string refile2 = @"C:\Users\amirul azman\Desktop\malware2.txt";
           
            var previousLines1 = new HashSet<string>();

            File.WriteAllLines(refile, File.ReadLines(rifile)
                                                    .Where(line => previousLines1.Add(line)));

            using (StreamReader sr = new StreamReader(refile))
            {

                string text = sr.ReadToEnd();
                string[] lines = Regex.Split(text, "\n");
                double line = lines.Count();

                for (int i=0; i<line; i++)
                {
                    richTextBox3.AppendText(lines[i]+"\n\n");
                }


            } 
            string pattern = @"\b(?:(?:2(?:[0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9])\.){3}(?:(?:2([0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9]))";
           

            string matchIP = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\matchIP.txt";
            string matchIP2 = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\matchIP2.txt";
            string trainben = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\stringbiasa.txt";
            string trainben2 = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\stringbiasa2.txt";

            File.WriteAllText(matchIP, String.Empty);
            File.WriteAllText(matchIP2, String.Empty);


            Regex r = new Regex(pattern);
            string input = File.ReadAllText(refile);
            MatchCollection matches = r.Matches(input);
            //string valuelama = "";
            foreach (Match match in matches)
            {
                if (File.Exists(matchIP2) || File.Exists(matchIP))
                {
                    using (StreamWriter sw = File.AppendText(matchIP))
                    {
                        sw.WriteLine(match.Value);
                    }
                    var previousLines = new HashSet<string>();

                    File.WriteAllLines(matchIP2, File.ReadLines(matchIP)
                                                            .Where(line => previousLines.Add(line)));

                }



            }
            getCompareIP(matchIP, matchIP2);


            getCompare2();

            /**var previousLines2 = new HashSet<string>();

            File.WriteAllLines(trainben2, File.ReadLines(trainben)
                                                    .Where(line => previousLines2.Add(line)));


            using (StreamReader sr = new StreamReader(trainben2))
            {

                string text = sr.ReadToEnd();
                string[] lines = Regex.Split(text, "\n");
                double line = lines.Count();

                for (int i = 0; i < line; i++)
                {
                    richTextBox3.AppendText(lines[i] + "\n\n");
                }


            }*/

        }
        
        private void button7_MouseHover(object sender, EventArgs e)
        {
           
            System.Windows.Forms.ToolTip ToolTip7 = new System.Windows.Forms.ToolTip();
            ToolTip7.SetToolTip(this.button7, "Scan Button will Scan the Test Set with the Trained Malicous KB");


        }
       
        public void getCompare2()
        {
            string filewow1 = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\SQLiProjectFYP\datasets\test.txt";
            string filewow2 = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\malware2.txt";

            HashSet<string> listFile1 = new HashSet<string>();
            string line;
            StreamReader sr = new StreamReader(filewow1);
            while ((line = sr.ReadLine()) != null)
            {
                listFile1.Add(line);
            }
            sr.Close();

            //Making a list for file2
            HashSet<string> listFile2 = new HashSet<string>();
            string line1;
            StreamReader sr1 = new StreamReader(filewow2);
            while ((line1 = sr1.ReadLine()) != null)
            {
                listFile2.Add(line1);
            }
            sr1.Close();


            IEnumerable<string> allLogs = listFile1.Union(listFile2);

            // this will double check the logs
            foreach (string element in allLogs)
            {
                if (!listFile2.Contains(element))
                    richTextBox2.AppendText("Benign: " + element+"\n\n");
                    richTextBox2.ForeColor = Color.Green;
                

            }
        }


        public int[] SearchString2(string str, string pat, string rifile, string refile)
        {
            List<int> retVal = new List<int>();
            int m = pat.Length;
            int n = str.Length;
            Console.WriteLine("pat length: " + m);
            Console.WriteLine("str lenght: " + n);

            int[] badChar = new int[256];

            BadCharHeuristic(pat, m, ref badChar);

            int s = 0;
            while (s <= (n - m))
            {
                int j = m - 1;

                while (j >= 0 && pat[j] == str[s + j])
                    --j;

                if (j < 0)
                {
                    retVal.Add(s);
                    //triggerString(str);
                    if (str == ""|| pat =="")
                    {

                    

                    }else
                    {
                        
                        if (File.Exists(refile) || File.Exists(rifile))
                        {
                            using (StreamWriter sw = File.AppendText(rifile))
                            {
                                sw.WriteLine(str);
                                //richTextBox3.AppendText(str+"\n\n");
                            }
                           

                            
                        }



                        Console.WriteLine("the ans:" + s);
                    }

                    
                    s += (s + m < n) ? m - badChar[str[s + m]] : 1;

                }
                else
                {
                    //Console.WriteLine("the ans2:" + s);
                    s += Math.Max(1, j - badChar[str[s + j]]);

                }
            }


            return retVal.ToArray();
        }

        public static void PrintAnswer(double line2, List<int> key, string val)
        {
            
            int amount = key.Count();
            double percentage = (amount / line2) * 100;
            if (percentage >= 20 / 100)
            {
                
                Console.WriteLine("sqli2:" + val);
                Console.WriteLine("amount" + percentage);
            }


        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //button extract
            stopwatch.Start();
            string fileName = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\SQLiProjectFYP\datasets\learning.txt";
            string value = this.richTextBox1.Text;
            int i = 0;
            string[] lines = Regex.Split(value, "\n");
            

            valuetext = total / 100 * 20;
  
            if (flag == 0)
            {
                File.WriteAllText(fileName, String.Empty);

                label6.Text = "1st Test Set";
                label6.ForeColor = Color.Green;
                clickbtn1(lines, fileName);
            }
            else if (flag == 1)
            {
                File.WriteAllText(fileName, String.Empty);
               
                    richTextBox4.Clear();
                    richTextBox4.Focus();

                label6.Text = "2nd Test Set";
                label6.ForeColor = Color.Green;
                clickbtn2(lines, fileName);
            }
            else if (flag == 2)
            {
                File.WriteAllText(fileName, String.Empty);
                
                    richTextBox4.Clear();
                    richTextBox4.Focus();
                label6.Text = "3rd Test Set";
                label6.ForeColor = Color.Green;

                clickbtn3(lines, fileName);
            }
            else if (flag == 3)
            {
                File.WriteAllText(fileName, String.Empty);
               
                    richTextBox4.Clear();
                    richTextBox4.Focus();
                label6.Text = "4th Test Set";
                label6.ForeColor = Color.Green;

                clickbtn4(lines, fileName);
            }
            else if (flag == 4)
            {
                File.WriteAllText(fileName, String.Empty);
                
                    richTextBox4.Clear();
                    richTextBox4.Focus();
                label6.Text = "5th Test Set";
                label6.ForeColor = Color.Green;

                clickbtn5(lines, fileName);
            }
            else
            {
                richTextBox4.AppendText("The button has stopped");
                button3.Enabled = false;
            }

            richTextBox4.AppendText("total lines: " + valuetext +"\n\n");
            richTextBox4.AppendText("flag: " + flag + "\n\n");
            richTextBox4.AppendText("flag: " + valuetext1 + "\n" + valuetext2 + "\n" + valuetext3 + "\n" + valuetext4 + "\n");

            flag = flag + 1;
            stopwatch.Stop();
            

        }
        
        private void button3_MouseHover(object sender, EventArgs e)
        {
            
            System.Windows.Forms.ToolTip ToolTip3 = new System.Windows.Forms.ToolTip();
            ToolTip3.SetToolTip(this.button3, "Extract 1/5 from Log File to become Test File");

        }


        public void clickbtn1(string[] lines, string fileName)
        {
           
                for (int i = 0; i < total; i++)
                {
                    if (i <= valuetext)
                    {

                        richTextBox4.AppendText(lines[i] + "\n");
                        
                       
                    }
                    else 
                    {

                        if (File.Exists(fileName))
                        {
                            using (StreamWriter sw = File.AppendText(fileName))
                            {
                                sw.WriteLine(lines[i] + "\n");
                                
                            }
                        }

                    }


                }
        
        }

        public void clickbtn2(string[] lines, string fileName)
        {
            valuetext1 = valuetext + valuetext;
           
            for (int i = 0; i < total; i++)
            {
                if (i <= valuetext)
                {
                    if (File.Exists(fileName))
                    {
                        using (StreamWriter sw = File.AppendText(fileName))
                        {
                            sw.WriteLine(lines[i] + "\n");

                        }
                    }



                }
                else if (i > valuetext && i <= valuetext1)
                    {

                        richTextBox4.AppendText(lines[i] + "\n");

                    }
                else if (i > valuetext1)
                {

                        if (File.Exists(fileName))
                        {
                            using (StreamWriter sw = File.AppendText(fileName))
                            {
                                sw.WriteLine(lines[i] + "\n");

                            }
                        }

                }


                }
           
        }

        public void clickbtn3(string[] lines, string fileName)
        {
            valuetext2 = valuetext1 + valuetext;
          
                for (int i= 0; i < total; i++)
                {
                    if (i <= valuetext1)
                    {

                        if (File.Exists(fileName))
                        {
                            using (StreamWriter sw = File.AppendText(fileName))
                            {
                                sw.WriteLine(lines[i] + "\n");

                            }
                        }

                    }
                    else if (i > valuetext1 && i <= valuetext2)
                    {
                        richTextBox4.AppendText(lines[i] + "\n");
                        

                    }
                    else if (i> valuetext2)
                    {
                        if (File.Exists(fileName))
                        {
                            using (StreamWriter sw = File.AppendText(fileName))
                            {
                                sw.WriteLine(lines[i] + "\n");

                            }
                        }
                    }


                }
          
        }
        public void clickbtn4(string[] lines, string fileName)
        {
            valuetext3 =valuetext2+valuetext;
           
            for (int i = 0; i < total; i++)
            {
                if (i <= valuetext2)
                {

                    if (File.Exists(fileName))
                    {
                        using (StreamWriter sw = File.AppendText(fileName))
                        {
                            sw.WriteLine(lines[i] + "\n");

                        }
                    }

                }
                else if (i > valuetext2 && i <= valuetext3)
                {
                    richTextBox4.AppendText(lines[i] + "\n");


                }
                else if (i > valuetext3)
                {
                    if (File.Exists(fileName))
                    {
                        using (StreamWriter sw = File.AppendText(fileName))
                        {
                            sw.WriteLine(lines[i] + "\n");

                        }
                    }
                }


            }
          
        }
        public void clickbtn5(string[] lines, string fileName)
        {
            valuetext4 = valuetext3 + valuetext;
          
            for (int i = 0; i < total; i++)
            {
                if (i <= valuetext3)
                {

                    if (File.Exists(fileName))
                    {
                        using (StreamWriter sw = File.AppendText(fileName))
                        {
                            sw.WriteLine(lines[i] + "\n");

                        }
                    }

                }
                else if (i > valuetext3 && i <= valuetext4)
                {
                    richTextBox4.AppendText(lines[i] + "\n");


                }
                


            }
            
        }

        

        private void Button1_Click(object sender, EventArgs e)
        {
            string pathToFile = "";
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            //theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\xampp\apache";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(theDialog.FileName.ToString());

                pathToFile = theDialog.FileName;//doesn't need .tostring because .filename returns a string// saves the location of the selected object
                textBox1.Text = pathToFile;
            }

            if (File.Exists(pathToFile))// only executes if the file at pathtofile exists//you need to add the using System.IO reference at the top of te code to use this
            {
                

                string pathToFile2 = @"C:\xampp\apache\logs\accesslog.txt";
                var previousLines = new HashSet<string>();

                File.WriteAllLines(pathToFile2, File.ReadLines(pathToFile)
                                                        .Where(line => previousLines.Add(line)));


                string text = "";
                using (StreamReader sr = new StreamReader(pathToFile2))
                {
                    text = sr.ReadToEnd();//all text wil be saved in text enters are also saved

                    string value = text;
                    // Split the string on line breaks.
                    // ... The return value from Split is a string array.

                    string[] lines = Regex.Split(text, "\n");

                    //foreach (string line in lines)
                    //{
                    richTextBox1.AppendText( text + "\n");
                    total = lines.Count();
                    //Console.WriteLine(total);
                    richTextBox1.AppendText("total lines: " + total);


                    //}



                }

            }
        }
        
        private void button1_MouseHover(object sender, EventArgs e)
        {
           
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.button1, "Browse your Log File Here..");

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Selecting the File to append the testFile
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Destination TextFile";
            string pathToFile = "";
            //theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\SQLiProjectFYP\datasets";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(theDialog.FileName.ToString());

                pathToFile = theDialog.FileName;//doesn't need .tostring because .filename returns a string// saves the location of the selected object
                textBox3.Text = pathToFile;
                File.WriteAllText(pathToFile, String.Empty);
            }

            if (File.Exists(pathToFile))
            {
                using (StreamWriter sw = File.AppendText(pathToFile))
                {
                    
                    // Append the the logs into testFile
                    String getText = this.richTextBox4.Text;
                    string[] lines = Regex.Split(getText, "\n");
                    double valuetext = lines.Count();



                    for (int i = 0; i < valuetext; i++)
                    {
                        sw.WriteLine(lines[i] + "\n");
                    }

                    

                }
                createMalText(pathToFile);
            }
            else
            {
                MessageBox.Show("Please Create the testFile for knowledge base");
            }

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            
            System.Windows.Forms.ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip2.SetToolTip(this.button2, "Create the File for TestFile");

        }
        public void createMalText(string pathToFile)
        {
            
            string maltext = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\maltext.txt";
            string maltext2 = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\maltext2.txt";
            File.WriteAllText(maltext, String.Empty);
            File.WriteAllText(maltext2, String.Empty);
            string bentext = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\bentext";
            string learning = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\sql.txt";

            if (File.Exists(pathToFile))
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    string text = sr.ReadToEnd();

                    string[] lines = Regex.Split(text, "\n");
                    double line = lines.Count();

                    for (int i = 0; i < line; i++)
                    {
                        string str = lines[i].Trim().Replace("\r\n", "");
                        if (File.Exists(learning))
                        {
                            using (StreamReader sr2 = new StreamReader(learning))
                            {
                                string text2 = sr2.ReadToEnd();

                                string[] lines2 = Regex.Split(text2, "\n");
                                double line2 = lines2.Count();

                                for (int a = 0; a < line2; a++)
                                {

                                    string pat = lines2[a].Trim().Replace("\r\n", "");
                                    SearchString(str, pat, maltext, maltext2);
                                    Console.WriteLine("i value is :" + lines[i]);
                                    Console.WriteLine("a value is :" + lines2[a]);

                                }

                            }

                        }
                    }
                }
            }

            var previousLines = new HashSet<string>();

            File.WriteAllLines(maltext2, File.ReadLines(maltext)
                                                    .Where(line => previousLines.Add(line)));

        }

        public void createbenText(string pathToFile)
        {
            string bentext = @"";
            string learning = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\sql.txt";
            using (StreamWriter sw = File.CreateText(bentext))
            {
              //  sw.WriteLine(lines[i] + "\n");
            }

        }



        private void Button4_Click(object sender, EventArgs e)
        {
            
            string textFile = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\SQLiProjectFYP\datasets\learning.txt";
            string learning = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\sql.txt";
            string rifile = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\pattern.txt";
            string refile = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\pattern2.txt";
            File.WriteAllText(rifile, String.Empty);
            File.WriteAllText(refile, String.Empty);

            if (File.Exists(textFile))
            {
                using (StreamReader sr = new StreamReader(textFile))
                {
                    string text = sr.ReadToEnd();

                    string[] lines = Regex.Split(text, "\n");
                    double line = lines.Count();

                    for (int i = 0; i < line; i++)
                    {
                        string str = lines[i].Trim().Replace("\r\n", "");
                        if (File.Exists(learning))
                        {
                            using (StreamReader sr2 = new StreamReader(learning))
                            {
                                string text2 = sr2.ReadToEnd();

                                string[] lines2 = Regex.Split(text2, "\n");
                                double line2 = lines2.Count();

                                for (int a = 0; a < line2; a++)
                                {

                                    string pat = lines2[a].Trim().Replace("\r\n", "");
                                    SearchString(str, pat, rifile,refile);
                                    Console.WriteLine("i value is :" + lines[i]);
                                    Console.WriteLine("a value is :" + lines2[a]);


                                }

                            }
                        }

                    }



                }
           
            }


            var previousLines = new HashSet<string>();

            File.WriteAllLines(refile, File.ReadLines(rifile)
                                                    .Where(line => previousLines.Add(line)));

        }
        
        private void button4_MouseHover(object sender, EventArgs e)
        {
           
            System.Windows.Forms.ToolTip ToolTip4 = new System.Windows.Forms.ToolTip();
            ToolTip4.SetToolTip(this.button4, "Training Button is to train the Training sets which is 4/5 from the Log File");


        }

        public static int[] SearchString(string str, string pat, string rifile, string refile)
        {
            List<int> retVal = new List<int>();
            int m = pat.Length;
            int n = str.Length;
            Console.WriteLine("pat length: " + m);
            Console.WriteLine("str lenght: " + n);

            int[] badChar = new int[256];

            BadCharHeuristic(pat, m, ref badChar);

            int s = 0;
            while (s <= (n - m))
            {
                int j = m - 1;

                while (j >= 0 && pat[j] == str[s + j])
                    --j;

                if (j < 0)
                {
                    retVal.Add(s);
                    if (str == "")
                    {


                    }
                    else
                    {
                        

                        //File.WriteAllText(rifile, String.Empty);
                        //File.WriteAllText(refile, String.Empty);
                        if (File.Exists(refile) || File.Exists(rifile))
                        {
                           
                            using (StreamWriter sw = File.AppendText(rifile))
                            {
                                sw.WriteLine(pat);
                                
                            }
                            
                            

                        }


                        /**List <int> integerArray = new List< int > ();
                        integerArray.Add(n);
          

                        // This will track the lowest number found
                        int lowestFound = int.MaxValue;

                        foreach (int i in integerArray)
                        {
                            // By using int.MaxValue as the initial value,
                            // this check will usually succeed.
                            if (lowestFound > i)
                            {
                                lowestFound = i;
                                Console.WriteLine("what "+lowestFound);
                            }
                        }*/

                        Console.WriteLine("the ans:" + s);
                    }
                    
                    s += (s + m < n) ? m - badChar[str[s + m]] : 1;

                }
                else
                {
                   
                    
                    //Console.WriteLine("the ans2:" + s);
                    s += Math.Max(1, j - badChar[str[s + j]]);
                    
                  
                }
                
            }
           

            return retVal.ToArray();
        }

        private static void BadCharHeuristic(string str, int size, ref int[] badChar)
        {
            int i;

            for (i = 0; i < 256; i++)
                badChar[i] = -1;

            for (i = 0; i < size; i++)
                badChar[(int)str[i]] = i;
        }

        public void getComparemalware(string filewow1, string filewow2, string trainben)
        {
            using (StreamReader sr = new StreamReader(filewow1))
            {
                //List<string> l1 = System.IO.File.ReadLines(filewow1).ToList();
                string text = sr.ReadToEnd().Trim().Replace("\n", "");
                string[] lines = Regex.Split(text, "\r");
                double total1 = lines.Count();

                for (int i = 0; i < total1; i++)
                {
                    using (StreamReader sr1 = new StreamReader(filewow2))
                    {
                        //List<string> l1 = System.IO.File.ReadLines(filewow1).ToList();
                        string text1 = sr1.ReadToEnd().Trim().Replace("\n", "");
                        string[] lines2 = Regex.Split(text1, "\r");
                        double total2 = lines2.Count();
                        for (int a = 0; a < total2; a++)
                        {
                            if (lines[i].Equals(lines2[a]))
                            {
                                using (StreamWriter sw = File.AppendText(trainben))
                                {
                                    sw.WriteLine(lines[i]);

                                }
                            }
                            else
                            {
                                
                            }


                        }


                    }

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string rifile = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\quick.txt";
            string refile = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\quick2.txt";
            OpenFileDialog theDialog = new OpenFileDialog();
            string pathToFile = "";
            theDialog.Title = "Open Text File";
            //theDialog.Filter = "TXT files|*.txt";
            theDialog.InitialDirectory = @"C:\xampp\apache";
            string learning = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\sql.txt";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(theDialog.FileName.ToString());

                pathToFile = theDialog.FileName;//doesn't need .tostring because .filename returns a string// saves the location of the selected object
                //File.WriteAllText(pathToFile, String.Empty);
                
            }
            if (File.Exists(pathToFile))
            {
                using (StreamReader sr = new StreamReader(pathToFile))
                {
                    string text = sr.ReadToEnd();

                    string[] lines = Regex.Split(text, "\n");
                    double line = lines.Count();

                    for (int i = 0; i < line; i++)
                    {
                        string str = lines[i].Trim().Replace("\r\n", "");
                        if (File.Exists(learning))
                        {
                            using (StreamReader sr2 = new StreamReader(learning))
                            {
                                string text2 = sr2.ReadToEnd();

                                string[] lines2 = Regex.Split(text2, "\n");
                                double line2 = lines2.Count();

                                for (int a = 0; a < line2; a++)
                                {

                                    string pat = lines2[a].Trim().Replace("\r\n", "");
                                    SearchString4(str, pat, rifile, refile);
                                    Console.WriteLine("i value is :" + lines[i]);
                                    Console.WriteLine("a value is :" + lines2[a]);

                                }

                            }

                        }
                    }
                }
            }
            //string refile = @"C:\Users\amirul azman\Desktop\quick2.txt";
            /**string pattern = @"\b(?:(?:2(?:[0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9])\.){3}(?:(?:2([0-4][0-9]|5[0-5])|[0-1]?[0-9]?[0-9]))";

            string matchIP = @"C:\Users\amirul azman\Desktop\matchIP.txt";
            string matchIP2 = @"C:\Users\amirul azman\Desktop\matchIP2.txt";
            File.WriteAllText(matchIP, String.Empty);
            File.WriteAllText(matchIP2, String.Empty);
            Regex r = new Regex(pattern);
            string input = File.ReadAllText(refile);
            MatchCollection matches = r.Matches(input);
            //string valuelama = "";
            foreach (Match match in matches)
            {
                if (File.Exists(matchIP2) || File.Exists(matchIP))
                {
                    using (StreamWriter sw = File.AppendText(matchIP))
                    {

                        sw.WriteLine(match.Value);
                        
                    }
                    var previousLines = new HashSet<string>();

                    File.WriteAllLines(matchIP2, File.ReadLines(matchIP)
                                                            .Where(line => previousLines.Add(line)));

                }*/




                //Console.WriteLine(match.Value);
                /**var previousLines = new HashSet<string>();
                string valuebaru = match.Value;
                
                if (valuelama == valuebaru)
                {
                    Regex w = new Regex(match);
                    w.Matches(matches, "true").Count();
                    Console.WriteLine(match.Value);
                }else
                {
                    valuelama=valuebaru;
            using (StreamReader sr = new StreamReader(filewow1))
            {
                List<string> l1 = System.IO.File.ReadLines(filewow2).ToList();
                string text = sr.ReadToEnd();
                string[] lines2 = Regex.Split(text, "\n");
                double total = lines2.Count();
                for (int i=0; i<=total; i++)
                {
                    string result = lines2[i].Contains(l1);
                }
                
                var result1 = l1.Where(lines2.Contains).ToList();

                if (result1.Count >= 3)
                {
                    richTextBox3.AppendText("The malicous IP is " + result1);
                }
                else
                {
                    richTextBox3.AppendText("This Ip:" + l1.ToString() + " has done some injection");
                }

               
                
               // double percentage = (result.Count() / total) * 100;
                

            }
                }

            }*/

            var previousLines1 = new HashSet<string>();

            File.WriteAllLines(refile, File.ReadLines(rifile)
                                                    .Where(line => previousLines1.Add(line)));

            using (StreamReader sr = new StreamReader(refile))
            {

                string text = sr.ReadToEnd();
                string[] lines = Regex.Split(text, "\n");
                double line = lines.Count();

                for (int i = 0; i < line; i++)
                {
                    richTextBox3.AppendText(lines[i] + "\n\n");
                }
            }

               // getCompareIP(matchIP,matchIP2);

            //File.WriteAllText(matchIP, String.Empty);
            //File.WriteAllText(matchIP2, String.Empty);
        }
       
        private void button5_MouseHover(object sender, EventArgs e)
        {
           
            System.Windows.Forms.ToolTip ToolTip5 = new System.Windows.Forms.ToolTip();
            ToolTip5.SetToolTip(this.button5, "Quick Scanning");


        }

        public void getCompareIP(string filewow1, string filewow2)
        {
            using (StreamReader sr = new StreamReader(filewow2))
            {
                List<string> l1 = System.IO.File.ReadLines(filewow1).ToList();
                string text = sr.ReadToEnd().Trim().Replace("\n", "");
                string[] lines2 = Regex.Split(text,"\r");
                double total1 = lines2.Count();

                 for (int i = 0; i < total1; i++)
                    {
                        
                            double totalcount = 0;
                            var result1 = l1.Where(lines2[i].Contains).ToList();
                            totalcount = result1.Count();
                            if (totalcount >= 3)
                            {
                                richTextBox3.AppendText("The malicous IP : "  +lines2[i]+ "\n\n");
                                richTextBox3.ForeColor = Color.Red;
                                
                            }
                            else
                            {
                                richTextBox3.AppendText("This Ip: " + lines2[i] + " is doing kind of SQL injection  \n");
                            }
                        

                        
                    }
                
               
                //int totalcount = result1.Count();
               






                // double percentage = (result.Count() / total) * 100;


            }
        }

       /** public void getTotalAccuracy()
        {
            double totaldetected =;
            double totalfeatures =;

            double accuracy = totaldetected / totalfeatures * 100;
        }*/

    

            public static int[] SearchString4(string str, string pat, string rifile, string refile)
        {
            List<int> retVal = new List<int>();
            int m = pat.Length;
            int n = str.Length;
            Console.WriteLine("pat length: " + m);
            Console.WriteLine("str lenght: " + n);

            int[] badChar = new int[256];

            BadCharHeuristic(pat, m, ref badChar);

            int s = 0;
            while (s <= (n - m))
            {
                int j = m - 1;

                while (j >= 0 && pat[j] == str[s + j])
                    --j;

                if (j < 0)
                {
                    retVal.Add(s);
                    if (str == "")
                    {


                    }
                    else
                    {

                        //File.WriteAllText(rifile, String.Empty);
                        //File.WriteAllText(refile, String.Empty);
                        if (File.Exists(refile) || File.Exists(rifile))
                        {
                            using (StreamWriter sw = File.AppendText(rifile))
                            {
                                sw.WriteLine(str);
                            }
                            var previousLines = new HashSet<string>();

                            File.WriteAllLines(refile, File.ReadLines(rifile)
                                                                    .Where(line => previousLines.Add(line)));

                        }
                        Console.WriteLine("the ans:" + s);


                    }

                    s += (s + m < n) ? m - badChar[str[s + m]] : 1;

                }

                else
                {

                    s += Math.Max(1, j - badChar[str[s + j]]);

                }
                

            }

            return retVal.ToArray();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string maltext2 = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\maltext2.txt";
            string refile = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\pattern2.txt";

            string trainben = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\trainben.txt";
            string trainben2 = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\trainben2.txt";
            File.WriteAllText(trainben, String.Empty);
            File.WriteAllText(trainben2, String.Empty);

            getComparemalware(maltext2, refile, trainben);

            var previousLines = new HashSet<string>();

            File.WriteAllLines(trainben2, File.ReadLines(trainben)
                                                    .Where(line => previousLines.Add(line)));

            using (StreamReader sr = new StreamReader(maltext2))
            using (StreamReader sr1 = new StreamReader(trainben2))
            {
                string text = sr1.ReadToEnd().Trim().Replace("\n","");
                string text1 = sr.ReadToEnd().Trim().Replace("\n", "");

                string[] lines = Regex.Split(text, "\r");
                string[] lines1 = Regex.Split(text1, "\r");

                double detectedMalware = lines.Count();
                double totalMalwareinTest = lines1.Count();

                double accuracy = detectedMalware / totalMalwareinTest * 100;

                richTextBox3.AppendText("The accuracy: "+accuracy+"%");

            }

                

        }
        
        /**private void button6_MouseHover(object sender, EventArgs e)
        {
            
            System.Windows.Forms.ToolTip ToolTip6 = new System.Windows.Forms.ToolTip();
            ToolTip6.SetToolTip(this.button6, "Calculate the Accuracy of Detected Malicious Log");


        }*/

        private void button8_Click(object sender, EventArgs e)
        {
            string filewow1 = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\kb1.txt";
            string filewow2 = @"C:\Users\TUF\Desktop\SQLiProjectFYP\SQLiProjectFYP\DATASET\kb2.txt";
           /** string trainben = @"C:\Users\amirul azman\Desktop\trainben.txt";
            string trainben2 = @"C:\Users\amirul azman\Desktop\trainben2.txt";
            getComparemalware(filewow1, filewow2, trainben);*/

            var previousLines = new HashSet<string>();

            File.WriteAllLines(filewow2, File.ReadLines(filewow1)
                                                    .Where(line => previousLines.Add(line)));
        }


        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            /**

            string MatchIP2 = @"C:\Users\amirul azman\Desktop\matchIP2.txt";
            using (StreamReader sr = new StreamReader(MatchIP2))
            {
                string text = sr.ReadToEnd().Trim().Replace("\n", "");
                string[] lines = Regex.Split(text, "\r");
                int ipmatch = lines.Count();

                for (int i=0; i<ipmatch; i++)
                {
                    if (!string.IsNullOrEmpty(lines[i]))
                    {
                        int t = this.richTextBox3.SelectionStart;
                        this.richTextBox3.SelectedText = lines[i];
                        //this.richTextBox3.SelectionStart = t;
                        this.richTextBox3.SelectionLength = lines[i].Length;
                    }
                }

               

            }*/

               
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(30);
                backgroundWorker1.ReportProgress(0);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Increment(+1);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Scan has been completed !");
        }
    }

}
               

