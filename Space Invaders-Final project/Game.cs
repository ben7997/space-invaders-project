using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Invaders_Final_project
{
    internal class Game: Form
    {
        private double score;
        private Player player = new Player();
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Game
            // 
            this.ClientSize = new System.Drawing.Size(405, 246);
            this.Name = "Game";
            this.ResumeLayout(false);
            player.draw();

        }
    }
}
