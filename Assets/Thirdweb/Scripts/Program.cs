using System.Threading.Tasks;

namespace Thirdweb
{
    /// <summary>
    /// Convenient wrapper to interact with any EVM contract
    /// </summary>
    public class Program : Routable
    {
        public string address;
        public string type;

        public Program(string address, string type = null) : base(type != null ? $"{address}{Routable.subSeparator}{type}" : address)
        {
            this.address = address;
            this.type = type;
        }

        public async Task<T> Call<T>(string route, params object[] args)
        {
            return await Bridge.InvokeRoute<T>(getRoute(route), Utils.ToJsonStringArray(args));
        }
    }
}