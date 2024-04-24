using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Launch
    {
        #region Construtores

        public Launch()
        {
            this.id = 0;
            this.gameId = 0;
            this.realeaseDate = DateTime.Now;
            this.rating = 0.00f;
            this.price = 0.00f;
            this.salesNumber = 0;
            this.platformId = 0;
            this.publisherId = 0;

        }

        public Launch(long id, long gameId, DateTime realeaseDate, float rating, float price, long salesNumber, long platformId, long publisherId)
            : this()
        {
            this.id = id;
            this.gameId = gameId;
            this.realeaseDate = realeaseDate;
            this.rating = rating;
            this.price = price;
            this.salesNumber = salesNumber;
            this.platformId = platformId;
            this.publisherId = publisherId;

        }

        #endregion

        #region Propriedades

        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private long gameId;

        public long GameId
        {
            get { return gameId; }
            set { gameId = value; }
        }

        private DateTime realeaseDate;

        public DateTime RealeaseDate
        {
            get { return realeaseDate; }
            set { realeaseDate = value; }
        }

        private float rating;

        public float Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        private long salesNumber;
        public long SalesNumber
        {
            get { return salesNumber; }
            set { salesNumber = value; }
        }

        private long platformId;
        public long PlatformId
        {
            get { return platformId; }
            set { platformId = value; }
        }
        private long publisherId;

        public long PublisherId
        {
            get { return publisherId; }
            set { publisherId = value; }
        }

        #endregion

        #region Metodos

        public void Novo()
        {
            this.Id = 0;
            this.GameId = 0;
            this.RealeaseDate = DateTime.Now;
            this.Rating = 0;
            this.Price = 0;
            this.SalesNumber = 0;
            this.PlatformId = 0;
            this.PublisherId = 0;
        }


        public static Launch GetLaunch(long id, out string error)
        {
            Launch launch = null;
            long gameId = 0;
            DateTime realeaseDate = DateTime.Now;
            float rating = 0;
            float price = 0;
            long salesNumber = 0;
            long platformId = 0;
            long publisherId = 0;

            bool ok = DataLayer.Launch.GetLaunch(id, ref gameId, ref realeaseDate, ref rating, ref price, ref salesNumber, ref platformId, ref publisherId, out error);
            if (ok)
            {
                launch = new Launch(id, gameId, realeaseDate, rating, price, salesNumber, platformId, publisherId);
            }
            return launch;
        }

        public static DataTable List()
        {
            DataTable dataTable = DataLayer.Launch.ListLaunch();
            return dataTable;
        }

        public static LaunchCollection GetListLaunch()
        {
            string erro = string.Empty;
            DataTable dataTable = Launch.List();
            LaunchCollection launchs = new LaunchCollection(dataTable);
            return launchs;
        }

        #endregion


    }
}
