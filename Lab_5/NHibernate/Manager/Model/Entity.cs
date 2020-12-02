namespace SP_Lab_5.Manager.Model
{
    public class Entity
    {
        // [Id(0, Name = "Id", Type = "int", Column = "id")]
        // [Generator(1, Class = "sequence")]
        // [Param(2, Name = "sequence", Content = "hibernate_sequence")]
        public virtual int Id { set; get; }
    }
}