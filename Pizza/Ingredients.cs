using System.Collections.Generic;

namespace Pizza;

interface IIngredient
{
    string Title { get; set; }
    double Cost { get; set; }
}

interface IPizzaDough : IIngredient
{
    string Title { get; set; }
    double Cost { get; set; }
}

class ThinPizza : IPizzaDough           //Ингридиент для паттерна строитель - тонкое тесто
{
    public string Title { get; set; } = "тонком тесте";
    public double Cost { get; set; } = 10;
}

class ThickPizza : IPizzaDough          //Ингридиент для паттерна строитель - толстое тесто
{
    public string Title { get; set; } = "толстом тесте";
    public double Cost { get; set; } = 20;
}

class Ingridient : IIngredient          //Ингридиент для паттерна декоратор, определяющию структуру component
{
    public Ingridient(string title, double cost)
    {
        Title = title;
        Cost = cost;
    }

    public string Title { get; set; }
    public double Cost { get; set; }

    public override string ToString() => Title;
}

//Оставляем паттерн декоратор, он тоже похож на паттерн строитель, но в отличии от фабричного метода добавляет функционал уже после создания класса пиццы,
//т.о. мы его не добавляем в строитель, чтобы можно было добавлять разные добавки по требованию клиента, уже после приготовления пиццы
abstract class PizzaDecorator : Pizza   //Паттерн декоратор - абстрактный класс Decorator, наследуемый от Component
{
    public PizzaDecorator(Pizza p)
    {
        this.Dough = p.Dough;
        this.Type = p.Type;
        this.Cost = p.Cost;
        this.Ingredients = p.Ingredients;
    }
}

class TomatoPizza : PizzaDecorator      //Паттерн декоратор - конкретный класс, наследуемый от Decorator (добавляем ингридиент томаты)
{
    public TomatoPizza(Pizza p) : base(p)
    {
        this.Ingredients.Add(new Ingridient("с томатами", 3));
    }
}

class CheesePizza : PizzaDecorator      //Паттерн декоратор - конкретный класс, наследуемый от Decorator (добавляем ингридиент сыр)
{
    public CheesePizza(Pizza p) : base(p)
    {
        this.Ingredients.Add(new Ingridient("с сыром", 5));
    }
}
