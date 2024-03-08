namespace Pizza;

class Program
{
    static void Main()
    {
        BaseForPizza baseForPizza = new();
        Pizza pizza = new BaseForPizza().Make(new ThinPizza(), new ItalianPizza());
        Console.WriteLine(pizza);
        pizza = new TomatoPizza(pizza);
        Console.WriteLine(pizza);

        //Pizza pizza1 = new ItalianPizza();
        //pizza1 = new TomatoPizza(pizza1); // итальянская с томатами
        //Console.WriteLine("Название: {0}", pizza1.Name);
        //Console.WriteLine("Цена: {0}", pizza1.GetCost());
        //Pizza pizza2 = new ItalianPizza();
        //pizza2 = new CheesePizza(pizza2);// итальянская с сыром
        //Console.WriteLine("Название: {0}", pizza2.Name);
        //Console.WriteLine("Цена: {0}", pizza2.GetCost());
        //Pizza pizza3 = new BulgerianPizza();
        //pizza3 = new TomatoPizza(pizza3);
        //pizza3 = new CheesePizza(pizza3);//болгарская с томатами и сыром
        //Console.WriteLine("Название: {0}", pizza3.Name);
        //Console.WriteLine("Цена: {0}", pizza3.GetCost());
        Console.ReadLine();
    }
}

class BaseForPizza
{
    public Pizza Make(PizzaBuilder doudh, IPizzaType type)
    {
        PizzaBuilder builder = doudh;
        builder.SetDough();
        builder.SetType(type);
        return builder.Pizza;
    }
}

abstract class PizzaBuilder
{

    public Pizza Pizza { get; set; } = new();
    public abstract void SetDough();
    public abstract void SetType(IPizzaType Dough);
}

class ThinPizza : PizzaBuilder
{
    public override void SetDough()
    {
        this.Pizza = new Pizza
        {
            Dough = "тонком тесте",
            Cost = 10
        };
    }

    public override void SetType(IPizzaType dough)
    {
        this.Pizza.Type = dough.Title;
        this.Pizza.Cost += dough.Cost;
    }
}

class ThickPizza : PizzaBuilder
{
    public override void SetDough()
    {
        this.Pizza = new Pizza
        {
            Dough = "толстом тесте",
            Cost = 20
        };
    }

    public override void SetType(IPizzaType dough)
    {
        this.Pizza.Type = dough.Title;
        this.Pizza.Cost += dough.Cost;
    }
}

class Pizza
{
    public string Dough { get; set; }
    public string Type { get; set; }
    public double Cost { get; set; }
    public List<IIngredient> Ingredients { get; set; } = new();

    public override string ToString()
    {
        string result = Type + " на " + Dough;
        double Cost = this.Cost;
        if (Ingredients?.Count > 0)
        {
            result = string.Join(", ", Ingredients);
            Cost += Ingredients.Sum(el => el.Cost);
        }
        return result + " - " + Cost + " р.";
    }
}

