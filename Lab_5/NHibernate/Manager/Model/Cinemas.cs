using System.Collections.Generic;
using NHibernate.Mapping.Attributes;

namespace SP_Lab_5.Manager.Model
{
    [Class]
    public class Cinemas : Entity
    {
        [Id(0, Name = "Id", Type = "int", Column = "id")]
        [Generator(1, Class = "sequence")]
        [Param(2, Name = "sequence", Content = "cinemas_id_seq")]
        public virtual int Id { get; set; }
        
        [Bag(2, Name = "Tickets")]
        [Key(3, Column = "cinema_id")]
        [OneToMany(4, ClassType = typeof(Tickets))]
        private IList<Tickets> _tickets;
        public virtual IList<Tickets> Tickets
        {
            get => _tickets ??= new List<Tickets>();
            set => _tickets = value;
        }
        
        [Property(Name = "Name", Type = "string", Column = "name")]
        public virtual string Name { get; set; }
        
        [Property(Name = "Country", Type = "string", Column = "country")]
        public virtual string Country { get; set; }

        [Property(Name = "City", Type = "string", Column = "city")] 
        public virtual string City { get; set; }


        [ManyToOne(Name = "SharedFilm", Column = "shared_film", ClassType = typeof(Movies), Cascade = "save-update")] 
        public virtual Movies SharedFilm { get; set; }
        
        public override string ToString()
        {
            return $"{Id, 3}) {Name, 14};  {Country} - {City}; {SharedFilm}";
        }
    }
}