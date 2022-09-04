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
        private List<Entity> entities = new List<Entity>(10);
        public Game()
        {
            this.InitializeComponent();
            Entity.border = this.ClientSize;
            entities.Add(this.player);
            entities.Add(new Invader());

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
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            this.ResumeLayout(false);


        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach(Entity entity in entities)
            {
                entity.draw(g);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach(Entity entity in entities)
            {
                entity.update();
            }
            entities=entities.FindAll(entity => entity.IsAlive);
            this.Invalidate(); 
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player.LeftPress=true;
                    break;
                case Keys.Right:
                    player.RightPress=true;
                    break;
                case Keys.Space:
                    player.shoot(entities);
                    break;
                default:
                    break;
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player.LeftPress=false;
                    break;
                case Keys.Right:
                    player.RightPress=false;
                    break;
                default:
                    break;
            }
        }
    }
}
