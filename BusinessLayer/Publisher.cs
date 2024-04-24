using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Publisher
    {
        #region Construtores

        public Publisher()
        {
            this.id = 0;
            this.publisherName = string.Empty;
        }

        public Publisher(long id, string publisherName)
            : this()
        {
            this.id = id;
            this.publisherName = publisherName;
        }

        #endregion

        #region Propriedades

        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string publisherName;

        public string PublisherName
        {
            get { return publisherName; }
            set { publisherName = value; }
        }

        #endregion

        #region Metodos

        public void Novo()
        {
            this.Id = 0;
            this.PublisherName = string.Empty;
        }


        public static Publisher GetGender(long id, out string error)
        {
            Publisher publisher = null;
            string publisherName = string.Empty;

            bool ok = DataLayer.Publisher.GetPublisher(id, ref publisherName, out error);
            if (ok)
            {
                publisher = new Publisher(id, publisherName);
            }
            return publisher;
        }

        public static DataTable List()
        {
            DataTable dataTable = DataLayer.Publisher.GetPublisher();
            return dataTable;
        }

        public static PublisherCollection GetListPublisher()
        {
            string erro = string.Empty;
            DataTable dataTable = Publisher.List();
            PublisherCollection publishers = new PublisherCollection(dataTable);
            return publishers;
        }

        #endregion
    }
}
