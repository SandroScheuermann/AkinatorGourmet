﻿namespace AkinatorGourmet
{
    public class MysteriousObject
    {
        public string? Name { get; set; }
        public MysteriousObject? YesNode { get; set; }
        public MysteriousObject? NoNode { get; set; }

        public string GetQuestionMessage() => $"Sua comida é {Name}";

    }
}