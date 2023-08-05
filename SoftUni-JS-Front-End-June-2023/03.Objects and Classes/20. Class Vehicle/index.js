class Vehicle {
    constructor(type, model, parts, fuel) {
      this.type = type;
      this.model = model;
      this.parts = parts;
      this.fuel = fuel;
    }
  
    get parts() {
      return this._parts;
    }
  
    set parts(value) {
      if (typeof value.engine !== 'number' || typeof value.power !== 'number') {
        throw new TypeError('Invalid parts object');
      }
  
      this._parts = {
        engine: value.engine,
        power: value.power,
        quality: value.engine * value.power,
      };
    }
  
    drive(fuelLoss) {
      if (this.fuel < fuelLoss) {
        throw new RangeError('Not enough fuel');
      }
  
      this.fuel -= fuelLoss;
    }
  }
  