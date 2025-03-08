using Macao.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Macao
{
    public partial class ChooseColorForm : Form
    {

        public CardSymbolEnum SelectedOption { get; set; } = new CardSymbolEnum();
        public ChooseColorForm()
        {
            InitializeComponent();
        }

        private void ClubButton_Click(object sender, EventArgs e)
        {
            SelectedOption = CardSymbolEnum.Club;
            this.DialogResult = DialogResult.OK;
        }

        private void DiamondButton_Click(object sender, EventArgs e)
        {
            SelectedOption = CardSymbolEnum.Diamond;
            this.DialogResult = DialogResult.OK;
        }

        private void HeartButton_Click(object sender, EventArgs e)
        {
            SelectedOption = CardSymbolEnum.Heart;
            this.DialogResult = DialogResult.OK;
        }

        private void SpadeButton_Click(object sender, EventArgs e)
        {
            SelectedOption = CardSymbolEnum.Spade;
            this.DialogResult = DialogResult.OK;
        }
    }
}
