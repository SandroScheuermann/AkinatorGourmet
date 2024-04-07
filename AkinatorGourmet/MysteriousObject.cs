namespace AkinatorGourmet
{
    public class MysteriousObject
    {
        public string? Name { get; set; }
        public MysteriousObject? ParentNode { get; set; }
        public MysteriousObject? YesNode { get; set; }
        public MysteriousObject? NoNode { get; set; }
        public bool IsEndNode { get; set; }
        public bool IsResponseNode { get; set; }
        public string GetQuestionMessage() => $"Sua comida é {Name}";
    }
}
