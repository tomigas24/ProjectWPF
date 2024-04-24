using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Game
    {
        #region Constructors
        public Game() {
            this.id = 0;
            this.gameName = "";
            this.gameImage = "";
            this.genderId = 0;
        }

        public Game(long id, string gameName, string gameImage, long genderId) : this()
        {
            this.id = id;
            this.gameName = gameName;
            this.gameImage = gameImage;
            this.genderId = genderId;
        }
        #endregion

        #region Properties

        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string gameName;

        public string GameName
        {
            get { return gameName; }
            set { gameName = value; }
        }

        private string gameImage;

        public string GameImage
        {
            get { return gameImage; }
            set { gameImage = value; }
        }

        private long genderId;

        public long GenderId
        {
            get { return genderId; }
            set { genderId = value; }
        }

        #endregion

        #region Methods
        public void Novo() {
            this.id = 0;
            this.gameName = "";
            this.gameImage = "";
            this.genderId = 0;
        }

        public static Game GetGame(long id, out string error)
        {
            Game game = null;
            string gameName = "";
            string gameImage = "";
            long genderId = 0;
            

            bool ok = DataLayer.Game.GetGame(id, ref gameName, ref gameImage, ref genderId, out error);
            if (ok)
            {
                game = new Game(id, gameName, gameImage, genderId);
            }
            return game;
        }

        public static DataTable List()
        {
            DataTable dataTable = DataLayer.Game.ListGame();
            return dataTable;
        }

        public static GameCollection GetListGame()
        {
            string erro = string.Empty;
            DataTable dataTable = Game.List();
            GameCollection games = new GameCollection(dataTable);
            return games;
        }
        #endregion
    }
}
