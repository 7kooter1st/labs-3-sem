using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace lab4
{
    public partial class Form1 : Form
    {
    private HashSet<string> allLinesText;
    public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                ofd.InitialDirectory = "";
                ofd.Filter = "txt files(*.txt) | *.txt | All files(*.*) | *.*";
                txt1.Text = Path.GetFileName(ofd.FileName);
            }
            var sw = Stopwatch.StartNew();
            allLinesText = File.ReadAllText(ofd.InitialDirectory + txt1.Text).Split(' ', '\n', '\r', ',', ';', ':', '.', '!', '?', '-').ToHashSet();
            sw.Stop();
            lbl.Text = "время выполнения: " + sw.Elapsed.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sw = Stopwatch.StartNew();
            string resultWord = null;
            string searchWord = txt2.Text;
            if (allLinesText.Contains(searchWord))
            {
                resultWord = searchWord;
                lst.Items.Add(resultWord);
            }
            sw.Stop();

            lbl2.Text = "Время поиска: " + sw.ElapsedMilliseconds.ToString();
        }
    }
}
