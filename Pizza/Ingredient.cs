namespace Pizza;

interface IIngredient
{
    string Title { get; set; }
    double Cost { get; set; }
}

interface IPizzaType : IIngredient
{
    string Title { get; set; }
    double Cost { get; set; }
}

class ItalianPizza : IPizzaType
{
    public string Title { get; set; } = "Итальянская пицца";
    public double Cost { get; set; } = 10;
}

class BulgerianPizza : IPizzaType
{
    public string Title { get; set; } = "Болгарская пицца";
    public double Cost { get; set; } = 8;
}

class Ingridient : IIngredient {
    public string Title { get; set; }
    public double Cost { get; set; }

    public override string ToString() => Title;
}

abstract class PizzaDecorator : Pizza
{
    protected Pizza pizza;
    public PizzaDecorator(Pizza pizza)
    {
        this.pizza = pizza;
    }
}
class TomatoPizza : PizzaDecorator
{
    public TomatoPizza(Pizza p) : base(p)
    {
        p.Ingredients.Add(new Ingridient { Title = "с томатами", Cost = 3 });
    }
}

class CheesePizza : PizzaDecorator
{
    public CheesePizza(Pizza p) : base(p)
    {
        p.Ingredients.Add(new Ingridient { Title = "с сыром", Cost = 5 });
    }
}
