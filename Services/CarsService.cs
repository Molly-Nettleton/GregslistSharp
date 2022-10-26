namespace GregslistShark.Services;

public class CarsService
{
  private readonly CarsRepository _carsRepo;


  public CarsService(CarsRepository carsRepo)
  {
    _carsRepo = carsRepo;
  }

  public List<Car> GetCars()
  {
    return _carsRepo.GetCars();
  }

  public Car CreateCar(Car carData)
  {
    return _carsRepo.CreateCar(carData);
  }

  public Car GetCarById(int id)
  {
    var car = _carsRepo.GetCarById(id);
    if (car == null)
    {
      throw new Exception("Invalid car id");
    }
    return car;
  }

  public Car RemoveCar(int id)
  {
    var car = this.GetCarById(id);
    if (car == null)
    {
      throw new Exception("Invalid ID [GetCarById]");
    }
    return _carsRepo.RemoveCar(id);
  }

  public Car UpdateCar(Car carData)
  {
    Car original = GetCarById(carData.Id);
    original.Make = carData.Make ?? original.Make;
    original.Model = carData.Model ?? original.Model;
    original.Year = carData.Year;
    original.Price = carData.Price;
    original.ImgUrl = carData.ImgUrl ?? original.ImgUrl;
    original.Description = carData.Description ?? original.Description;
    return _carsRepo.UpdateCar(original);
  }
}