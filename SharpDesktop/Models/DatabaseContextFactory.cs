using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace SharpDesktop.Models;

/// <summary>
/// 用于支持 SQLite 数据库的数据库上下文工厂
/// </summary>
public static class DatabaseContextFactory
{
    public static DatabaseContext CreateContext(string[] args)
    {
        // 链接到 SQLite 数据库
        var dbSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SharpDesktop.db");
        var options = new DbContextOptionsBuilder<DatabaseContext>();
        options.UseSqlite($"Data Source={dbSource}");

        // 创建数据库上下文
        return new DatabaseContext(options.Options);
    }

    public static DatabaseContext CreateContext() => CreateContext(new string[0]);
}