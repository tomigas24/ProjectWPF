using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GameCollection : Collection<Game>
    {
        #region Construtores

        public GameCollection()
        {
        }
        public GameCollection(DataTable dataTable)
        : this()
        {
            this.LoadList(dataTable);
        }

        #endregion

        #region Metodos

        public void LoadList(DataTable dataTable)
        {
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.AsEnumerable())
                {
                    Game game = new Game();
                    game.Id = dataRow.Field<long>("Id");
                    game.GameName = dataRow.Field<string>("GameName");
                    game.GameImage = dataRow.Field<string>("GameImage");
                    game.GenderId = dataRow.Field<long>("GenderId");
                    
                    this.Add(game);
                }
            }
        }

        #endregion

    }
}
