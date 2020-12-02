using System;
using System.Collections.Generic;
using NHibernate.Mapping.Attributes;

namespace SP_Lab_5.Manager.Model
{
    [Class]
    public class Movies : Entity
    {
        [Id(0, Name = "Id", Type = "int", Column = "id")]
        [Generator(1, Class = "sequence")]
        [Param(2, Name = "sequence", Content = "movies_id_seq")]
        public virtual int Id { get; set; }
        
        [Bag(2, Name = "Cinemas")]
        [Key(3, Column = "shared_film")]
        [OneToMany(4, ClassType = typeof(Cinemas))]
        private IList<Cinemas> _cinemas;
        public virtual IList<Cinemas> Cinemas
        {
            get => _cinemas ??= new List<Cinemas>();
            set => _cinemas = value;
        }
        
        [Bag(5, Name = "Tickets")]
        [Key(6, Column = "film_id")]
        [OneToMany(7, ClassType = typeof(Tickets))]
        private IList<Tickets> _tickets;
        public virtual IList<Tickets> Tickets
        {
            get => _tickets ??= new List<Tickets>();
            set => _tickets = value;
        }

        [ManyToOne(Name = "CompanyId", Column = "company_id", ClassType = typeof(Companies), Cascade = "save-update")]
        public virtual Companies CompanyId { get; set; }

        [Property(Name = "Name", Type = "string", Column = "name")]
        public virtual string Name { get; set; }
        
        [Property(Name = "Date", Type = "date", Column = "date")]
        public virtual DateTime Date { get; set; }
        
        [Property(Name = "Genre", Type="String", Column = "genre")]
        public virtual string Genre { get; set; }

        public override string ToString()
        {
            return $"{Id, 3}) {Name, 14}; {CompanyId};  {Date.Day}/{Date.Month}/{Date.Year}  {Genre}";
        }
    }
}