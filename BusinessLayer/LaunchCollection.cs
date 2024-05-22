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

        public int[] GetAllYears()
        {
            return this.Select(k => k.RealeaseDate.Year).Distinct().ToArray();
        }


        public int GetTotalLaunchesByFilter(int year, long platformId)
        {
            int totalGames = this.Count(game => (game.RealeaseDate.Year == year ||year == 0) && (game.PlatformId == platformId || platformId == 0));

            return totalGames;
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

    }
}
