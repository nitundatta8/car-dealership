using System;
using System.Collections.Generic;

public class Car
{
  public string MakeModel;
  public int Price;
  public int Miles;
  public string Message;

  public Car(string makeModel, int price, int miles, string message)
  {
    MakeModel = makeModel;
    Price = price;
    Miles = miles;
    Message = message;
  }
  public bool WorthBuying(int maxPrice,int maxMiles)
  {
    return (Price < maxPrice && Miles> maxMiles);
  }

  public  bool DoesNotMatch(int maxPrice,int minPrice){
     if(maxPrice<minPrice){
       return true;
     }
     return false;
  }

  public void toString()
  {

    Console.WriteLine(this.MakeModel);
    Console.WriteLine(this.Price);
    Console.WriteLine(this.Miles);
    Console.WriteLine(this.Message);

  }
}

public class Program
{
  public static void DisplayCarInfo(List<Car> Cars)
  {

    for (int i = 0; i < Cars.Count; i++)
    {
      Cars[i].toString();
    }


  }
  
  public static void Main()
  {
    Car volkswagen = new Car("1974 Volkswagen Thing", 1100, 368792, " Don't forget to check out our used cars");
    Car yugo = new Car("1980 Yugo Koral", 700, 56000, "Everybody Needs A Yugo Sometime.");
    Car ford = new Car("1988 Ford Country Squire", 1400, 239001, "One Ford.");
    Car amc = new Car("1976 AMC Pacer", 400, 198000, "Jump to Experimental cars.");


    List<Car> Cars = new List<Car>() { volkswagen, yugo, ford, amc };
    DisplayCarInfo(Cars);

    Console.WriteLine("Enter maximum price: ");
    string stringMaxPrice = Console.ReadLine();
    int maxPrice = int.Parse(stringMaxPrice);
    bool flag = false;
	  int minPrice = Int32.MaxValue;

    foreach(Car car in Cars){
	  if(car.Price < minPrice){
		minPrice = car.Price;  
	  }	
      flag = car.DoesNotMatch(maxPrice,minPrice);
      
    }
    if(flag){
      Console.WriteLine("No cars match the budget.Would you like to check others [Yes for y and no for n].");
      string answer = Console.ReadLine();
      if(answer == "y"){
        Main();
      }else{
        Console.WriteLine("Good Bye");
      }
    }
    

    Console.WriteLine("Enter maximum miles: ");
    string stringMaxMiles = Console.ReadLine();
    int maxMiles = int.Parse(stringMaxMiles);

    List<Car> CarsMatchingSearch = new List<Car>(0);

    foreach (Car automobile in Cars)
    {
      if (automobile.WorthBuying(maxPrice, maxMiles))
      {
        CarsMatchingSearch.Add(automobile);
      }
    }

    foreach (Car automobile in CarsMatchingSearch)
    {
      Console.WriteLine(automobile.MakeModel);
    }
  }
}