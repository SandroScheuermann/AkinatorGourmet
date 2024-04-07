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
    Console.Clear();
    Console.WriteLine("Bem-vindo ao Akinator Gourmet!");
    Console.WriteLine("Pense em um prato.\n");

    MysteriousObject? deductedObject = new();

    deductedObject = FindFood(massaNode);

    if (deductedObject is not null)
    {
        Console.Clear();

        Console.WriteLine($"Acertei! a comida que você pensou é {deductedObject.Name}\n");
    }
}

void UpdateTree(MysteriousObject lastNode)
{
    Console.Clear();

    Console.WriteLine($"Desisto! Qual a foi a comida que você pensou?");

    var thinkedFood = Console.ReadLine();

    MysteriousObject deductedObject = new() { Name = thinkedFood };

    Console.WriteLine($"O que a {thinkedFood} é, que {lastNode.Name} não é ?");

    var unmappedAspect = Console.ReadLine();

    MysteriousObject aspect = new()
    {
        Name = unmappedAspect,
        ParentNode = lastNode.ParentNode
    };

    if (lastNode.ParentNode is not null && lastNode.ParentNode?.YesNode == lastNode)
    {
        lastNode.ParentNode.YesNode = aspect;
    }
    else if (lastNode.ParentNode is not null && lastNode.ParentNode.YesNode != lastNode)
    {
        lastNode.ParentNode.NoNode = aspect;
    }

    lastNode.ParentNode = aspect;
    aspect.NoNode = lastNode;
    deductedObject.ParentNode = aspect;
    aspect.YesNode = deductedObject;
}

MysteriousObject? FindFood(MysteriousObject food)
{
    Console.WriteLine(food.GetQuestionMessage());

    Console.WriteLine("1 - Sim\n" +
                      "2 - Não");

    var result = Console.ReadLine() == "1";

    if (result && food.YesNode is not null)
    {
        return FindFood(food.YesNode);
    }
    else if (result && food.YesNode is null)
    {
        return food;
    }
    else if (!result && food.NoNode is not null)
    {
        return FindFood(food.NoNode);
    }
    else if (!result && food.NoNode is null)
    {
        UpdateTree(food);
        return null;
    }

    return null;
}

MysteriousObject GetLastNode(MysteriousObject node)
{
    return node.NoNode switch
    {
        null => node,
        _ => GetLastNode(node.NoNode)
    };
}
