using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KursovoiProject.ClassesOfTasks;

namespace KursovoiProject
{
    public partial class MainMenuForm : Form
    {

        public MainMenuForm()
        {
            InitializeComponent();

            DataBase.ReadFromFile();

            // События клика по кнопкам
            buttonStart.Click += button_Start;
            buttonStatist.Click += button_Statist;
            buttonAdvice.Click += button_Advice;
            buttonExit.Click += button_Exit;

            this.FormClosing += ((sender, e) =>
            {
                Application.Exit();
                DataBase.WriteInFile();
            });
        }

        // Обработка событий с кнопок
        void button_Start(object sender, EventArgs e)
        {
            StartForm formMenu2 = new StartForm(this);
            formMenu2.Show();
        }

        void button_Statist(object sender, EventArgs e)
        {
            FormStatist formStatist = new FormStatist(this);
            formStatist.Show();
        }

        void button_Advice(object sender, EventArgs e)
        {
            FormAdvice formAdvice = new FormAdvice(this);
            formAdvice.Show();
        }

        void button_Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
