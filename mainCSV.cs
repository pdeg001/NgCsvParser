using System.Windows.Forms;
using System.IO;
using CsvHelper;
using System.Linq;


namespace zegrisCsvParser
{
    public partial class csvMain : Form
    {
        string fileDirectory, newCsvContent;
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
            newCsvContent = "";

            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "CSV Bestanden (*.csv)|*.csv";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                txtSelectedFile.Text = path;
                fileDirectory = Path.GetDirectoryName(path);
                OpenCsv();
                MessageBox.Show("Csv bestand vewerkt..", "Zegris CSV Parser");
            }
        }

        private void OpenCsv()
        {
            string newCsvText = "", newLine = "";
            string edtItem, newValue;
            int lineCount = 0;
            var csv = new StringWriter();
            using (var reader = new StreamReader(txtSelectedFile.Text))
                while (!reader.EndOfStream)
                {
                    string line = "";
                    line = reader.ReadLine();
                    if (lineCount == 0)
                    {
                        newCsvText += line + '\n';
                        csv.WriteLine(line);
                        lineCount++;
                        continue;
                    }
                    
                    var values = line.Split(';');

                    for(int i = 0; i < values.Length - 1; i++)
                    {
                        newLine += $"{values[i]};";
                        if(i == 6)
                        {
                            string ItemText = values[6];

                            edtItem = values[6];
                            string[] lookForGr = { "g", "gr" };
                            newValue = IsStringReplaceItem(edtItem, lookForGr, "gr", "r");
                            if (newValue != edtItem)
                            {
                                newLine = line.Replace(edtItem, NoGoChars(newValue));
                                csv.WriteLine(newLine);
                                continue;
                            }
                            string[] lookForLt = { "l", "lt" };
                            newValue = IsStringReplaceItem(edtItem, lookForLt, "ltr", "r");
                            if (newValue != edtItem)
                            {
                                newLine = line.Replace(edtItem, NoGoChars(newValue));
                                csv.WriteLine(newLine);
                                continue;
                            }
                            newLine = line.Replace(edtItem, NoGoChars(newValue));
                            csv.WriteLine(newLine);
                        }
                    }
                    
                    
                }
            File.WriteAllText($"{fileDirectory}\\parsed_Csv.csv", csv.ToString());
        }

        private string NoGoChars(string edtItem)
        {
            string newItemDescr;
            newItemDescr = edtItem.Replace(".", "");
            newItemDescr = newItemDescr.Replace("&", " & ");
            newItemDescr = newItemDescr.Replace("<", "");
            newItemDescr = newItemDescr.Replace(">", "");
            newItemDescr = newItemDescr.Replace("!", "");

            return newItemDescr;

        }

        private string IsStringReplaceItem(string item, string[] lookFor, string replaceWith, string addCharacter)
        {
            string oldItem = item;
            int itemLen = item.Length - 1;
            int i, y;
            if(itemLen == 0)
            {
                return item;
            }

            for (i = itemLen; i >= 0; i--)
            {
                if (i < 0)
                {
                    return item;
                }
                
                if (lookFor.Contains(item.Substring(i, 1)))
                {
                    if (IsCharDigit(char.Parse(item.Substring(i - 1, 1))))
                    {
                        for (y = i; y <= itemLen; y++)
                        {
                            //FIND FIRST SPACE, THIS MEANS THE FOUND IS IN BETWEEN
                            if (item.Substring(y, 1) == " ")
                            {
                                item = item.Replace(item.Substring(i, y - i), replaceWith);
                             //   Console.WriteLine($"{debugTxt} GEVONDEN - {oldItem} CHANGED TO  - {item}");
                                return item;
                            }

                            //END OF LINE REACHED
                            if (y == itemLen)
                            {
                                //GO BACK TO POS Y + 1 AND REPLACE ALL TO END OF LINE
                                int startPos, endPos;
                                startPos = i;
                                endPos = itemLen - (i - 1);
                              //  Console.WriteLine($"{debugTxt} GEVONDEN - {item} CHANGED TO  - {item.Replace(item.Substring(startPos, endPos), replaceWith)}");
                                return item.Replace(item.Substring(startPos, endPos), replaceWith);
                            }
                        }
                    }
                }
            }

            return item;
        }

        public static bool IsCharDigit(char c)
        {
            return ((c >= '0') && (c <= '9'));
        }
        
        private string CheckChar(string strItem)
        {
            string[] ForbiddenChars = {"~", "!", "@", "#", "$", "%", "^", "&", "*", "."};
                      
            foreach (string strChr in ForbiddenChars)
            {
                if (strItem.IndexOf(strChr) > -1)
                {
                    if (strChr == ".")// || strChr == "!")
                    {
                        strItem = strItem.Replace(strChr, "");
                    }
                }
            }
            newCsvContent = newCsvContent + strItem+"\n";
            return $"{strItem}\n";
        }

       

    }
}
