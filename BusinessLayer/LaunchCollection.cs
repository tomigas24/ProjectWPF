using DataLayer;
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

        public int GetTotalLaunchesByFilter(int? year, long? platformId, long? publisherId)
        {
            int totalLaunches = this.Count(game => (year == null || game.RealeaseDate.Year == year ) && (platformId == null || game.PlatformId == platformId) && ( publisherId == null || game.PublisherId == publisherId));

            return totalLaunches;
        }

        public int GetTotalGamesByFilter(int? year, long? platformId, long? publisherId)
        {
            HashSet<long> distinctGameIds = new HashSet<long>();

            foreach (var game in this)
            {
                if ((year == null || game.RealeaseDate.Year == year) && (platformId == null || game.PlatformId == platformId) && (publisherId == 0 || game.PublisherId == publisherId))
                {
                    distinctGameIds.Add(game.GameId);
                }
            }

            return distinctGameIds.Count;
        }

        public long GetMostUsedPlatformByFilter(int? year, long? publisherId)
        {
            Dictionary<long, long> platformCounts = new Dictionary<long, long>();

            foreach (var game in this)
            {
                if ((year == null || game.RealeaseDate.Year == year) && (publisherId == null || game.PublisherId == publisherId))
                {
                    if (!platformCounts.ContainsKey(game.PlatformId))
                    {
                        platformCounts[game.PlatformId] = 0;
                    }
                    platformCounts[game.PlatformId]++;
                }
            }

            long maxCount = 0;
            long mostUsedPlatformId = -1;

            foreach (var kvp in platformCounts)
            {
                if (kvp.Value > maxCount)
                {
                    maxCount = kvp.Value;
                    mostUsedPlatformId = kvp.Key;
                }
            }

            return mostUsedPlatformId;
        }

        public long GetMostUsedPublisherByFilter(int? year, long? platformId)
        {
            Dictionary<long, long> publisherCounts = new Dictionary<long, long>();

            foreach (var game in this)
            {
                if ((year == null || game.RealeaseDate.Year == year) && (platformId == null || game.PlatformId == platformId))
                {
                    if (!publisherCounts.ContainsKey(game.PublisherId))
                    {
                        publisherCounts[game.PublisherId] = 0;
                    }
                    publisherCounts[game.PublisherId]++;
                }
            }

            long maxCount = 0;
            long mostUsedPublisherId = -1;

            foreach (var kvp in publisherCounts)
            {
                if (kvp.Value > maxCount)
                {
                    maxCount = kvp.Value;
                    mostUsedPublisherId = kvp.Key;
                }
            }

            return mostUsedPublisherId;
        }




        public int[] GetAllYears()
        {
            return this.Select(k => k.RealeaseDate.Year).Distinct().ToArray();
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
