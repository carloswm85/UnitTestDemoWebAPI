namespace UnitTestDemoWebAPI.Models.Services
{
    public interface IHardwareComponentServices
    {
        public IEnumerable<HardwareComponent> Get();
        public HardwareComponent? Get(int id);
    }
}
