﻿using Macao.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Macao
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void StartGameBtn_Click(object sender, EventArgs e)
        {
            GamePlaceForm gamePlace = new GamePlaceForm();
            gamePlace.Show();

            this.Hide();
        }
    }
}