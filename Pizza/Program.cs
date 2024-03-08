namespace Pizza;

class Program
{
    static void Main()
    {
        Pizza pizza = new BaseForPizza().Make(new ItalianPizza(), new ThinPizza());
        Console.WriteLine(pizza);   //Итальянская пицца на тонком тесте
        Pizza pizza2 = new BaseForPizza().Make(new ItalianPizza(), new ThinPizza());
        pizza2 = new TomatoPizza(pizza2);
        Console.WriteLine(pizza2);  //Итальянская пицца на тонком тесте с томатом
        Pizza pizza3 = new BaseForPizza().Make(new ItalianPizza(), new ThinPizza());
        pizza3 = new TomatoPizza(pizza3);
        pizza3 = new CheesePizza(pizza3);
        Console.WriteLine(pizza3);  //Итальянская пицца на тонком тесте с томатом и с сыром
        Pizza pizza4 = new BaseForPizza().Make(new BulgerianPizza(), new ThickPizza());
        Console.WriteLine(pizza4);  //Болгарская пица на толстом тесте с томатом и с сыром
        Console.ReadLine();
    }
}

class BaseForPizza                  //Паттерн Строитель, метод создания класса - dirrector
{   
    public Pizza Make(PizzaBuilder type, IPizzaDough dough)
    {
        PizzaBuilder builder = type;
        builder.SetType();
        builder.SetDough(dough);
        return builder.Pizza;
    }
}

abstract class PizzaBuilder         //Паттерн Строитель, абстрактный класс порядка строительства - builder
{
    public Pizza Pizza { get; set; } = new();
    //Поскольку у нас был фабричный метод для создания класса пиццы, а теперь мы применили паттерн строитель,
    //то будет правильно метод определения типа пицы включить в функционал строителя (поскольку это разные паттерны для одной цели - массового создания класса)
    public abstract void SetType();
    public abstract void SetDough(IPizzaDough Dough); 
}

class ItalianPizza : PizzaBuilder      //Паттерн Строитель, конкретный класс строительства - ConcreteBuilder (итальянская пицца)
{
    public override void SetType()
    {
        this.Pizza = new Pizza
        {
            Type = "Итальянская пицца",
            Cost = 10
        };
    }

    public override void SetDough(IPizzaDough dough)
    {
        this.Pizza.Dough = dough.Title;
        this.Pizza.Cost += dough.Cost;
    }
}

class BulgerianPizza : PizzaBuilder     //Паттерн Строитель, конкретный классы выстраивания - ConcreteBuilder (болгарская пицца)
{
    public override void SetType()
    {
        this.Pizza = new Pizza
        {
            Type = "Болгарская пицца",
            Cost = 8
        };
    }

    public override void SetDough(IPizzaDough dough)
    {
        this.Pizza.Dough = dough.Title;
        this.Pizza.Cost += dough.Cost;
    }
}

//Наша модель,
class Pizza                         
{
    public string Dough { get; set; }                           //элемент product для паттерна строитель 
    public string Type { get; set; }                            //элемент product для паттерна строитель
    public double Cost { get; set; }                            //элемент product для паттерна строитель
    public List<IIngredient> Ingredients { get; set; } = new(); //элемент сomponent для паттерна декоратор

    public override string ToString()
    {
        string result = Type + " на " + Dough;
        double Cost = this.Cost;
        if (Ingredients?.Count > 0)
        {
            result += " " + string.Join(", ", (IEnumerable<IIngredient>)Ingredients);
            Cost += Ingredients.Sum(el => el.Cost);
        }
        return result + " - " + Cost + " р.";
    }
}

