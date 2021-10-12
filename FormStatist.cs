using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using KursovoiProject.ClassesOfTasks;


namespace KursovoiProject
{
    public partial class FormStatist : Form
    {
        MainMenuForm formStart1;
        public FormStatist(MainMenuForm formStart)
        {
            InitializeComponent();
            formStart.Hide();

            formStart1 = formStart;

            this.FormClosing += ((sender, e) =>
            {
                Application.Exit();
                DataBase.WriteInFile();
            });


            StatTable();

            buttonClear.Click += buttonClear_Click;
            buttonExit.Click += buttonExit_Click;
        }

        void closongFormStatist(object sender, EventArgs e)
        {
            formStart1.Show();
        }

        void StatTable()
        {
            // Вывод статистики по ударениям
            labelCorrectAccent.Text = $"     {AccentStatist.statisticsCorrect / 2}";
            labelWrongAccent.Text = $"     {AccentStatist.statisticsWrong / 2}";

            if (AccentStatist.statisticsCorrect + AccentStatist.statisticsWrong == 0)
                labelAccentPersent.Text = "   0";
            else if (AccentStatist.statisticsCorrect == 0)
                labelAccentPersent.Text = "   0";
            else if (AccentStatist.statisticsWrong == 0)
                labelAccentPersent.Text = "   100";
            else
            {
                double percentAccent = (double)AccentStatist.statisticsCorrect / (double)(AccentStatist.statisticsCorrect + AccentStatist.statisticsWrong);
                labelAccentPersent.Text = $"    {Math.Truncate(percentAccent * 100)}";
            }

            // Вывод статистики по паронимам
            labelCorrectParons.Text = $"     {ParonsStatist.statisticsCorrect}";
            labelWrongParons.Text = $"     {ParonsStatist.statisticsWrong}";

            if (ParonsStatist.statisticsCorrect + ParonsStatist.statisticsWrong == 0)
                labelParonsPersent.Text = "   0";
            else if (ParonsStatist.statisticsCorrect == 0)
                labelParonsPersent.Text = "   0";
            else if (ParonsStatist.statisticsWrong == 0)
                labelParonsPersent.Text = "   100";
            else
            {
                double percentParons = (double)ParonsStatist.statisticsCorrect / (double)(ParonsStatist.statisticsCorrect + ParonsStatist.statisticsWrong);
                labelParonsPersent.Text = $"    {Math.Truncate(percentParons * 100)}";
            }

            // Вывод статистики по лексике
            labelCorrectLex.Text = $"     {LexStatist.statisticsCorrect}";
            labelWrongLex.Text = $"     {LexStatist.statisticsWrong}";

            if (LexStatist.statisticsCorrect + LexStatist.statisticsWrong == 0)
                labelLexPersent.Text = "   0";
            else if (LexStatist.statisticsCorrect == 0)
                labelLexPersent.Text = "   0";
            else if (LexStatist.statisticsWrong == 0)
                labelLexPersent.Text = "   100";
            else
            {
                double percentLex = (double)LexStatist.statisticsCorrect / (double)(LexStatist.statisticsCorrect + LexStatist.statisticsWrong);
                labelLexPersent.Text = $"    {Math.Truncate(percentLex * 100)}";
            }

            // Вывод статистики по морфологии
            labelCorrectMorph.Text = $"     {MorphStatist.statisticsCorrect}";
            labelWrongMorph.Text = $"     {MorphStatist.statisticsWrong}";

            if (MorphStatist.statisticsCorrect + MorphStatist.statisticsWrong == 0)
                labelMorphPersent.Text = "   0";
            else if (MorphStatist.statisticsCorrect == 0)
                labelMorphPersent.Text = "   0";
            else if (MorphStatist.statisticsWrong == 0)
                labelMorphPersent.Text = "   100";
            else
            {
                double percentMorph = (double)MorphStatist.statisticsCorrect / (double)(MorphStatist.statisticsCorrect + MorphStatist.statisticsWrong);
                labelMorphPersent.Text = $"    {Math.Truncate(percentMorph * 100)}";
            }

            // Изменение цвета текста у процента, если он меньше 70
            if (Convert.ToInt32(labelAccentPersent.Text) < Convert.ToInt32("   70") && AccentStatist.statisticsWrong != 0)
                labelAccentPersent.ForeColor = Color.Red;

            if (Convert.ToInt32(labelLexPersent.Text) < Convert.ToInt32("   70") && LexStatist.statisticsWrong != 0)
                labelLexPersent.ForeColor = Color.Red;

            if (Convert.ToInt32(labelParonsPersent.Text) < Convert.ToInt32("   70") && ParonsStatist.statisticsWrong != 0)
                labelParonsPersent.ForeColor = Color.Red;

            if (Convert.ToInt32(labelMorphPersent.Text) < Convert.ToInt32("   70") && MorphStatist.statisticsWrong != 0)
                labelMorphPersent.ForeColor = Color.Red;

            // Изменение цвета текста у процента, если он меньше 70
            if (Convert.ToInt32(labelAccentPersent.Text) >= Convert.ToInt32("   70") && AccentStatist.statisticsWrong != 0)
                labelAccentPersent.ForeColor = Color.DarkGreen;

            if (Convert.ToInt32(labelLexPersent.Text) >= Convert.ToInt32("   70") && LexStatist.statisticsWrong != 0)
                labelLexPersent.ForeColor = Color.DarkGreen;

            if (Convert.ToInt32(labelParonsPersent.Text) >= Convert.ToInt32("   70") && ParonsStatist.statisticsWrong != 0)
                labelParonsPersent.ForeColor = Color.DarkGreen;

            if (Convert.ToInt32(labelMorphPersent.Text) >= Convert.ToInt32("   70") && MorphStatist.statisticsWrong != 0)
                labelMorphPersent.ForeColor = Color.DarkGreen;
        }

        // Сброс статистики
        private void buttonClear_Click(object sender, EventArgs e)
        {
            AccentStatist.statisticsCorrect = 0;
            AccentStatist.statisticsWrong = 0;

            LexStatist.statisticsCorrect = 0;
            LexStatist.statisticsWrong = 0; 

            ParonsStatist.statisticsCorrect = 0;
            ParonsStatist.statisticsWrong = 0; 

            MorphStatist.statisticsCorrect = 0;
            MorphStatist.statisticsWrong = 0;

            labelAccentPersent.ForeColor = Color.Black;
            labelLexPersent.ForeColor = Color.Black;
            labelParonsPersent.ForeColor = Color.Black;
            labelMorphPersent.ForeColor = Color.Black;
            StatTable();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            formStart1.Show();
        }

        private void FormStatist_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string pathWrongDocument = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Files\Wrong paronims.txt");
            Process accentProcess = new Process();
            accentProcess.StartInfo.UseShellExecute = true;
            accentProcess.StartInfo.FileName = pathWrongDocument;
            accentProcess.Start();
        }
    }
}
