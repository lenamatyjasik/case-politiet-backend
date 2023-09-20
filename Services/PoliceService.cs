using Domain;
using System.Net.Http.Json;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System;

namespace Services
{
    public class PoliceService
    {
        private HttpClient _client;

        private static List<PoliceCar>? policeCars;

        public PoliceService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://politibiler-c6e73455ac85.herokuapp.com");
            policeCars ??= _client.GetFromJsonAsync<List<PoliceCar>>("").Result ?? new List<PoliceCar>();
            policeCars = policeCars.OrderBy(pc => pc.Id).ToList();
        }

        public async Task<PoliceCar?> GetPoliceCar(int id)
        {
            return (await GetPoliceCars(new List<int> { id })).SingleOrDefault();
        }

        public async Task<List<PoliceCar>> GetPoliceCars(List<int>? ids = null, string? status = null)
        {
            var result = policeCars.AsEnumerable();

            if (status != null)
                result = result.Where(pc => pc.Status == status);

            if (ids != null)
                result = result.Where(pc => ids.Contains(pc.Id));

            return result.OrderBy(pc => pc.Id).ToList();
        }

        public PoliceCar UpdatePoliceCarStatus(int id, string status)
        {
            var policeCar = policeCars.FirstOrDefault(pc => pc.Id == id);
            if (policeCar == null)
                throw new Exception("Police car not found");

            policeCar.Status = status;
            return policeCar;
        }

        public PoliceCar UpdatePoliceCarMission(int id, string mission)
        {
            var policeCar = policeCars.FirstOrDefault(pc => pc.Id == id);
            if (policeCar == null)
                throw new Exception("Police car not found");

            policeCar.Mission = mission;
            return policeCar;
        }
    }
}
