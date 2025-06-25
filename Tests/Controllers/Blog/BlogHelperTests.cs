using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Personal;
using Personal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System;
using System.Linq;

namespace Personal.Tests
{
    [TestClass()]
    public class BlogHelperTests
    {
        [TestMethod()]
        public void ProcessTags_AddsNewTagsToContext()
        {
            // Arrange
            var blogCtx = new BlogContext(); // Create an instance of your BlogContext (you may need to mock this)

            // Act
            BlogHelper.Configure(blogCtx);
            BlogHelper.ProcessTags("tag1;tag2;tag3", "postId");

            // Assert
            // Check that the tags "tag1", "tag2", and "tag3" were added to the context
            Assert.IsTrue(blogCtx.Etiquetas.Any(t => t.Name == "tag1"));
            Assert.IsTrue(blogCtx.Etiquetas.Any(t => t.Name == "tag2"));
            Assert.IsTrue(blogCtx.Etiquetas.Any(t => t.Name == "tag3"));
        }
    }

        // Mock for BlogContext
        public class MockBlogContext : BlogContext
        {
            private readonly DbContextOptions<BlogContext> _options;

            public MockBlogContext()
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
                var connectionString = connectionStringBuilder.ToString();
                var connection = new SqliteConnection(connectionString);

                _options = new DbContextOptionsBuilder<BlogContext>()
                    .UseSqlite(connection)
                    .Options;

                // Initialize the in-memory database
                using (var context = new BlogContext())
                {
                    context.Database.OpenConnection();
                    context.Database.EnsureCreated();
                }
            }

            //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //{
            //    optionsBuilder.UseSqlite(_options. .GetConnectionString());
            //}
        }
    }