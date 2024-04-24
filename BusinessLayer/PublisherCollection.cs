using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PublisherCollection : Collection<Publisher>
    {
        #region Construtores

        public PublisherCollection()
        {
        }
        public PublisherCollection(DataTable dataTable)
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
                    Publisher publisher = new Publisher();
                    publisher.Id = dataRow.Field<long>("Id");
                    publisher.PublisherName = dataRow.Field<string>("PublisherName");

                    this.Add(publisher);
                }
            }
        }

        #endregion
    }
}
