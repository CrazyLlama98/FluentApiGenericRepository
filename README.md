# FluentApiGenericRepository

[![Build Status](https://travis-ci.com/CrazyLlama98/FluentApiGenericRepository.svg?branch=master)](https://travis-ci.com/CrazyLlama98/FluentApiGenericRepository) [![codecov](https://codecov.io/gh/CrazyLlama98/FluentApiGenericRepository/branch/master/graph/badge.svg)](https://codecov.io/gh/CrazyLlama98/FluentApiGenericRepository) ![Nuget](https://img.shields.io/nuget/dt/FluentApiGenericRepository) [![CodeFactor](https://www.codefactor.io/repository/github/crazyllama98/fluentapigenericrepository/badge)](https://www.codefactor.io/repository/github/crazyllama98/fluentapigenericrepository) ![GitHub](https://img.shields.io/github/license/CrazyLlama98/FluentApiGenericRepository) ![Nuget](https://img.shields.io/nuget/v/FluentApiGenericRepository)

This library represents an implementation of generic repository pattern exposing a fluent API developed with .NET Core 2.2 and Entity Framework Core.

# Features!

  - You can use the default implementation for generic repository (readonly or not) for Entity Framework Core.
  - You can provide you custom implementation for the existing interfaces or can extend the default implementations.
  - You can use the fluent API generic functions to control the queries from the Service Layer for the new implementation from your app (without to write repository code at each new feature)

### Future work
  - Intellisense documentation and more examples
  - More functions available through fluent API
  - Suggestions from users
  - UnitOfWork Pattern default implementation

# Example of usage
### Entities
The entities defined in the consumer app needs to implement __*IEntity*__ interface or extend the generic __*Entity<T>*__ class. As example I took 2 entities: __Blog__ and __Post__.

```csharp
public class Blog : Entity<long>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public IEnumerable<Post> Posts { get; set; }
}
```

```csharp
public class Post : Entity<long>
{
    public string Name { get; set; }
    public string Content { get; set; }

    public Blog Blog { get; set; }
}
```

Also you need to create a DbContext class to be used by Repository.

```csharp
public class BlogDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public BlogDbContext(DbContextOptions<BlogDbContext> options)
        : base(options)
    {
    }
}
```

### Repository
The library provides 2 interfaces that can be used by custom repository interfaces from your app:
- IReadOnlyRepository<TEntity>
- IRepository<TEntity>

You can register them in dependency injection or use a custom interface like in the example below.
```csharp
public interface IBlogRepository : IReadOnlyRepository<Blog>
{
    // custom blog repository methods here
}
```
```csharp
public interface IPostRepository : IRepository<Post>
{
    // custom blog repository methods here
}
```
For the implementation of this repository you can extend the existing default implementation:
- ReadOnlyRepository<TEntity>
- Repository<TEntity>
```csharp
public class BlogRepository : ReadOnlyRepository<Blog>, IBlogRepository
{
    public BlogRepository(BlogDbContext dbContext) 
        : base(dbContext)
    {
    }

    // custom repository methods from public custom interface here
}
```
```csharp
public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(DbContext dbContext) : base(dbContext)
    {
        // custom blog repository methods here
    }
}
```
Now I can register these repositories in dependency injection or can instantiate the concrete class if it is used in a console app.

#### Fluent API examples
##### 1. Get first 10 posts with name 'test'
```csharp
var result = await postRepository
        .Filter()
        .Where(post => post.Name.Equals("test"))
        .Take(10)
        .ToListAsync();
```

##### 2. Get first 10 blogs with name 'test' and their posts
```csharp
var result = await blogRepository
        .Filter()
        .Include(blog => blog.Posts)
        .Where(blog => blog.Name.Equals("test"))
        .Take(10)
        .ToListAsync();
```

