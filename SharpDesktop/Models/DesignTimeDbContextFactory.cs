using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.IO;

namespace SharpDesktop.Models;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        // 链接到 SQLite 数据库
        var dbSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SharpDesktop.db");
        var options = new DbContextOptionsBuilder<DatabaseContext>();
        options.UseSqlite($"Data Source={dbSource};");

        // 创建数据库上下文
        return new DatabaseContext(options.Options);
    }
}