using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Platform
    {
        public Platform()
        {
            this.id = 0;
            this.platformName = "";

        }

        public Platform(long id, string platformName)
            : this()
        {
            this.id = id;
            this.platformName = platformName;
        }

        #region Properties
        private long id;

		public long Id
		{
			get { return id; }
			set { id = value; }
		}

		private string platformName;

		public string PlatformName
		{
			get { return platformName; }
			set { platformName = value; }
		}
        #endregion

        #region Metodos

        public void Novo()
        {
            this.Id = 0;
            this.PlatformName = string.Empty;
        }


        public static Platform GetPlatform(long id, out string error)
        {
            Platform platform = null;
            string platformName = string.Empty;

            bool ok = DataLayer.Platform.GetPlatform(id, ref platformName, out error);
            if (ok)
            {
                platform = new Platform(id, platformName);
            }
            return platform;
        }

        public static DataTable List()
        {
            DataTable dataTable = DataLayer.Platform.ListPlatform();
            return dataTable;
        }

        public static PlatformCollection GetListPlatform()
        {
            string erro = string.Empty;
            DataTable dataTable = Platform.List();
            PlatformCollection platforms = new PlatformCollection(dataTable);
            return platforms;
        }

        #endregion

    }
}
