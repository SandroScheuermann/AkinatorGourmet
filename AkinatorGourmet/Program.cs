using AkinatorGourmet;

var parentNode = new MysteriousObject
{
    Name = "Lasanha",
};

var startNode = new MysteriousObject
{
    Name = "Massa",
    YesNode = parentNode
};

var endNode = new MysteriousObject
{
    Name = "Bolo de Chocolate"
};

HashSet<MysteriousObject> mysteriousFood = [startNode, parentNode, endNode];

while (true)
{
    Console.WriteLine("Bem-vindo ao Akinator Gourmet!");
    Console.WriteLine("Pense em um prato.");

    MysteriousObject? deductedObject = new();

    deductedObject = FindFood(startNode);

    if (deductedObject is null)
    {
        deductedObject = FindFood(endNode);
    }

    if (deductedObject is not null)
    {
        Console.Clear();

        Console.WriteLine($"Acertei! a comida que você pensou é {deductedObject.Name}");
    }
    else
    {
        Console.Clear();

        Console.WriteLine($"Desisto! Qual a foi a comida que você pensou?");

        var thinkedFood = Console.ReadLine();

        Console.WriteLine($"O que a {thinkedFood} é, que {endNode.Name} não é ?");

        var unmappedAspect = Console.ReadLine();

        deductedObject = new() { Name = unmappedAspect, YesNode = new() { Name = thinkedFood } };

        startNode.NoNode = deductedObject;
    }
}

MysteriousObject? FindFood(MysteriousObject food)
{
    Console.WriteLine(food.GetQuestionMessage());

    Console.WriteLine("1 - Sim\n" +
                      "2 - Não");

    var result = Console.ReadLine() == "1";

    if (result && food.YesNode is not null)
    {
        //ACERTEI PARCIALMENTE, CONTINUO BUSCANDO
        return FindFood(food.YesNode);
    }
    else if (result && food.YesNode is null)
    {
        // ACERTEI
        return food;
    }
    else if (!result && food.NoNode is not null)
    {
        //NÃO É, MAS TENHO MAS OPÇÕES
        return FindFood(food.NoNode);
    }
    else if (!result && food.NoNode is null)
    {
        //NÃO É E NÃO TENHO MAIS OPÇÕES
        return null;
    }

    return null;
}
