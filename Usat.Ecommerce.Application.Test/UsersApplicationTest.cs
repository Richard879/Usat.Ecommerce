using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Usat.Ecommerce.Application.Interface;


namespace Usat.Ecommerce.Application.Test
{
    [TestClass]
    public class UsersApplicationTest
    {
        private static IConfiguration? _configuration;
        private static IServiceScopeFactory? _scopeFactory;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();

            //var startup = new StartupBase(_configuration);
        }

        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametros_RetornarMensajeErrorValidacion()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            // Arrange
            var userName = string.Empty;
            var password = string.Empty;
            var expected = "Errores de Validaci�n";

            // Act            
            var result = context!.Authenticate(userName, password);
            var actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosCorrectos_RetornarMensajeExito()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            // Arrange
            var userName = "ALEX";
            var password = "123456";
            var expected = "Autenticaci�n Exitosa!!!";

            // Act
            var result = context!.Authenticate(userName, password);
            var actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosIncorrectos_RetornarMensajeUsuarioNoExiste()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            // Arrange
            var userName = "ALEX";
            var password = "123456899";
            var expected = "Usuario no existe";

            // Act
            var result = context!.Authenticate(userName, password);
            var actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}