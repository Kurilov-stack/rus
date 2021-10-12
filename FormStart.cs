using KursovoiProject.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KursovoiProject
{
    public partial class StartForm : Form
    {
        MainMenuForm mainMenuForm;

        public StartForm(MainMenuForm mainMenuForm)
        {
            InitializeComponent();
            mainMenuForm.Hide();

            this.mainMenuForm = mainMenuForm;

            //обработка кнопок
            buttonAccents.Click += button_Accents;
            buttonParons.Click += button_Parons;
            buttonLex.Click += button_Lex;
            buttonMorf.Click += button_Morf;
            buttonMenu.Click += button_Menu;

            this.FormClosing += ((sender, e) =>
            {
                Application.Exit();
                DataBase.WriteInFile();
            });
        }

        //обработка закрытия
        void closongFormStart(object sender, EventArgs e)
        {
            mainMenuForm.Show();
        }

        //обработка кнопок
        void button_Accents(object sender, EventArgs e)
        {
            Accents accentsForm = new Accents(mainMenuForm, this);
            accentsForm.Show();
        }

        void button_Parons(object sender, EventArgs e)
        {
            Parons paronsForm = new Parons(mainMenuForm, this);
            paronsForm.Show();
        }

        void button_Lex(object sender, EventArgs e)
        {
            Lex lexForm = new Lex(mainMenuForm, this);
            lexForm.Show();
        }

        void button_Morf(object sender, EventArgs e)
        {
            Morph morphForm = new Morph(mainMenuForm, this);
            morphForm.Show();
        }

        void button_Menu(object sender, EventArgs e)
        {
            mainMenuForm.Show();
            this.Hide();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }
    }
}
