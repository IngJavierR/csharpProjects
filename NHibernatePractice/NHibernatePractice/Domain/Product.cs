using System;

namespace NHibernatePractice.Domain
{
    public class Product
    {
        private string _name;
        private string _category;
        private int _discontinued;

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public virtual int Discontinued
        {
            get { return _discontinued; }
            set { _discontinued = value; }
        }
    }
}
