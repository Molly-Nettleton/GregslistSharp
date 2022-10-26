namespace GregslistShark.Repositories;

public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Car> GetCars()
  {
    var sql = "SELECT * FROM cars";
    return _db.Query<Car>(sql).ToList();
  }

  public Car CreateCar(Car carData)
  {
    var sql = @"
    INSERT INTO cars(
      make, model, year, price, description, imgUrl
    )
    VALUES(
      @Make, @Model, @Year, @Price, @Description, @ImgUrl
    );
    SELECT LAST_INSERT_ID();
    ";

    carData.Id = _db.ExecuteScalar<int>(sql, carData);
    return carData;
  }

  public Car GetCarById(int id)
  {
    var sql = @"SELECT * FROM cars WHERE id = @id";
    return _db.QueryFirstOrDefault<Car>(sql, new { id });
  }

  public Car RemoveCar(int id)
  {
    var car = GetCarById(id);
    var sql = "DELETE FROM cars WHERE id = @id";

    _db.Execute(sql, new { id });
    return car;
  }

  public Car UpdateCar(Car carData)
  {
    string sql = @"UPDATE cars SET 
    make = @make,
    model = @model,
    year = @year,
    price = @price,
    imgurl = @imgUrl,
    description = @description
    WHERE id = @idl
    ";
    int rows = _db.Execute(sql, carData);
    if(rows== 0)
    {
      throw new Exception("unable to edit");
    }
    return carData;
  }
}