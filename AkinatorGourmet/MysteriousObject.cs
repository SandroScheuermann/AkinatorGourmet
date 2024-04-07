namespace AkinatorGourmet
{
    public class MysteriousObject
    {
        public string? Name { get; set; }
        public MysteriousObject? ParentNode { get; set; }
        public MysteriousObject? YesNode { get; set; }
        public MysteriousObject? NoNode { get; set; }
        public bool IsLeftNode => ParentNode is not null && ParentNode.YesNode != this;
        public string QuestionMessage => $"Sua comida é {Name}?";
    }
}
