using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace typinggame
{
    public partial class Form1 : Form
    {
        static string path = Directory.GetCurrentDirectory();
        // Goes back 3 folders 
        static string contents = File.ReadAllText(path + "../../../Listan.txt").Replace(",", ""); 
        string[] words = contents.Split();

        Random rnd = new Random();
        Stopwatch klocka = new Stopwatch(); // Creates a timer 
        
        int totalwords = 0; // Total amount of words written by the user
        int correct = 0;
        int incorrect = 0;

        public Form1()
        {
            InitializeComponent();

            lblword.Text = words[rnd.Next(0, words.Length)]; // What words are shown
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void CheckGame(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) // If the user presses space...
            {
                if (textBox1.Text == lblword.Text + ' ')
                {
                    correct++; // +1 to correct
                    lblword.Text = words[rnd.Next(0, words.Length)];
                    textBox1.Text = null;
                }
                else
                {
                    incorrect++;
                    lblword.Text = words[rnd.Next(0, words.Length)];
                    textBox1.Text = null;
                }

                lblright.Text = "Correct: " + correct;
                lblwrong.Text = "Incorrect " + incorrect;
                totalwords++;
                lblacc.Text = "Accuracy: " + 100 * correct / totalwords + '%';

                if (totalwords == 1) // When the first word is written the timer starts
                { 
                    klocka.Start();
                }
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        { // Caculates the wpm updates it every 10 milliseconds 
            Timer1.Text = "Wpm: " + 60 * correct / (float)klocka.Elapsed.TotalSeconds; 
        }
    }
}
