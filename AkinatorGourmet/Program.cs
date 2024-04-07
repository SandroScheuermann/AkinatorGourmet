using AkinatorGourmet;

var boloNode = new MysteriousObject
{
    Name = "Bolo de Chocolate",
};
var lasanhaNode = new MysteriousObject
{
    Name = "Lasanha",
};
var massaNode = new MysteriousObject
{
    Name = "Massa",
    YesNode = lasanhaNode,
    NoNode = boloNode,
};

lasanhaNode.ParentNode = massaNode;
boloNode.ParentNode = massaNode;

while (true)
{
    Console.WriteLine("Bem-vindo ao Akinator Gourmet!");
    Console.WriteLine("Pense em um prato.\n");

    MysteriousObject? deductedObject = new();

    deductedObject = FindObject(massaNode);

    if (deductedObject is not null)
    {
        Console.Clear();

        Console.WriteLine($"\nAcertei! a comida que você pensou é {deductedObject.Name}\n");
    }
}

void UpdateTree(MysteriousObject lastNode)
{
    Console.Clear();

    Console.WriteLine($"Desisto! Qual a foi a comida que você pensou?");

    var thoughtFood = Console.ReadLine();

    MysteriousObject deductedObject = new() { Name = thoughtFood };

    Console.WriteLine($"O que a {thoughtFood} é, que {lastNode.Name} não é ?");

    var unmappedAspect = Console.ReadLine();

    MysteriousObject aspect = new()
    {
        Name = unmappedAspect,
        ParentNode = lastNode.ParentNode
    };

    if (lastNode.ParentNode is not null)
    {
        if (lastNode.IsLeftNode)
        {
            lastNode.ParentNode.NoNode = aspect;
        }
        else
        {
            lastNode.ParentNode.YesNode = aspect;
        }
    }

    lastNode.ParentNode = aspect;
    aspect.NoNode = lastNode;
    deductedObject.ParentNode = aspect;
    aspect.YesNode = deductedObject;
}

MysteriousObject? FindObject(MysteriousObject currentNode)
{
    Console.WriteLine(currentNode.GetQuestionMessage());
    Console.WriteLine("1 - Sim\n2 - Não");

    var userInput = Console.ReadLine();

    bool result = userInput == "1";

    if (result && currentNode.YesNode != null)
    {
        return FindObject(currentNode.YesNode);
    }
    else if (!result && currentNode.NoNode != null)
    {
        return FindObject(currentNode.NoNode);
    }
    else if (result && currentNode.YesNode == null)
    {
        return currentNode;
    }
    else
    {
        UpdateTree(currentNode);
        return null;
    }
}
