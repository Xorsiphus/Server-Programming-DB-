using System;
using NHibernate.Mapping.Attributes;

namespace SP_Lab_5.Manager.Model
{
    [Class]
    public class Personal : Entity
    {
        [Id(0, Name = "Id", Type = "int", Column = "id")]
        [Generator(1, Class = "sequence")]
        [Param(2, Name = "sequence", Content = "personal_id_seq")]
        public virtual int Id { get; set; }
        
        [ManyToOne(Name = "CompanyId", Column = "company_id", ClassType = typeof(Companies), Cascade = "save-update")]
        public virtual Companies CompanyId { get; set; }

        [Property(Name = "Name", Type = "string", Column = "name")]
        public virtual string Name { get; set; }
        
        [Property(Name = "BDate", Type = "date", Column = "b_date")]
        public virtual DateTime BDate { get; set; }
        
        [Property(Name = "Position", Type = "string", Column = "position")]
        public virtual string Position { get; set; }

        public override string ToString()
        {
            return $"{Id, 3}) {Name, 14}; {CompanyId};  {BDate.Day}/{BDate.Month}/{BDate.Year}  {Position}";
        }
    }
}