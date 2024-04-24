using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class GenderCollection : Collection<Gender>
    {
        #region Construtores

        public GenderCollection()
        {
        }
        public GenderCollection(DataTable dataTable)
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
                    Gender gender = new Gender();
                    gender.Id = dataRow.Field<long>("Id");
                    gender.GenderName = dataRow.Field<string>("GenderName");

                    this.Add(gender);
                }
            }
        }

        #endregion
    }
}
