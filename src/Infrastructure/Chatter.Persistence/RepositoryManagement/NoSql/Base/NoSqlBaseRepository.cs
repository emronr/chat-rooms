using Chatter.Common.Settings;
using Chatter.Domain.Entities.NoSql.Base;
using Chatter.Persistence.RepositoryManagement.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Chatter.Persistence.RepositoryManagement.NoSql.Base;

public class NoSqlBaseRepository<TEntity> : IBaseRepository<TEntity, string>
    where TEntity : BaseEntity, new()
{
    protected readonly IMongoCollection<TEntity> _collection;

    public NoSqlBaseRepository(IOptions<DatabaseSetting> databaseSetting)
    {
        var mongoDbSettings = databaseSetting.Value.MongoDbSettings;
        var client = new MongoClient(mongoDbSettings.ConnectionString);
        var database = client.GetDatabase(mongoDbSettings.DatabaseName);
        _collection = database.GetCollection<TEntity>(typeof(TEntity).Name.ToLowerInvariant());
    }

    public async Task CreateAsync(List<TEntity> entites)
    {
        await _collection.InsertManyAsync(entites);
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public void Update(TEntity entity)
    {
        _collection.FindOneAndReplace(x => x.Id == entity.Id, entity);
    }

    public void Delete(TEntity entity)
    {
        _collection.DeleteOne(x => x.Id == entity.Id);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _collection.Find(x => true).ToListAsync();
    }

    public async Task<TEntity> FindAsync(string entityId)
    {
        return await _collection.Find(x => x.Id == entityId).FirstOrDefaultAsync();
    }

    public IQueryable<TEntity> Query(bool asNoTracking = false)
    {
        return asNoTracking
            ? _collection.AsQueryable().AsNoTracking()
            : _collection.AsQueryable();
    }
}