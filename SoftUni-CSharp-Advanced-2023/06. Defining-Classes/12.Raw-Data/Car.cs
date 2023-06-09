using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }//int speed, int power
    public Cargo Cargo { get; set; }//int Weight,string Type
    public Tyre[] Tyres { get; set; }//int Age ,double Pressure

    public Car(
        string model,
        int speed,
        int power,
        int weight,
        string type,
        double tyre1pressure,
        int tyre1age,
        double tyre2pressure,
        int tyre2age,
        double tyre3pressure,
        int tyre3age,
        double tyre4pressure,
        int tyre4age)
    {

        Model = model;
        Engine = new(speed, power);
        Cargo = new(weight, type);
        Tyres = new Tyre[4];
        Tyres[0] = new(tyre1age, tyre1pressure);
        Tyres[1] = new(tyre2age, tyre2pressure);
        Tyres[2] = new(tyre3age, tyre3pressure);
        Tyres[3] = new(tyre4age, tyre4pressure);
    }
    
}  