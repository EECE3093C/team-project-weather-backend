using AutoMapper;
using Controllers.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Weather.Core.IServices;
using Weather.Core.Models;
using Weather.Messages.Responses;
using Xunit;

public class PlantControllerTests
{
    private readonly Mock<ILogger<PlantController>> _mockLogger;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IPlantService> _mockPlantService;
    private readonly PlantController _controller;

    public PlantControllerTests()
    {
        _mockLogger = new Mock<ILogger<PlantController>>();
        _mockMapper = new Mock<IMapper>();
        _mockPlantService = new Mock<IPlantService>();
        _controller = new PlantController(_mockLogger.Object, _mockMapper.Object, _mockPlantService.Object);
    }

    [Fact]
    public async Task GetAllPlants_ReturnsOk_With_Plants()
    {
        // Arrange
        var plants = new List<Plant> { new Plant { Name = "Plant 1", Description = "Description 1", WeatherTypeFk = 1 } };
        var expectedResponse = new List<GetPlantsResponse> { new GetPlantsResponse { Name = "Plant 1", Description = "Description 1", WeatherType = 1 } };
        _mockPlantService.Setup(service => service.GetAllPlantsAsync()).ReturnsAsync(plants);
        _mockMapper.Setup(mapper => mapper.Map<List<GetPlantsResponse>>(plants)).Returns(expectedResponse);

        // Act
        var result = await _controller.GetAllPlants();

        // Assert
        var okResult = result is ActionResult<GetPlantsResponse>;
        var actualResponse = Assert.IsAssignableFrom<List<GetPlantsResponse>>(result.Value);
        Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public async Task GetAllPlants_ReturnsStatusCode_When_PlantServiceThrowsException()
    {
        // Arrange
        _mockPlantService.Setup(service => service.GetAllPlantsAsync()).ThrowsAsync(new Exception("Error message"));

        // Act
        var result = await _controller.GetAllPlants();

        // Assert
        var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
    }

    [Fact]
    public async Task GetPlantsByWeather_ReturnsOk_With_Plants()
    {
        // Arrange
        var plants = new List<Plant> { new Plant { Name = "Plant 1", Description = "Description 1", WeatherTypeFk = 1 } };
        var expectedResponse = new List<GetPlantsResponse> { new GetPlantsResponse { Name = "Plant 1", Description = "Description 1", WeatherType = 1 } };
        _mockPlantService.Setup(service => service.GetPlantsByWeather(It.IsAny<int>())).ReturnsAsync(plants);
        _mockMapper.Setup(mapper => mapper.Map<List<GetPlantsResponse>>(plants)).Returns(expectedResponse);

        // Act
        var result = await _controller.GetPlantsByWeather(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var actualResponse = Assert.IsAssignableFrom<List<GetPlantsResponse>>(okResult.Value);
        Assert.Equal(expectedResponse, actualResponse);
    }

    [Fact]
    public async Task GetPlantsByWeather_ReturnsStatusCode_When_PlantServiceThrowsException()
    {
        // Arrange
        _mockPlantService.Setup(service => service.GetPlantsByWeather(It.IsAny<int>())).ThrowsAsync(new Exception("Error message"));

        // Act
        var result = await _controller.GetPlantsByWeather(1);

        // Assert
        var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
    }
}
