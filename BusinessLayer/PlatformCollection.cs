using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PlatformCollection : Collection<Platform>
    {
        #region Construtores

        public PlatformCollection()
        {
        }
        public PlatformCollection(DataTable dataTable)
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
                Platform platform = new Platform();
                platform.Id = 0;
                platform.PlatformName = "All";

                this.Add(platform);

                foreach (DataRow dataRow in dataTable.AsEnumerable())
                {
                    platform = new Platform();
                    platform.Id = dataRow.Field<long>("Id");
                    platform.PlatformName = dataRow.Field<string>("PlatformName");

                    this.Add(platform);
                }
            }
        }


        public string GetPlatformNameById(int platformId)
        {
            Platform platform = this.FirstOrDefault(p => p.Id == platformId);

            return platform?.PlatformName;
        }

        public IEnumerable<Platform> GetFilterValues(LaunchCollection launches, long? publisherIdFiltered, ref long? platformIdFiltered)
        {
            if (!publisherIdFiltered.HasValue)
            {
                return this;
            }
            else
            {
                IEnumerable<long> platformIdFilter = launches.Where(k => k.PublisherId == publisherIdFiltered.Value).Select(k=>k.PlatformId).Distinct();

                if (platformIdFiltered.HasValue)
                {
                    if (!platformIdFilter.Contains(platformIdFiltered.Value))
                    {
                        platformIdFiltered = null;
                    }
                }
                return this.Where(p => platformIdFilter.Contains(p.Id));
            }
            
        }

        #endregion
    }
}
