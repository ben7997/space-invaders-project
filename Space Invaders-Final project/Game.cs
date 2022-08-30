using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Invaders_Final_project
{
    internal class Game: Form
    {
        private double score;
        private Timer timer1;
        private System.ComponentModel.IContainer components;
        private Player player = new Player();
        private List<Entity> entities = new List<Entity>();
        public Game() {
            this.InitializeComponent();
            this.Invalidate();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Game
            // 
            this.ClientSize = new System.Drawing.Size(405, 246);
            this.Name = "Game";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.ResumeLayout(false);

        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            player.draw(g);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(Entity entity in entities)
            {
                entity.update();
            }
            this.Invalidate(); 
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player.moveLeft();
                    break;
                case Keys.Right:
                    player.moveRight();
                    break;
                default:
                    break;
            }
        }
    }
}
