using System;

//
// 🔹 Интерфейс для всех напитков
//
public interface IBeverage
{
    string GetDescription();  // Метод для получения описания напитка
    double Cost();            // Метод для расчета стоимости напитка
}

//
// 🔹 Конкретные классы напитков (базовые объекты)
//
public class Espresso : IBeverage
{
    public string GetDescription() => "Эспрессо";
    public double Cost() => 3.0;
}

public class Tea : IBeverage
{
    public string GetDescription() => "Чай";
    public double Cost() => 2.0;
}

public class Latte : IBeverage
{
    public string GetDescription() => "Латте";
    public double Cost() => 3.5;
}

//
// 🔹 Абстрактный декоратор (наследует интерфейс напитка)
//
public abstract class BeverageDecorator : IBeverage
{
    protected IBeverage beverage;  // ссылка на объект, который декорируется

    public BeverageDecorator(IBeverage beverage)
    {
        this.beverage = beverage;
    }

    public virtual string GetDescription() => beverage.GetDescription();
    public virtual double Cost() => beverage.Cost();
}

//
// 🔹 Конкретные декораторы (добавки)
//
public class Milk : BeverageDecorator
{
    public Milk(IBeverage beverage) : base(beverage) { }

    public override string GetDescription() => beverage.GetDescription() + ", Молоко";
    public override double Cost() => beverage.Cost() + 0.5;
}

public class Sugar : BeverageDecorator
{
    public Sugar(IBeverage beverage) : base(beverage) { }

    public override string GetDescription() => beverage.GetDescription() + ", Сахар";
    public override double Cost() => beverage.Cost() + 0.2;
}

public class WhippedCream : BeverageDecorator
{
    public WhippedCream(IBeverage beverage) : base(beverage) { }

    public override string GetDescription() => beverage.GetDescription() + ", Взбитые сливки";
    public override double Cost() => beverage.Cost() + 0.7;
}

public class Syrup : BeverageDecorator
{
    public Syrup(IBeverage beverage) : base(beverage) { }

    public override string GetDescription() => beverage.GetDescription() + ", Сироп";
    public override double Cost() => beverage.Cost() + 0.6;
}

//
// 🔹 Клиентский код (пример использования)
//
class Program
{
    static void Main()
    {
        // Создаем базовый напиток
        IBeverage drink = new Espresso();
        Console.WriteLine($"{drink.GetDescription()} = ${drink.Cost()}");

        // Добавляем добавки (декораторы)
        drink = new Milk(drink);
        drink = new Sugar(drink);
        drink = new WhippedCream(drink);

        // Выводим итоговое описание и стоимость
        Console.WriteLine($"Ваш заказ: {drink.GetDescription()}");
        Console.WriteLine($"Общая стоимость: ${drink.Cost():0.00}");
    }
}
