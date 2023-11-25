using Business.Models;
using DataAccess.Contexts;
using DataAccess.Entitites;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;

namespace Business;

/// <summary>
/// Performs user CRUD operations.
/// </summary>
public interface IStudentService
{
    // method definitions: method definitions must be created here in order to be used in the related controller

    /// <summary>
    /// Queries the records in the Users table.
    /// </summary>
    /// <returns></returns>
    IQueryable<Business.Models.Student> Query();
    bool Add(Models.Student model);

    bool Delete(int id);


    bool Update(Models.Student model);


}

public class StudentService : IStudentService // UserService is a IUserService (UserService implements IUserService)
{
    #region Db Constructor Injection
    private readonly Db _db;

    // An object of type Db which inherits from DbContext class is
    // injected to this class through the constructor therefore
    // user CRUD and other operations can be performed with this object.
    public StudentService(Db db)
    {
        _db = db;
    }
    #endregion

    // method implementations of the method definitions in the interface
    public IQueryable<Models.Student> Query()
    {
        // Query method will be used for generating SQL queries without executing them.
        // From the Users DbSet first order records by IsActive data descending
        // then for records with same IsActive data order UserName ascending
        // then for each element in the User entity collection map user entity
        // properties to the desired user model properties (projection) and return the query.
        // In Entity Framework Core, lazy loading (loading related data automatically without the need to include it) 
        // is not active by default if projection is not used. To use eager loading (loading related data 
        // on-demand with include), you can write the desired related entity property on the DbSet retrieved from 
        // the _db using the Include method either through a lambda expression or a string. If you want to include 
        // the related entity property of the included entity, you should write it through a delegate of type
        // included entity in the ThenInclude method. However, if the ThenInclude method is to be used, 
        // a lambda expression should be used in the Include method.
        return _db.Students.Include(e => e.Grade)
            .Select(e => new Models.Student()
            {
                // model - entity property assignments
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                UniversityExamRank = e.UniversityExamRank,
                CumulativeGpa = e.CumulativeGpa,
                GradeId = e.GradeId,
                // modified model - entity property assignments for displaying in views
                FullNameOutput= e.Name + " " + e.Surname,
                GradeOutput = e.Grade.Year
            });
    }


    public bool Add(Models.Student model)
    {
        if (_db.Students.Any(s => s.Name.ToUpper() == model.Name.ToUpper().Trim()))
            return false;
        DataAccess.Entitites.Student entity = new DataAccess.Entitites.Student()
        {
            Id = model.Id,
            Name = model.Name.Trim(),
            Surname = model.Surname,
            UniversityExamRank = model.UniversityExamRank,
            CumulativeGpa = model.CumulativeGpa,
            GradeId=model.GradeId
        };
        _db.Students.Add(entity);
        _db.SaveChanges();
        return true;
    }


    public bool Delete(int id)
    {
        DataAccess.Entitites.Student entity = _db.Students.SingleOrDefault(s => s.Id == id);
        if (entity is null)
            return false;
        _db.Students.Remove(entity);
        _db.SaveChanges();
        return true;
    }


    public bool Update(Models.Student model)
    {
        if (_db.Students.Any(s => s.Name.ToUpper() == model.Name.ToUpper().Trim() && s.Id != model.Id))
            return false;
        DataAccess.Entitites.Student existingEntity = _db.Students.SingleOrDefault(s => s.Id == model.Id);
        if (existingEntity is null)
            return false;
        existingEntity.GradeId = model.GradeId;
        existingEntity.Name = model.Name.Trim();
        existingEntity.Surname = model.Surname;
        existingEntity.UniversityExamRank = model.UniversityExamRank;
        existingEntity.CumulativeGpa = model.CumulativeGpa;

        _db.Students.Update(existingEntity);
        _db.SaveChanges();
        return true;
    }




}
