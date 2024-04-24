using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer 
{
    public class LaunchCollection : Collection<Launch>
    {

        #region Construtores

        public LaunchCollection()
        {
        }
        public LaunchCollection(DataTable dataTable)
        : this()
        {
            this.LoadList(dataTable);
        }

        public int GetTotalLaunches()
        {
            int totalGames = 0;


            totalGames = this.Select(k => k.Id).Distinct().Count();
            return totalGames;
        }
        public int GetTotalGames()
        {
            int totalGames = 0;


            totalGames = this.Select(k => k.GameId).Distinct().Count();
            return totalGames;
        }

        #endregion

        #region Metodos

        public void LoadList(DataTable dataTable)
        {
            if (dataTable != null)
            {
                foreach (DataRow dataRow in dataTable.AsEnumerable())
                {
                    Launch launch = new Launch();
                    launch.Id = dataRow.Field<long>("Id");
                    launch.GameId = dataRow.Field<long>("GameId");
                    launch.RealeaseDate = dataRow.Field<DateTime>("ReleaseDate");
                    launch.Rating = (float)dataRow.Field<double>("Rating");
                    launch.Price = (float)dataRow.Field<double>("Price");
                    launch.SalesNumber = dataRow.Field<long>("SalesNumber");
                    launch.PlatformId = dataRow.Field<long>("PlatformId");
                    launch.PublisherId = dataRow.Field<long>("PublisherId");

                    this.Add(launch);
                }
            }
        }

        #endregion

    }
}
