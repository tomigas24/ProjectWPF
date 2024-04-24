using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Gender
    {
        #region Construtores

        public Gender()
        {
            this.id = 0;
            this.genderName = string.Empty;
        }

        public Gender(long id, string genderName)
            : this()
        {
            this.id = id;
            this.genderName = genderName;
        }

        #endregion

        #region Propriedades

        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string genderName;

        public string GenderName
        {
            get { return genderName; }
            set { genderName = value; }
        }

        #endregion

        #region Metodos

        public void Novo()
        {
            this.Id = 0;
            this.GenderName = string.Empty;
        }


        public static Gender GetGender(long id, out string error)
        {
            Gender gender = null;
            string genderName = string.Empty;

            bool ok = DataLayer.Gender.GetGender(id, ref genderName, out error);
            if (ok)
            {
                gender = new Gender(id, genderName);
            }
            return gender;
        }

        public static DataTable List()
        {
            DataTable dataTable = DataLayer.Gender.ListGender();
            return dataTable;
        }

        public static GenderCollection GetListGender()
        {
            string erro = string.Empty;
            DataTable dataTable = Gender.List();
            GenderCollection genders = new GenderCollection(dataTable);
            return genders;
        }

        #endregion
    }
}
