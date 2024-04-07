using AkinatorGourmet;

var endNode = new MysteriousObject
{
    Name = "Bolo de Chocolate",
};
var intermediateNode = new MysteriousObject
{
    Name = "Lasanha",
};
var startNode = new MysteriousObject
{
    Name = "Massa",
    YesNode = intermediateNode,
    NoNode = endNode,
};

intermediateNode.ParentNode = startNode;
endNode.ParentNode = startNode;

while (true)
{
    Console.WriteLine("Bem-vindo ao Akinator Gourmet!");
    Console.WriteLine("Pense em um prato.\n");

    MysteriousObject? deductedNode = new();

    deductedNode = ExploreTree(startNode);

    if (deductedNode is not null)
    {
        Console.Clear();

        Console.WriteLine($"\nAcertei! a comida que você pensou é {deductedNode.Name}\n");
    }
}

void UpdateTree(MysteriousObject lastNode)
{
    Console.Clear();

    Console.WriteLine($"Desisto! Qual a foi a comida que você pensou?");

    var userThoughtFood = Console.ReadLine();

    MysteriousObject thoughtNode = new() { Name = userThoughtFood };

    Console.WriteLine($"O que a {userThoughtFood} é, que {lastNode.Name} não é ?");

    var userThoughtAspect = Console.ReadLine();

    MysteriousObject thoughtAspect = new()
    {
        Name = userThoughtAspect,
        ParentNode = lastNode.ParentNode
    };

    if (lastNode.ParentNode is not null)
    {
        if (lastNode.IsLeftNode)
        {
            lastNode.ParentNode.NoNode = thoughtAspect;
        }
        else
        {
            lastNode.ParentNode.YesNode = thoughtAspect;
        }
    }

    lastNode.ParentNode = thoughtAspect;
    thoughtAspect.NoNode = lastNode;
    thoughtNode.ParentNode = thoughtAspect;
    thoughtAspect.YesNode = thoughtNode;
}

MysteriousObject? ExploreTree(MysteriousObject currentNode)
{
    Console.WriteLine(currentNode.QuestionMessage);
    Console.WriteLine("1 - Sim\n2 - Não");
     
    bool userConfirmed = Console.ReadLine() == "1";

    if (userConfirmed && currentNode.YesNode is not null)
    {
        return ExploreTree(currentNode.YesNode);
    }
    else if (userConfirmed && currentNode.YesNode is null)
    {
        return currentNode;
    }
    else if (!userConfirmed && currentNode.NoNode is not null)
    {
        return ExploreTree(currentNode.NoNode);
    }

    UpdateTree(currentNode);
    return null;
}
