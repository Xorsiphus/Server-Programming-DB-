using System;
using System.Collections.Generic;
using NHibernate.Mapping.Attributes;

namespace SP_Lab_5.Manager.Model
{
    [Class]
    public class Companies : Entity
    {
        [Id(0, Name = "Id", Type = "int", Column = "id")]
        [Generator(1, Class = "sequence")]
        [Param(2, Name = "sequence", Content = "companies_id_seq")]
        public virtual int Id { get; set; }
        
        [Bag(0, Name = "Personal")]
        [Key(1, Column = "company_id")]
        [OneToMany(2, ClassType = typeof(Personal))]
        private IList<Personal> _personal;
        public virtual IList<Personal> Personal
        {
            get => _personal ??= new List<Personal>();
            set => _personal = value;
        }
        
        [Bag(0, Name = "Movies")]
        [Key(1, Column = "company_id")]
        [OneToMany(2, ClassType = typeof(Personal))]
        private IList<Movies> _movies;
        public virtual IList<Movies> Movies
        {
            get => _movies ??= new List<Movies>();
            set => _movies = value;
        }
        
        [Property(Name = "Name", Type = "string", Column = "name")]
        public virtual string Name { get; set; }
        
        [Property(Name = "Date", Type = "date", Column = "date")]
        public virtual DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Id, 3}) {Name, 14};  {Date.Day}/{Date.Month}/{Date.Year}";
        }
    }
}