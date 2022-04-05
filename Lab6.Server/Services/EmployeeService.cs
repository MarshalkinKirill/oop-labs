using lab6.DaLayer;
using Lab6.Server;
using lab6.BlLayer;
namespace Lab6.Server.Services
{
    public class EmployeeService
    {
        private IJsonContext jsonContext;
        private JsonRepository jsonRepository;

        public EmployeeService(JsonContext jsonContext)
        {
            jsonRepository = new JsonRepository(jsonContext);
        }

        public string GetAll()
        {
            return jsonRepository.GetAllEmployees();
        }

        public string FindById(int id)
        {
            return jsonRepository.GetEmployeeById(id);
        }

        public void CreateEmployee(string name, int type)
        {
            jsonRepository.CreateEmployee(name, type);
        }

        public void UpdateEmployee(int id, string name, EmployeeType type)
        {
            jsonRepository.UpdateEmployee(id, name, type);
        }
    }
}
