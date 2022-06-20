using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ResetGame();
        }

        #region Helper Functions
        // Name: ResetGame
        // Desc: Hands all tiles from previous game to GC and creates new ones
        void ResetGame()
        {
            // Dispose tiles from previous game and allocate new tiles
            DisposeCurrentTiles();
            CreateNewTiles();
            mine_ids.Clear();

            // Renders each tile, resets the # of flags left
            foreach (Tile tile in tiles)
            {
                tile.RenderTile();
            }

            gameStart = false; 
            flagsLeft = 0;
            UpdateFlags();
        }


        // Name: DisposeCurrentTiles
        // Desc: Passes tiles to GC
        void DisposeCurrentTiles()
        {
            // Removes all current tiles from the game 
            foreach (Tile t in tiles)
            {
                t.tile.Dispose();
                t.tile.Location = new Point(-100, -100);
            }

            tiles.Clear();
        }


        // Name: CreateNewTiles
        // Desc: Creates new tiles for the game
        void CreateNewTiles()
        {
            // Determine dimensions of the board
            int numToCreate = 0;
            int size = 0;

            switch (Mode)
            {
                case MODES.EASY:
                    numToCreate = 64;
                    size = 60;
                    break;

                case MODES.MEDIUM:
                    numToCreate = 256;
                    size = 30;
                    break;

                case MODES.DIFFICULT:
                    numToCreate = 576;
                    size = 20;
                    break;
            }

            // Initialize the tile
            int x = 0;
            int y = -1;

            for (int i = 0; i < numToCreate; i++)
            {
                // Calculate tile offsets
                if (i % Math.Sqrt(numToCreate) == 0)
                {
                    x = 0;
                    y++;
                }
                else
                {
                    x++;
                }

                tiles.Add(new Tile(this, new Point(x * size, y * size), new Size(size, size), i));
            }
        }


        // Name: GetTileFromID
        // Desc: Gets a tile instance from an ID lmao 
        Tile GetTileFromID(int id)
        {
            return (id >= 0) ? tiles[id] : null;
        }


        // Name: UpdateFlags
        // Desc: Updates the text in the flag label to the # of flags left
        public void UpdateFlags()
        {
            flagLabel.Text = flagsLeft.ToString();
        }


        // Name: GenerateMines
        // Desc: Generates mines lmao
        public void GenerateMines(int safe_id)
        {
            // Calculate the number of mines to place 
            int minesToPlace = (int)Math.Ceiling(0.2 * tiles.Count);
            flagsLeft = minesToPlace;
            UpdateFlags();

            // Reserve the surrounding spaces around a square
            List<int> reservedIDs = new List<int>();
            foreach (Tile t in GetNeighbors(safe_id))
            {
                reservedIDs.Add(t.ID);
            }

            // Place the mines based on RNG + the reserved squares
            Random rand = new Random();
            while (minesToPlace > 0)
            {
                int mine_id = rand.Next(0, tiles.Count);

                if (!mine_ids.Contains(mine_id) && mine_id != safe_id && !reservedIDs.Contains(mine_id))
                {
                    // Place a mine 
                    mine_ids.Add(mine_id);
                    GetTileFromID(mine_id).IsSafe = false;
                    minesToPlace--;
                }   
            }
        }


        // Name: CalculateSurroundingMines
        // Desc: Calculates the number of adjacent mines near a tile
        public void CalculateSurroundingMines()
        {
            foreach (int mine in mine_ids)
            {
                foreach (Tile tile in GetNeighbors(mine))
                {
                    if (tile.IsSafe)
                    {
                        tile.SurroundingMines++;
                    }
                }
            }
        }


        // Name: RevealTiles
        // Desc: Reveals local tiles when clicked
        public void RevealTiles(int ID)
        {
            // Set the current tile as visited
            GetTileFromID(ID).Visited = true; 

            // Make sure we aren't stepping on a mine 
            if (GetTileFromID(ID).IsSafe)
            {
                // Check to see if the tile is adjacent to a mine
                if (GetTileFromID(ID).SurroundingMines > 0)
                {
                    // Reveal the number of adjacent mines and then stop 
                    RevealSingleTile(ID);
                }
                else
                {
                    /// Flood fill algorithm to reveal tiles around the empty tile

                    // Get the list of neighbors
                    foreach (Tile tile in GetNeighbors(ID))
                    {
                        if (!tile.Visited)
                        {
                            RevealSingleTile(ID);
                            RevealTiles(tile.ID);
                        }
                    }
                }
            }
            else
            {
                // Game over!
                RevealAllBombs();
                timer.Start();
            }
        }


        // Name: RevealAllBombs
        // Desc: Reveals all bombs on the grid lmao 
        void RevealAllBombs()
        {
            foreach (int id in mine_ids)
            {
                GetTileFromID(id).tile.Image = Properties.Resources.bomb;
            }
        }


        // Name: RevealSingleTile
        // Desc: Reveals the tile and removes any flag it has
        void RevealSingleTile(int ID)
        {
            GetTileFromID(ID).RenderImage();

            if (GetTileFromID(ID).Flagged)
            {
                GetTileFromID(ID).Flagged = false;
                flagsLeft++;
                UpdateFlags();
            }
        }

        // Name: ResetColors
        // Desc: Resets the background color of the difficulty options
        void ResetColors()
        {
            easyButton.BackColor = Color.Transparent;
            mediumButton.BackColor = Color.Transparent;
            hardButton.BackColor = Color.Transparent;
        }


        // Name: GetNeighbors
        // Desc: Gets all adjacent tiles given a valid ID
        List<Tile> GetNeighbors(int ID)
        {
            List<Tile> neighbors = new List<Tile>();

            // Calculate the side length of the square grid
            int side = (int)Math.Sqrt(tiles.Count);

            // Get the neighboring tiles 
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int temp_ID = ID + (i * side) + j;

                    // Filter out any squares that aren't directly adjacent (edge case handler)
                    if (temp_ID != ID && temp_ID >= 0 && temp_ID < tiles.Count && (Math.Abs((temp_ID % side) - (ID % side)) <= 1))
                    {
                        neighbors.Add(GetTileFromID(temp_ID));
                    }
                }
            }

            return neighbors;
        }
        
        
        // Name: CheckWinConditions
        // Desc: Checks whether or not all mines are flagged
        public void CheckWinCondition()
        {
            bool gameOver = true; 
            foreach (int ID in mine_ids)
            {
                if (!GetTileFromID(ID).Flagged)
                {
                    gameOver = false; 
                }
            }
            if (gameOver)
            {
                timer.Start();
            }
        }
        #endregion

        #region Events
        // Name: timer_Tick
        // Desc: Resets the game whenever a game over occurs
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            ResetGame();
        }


        // Name: easyButton_Click
        // Desc: Sets the mode to easy and starts the game 
        private void easyButton_Click(object sender, EventArgs e)
        {
            ResetColors();
            easyButton.BackColor = Color.LightGray;
            Mode = MODES.EASY;
            ResetGame();
        }


        // Name: mediumButton_Click
        // Desc: Sets the mode to medium and starts the game 
        private void mediumButton_Click(object sender, EventArgs e)
        {
            ResetColors();
            mediumButton.BackColor = Color.LightGray;
            Mode = MODES.MEDIUM;
            ResetGame();
        }

        // Name: hardButton_Click
        // Desc: Sets the mode to hard and starts the game 
        private void hardButton_Click(object sender, EventArgs e)
        {
            ResetColors();
            hardButton.BackColor = Color.LightGray;
            Mode = MODES.DIFFICULT;
            ResetGame();
        }
        #endregion

        #region Member Variables
        public enum MODES { EASY = 0, MEDIUM = 1, DIFFICULT = 2 };  // Enum for game modes 
        public MODES Mode { get; set; }
        public bool gameStart = false;
        public int flagsLeft = 0;       
        List<Tile> tiles = new List<Tile>();    // List of tile instances
        List<int> mine_ids = new List<int>();   // List of mine IDs 
        #endregion
    }
}
