using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using KursovoiProject.ClassesOfTasks;

namespace KursovoiProject
{
    public partial class FormAdvice : Form
    {
        MainMenuForm formStart1;

        public FormAdvice(MainMenuForm formStart)
        {
            InitializeComponent();
            formStart.Hide();

            formStart1 = formStart;

            this.FormClosing += ((sender, e) =>
            {
                Application.Exit();
                DataBase.WriteInFile();
            });

            button1.Click += closingFormAdvice;


            label1.Text = "1. Приложение предлагает на выбор 4 варианта заданий на нормы русского языка.\n" +
                          "2. Перед Вами будет задача найти правильный ответ.\n" +
                          "3. При выборе правильного ответа будет гореть зеленый, иначе красный.\n" +
                          "4. Все результаты Ваших ответов записываются в статистику.\n";

            label2.Text = "1. Решайте этот тренажер КАЖДЫЙ ДЕНЬ по 15 мин, выбирая верные ответы.\n" +
                          "2. Цветовая гамма поможет запомнить верную норму.\n" +
                          "3. Благодаря постоянству Вы легко сможете вспомнить верное употребление нормы.";

            label3.Text = "1. Если вы не можете запомнить норму, то ей нужно выделить особое внимание.\n" +
                          "2. Пусть она будет всегда у вас перед глазами.\n" +
                          "3. Тогда вы точно запомните ее написание и не ошибетесь на экзамене";

            label4.Text = "1. Необходимо сразу понимать, сколько Вам нужно баллов для поступления.\n" +
                          "2. Посмотрите шкалу перевода баллов из первичных во вторичные.\n" +
                          "3. Поймите, какие задание Вам нужно научиться решать и углубитесь в них.";

            linkLabel1.Text = @"Ваш процент правильно решенных заданий по постановке ударений менее, чем 70%!

Чтобы улучшить свои знания в области постановки ударений в словах русского языка, мы предлагаем Вам:
1. Ознакомьтесь с теорией для данного задания по ссылке: https://rustutors.ru/egeteoriya/1137-zadanie-4.html
2. Уделяйте больше времени практике этого задания";

            linkLabel2.Text = @"Ваш процент правильно решенных заданий по лексике менее, чем 70%!

Чтобы улучшить свои знания в области лексических норм в русском языке, мы предлагаем Вам:
1. Ознакомьтесь с теорией для данного задания по ссылке: https://rustutors.ru/egeteoriya/1139-zadanie-6.html
2. Уделяйте больше времени практике этого задания";

            linkLabel3.Text = @"Ваш процент правильно решенных заданий по морфологии менее, чем 70%!

Чтобы улучшить свои знания в области морфологических норм в русском языке, мы предлагаем Вам:
1. Ознакомьтесь с теорией для данного задания по ссылке: https://rustutors.ru/egeteoriya/1140-zadanie-7.html
2. Выучите правильные формы слов
3. Уделяйте больше времени практике этого задания";

            linkLabel4.Text = @"Ваш процент правильно решенных заданий по паронимам менее, чем 70%!

Чтобы улучшить свои знания в области паронимов русского языка, мы предлагаем Вам:
1. Ознакомьтесь с теорией для данного задания по ссылке: https://rustutors.ru/egeteoriya/1138-zadanie-5.html
2. Выучите все слова и из значения из словаря паронимов
3. Уделяйте больше времени практике этого задания";


            TabPage accentTabPage = new TabPage();
            accentTabPage.Controls.Add(linkLabel1);
            accentTabPage.Text = "Ударения";

            TabPage lexTabPage = new TabPage();
            lexTabPage.Controls.Add(linkLabel2);
            lexTabPage.Text = "Лексика";

            TabPage morphTabPage = new TabPage();
            morphTabPage.Controls.Add(linkLabel3);
            morphTabPage.Text = "Морфология";

            TabPage paronsTabPage = new TabPage();
            paronsTabPage.Controls.Add(linkLabel4);
            paronsTabPage.Text = "Паронимы";

            if (AccentStatist.statisticsWrong != 0 && (double)AccentStatist.statisticsCorrect * 100 / (AccentStatist.statisticsCorrect + AccentStatist.statisticsWrong) < 70)
            {
                tabControl1.TabPages.Add(accentTabPage);
            }
            else
            {
                tabControl1.TabPages.Remove(accentTabPage);
            }

            if (LexStatist.statisticsWrong != 0 && (double)LexStatist.statisticsCorrect * 100 / (LexStatist.statisticsCorrect + LexStatist.statisticsWrong) < 70)
            {
                tabControl1.TabPages.Add(lexTabPage);
            }
            else
            {
                tabControl1.TabPages.Remove(lexTabPage);
            }

            if (MorphStatist.statisticsWrong != 0 && (double)MorphStatist.statisticsCorrect * 100 / (MorphStatist.statisticsCorrect + MorphStatist.statisticsWrong) < 70)
            {
                tabControl1.TabPages.Add(morphTabPage);
            }
            else
            {
                tabControl1.TabPages.Remove(morphTabPage);
            }

            if (ParonsStatist.statisticsWrong != 0 && (double)ParonsStatist.statisticsCorrect * 100 / (ParonsStatist.statisticsCorrect + ParonsStatist.statisticsWrong) < 70)
            {
                tabControl1.TabPages.Add(paronsTabPage);
            }
            else
            {
                tabControl1.TabPages.Remove(paronsTabPage);
            }
        }

        void closingFormAdvice(object sender, EventArgs e)
        {
            this.Hide();
            formStart1.Show();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdvice));
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.advice0 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.advice1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.advice2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.advice3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.tabControl1.SuspendLayout();
            this.advice0.SuspendLayout();
            this.advice1.SuspendLayout();
            this.advice2.SuspendLayout();
            this.advice3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(623, 370);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Меню";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.advice0);
            this.tabControl1.Controls.Add(this.advice1);
            this.tabControl1.Controls.Add(this.advice2);
            this.tabControl1.Controls.Add(this.advice3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(755, 334);
            this.tabControl1.TabIndex = 1;
            // 
            // advice0
            // 
            this.advice0.Controls.Add(this.label1);
            this.advice0.Location = new System.Drawing.Point(4, 29);
            this.advice0.Name = "advice0";
            this.advice0.Padding = new System.Windows.Forms.Padding(3);
            this.advice0.Size = new System.Drawing.Size(747, 301);
            this.advice0.TabIndex = 1;
            this.advice0.Text = "Как пользоваться";
            this.advice0.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // advice1
            // 
            this.advice1.Controls.Add(this.label2);
            this.advice1.Location = new System.Drawing.Point(4, 29);
            this.advice1.Name = "advice1";
            this.advice1.Padding = new System.Windows.Forms.Padding(3);
            this.advice1.Size = new System.Drawing.Size(747, 301);
            this.advice1.TabIndex = 0;
            this.advice1.Text = "Совет №1";
            this.advice1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // advice2
            // 
            this.advice2.Controls.Add(this.label3);
            this.advice2.Location = new System.Drawing.Point(4, 29);
            this.advice2.Name = "advice2";
            this.advice2.Size = new System.Drawing.Size(747, 301);
            this.advice2.TabIndex = 2;
            this.advice2.Text = "Совет №2";
            this.advice2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // advice3
            // 
            this.advice3.Controls.Add(this.label4);
            this.advice3.Location = new System.Drawing.Point(4, 29);
            this.advice3.Name = "advice3";
            this.advice3.Size = new System.Drawing.Size(747, 301);
            this.advice3.TabIndex = 3;
            this.advice3.Text = "Совет №3";
            this.advice3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 4);
            this.label4.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "label4";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(240, 51);
            this.linkLabel1.Location = new System.Drawing.Point(4, 4);
            this.linkLabel1.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(50, 20);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkArea = new System.Windows.Forms.LinkArea(217, 51);
            this.linkLabel2.Location = new System.Drawing.Point(4, 4);
            this.linkLabel2.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(50, 20);
            this.linkLabel2.TabIndex = 0;
            this.linkLabel2.Text = "linkLabel2";
            this.linkLabel2.UseCompatibleTextRendering = true;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.LinkArea = new System.Windows.Forms.LinkArea(224, 51);
            this.linkLabel3.Location = new System.Drawing.Point(4, 4);
            this.linkLabel3.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(50, 20);
            this.linkLabel3.TabIndex = 0;
            this.linkLabel3.Text = "linkLabel3";
            this.linkLabel3.UseCompatibleTextRendering = true;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.LinkArea = new System.Windows.Forms.LinkArea(211, 51);
            this.linkLabel4.Location = new System.Drawing.Point(4, 4);
            this.linkLabel4.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(50, 20);
            this.linkLabel4.TabIndex = 0;
            this.linkLabel4.Text = "linkLabel4";
            this.linkLabel4.UseCompatibleTextRendering = true;
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // FormAdvice
            // 
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(779, 451);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(698, 484);
            this.Name = "FormAdvice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tabControl1.ResumeLayout(false);
            this.advice0.ResumeLayout(false);
            this.advice0.PerformLayout();
            this.advice1.ResumeLayout(false);
            this.advice1.PerformLayout();
            this.advice2.ResumeLayout(false);
            this.advice2.PerformLayout();
            this.advice3.ResumeLayout(false);
            this.advice3.PerformLayout();
            this.ResumeLayout(false);

        }

        private Button button1 = new Button();
        private TabControl tabControl1;
        private TabPage advice0;
        private TabPage advice1;
        private TabPage advice2;
        private TabPage advice3;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process accentProcess = new Process();
            accentProcess.StartInfo.UseShellExecute = true;
            accentProcess.StartInfo.FileName = "https://rustutors.ru/egeteoriya/1137-zadanie-4.html";
            accentProcess.Start();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process lexProcess = new Process();
            lexProcess.StartInfo.UseShellExecute = true;
            lexProcess.StartInfo.FileName = "https://rustutors.ru/egeteoriya/1139-zadanie-6.html";
            lexProcess.Start();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process morphProcess = new Process();
            morphProcess.StartInfo.UseShellExecute = true;
            morphProcess.StartInfo.FileName = "https://rustutors.ru/egeteoriya/1140-zadanie-7.html";
            morphProcess.Start();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process paronsProcess = new Process();
            paronsProcess.StartInfo.UseShellExecute = true;
            paronsProcess.StartInfo.FileName = "https://rustutors.ru/egeteoriya/1138-zadanie-5.html";
            paronsProcess.Start();
        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel4;
    }
}
