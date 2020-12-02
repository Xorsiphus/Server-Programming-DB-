using NHibernate.Mapping.Attributes;

namespace SP_Lab_5.Manager.Model
{
    [Class]
    public class Tickets : Entity
    {
        [Id(0, Name = "Id", Type = "int", Column = "id")]
        [Generator(1, Class = "sequence")]
        [Param(2, Name = "sequence", Content = "tickets_id_seq")]
        public virtual int Id { get; set; }
        
        [ManyToOne(Name = "CinemaId", Column = "cinema_id", ClassType = typeof(Cinemas), Cascade = "save-update")]
        public virtual Cinemas CinemaId { get; set; }
        
        [ManyToOne(Name = "FilmId", Column = "film_id", ClassType = typeof(Movies), Cascade = "save-update")]
        public virtual Movies FilmId { get; set; }

        public override string ToString()
        {
            return $"{Id, 3}) {CinemaId} - {FilmId}";
        }
    }
}