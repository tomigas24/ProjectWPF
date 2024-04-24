using System;
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
                foreach (DataRow dataRow in dataTable.AsEnumerable())
                {
                    Platform platform = new Platform();
                    platform.Id = dataRow.Field<long>("Id");
                    platform.PlatformName = dataRow.Field<string>("PlatformName");

                    this.Add(platform);
                }
            }
        }

        #endregion
    }
}
