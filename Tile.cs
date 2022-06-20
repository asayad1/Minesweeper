using System.Windows.Forms;
using System.Drawing;

namespace Minesweeper
{
    internal class Tile
    {
        public Tile(Form1 form, Point location, Size size, int id)
        {
            // Initialize tile values 
            RenderForm = form;
            Location = location;
            Size = size;
            ID = id;
            IsSafe = true;
            Flagged = false;
            Visited = false;            
            SurroundingMines = 0;

            // Add a mouse click event
            tile.MouseClick += Tile_Click;
        }

        #region Helper Functions
        // Name: RenderTile
        // Desc: Sets up tile properties and adds it to form controls
        public void RenderTile()
        {
            tile.Location = Location;
            tile.Size = Size;
            tile.Image = Properties.Resources.facingDown;
            tile.SizeMode = PictureBoxSizeMode.StretchImage;
            tile.BorderStyle = BorderStyle.FixedSingle;

            RenderForm.Controls.Add(tile);
        }

        
        // Name: RenderImage
        // Desc: Assigns the proper image based on the # of surrounding mines
        public void RenderImage()
        {
            switch (SurroundingMines)
            {
                case 0: tile.Image = Properties.Resources._0;
                    break;

                case 1: tile.Image = Properties.Resources._1;
                    break;

                case 2: tile.Image = Properties.Resources._2;
                    break;

                case 3: tile.Image = Properties.Resources._3;
                    break;

                case 4: tile.Image = Properties.Resources._4;
                    break;

                case 5: tile.Image = Properties.Resources._5;
                    break;

                case 6: tile.Image = Properties.Resources._6;
                    break;

                case 7: tile.Image = Properties.Resources._7;
                    break;

                case 8: tile.Image = Properties.Resources._8;
                    break;
            }
        }
        #endregion

        #region Events
        // Name: Tile_Click
        // Desc: Handles game creation on first click, and then revealing & placing flags/tiles
        private void Tile_Click(object sender, MouseEventArgs e)
        {
            // When a tile is clicked, start the game 
            if (!RenderForm.gameStart)
            {
                RenderForm.gameStart = true;
                RenderForm.GenerateMines(ID);
                RenderForm.CalculateSurroundingMines();
            }

            switch (e.Button)
            { 
                // Reveal the tile 
                case MouseButtons.Left:
                    RenderForm.RevealTiles(ID);                    
                    break;

                // Place a flag 
                case MouseButtons.Right:
                    // Make sure that the tile we want to put a flag in isnt visited
                    if (!Visited)
                    {
                        if (!Flagged && RenderForm.flagsLeft > 0)
                        {
                            // Place the flag 
                            Flagged = true;
                            tile.Image = Properties.Resources.flagged;
                            RenderForm.flagsLeft--;

                            // Check win condition whenever we place a flag
                            RenderForm.CheckWinCondition();
                        }
                        else if (Flagged)
                        {
                            // Remove the flag 
                            Flagged = false;
                            RenderForm.flagsLeft++;
                            tile.Image = Properties.Resources.facingDown;
                        }
                        RenderForm.UpdateFlags();
                    }
                    break;
            }
        }
        #endregion

        #region Member Variables
        Form1 RenderForm;
        public PictureBox tile = new PictureBox();
        public bool IsSafe { get; set; }
        public int ID { get; set; }
        public bool Flagged { get; set; }
        public int SurroundingMines { get; set; }
        public bool Visited { get; set; }
        Point Location { get; set; }
        Size Size { get; set; }  
        #endregion
    }
}
