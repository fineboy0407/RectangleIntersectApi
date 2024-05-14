using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using RectangleIntersectionWebApi.Controllers;
using RectangleIntersectionWebApi.Data;
using RectangleIntersectionCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class RectanglesControllerTests
{
    private readonly Mock<ApplicationDbContext> _mockContext;
    private readonly RectanglesController _controller;
    private readonly DbSet<Rectangle> _mockSet;

    public RectanglesControllerTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        var dbContext = new ApplicationDbContext(options);

        // Sample data
        dbContext.Rectangles.AddRange(
            new Rectangle { Id = 1, X1 = 0, Y1 = 0, X2 = 10, Y2 = 10 },
            new Rectangle { Id = 2, X1 = 5, Y1 = 5, X2 = 15, Y2 = 15 }
        );
        dbContext.SaveChanges();

        _controller = new RectanglesController(dbContext);
    }

    [Fact]
    public async Task GetIntersectingRectangles_ReturnsCorrectRectangles()
    {
        // Act: Call the method with a segment that should intersect both rectangles
        var result = await _controller.GetIntersectingRectangles(2, 2, 6, 6) as OkObjectResult;

        // Assert: Verify it returns the correct status code and data
        Assert.NotNull(result);
        var rectangles = result.Value as List<Rectangle>;
        Assert.Equal(2, rectangles.Count);
        Assert.Contains(rectangles, r => r.Id == 1);
        Assert.Contains(rectangles, r => r.Id == 2);
    }
}