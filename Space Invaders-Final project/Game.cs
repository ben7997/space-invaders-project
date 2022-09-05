using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        private Player player;
        private Timer timer2;
        private ToolStrip toolStrip1;
        private ToolStripButton saveBtn;
        private ToolStripButton LoadBtn;
        private List<Entity> entities = new List<Entity>(10);
        public Game()
        {
            this.InitializeComponent();
            Entity.border = this.ClientSize;
            player = new Player(this.ClientSize.Width/2, this.ClientSize.Height);
            entities.Add(this.player);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.saveBtn = new System.Windows.Forms.ToolStripButton();
            this.LoadBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveBtn,
            this.LoadBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(521, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // saveBtn
            // 
            this.saveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBtn.Image")));
            this.saveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(35, 22);
            this.saveBtn.Text = "Save";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // LoadBtn
            // 
            this.LoadBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadBtn.Image = ((System.Drawing.Image)(resources.GetObject("LoadBtn.Image")));
            this.LoadBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadBtn.Name = "LoadBtn";
            this.LoadBtn.Size = new System.Drawing.Size(37, 22);
            this.LoadBtn.Text = "Load";
            this.LoadBtn.Click += new System.EventHandler(this.LoadBtn_Click);
            // 
            // Game
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(521, 326);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Game";
            this.Text = "Game";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
                entity.isColied(entities);
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Invader.enemyCount < 5)
            { 
                entities.Add(new Invader());
            }
        }

            private void saveBtn_Click(object sender, EventArgs e)
        {
            using (Stream stream = File.Open("save.bin", FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, entities);
            }
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            using (Stream stream = File.Open("data.bin", FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                this.entities=(List<Entity>)bin.Deserialize(stream);
                this.player =(Player)entities.Find(entity => entity is Player);
            }
        }
    }
}
