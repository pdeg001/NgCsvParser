using System.Windows.Forms;
using System.IO;

using System;
using System.Linq;


namespace zegrisCsvParser
{
    public partial class csvMain : Form
    {
        string fileDirectory, newCsv, newCsvContent;
        public csvMain()
        {
            InitializeComponent();
           
        }

        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnSelectFile_MouseUp(object sender, MouseEventArgs e)
        {
            string path;
            listBox1.Items.Clear();
            newCsvContent = "";
           

            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "CSV Bestanden (*.csv)|*.csv";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                txtSelectedFile.Text = path;
                OpenCsv();
                fileDirectory = Path.GetDirectoryName(path);
                newCsv = $"{fileDirectory}\\parsedCsv.csv";
                File.WriteAllText(newCsv, newCsvContent);
                MessageBox.Show("Csv bestand vewerkt..", "Zegris CSV Parser");
            }
        }

        private void OpenCsv()
        {
            using (var reader = new StreamReader(txtSelectedFile.Text))
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    CheckChar(line);
                   
                //    foreach (string item in values)
                //    {
                        string ItemText = values[6];
                        IsGramItem(ItemText);
                        IsLiterItem(ItemText);
                        
                //    }
                   
                }
        }

        //private bool IsGramItem(string item)
        //{
        //    int itemLen = item.Length-1;
        //    for (int i = itemLen; i >= 0; i--)
        //    {
        //        if (i < 0)
        //        {
        //            return false;
        //        }
        //        if (item.Substring(i, 1) == "g")
        //        {
        //            if (IsCharDigit(char.Parse(item.Substring(i-1, 1))) && i == itemLen)
        //            {
        //                Console.WriteLine($"GRAM GEVONDEN - {item} CHANGED TO  - {item}r");
        //                break;
        //            }
        //        }
        //    }

        //    return true;
        //}

        private bool IsGramItem(string item)
        {
            string oldItem = item;
            item = item.Replace(".", "");
            int itemLen = item.Length - 1;
            for (int i = itemLen; i >= 0; i--)
            {
                if (i < 0)
                {
                    return false;
                }
                if (item.Substring(i, 1) == "g")
                {
                    if (IsCharDigit(char.Parse(item.Substring(i - 1, 1))))
                    {
                        for (int y = i; y <= itemLen; y++)
                        {
                            if (item.Substring(y, 1) == " ")
                            {
                                item = item.Replace(item.Substring(i, y - i), "gr");
                                Console.WriteLine($"GRAM GEVONDEN - {oldItem} CHANGED TO  - {item}");
                                break;
                            }
                        }


                        if (item.Substring(i, itemLen - i) != "gr")
                        {
                            Console.WriteLine($"GRAM GEVONDEN - {item} CHANGED TO  - {item}r");
                            break;
                        }
                    }
                }
            }

            return true;
        }

        private bool IsLiterItem(string item)
        {
            string oldItem = item;
            item = item.Replace(".", "");
            int itemLen = item.Length - 1;
            for (int i = itemLen; i >= 0; i--)
            {
                if (i < 0)
                {
                    return false;
                }
                if (item.Substring(i, 1) == "l")
                {
                    if (IsCharDigit(char.Parse(item.Substring(i - 1, 1))))
                    {
                        for(int y = i; y <= itemLen; y++)
                        {
                            if (item.Substring(y, 1) == " ")
                            {
                                item = item.Replace(item.Substring(i, y-i), "ltr");
                                Console.WriteLine($"LITER GEVONDEN - {oldItem} CHANGED TO  - {item}");
                                break;
                            } 
                        }

                        
                        if (item.Substring(i, itemLen-i) != "ltr")
                        {
                            Console.WriteLine($"LITER GEVONDEN - {item} CHANGED TO  - {item}r");
                           break;
                        }
                    }
                }
            }

            return true;
        }

        public static bool IsCharDigit(char c)
        {
            return ((c >= '0') && (c <= '9'));
        }

        private void CheckChar(string strItem)
        {
            string[] ForbiddenChars = {"~", "!", "@", "#", "$", "%", "^", "&", "*", "."};
            //if (ForbiddenChars.Any(strItem.Contains))
            //{
            //    Console.WriteLine($"Char FOUND IN {strItem}");
            //} else
            //{
            // //   Console.WriteLine($"??");
            //}
           
            foreach (string strChr in ForbiddenChars)
            {
                if (strItem.IndexOf(strChr) > -1)
                {
                   // Console.WriteLine($"Char {strChr} FOUND IN {strItem}");
                    if (strChr == ".")// || strChr == "!")
                    {
                        strItem = strItem.Replace(strChr, "");
                    }
                }
            }
            newCsvContent = newCsvContent + strItem+"\n";
           
        }

       

    }
}
